#include <iostream>
#include <fstream>
#include <vector>
#include <set>
#include <string>
using namespace std;

// generates vector containing all possible multiples up until 144
set<int> calc_is_short_for_calculator_btw() {
    set<int> ret;
    for(int i = 1; i <= 12; ++i)
        for(int j = i; j <= 12; ++j)
            ret.insert(i*j);
    return ret;
}

int main() {
    set<int> all_nums = calc_is_short_for_calculator_btw();
    // check all files in v2final/[color] for counts
    string color[4] = {"gray","glass","orange","white"};
    vector<int> res[4];
    for(int i = 0; i < 4; ++i) {
        // directory to color
        string dir = "C:/Users/Alex/Desktop/Code/CAT_GAME/sprites/v3final/" + color[i] + "/";
        // iterate through all nums
        for(auto&j:all_nums) {
            string f_path = dir + to_string(j) + ".png";    
            ifstream file;
            file.open(f_path);
            if(!file)
                res[i].push_back(j);
        }
    }
    // print all missing numbers
    for(int i = 0; i < 4; ++i) {
        cout << color[i] << ":\n";
        for(auto&j:res[i])
            cout << j << ' ';
        cout << endl;
    }
    return 0;
}