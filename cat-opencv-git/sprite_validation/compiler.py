import cv2
import numpy as np

# source path is going to be from orange, least chance of color clash?
path = "C:/Users/Alex/Desktop/Code/CAT_GAME/sprites/v2final/orange/"
out = "C:/Users/Alex/Desktop/Code/CAT_GAME/sprites/v2final/glass/"
whisker = "C:/Users/Alex/Desktop/Code/CAT_GAME/sprites/cat_whisker/glass_whisker.png"

# delete colors
def delete_color(image_path,output_path,target_colors):
    image = cv2.imread(image_path,cv2.IMREAD_UNCHANGED)
    # iterate through all colors to be deleted
    for color in target_colors:
        color_bgr = (color[2],color[1],color[0],255)
        mask = cv2.inRange(image,np.array(color_bgr),np.array(color_bgr))
        image[mask == 255,3] = 0
    # save
    cv2.imwrite(output_path,image)

# replace colors
def replace_color(image_path,output_path,target_colors,replacement_color):
    image = cv2.imread(image_path,cv2.IMREAD_UNCHANGED)
    replacement_bgr = (replacement_color[2],replacement_color[1],replacement_color[0],replacement_color[3])
    # iterate through all colors to be replaced
    for color in target_colors:
        color_bgr = (color[2],color[1],color[0],255)
        mask = cv2.inRange(image,np.array(color_bgr),np.array(color_bgr))    
        image[mask == 255] = replacement_bgr
    # save
    cv2.imwrite(output_path,image)

# overlay pngs
def overlay_img(bkg_path,ovl_path,output_path):
    # load
    bkg = cv2.imread(bkg_path,cv2.IMREAD_UNCHANGED)
    ovl = cv2.imread(ovl_path,cv2.IMREAD_UNCHANGED)
    # overlay
    for y in range(bkg.shape[0]):
        for x in range(bkg.shape[1]):
            acc_px = ovl[y,x]
            fla = acc_px[3]/255.0
            bkg[y,x] = bkg[y,x] * (1.0-fla) + acc_px * fla
    # save
    cv2.imwrite(output_path,bkg)

# to delete
deletion_targets = [(222,163,105),
           (211,145,101),
           (232,212,180),
           (215,147,83),
           (212,139,71),
           (219,177,120),
           (228,198,156),
           (219,155,92),
           (205,127,77),
           (208,136,89),
           (216,147,77),
           (219,155,90),
           (234,212,180),
           (216,147,79)]

# to replace
replacement_targets = [(177,107,39),
                       (151,91,33),
                       (164,99,36)]

# replacement color
replacement = (0,0,0,255)

# main script
all_nums = set()
for i in range(1,13):
    for j in range(i,13):
        all_nums.add(i * j)

for i in all_nums:
    i_ = f"{path}{i}.png"
    o_ = f"{out}{i}.png"
    delete_color(i_,o_,deletion_targets)
    replace_color(o_,o_,replacement_targets,replacement)
    overlay_img(whisker,o_,o_)