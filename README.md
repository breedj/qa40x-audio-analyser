# qa40x-audio-analyser
An audio amplifier analyser program for the Quant Asylum QA40x series.

![image](https://github.com/user-attachments/assets/51656860-b696-4bc5-8334-c33ec1f2b01f)

![image](https://github.com/user-attachments/assets/82691402-aceb-4ca5-866d-49693ab9a23d)

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
      
**TODO:**
- [ ] FFT with automatic peak search
- [ ] Amplifier impedance vs frequency measurement
- [ ] Saving of data to json file
- [ ] Importing data from json file
- [ ] Saving measurement results to image
- [ ] Generating pdf report of measurements
- [ ] Measurment project management
- [ ] Multiple measurements and results per project
- [ ] Overlay of multiple of the same measurements for comparison

## INSTALLATION NOTES

To install download the msi here: https://github.com/breedj/qa40x-audio-analyser/releases/download/V0.3/QA40xAudioAnalyserSetup.msi

The applicaton requires .net framework 4.8.

For now, since you are donwloading the installation files from the internet and I currently have not made proper installer yet (work in progess) be sure to check the Unblock-checkbox in the properties of the msi file before executing it. 

![Unblock_msi](https://github.com/user-attachments/assets/9825e1f3-8c23-44cc-b725-6bf0f1306de0)

Or choose to click Run anyway when windows protection comes with a popup.

![write protect](https://github.com/user-attachments/assets/dda420f8-3451-425f-881c-569851c17736)
