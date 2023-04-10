// Binary representation and parity.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int main() {
	int num = 50; // decimal number to be converted

	// Convert decimal to binary
	int bin = 0;
	int base = 1;
	while (num > 0) {
		bin += (num % 2) * base;
		num /= 2;
		base *= 10;
	}

	// Print binary representation
	printf("Binary: %08d\n", bin);

	// Check if the number is odd or even
	if (bin & 1) {
		printf("Odd\n");
	}
	else {
		printf("Even\n");
	}

	return 0;
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
