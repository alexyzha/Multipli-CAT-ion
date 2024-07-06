import cv2
import numpy as np

# file i/o
input = "C:/Users/Alex/Desktop/Code/CAT_GAME/sprites/v2final/"
output = "C:/Users/Alex/Desktop/Code/CAT_GAME/sprites/v3final/"

# file color
colors = ("glass","gray","orange","white")

# file number
all_nums = set()
for i in range(1,13):
    for j in range(i,13):
        all_nums.add(i * j)

# replace colors
def replace_color(image_path,output_path,target_color,replacement_color):
    image = cv2.imread(image_path,cv2.IMREAD_UNCHANGED)
    replacement_bgr = (replacement_color[2],replacement_color[1],replacement_color[0],255)
    # replace color
    color_bgr = (target_color[2],target_color[1],target_color[0],255)
    mask = cv2.inRange(image,np.array(color_bgr),np.array(color_bgr))    
    image[mask == 255] = replacement_bgr
    # save
    cv2.imwrite(output_path,image)

## lighter yellow: (255,214,0) ---> (31,83,107)
## darker yellow: (163,148,68) ---> (3,27,39)
r_arr = [(255,214,0),(138,28,28),(163,148,68),(93,1,1)]
## test replacement
# i_ = "C:/Users/Alex/Desktop/Code/CAT_GAME/sprites/v2final/orange/1.png"
# o_ = "C:/Users/Alex/Desktop/Code/CAT_GAME/sprites/test/1.png"
# replace_color(i_,o_,r_arr[0],r_arr[1])
# replace_color(o_,o_,r_arr[2],r_arr[3])

# main
for color in colors:
    for i in all_nums:
        # file i/o
        i_ = f"{input}{color}/{i}.png"
        o_ = f"{output}{color}/{i}.png"
        replace_color(i_,o_,r_arr[0],r_arr[1])
        replace_color(o_,o_,r_arr[2],r_arr[3])