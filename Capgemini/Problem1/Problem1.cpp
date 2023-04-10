// Problem1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

// Write a function to check if an array contains another array.
bool contains(int* a1, int* a2) {
	// Get size of arrays
	// int size1 = sizeof(a1) / sizeof(a1[0]);
	// int size2 = sizeof(a2) / sizeof(a2[0]);

	// Check if first element of a2 is in a1
	int j = 0;
	for (int i = 0; i < 8; ++i) {
		// Check if the a2 is in a1
		if (a1[i] == a2[j]) {
			++j; // increment here to use 'size' in if statement
			if (j == 4) {
				return true;
			}
		}
		else j = 0;
	}

	return false;
}

int main()
{
	int a1[] = { 1, 2, 3, 4, 5, 6, 7, 8 };
	int a2[] = { 3, 4, 5, 6 };

	if (contains(a1, a2)) {
		std::cout << "Array a2 is contained in a1\n";
		return 0;
	}
	else {
		std::cout << "Array a2 is not contained in a1\n";
		return -1;
	}
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
