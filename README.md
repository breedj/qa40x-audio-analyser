# qa40x-audio-analyser
An audio analyser program for the Quant Asylum QA40x series

First version. Currently only left channel is supported. Right channel and more features will be added.

To install download the msi here: https://github.com/breedj/qa40x-audio-analyser/releases/download/V0.1/QA40xAudioAnalyserSetup.msi
The applicaton requires .net framework 4.8

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
