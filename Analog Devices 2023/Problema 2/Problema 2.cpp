// Problema 2.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string.h>

int nstringToInt(const char* input_string, int n) {
	int result = 0;

	// Corner case 4, n = 0;
	if (n == 0) n = strlen(input_string);

	// Corner case 2, n > string length
	if (n > strlen(input_string)) {
		printf("n is greater than string length");
		return 1;
	}

	// Corner case 3, negative numbers
	bool negative = false;
	if (input_string[0] == '-') negative = true;
	int start = negative ? 1 : 0;

	// Corner case 1, invalid input
	for (int i = start; i < n; i++) {
		if (input_string[i] < '0' || input_string[i] > '9') {
			printf("Invalid input");
			return 1;
		}
	}

	for (int i = start; i < n; i++) {
		result = result * 10 + (input_string[i] - '0');
	}

	return negative ? -result : result;
}

int main()
{
	printf("%d\n", nstringToInt("123", 3));		// Prints 123
	printf("%d\n", nstringToInt("12345", 5));	// Prints 12345
	printf("%d\n", nstringToInt("12345", 2));	// Prints 12

	// Corner cases - extra points
	printf("%d\n", nstringToInt("1bc", 3));		// n is greater than string length
	printf("%d\n", nstringToInt("123", 5));		// n is greater than string length
	printf("%d\n", nstringToInt("-123", 4));     // Negative numbers
	printf("%d\n", nstringToInt("12345", 0));	// When n is 0, it goes to the end of the string

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
