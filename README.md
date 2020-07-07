# GK-2A-Enhance
A Python script to Enhance, Colour and Animate LRIT IR105 Images from the Geo-Kompsat-2A Satellite.

## Key Features
- Repairs Dropped Files from Images
- Enhances landmass with CLAHE
- False Colours
- Animates


## Running GK-2A Enhance
GK-2A Enhance can be run in most terminals/consoles (Windows, Mac OS X, Linux) using the following command:

`python test.py images/ images/ final/ True`

`python` being, well python. You can also optionally use python3, if you want.
<br/>

`images/` is the directory in which all of your images to convert an animate are located.
<br/>

The **second** `images/` is for your working directory, or where GK-2A enhnace will place enhanced images to be animated.
You can usually leave this as the directory where your images to enhance are already located, as they will be removed later.
<br/>

`final/` is where your animation will be placed one GK-2A Enhance is done with it. GK-2A Enhance will automatically create this directory for you if it doesn't already exist.

The final argument you can parse, `True` or `False` decided wheather or not you want GK-2A Enhance to remove drops from your images. Enabling this will make the program much slower. 700 Odd frames can take upwards of an hour.
<br>

If you run into import errors, you'll need:
- `pip install opencv-python`
- `pip install glob2`
- `pip install numpy`
- `pip install argparse`

### System Requirements

As simple as this script seems, it has some quite beefy system requirements. I'm working on optimizing it, but that is further down the path.
<br>

For the time being, I recommend having at **least**:
- 8GB Of RAM
- 20GB Disk Space

Your processor shouldn't matter *too* much, as long as you have something built within the past 5 years, you should be just fine.
<br>
*Be warned that I have seen this program use up to 11GB of RAM when doing exceptionally large animations (typically 1000+ frames)*

### What can it do?
GK-2A Enhance takes your boring old black and white Infrared images, enhances them with CLAHE and underlays some colour onto them. It also shoves them into a nice, smooth animation for you to watch, because, frankly I needed this program to do something more interesting.
<br>

Below are some examples of what GK-2A Enhance can do.
<br>

IR105 LRIT Image:
<p align="left">
  <img src="https://github.com/MouseBatteries/GK-2A-Enhance/blob/master/images/100.jpg" width="350" title="hover text">
</p>

CLAHE Enhanced Image:
<p align="left">
  <img src="https://github.com/MouseBatteries/GK-2A-Enhance/blob/master/examples/8-enhanced.jpg" width="350" title="hover text">
</p>

Falsely Coloured Image:
<p align="left">
  <img src="https://github.com/MouseBatteries/GK-2A-Enhance/blob/master/examples/1-enhanced.jpg" width="350" title="hover text">
</p>
<b>
A full weeks worth of animation can be found here, converted by this script. 
https://www.youtube.com/watch?v=9PvcAF5QSGk
