# Rodriguez
**Rodriguez - for all your geostationary orbit satellite image correction needs!**

Using a custom built Geostationary Error Correction Engine (GECE), Rodriguez is able to reconstruct pieces of missing data
from geostationary satellites. It's in it's early stages now, but development will continue, with new commits at least weekly.

## Documentation
Windows Use: 
- `Rodriguez.exe <in folder> <out folder>`

Linux Setup:
- Linux requires one extra step. You're required to make `Rodriguez-Linux` executable. You can do this with:
- `chmod +x Rodriguez-Linux`.
- Then Rodriguez can be run like such: `./Rodriguez-Linux <in folder> <out folder>`

## Support
- GK-2A IR
- Himawari IR
- GOES IR

__Colour support to come soon.__

## Sample Images
__Before:__
<p>
<img src="https://github.com/MouseBatteries/Rodriguez/blob/master/sample_images/118.jpg" style="width:250px;" alt="Un-Corrected Image">

__After:__
<p>
<img src="https://github.com/MouseBatteries/Rodriguez/blob/master/sample_images/18-correct.jpg" style="width:250px;" alt="Corrected Image">

## Download
Releases are currently only avaliable for Windows and Linux. However, ARM and Mac OS X builds are coming soon.
<p>
<a href="https://github.com/MouseBatteries/Rodriguez/releases/tag/Alpha">Downloads - V0.0.3 - Alpha</a>
