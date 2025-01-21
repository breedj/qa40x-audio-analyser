# qa40x-audio-analyser
An audio amplifier analyser program for the QuantAsylum QA40x series.

![{CC259019-3909-43AA-BC9D-5B96E9AE9685}](https://github.com/user-attachments/assets/c979e4ae-1325-40b0-8e2a-dd537c14313d)

![{35BD0BD1-255D-47B4-AE39-6C635A449D2B}](https://github.com/user-attachments/assets/157ee6ab-7afb-4e40-bc64-7134debbda6e)

![image](https://github.com/user-attachments/assets/7ac02e58-0fa7-4a78-aa42-2f42ed06aab3)

![image](https://github.com/user-attachments/assets/b3003300-b136-4545-9260-cc9436383a9a)

![image](https://github.com/user-attachments/assets/6b32d47d-7a12-44ae-8316-dbc39d3f3a07)


**DONE:**
- [x] THD vs frequency measurement
- [x] Automatic determination of input attenuation
- [x] Automatic determination of input amplitude based on output voltage or power setpoint
- [x] Cursors with data
- [x] Mini plots with frequency and time domain data
- [x] Autofitting if graph data
- [x] Plotting of noise floor in graphs
- [x] THD vs Output amplitude measurement
- [x] Added right channel support to measurements
- [x] Added Frequency Response measurement with bandwidth analysis
- [x] Bode plot with phase measurement

**IN PROGRESS:**
- [ ] FFT with automatic peak search of harmonics
- [ ] Amplifier impedance vs frequency measurement
- [ ] New interface
- [ ] Cross platform (Windows, Linux, Mac)
      
**TODO:**
- [ ] Saving of data to json file
- [ ] Importing data from json file
- [ ] Saving measurement results to image
- [ ] Generating pdf report of measurements
- [ ] Measurement project management
- [ ] Multiple measurements and results per project
- [ ] Overlay of multiple of the same measurements for comparison
- [ ] Replace REST calls by USB calls.

## INSTALLATION NOTES

To install download the msi here: https://github.com/breedj/qa40x-audio-analyser/releases/download/V0.5/QA40xAudioAnalyserSetup.msi

The applicaton requires .net framework 4.8.

For now, since you are donwloading the installation files from the internet and I currently have not made proper installer yet (work in progess) be sure to check the Unblock-checkbox in the properties of the msi file before executing it. 

![Unblock_msi](https://github.com/user-attachments/assets/9825e1f3-8c23-44cc-b725-6bf0f1306de0)

Or choose to click Run anyway when windows protection comes with a popup.

![write protect](https://github.com/user-attachments/assets/dda420f8-3451-425f-881c-569851c17736)
