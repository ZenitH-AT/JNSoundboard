# JN Soundboard - ZenitH-AT Fork
A program written in C# using the NAudio library that uses hotkeys to play sounds into a chosen sound device. It is similar to [EXP Soundboard](https://sourceforge.net/projects/expsoundboard/), except that JN Soundboard is not as cross-platform as EXP, but, there are more features in JN than EXP.

A fork of EmbarassingUsername's fork of Jitnaught's JN Soundboard in order to add more features and fix some issues.

My (ZenitH-AT) main goal with this fork was to make JN Soundboard into a "set and forget" program, with all options being remembered across launches and the ability to start the program with windows in a tray icon, as well as allow for custom sound volume (to easily match it with your microphone if using the loopback feature).

[Changelog](https://github.com/ZenitH-AT/JNSoundboard/blob/master/CHANGELOG.md).

## Features:
* Can play MP3, WAV, WMA, M4A, and AC3 audio files.
* Play sounds through any sound device. (speakers, virtual audio cable, etc.)
* Microphone loopback (loops microphone sound through playback device). Allows you to also use your real mic at the same time as the soundboard.
* Add, edit, remove, and clear hotkeys.
* Can play a random sound from a list of sounds. Just select multiple files when adding a hotkey!
* Restrict hotkey so that the hotkey is only played when a certain window is in the foreground.
* Save and load hotkeys to XML file.
* Hotkey that stops currently playing sound.
* Hotkeys that load XML files containing sound hotkeys.
* Auto press your game or chat program's push-to-talk key when playing a sound.
* Text-to-speech WAV file creator.
* Optional second audio output so you can hear the sound playing.

## Requires:
* .NET Framework 4.6
* NAudio

## How to play sounds through your speakers or headphones only:
1. Set the "Speakers or Virtual Cable" device to your speakers or headphones then load and play sounds.

## How to play sound through your microphone so that people in your game or chat program can hear them:
In Windows, a playback device is normally a set of speakers or headphones, but it can also be a virtual cable. A virtual cable acts like a playback device, but is connected behind the scenes to a virtual microphone. Thus, an output device can masquerade as an input device. This lets applications like the soundboard "speak" through your games and chat applications, as long as you set the virtual cable as your microphone in Windows or in the app. In order to use your real microphone to chat at the same time, we have to "loopback" your microphone into the virtual output device. (If you were to loopback your mic to your speakers or headphones, instead, you would hear yourself speak. If you do this with your speakers, though, it might cause feedback.)

1. You will need to install a virtual audio cable. It will act as an audio output that sends played sounds to its virtual microphone. I recommend [VB-CABLE](https://www.vb-audio.com/Cable/index.htm)).
2. Set the "Speakers or Virtual Cable" device to the virtual audio output cable. E.g., "CABLE Input (VB-Audio Virtual Cable)".
3. (Optional) Set the microphone loopback device to your real microphone. This will mix your real mic in with the virtual mic so that you can speak *and* play sounds. Note: Loopback only occurs when the "Enable Hotkeys and Loopback" checkbox is checked.
4. (Optional) If you would also like to have the sounds played through your speakers or headphones, set Playback Device 2 to that device.
5. Make sure the virtual microphone (e.g., "CABLE Output (VB-Audio Virtual Cable)") is either your default microphone in Windows or set as the desired microphone in the game or application that is going to use it.

## Screenshots: 

![Main window](https://ibb.co/sHksxX2)

![Add/edit sound window](https://ibb.co/3YqPCDD)

![Settings window](https://ibb.co/dbHRkrh)

![Text-to-speech window](https://ibb.co/qr77TFP)