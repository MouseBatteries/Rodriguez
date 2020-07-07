# GK-2A-Enhance
A Python script to Enhance your boring IR105 LRIT images from GK-2A.

## Key Features
- Repairs Dropped Files from Images
- Enhances landmass with CLAHE
- False Colours
- Animates


## Running GK-2A Enhance
GK-2A Enhance can be run in most terminals/consoles (Windows, Mac OS X, Linux) using the following command:

`python GK-2A-Enhance.py images/ images/ final/ True`

GK-2A Enhance has serveral Command Line Arguments that you need to use to process images. These include:
- `i` - Tells GK-2A Enhance where your images are
- `w` - Tells GK-2A Enhance where it can temporarily store files
- `o` - Tells GK-2A Enahnce where to put the final video
- `s` - Tells GK-2A Enhance if you want to try and repair dropped frames.

Type `python GK-2A-Enhance.py -h` to see arguments and what order to put them in.

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
https://youtu.be/4Xi7u-gzIk8
