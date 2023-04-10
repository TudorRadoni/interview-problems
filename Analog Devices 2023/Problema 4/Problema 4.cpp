// Problema 4.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <cstring>

const char name[] = ""; // Please enter your name here
//const char name[] = "Ion Popescu"; // as such

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

int arithmetic_operation(const char* input_string)
{
	int result;

	char* copy = strdup(input_string);

	// use strtok to split the string into tokens
	char* token = strtok(copy, "+-");

	// build array of other tokens
	char* tokens[10];
	int i = 0;
	while (token != NULL)
	{
		tokens[i] = nstringToInt(token, 0);
		token = strtok(NULL, "+-");
		i++;
	}

	// add or subtract the other tokens
	result = tokens[0] - '0';
	for (int j = 0; j < i; j++)
	{
		if (input_string[j] == '+')
		{
			result += tokens[j + 1] - '0';
		}
		else if (input_string[j] == '-')
		{
			result -= tokens[j + 1] - '0';
		}
	}

	return result;
}

int main()
{
	printf("%d\n", arithmetic_operation("1+2"));		// Prints 3
	printf("%d\n", arithmetic_operation("1-2"));		// Prints -1
	printf("%d\n", arithmetic_operation("123-456+789"));	// Prints 456

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
