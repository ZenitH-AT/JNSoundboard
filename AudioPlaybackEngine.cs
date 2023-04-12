﻿using System;
using System.Collections.Generic;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Linq;

namespace JNSoundboard
{
    class AudioPlaybackEngine : IDisposable
    {
        private IWavePlayer outputDevice;
        private readonly MixingSampleProvider mixer;
        private IDictionary<string, CachedSound> cachedSounds = new Dictionary<string, CachedSound>();

        public AudioPlaybackEngine(int sampleRate = 44100, int channelCount = 2)
        {
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
            mixer.ReadFully = true;
            mixer.MixerInputEnded += OnMixerInputEnded;
        }

        public event EventHandler AllInputEnded;

        private void OnMixerInputEnded(object sender, SampleProviderEventArgs e)
        {
            // check if there are any inputs left
            // OnMixerInputEnded gets invoked before the corresponding source is removed from the List so there should be exactly one source left
            if (mixer.MixerInputs.Count() == 1)
            {
                AllInputEnded?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Init(int deviceNumber)
        {
            if (outputDevice != null) outputDevice.Dispose();

            var output = new WaveOutEvent();
            output.DeviceNumber = deviceNumber;
            output.Init(mixer);
            output.Play();

            outputDevice = output;
        }

        public void PlaySound(string fileName, float volume = 1)
        {
            var input = new AudioFileReader(fileName);

            CachedSound cachedSound = null;

            if (!cachedSounds.TryGetValue(fileName, out cachedSound))
            {
                cachedSound = new CachedSound(fileName);
                cachedSounds.Add(fileName, cachedSound);
            }

            var resultingSampleProvider = new VolumeSampleProvider(new CachedSoundSampleProvider(cachedSound));

            resultingSampleProvider.Volume = volume;

            AddMixerInput(resultingSampleProvider);
        }

        public void StopAllSounds()
        {
            mixer.RemoveAllMixerInputs();
        }

        private ISampleProvider ConvertToRightChannelCount(ISampleProvider input)
        {
            if (input.WaveFormat.Channels == mixer.WaveFormat.Channels)
            {
                return input;
            }

            if (input.WaveFormat.Channels == 1 && mixer.WaveFormat.Channels == 2)
            {
                return new MonoToStereoSampleProvider(input);
            }

            throw new NotImplementedException("Not yet implemented this channel count conversion");
        }

        private void AddMixerInput(ISampleProvider input)
        {
            var resampled = new WdlResamplingSampleProvider(input, mixer.WaveFormat.SampleRate);
            mixer.AddMixerInput(ConvertToRightChannelCount(resampled));
        }

        public void Dispose()
        {
            if (outputDevice != null)
            {
                outputDevice.Dispose();
                outputDevice = null;
            }
        }
    }
}
