# qa40x-audio-analyser
An audio analyser program for the Quant Asylum QA40x series

First version. Currently only left channel is supported. Right channel and more features will be added soon.

![Github screenshot 1](https://github.com/user-attachments/assets/d5b7a46a-cb92-4634-a7d5-8b6794b2b76d)

**DONE:**
- [x] THD vs frequency measurement
- [x] Automatic determination of input attenuation
- [x] Automatic determination of input amplitude based on output voltage or power setpoint
- [x] Cursors with data
- [x] Mini plots with frequency and time domain data
- [x] Autofitting if graph data
- [x] Plotting of noise floor in graphs  
      
**TODO:**
- [ ] THD vs Output amplitude measurement
- [ ] FFT with automatic peak search
- [ ] Saving of data to json
- [ ] Importing data from json
- [ ] Saving result to image
- [ ] Generating pdf report of measurments
- [ ] Project management
- [ ] Multiple measurements and results per project
- [ ] Overlay of multiple of the same measurements

## INSTALLATION NOTES

To install download the msi here: https://github.com/breedj/qa40x-audio-analyser/releases/download/V0.2/QA40xAudioAnalyserSetup.msi

The applicaton requires .net framework 4.8.

For now, since you are donwloading the installation files from the internet and I currently have not made proper installer yet (work in progess) be sure to check the Unblock-checkbox in the properties of the msi file before executing it. 

![Unblock_msi](https://github.com/user-attachments/assets/9825e1f3-8c23-44cc-b725-6bf0f1306de0)

Or choose to click Run anyway when windows protection comes with a popup.

![write protect](https://github.com/user-attachments/assets/dda420f8-3451-425f-881c-569851c17736)
