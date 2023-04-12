# Changelog

## 1.3.0.0:

- Added "allow overlap" to settings (https://github.com/ZenitH-AT/JNSoundboard/pull/4)
- Bumped .NET Framework to 4.8
- Bumped NAudio to 2.1.0

## 1.2.1.1:

- Added start with windows and start minimised to settings.
- Program now only allows for one instance at a time.
- Added open and exit buttons to the tray icon.
- All options are saved as settings automatically so that they are remembered between launches.
- Device and window selector refreshes will reselect the last item if still present after the reload.
- Enable hotkeys and enable loopback are now separate buttons.
- Launching the program will start loopback without needing to untick and retick the checkbox.
- Added a scrollable sound volume control to the main form and add/edit sound form (the slider in the main form only affects sounds without custom volumes).
- Fixed several bugs related to the TTS form.
- TTS form now uses a checkbox to add to list, rather than use a different button.
- TTS form now allows the user to set a window restriction and custom volume.
- Fixed a few issues related to XML validation.
- XML saving now uses a timer to prevent file in use errors when saving settings (allows for more settings to be saved and push to talk hotkey timer to be reduced)
- Improved the responsiveness of key fields without causing clicking the field to set the key (timer interval is temporarily lowered after first timer tick until leaving the field)
- All keys fields no longer show context menus to make setting a key as right click easier (ShortcutsEnabled false).
- Reimplemented the Keys enum to include definitions for every key possible. LuaMacros users rejoice!
- Centralised redundant code in various areas (e.g. window listing and key combination code).
- Adjusted UI sizing, padding, tab stops and so on.
- Adjusted/added some tooltips.
- Fixed additional minor issues and inconsistencies.
- Refactored some of the code.

# Changelog - EmbarassingUsername

## 1.2.0.0:

- Added second sound output for also playing the sounds to yourself while playing them through the virtual cable.
- Added gender selector for Text-to-Speech (TTS) dialog.
- Added a Preview button to the TTS dialog along with a Stop button.
- TTS dialog text is now multi-line.
- TTS dialog now prompts for a filename instead of using the text as the filename.
- Added tooltips to audio device selectors with quick instructions.
- Relabeled device selectors in main form to be more clear.
- Added "clear" buttons to all key-input text boxes. It was not obvious that Esc would clear them.
- Fixed Esc button closing the Add Hotkey dialog (instead of clearing the hotkey) when the keys textbox has focus.
- Forced dialogs to open in the center of the main window.
- Forced main window to open in center of screen.
- Removed the requirement that there be hotkeys defined in order to enable the main checkbox. This is so Loopback can be tested even without there being hotkeys defined.
- In Settings dialog, prevented the "Stop all sounds hotkey" textbox from automatically having focus when opening the settings.
- Adjusted some popup messages to make them more simple and/or clear.
- Added detailed information and instructions to README regarding using a virtual cable.
- Rearranged the main form slightly; added explanatory text to the main Enabled checkbox.
- Fixed some button alignments.
- Refactored some of the code.