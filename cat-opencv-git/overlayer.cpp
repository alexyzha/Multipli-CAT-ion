#include <opencv2/opencv.hpp>
#include <iostream>
using namespace cv;
using namespace std;

void combine(Mat overlay, String str, String add);

int main() {
    int numbers[] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 27, 28, 30, 32, 33, 35, 36, 40,
        42, 44, 45, 48, 49, 50, 54, 55, 56, 60, 63, 66, 70, 72, 75, 77, 80, 81, 84, 88, 90, 96, 99, 100, 108, 110, 120, 121, 132, 144};
    for(int number : numbers) {
        //base image
//        Mat base = imread("/Users/~/Desktop/~/sprites/cat_color/orange.png", IMREAD_UNCHANGED);
        //overlay image
        String str = "/Users/~/Desktop/~/sprites/comb_cats/white/" + to_string(number) + ".png";
        Mat overlay = imread(str, IMREAD_UNCHANGED);
        //3rd img overlay
//        Mat third = imread("/Users/~/Desktop/~/sprites/cat_whisker/orange_whisker.png", IMREAD_UNCHANGED);
        //4th
//        Mat fourth = imread("/Users/~/Desktop/~/sprites/cover/orange.png", IMREAD_UNCHANGED);

        //layering 1 + 2
//        for(int y = 0; y < base.rows; y++) { for(int x = 0; x < base.cols; x++) { Vec4b overlayPX = overlay.at<Vec4b>(y, x); float fl = overlayPX[3] / 255.0; base.at<Vec4b>(y, x) = base.at<Vec4b>(y, x) * (1.0 - fl) + overlayPX * fl; } }

        //layering third
//        for(int yt = 0; yt < base.rows; yt++) { for(int xt = 0; xt < base.cols; xt++) { Vec4b thirdPX = third.at<Vec4b>(yt, xt); float flt = thirdPX[3] / 255.0; base.at<Vec4b>(yt, xt) = base.at<Vec4b>(yt, xt) * (1.0 - flt) + thirdPX * flt; } }
        //layering fourth
//        for(int yf = 0; yf < base.rows; yf++) { for(int xf = 0; xf < base.cols; xf++) { Vec4b fourthPX = fourth.at<Vec4b>(yf, xf); float flf = fourthPX[3] / 255.0; base.at<Vec4b>(yf, xf) = base.at<Vec4b>(yf, xf) * (1.0 - flf) + fourthPX * flf; }}

        string add;
        //add accessory code
//        for(int y = 0; y < overlay.rows; y++) { for(int x = 0; x < overlay.cols; x++) { Vec4b accPX = accessory.at<Vec4b>(y, x); float fla = accPX[3] / 255.0; overlay.at<Vec4b>(y, x) = overlay.at<Vec4b>(y, x) * (1.0 - fla) + accPX * fla; } }

        //adding 3s
        if(number % 3 == 0) {
            add = "bow/2";
            combine(overlay, str, add);
            if(number % 9 == 0) {
                add = "bow/3";
                combine(overlay, str, add);
                if(number % 27 == 0) {
                    add = "bow/4";
                    combine(overlay, str, add);
                    if(number % 81 == 0) {
                        add = "bow/1";
                        combine(overlay, str, add);
                    }
                }
            }
        }

        //adding 2s
        if(number % 2 == 0) {
            add = "heart/1";
            combine(overlay, str, add);
            if(number % 4 == 0) {
                add = "heart/2";
                combine(overlay, str, add);
                if(number % 8 == 0) {
                    add = "heart/3";
                    combine(overlay, str, add);
                    if(number % 16 == 0) {
                        add = "heart/4";
                        combine(overlay, str, add);
                        if(number % 32 == 0) {
                            add = "heart/5";
                            combine(overlay, str, add);
                            if(number % 64 == 0) {
                                add = "heart/6";
                                combine(overlay, str, add);
                            }
                        }
                    }
                }
            }
        }

        //change this by num
        str = "/Users/~/Desktop/~/sprites/final/white/" + to_string(number) + ".png";
        imwrite(str, overlay);

    }
    return 0;
}

// 1 2 3 4 5 6 7 8 9 10 11 12 14 15 16 18 20 21 22 24 25 27 28 30 32 33 35 36 40
// 42 44 45 48 49 50 54 55 56 60 63 66 70 72 75 77 80 81 84 88 90 96 99 100 108 110 120 121 132 144

void combine(Mat overlay, String str, String add) {
    //combine
    String acc = "/Users/~/Desktop/~/sprites/acc/" + add + ".png";
    Mat accessory = imread(acc, IMREAD_UNCHANGED);

    for(int y = 0; y < overlay.rows; y++) {
        for(int x = 0; x < overlay.cols; x++) {
            Vec4b accPX = accessory.at<Vec4b>(y, x);
            float fla = accPX[3] / 255.0;
            overlay.at<Vec4b>(y, x) = overlay.at<Vec4b>(y, x) * (1.0 - fla) + accPX * fla;
        }
    }    
}