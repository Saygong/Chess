//
// Created by andre on 23/01/2022.
//

#include<ctime>
#include<cstdlib>

bool random(int percentage){
    int value = 100/percentage;
    srand(time(nullptr));
    int n = rand()%value;
    return (n == 0);

}