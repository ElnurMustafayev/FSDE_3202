#include "pch.h"
#include <iostream>

using namespace std;

extern "C" {
	__declspec (dllexport) int GetSum(int x, int y) {
		return x + y;
	}

	__declspec (dllexport) void SayHi(char* name) {
		cout << "Hello, " << name << endl;
	}
}