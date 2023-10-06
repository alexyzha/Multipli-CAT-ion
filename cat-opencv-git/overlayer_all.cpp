#include <opencv2/opencv.hpp>
#include <iostream>
using namespace cv;
using namespace std;

void combine(Mat base, String str, String add);

int main() {

    string colors[] = {"gray", "white", "orange"};
    
    for(int col = 0; col <= 2; col++) {

        int numbers[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 27, 28, 30, 32, 33, 35, 36, 40,
            42, 44, 45, 48, 49, 50, 54, 55, 56, 60, 63, 64, 66, 70, 72, 75, 77, 80, 81, 84, 88, 90, 96, 99, 100, 108, 110, 120, 121, 132, 144};
        for(int number : numbers) {
            //base image
            String str = "~/sprites/cat_color/" + colors[col] + ".png";
            
            Mat base = imread(str, IMREAD_UNCHANGED);
            
            //need for variable overlayers
            string add;

            //face layer
            if(number % 121 == 0) {
                add = "face/blink";
                combine(base, str, add);
            } else if(number % 11 == 0) {
                add = "face/wink";
                combine(base, str, add);
            } else {
                add = "face/default";
                combine(base, str, add);
            }

            //number layer
            add = "number/" + to_string(number);
            combine(base, str, add);

            //mouth layer
            if(number <= 9) {
                add = "mouth/UTen";
                combine(base, str, add);
            } else if (number >= 10 && number <= 144) {
                add = "mouth/OTen";
                combine(base, str, add);
            }

            //outliner layer
            add = "outline/" + colors[col] + "_outline";
            combine(base, str, add);

            //whisker layer
            add = "cat_whisker/" + colors[col] + "_whisker";
            combine(base, str, add);

 
            //adding 2s, if any
            for(int p = 1; p <= 6; p++) {
                int divTwo = pow(2, p);
                if(number % divTwo == 0) {
                    add = "acc/heart/" + to_string(p);
                    combine(base, str, add);
                }
            }

            //adding 3s, if any
            for(int t = 1; t <= 4; t++) {
                int divThree = pow(3, t);
                if(number % divThree == 0) {
                    add = "acc/bow/" + to_string(t);
                    combine(base, str, add);
                }
            }

            //adding 5s, if any
            for(int q = 1; q <= 2; q++) {
                int divFive = pow(5, q);
                if(number % divFive == 0) {
                    add = "acc/hat/" + to_string(q);
                    combine(base, str, add);
                }
            }

            //adding 7s, if any
            for(int w = 1; w <= 2; w++) {
                int divSeven = pow(7, w);
                if(number % divSeven == 0) {
                    add = "acc/tailbow/" + to_string(w);
                    combine(base, str, add);
                }
            }

            //change this by num
            str = "~/sprites/final/" + colors[col] + "/" + to_string(number) + ".png";
            imwrite(str, base);

        }

    }
    return 0;
}

void combine(Mat base, String str, String add) {
    //combine
    String acc = "~/sprites/" + add + ".png";
    Mat accessory = imread(acc, IMREAD_UNCHANGED);

    for(int y = 0; y < base.rows; y++) {
        for(int x = 0; x < base.cols; x++) {
            Vec4b accPX = accessory.at<Vec4b>(y, x);
            float fla = accPX[3] / 255.0;
            base.at<Vec4b>(y, x) = base.at<Vec4b>(y, x) * (1.0 - fla) + accPX * fla;
        }
    }    
}
