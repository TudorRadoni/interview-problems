// Pairs and sum.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

// Function to check if an array contains
// pairs that sum to a number in the array
void pairs(int* arr) {
	for (int i = 0; i < 6; i++) {
		for (int j = 0; j < 6; j++) {
			// take pair and 
			// verify if sum is present in arr
			int sum = arr[i] + arr[j];
			for (int k = 0; k < 6; k++) {
				if (sum == arr[k]) {
					printf("(%d, %d)\n", arr[i], arr[j]);
				}
			}
		}
	}
}

int main()
{
	std::cout << "Hello World!\n";
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
