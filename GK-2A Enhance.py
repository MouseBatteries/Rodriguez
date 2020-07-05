import cv2
import glob
import numpy as np
import os
import argparse

print("""
┌──────────────────────────────────────────────┐
│                GK-2A Enhance                 │
│          Colour/Enhancer & Animator          │
│                    V 1.0                     │
├──────────────────────────────────────────────┤
│   @MouseBatteries   GitHub: MouseBatteries   │
└──────────────────────────────────────────────┘
""")

parser = argparse.ArgumentParser(description='Adding some options!')

parser.add_argument('input', metavar='i', type=str, help='Tells GK-2A Enhance where your images are.')
parser.add_argument('working', metavar='w', type=str, help='Tells GK-2A Enhance where it can temporarily store files.')
parser.add_argument('out', metavar='o', type=str, help='Tells GK-2A Enhance where to put the final video.')

args = parser.parse_args()

inputDir = (args.input) + '*.jpg'
workingDir = (args.working)
renderDir = (args.out)

#Try and create an output directory if it doesn't already exist.
try:
    os.mkdir(renderDir)
except OSError:
    pass

print(f'Images: {inputDir}')
print(f'Working Directory: {workingDir}')
print(f'Output Directory: {renderDir}\n')

imageArray = glob.glob(inputDir)
frame = 0
eframe_array = []


def progress_bar(progress, total, action):
    percent = (progress / total) * 100
    print(action, '-', float("{:.2f}".format(percent)), '% ', end='\r', flush=True)
    
for i in imageArray:
    
    image = cv2.imread(i) 
  
    image_bw = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY) 
  
    clahe = cv2.createCLAHE(clipLimit = 5) 
    final_img = clahe.apply(image_bw)
  
    _, ordinary_img = cv2.threshold(image_bw, 155, 255, cv2.THRESH_BINARY) 
  
    cv2.imwrite(f'{workingDir}{frame}-enhanced.jpg', final_img)

    eframe_array.append(f'{workingDir}{frame}-enhanced.jpg')

    
    frame += 1
    progress_bar(frame, len(imageArray), 'Enhancing with CLAHE')
print('Enhancing with CLAHE - Done!    ')
    

overlay = cv2.imread('falseColourGK2.png')
frame = 0


overlay = overlay.astype(float)/255

for i in eframe_array:
    image = cv2.imread(i)
    image = image.astype(float)/255

    mask = image >= 0.5
    overlayedimage = np.zeros_like(image)

    overlayedimage[~mask] = (2*image*overlay)[~mask] 
    overlayedimage[mask] = (1-2*(1-image)*(1-overlay))[mask] 

    x = (overlayedimage*255).astype(np.uint8)
    
    cv2.imwrite(f'{workingDir}{frame}-enhanced.jpg', x)
    frame += 1
    progress_bar(frame, len(eframe_array), 'Underlaying Colour')
print('Underlaying Colour - Done!    ')

frame = 0
video_array = []
for filename in eframe_array:
    img = cv2.imread(filename)
    height, width, layers = img.shape
    size = (width, height)
    video_array.append(img)

    frame += 1
    progress_bar(frame, len(eframe_array), 'Assembling Frames')
print('Assembling Frames - Done!    ')


out = cv2.VideoWriter(f'{renderDir}final.avi',cv2.VideoWriter_fourcc(*'DIVX'), 30, size)
for i in range(len(video_array)):
    out.write(video_array[i])
    progress_bar(i, len(video_array), 'Rendering Video')

out.release()

print('Rendering Video - Done!    ')

frame = 0


for i in eframe_array:
    os.remove(i)
    frame += 1
    progress_bar(frame, len(eframe_array), 'Cleaning Up')

print('Cleaning Up - Done!    ')

print('\n-------------------------------------------------------------------')



