// Problema 3.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

const char name[] = ""; // Please enter your name here
//const char name[] = "Ion Popescu"; // as such

const char* firstOccurencePtr(const char* input_string, const char* to_find)
{
	const char* first_occurence;

	for (int i = 0; i < strlen(input_string); i++)
	{
		for (int j = 0; j < strlen(to_find); j++)
		{
			if (input_string[i] == to_find[j])
			{
				first_occurence = &input_string[i];
				return first_occurence;
			}
		}
	}

	return first_occurence;
}

int main()
{
	printf("%s\n", firstOccurencePtr("Analog Devices", " "));		// " Devices"
	printf("%s\n", firstOccurencePtr("Vocale", "aeiou"));			// "ocale"
	printf("%s\n", firstOccurencePtr("Hi! Hello, how are you ?", "!,?;"));	// "! Hello, how are you ?"

	// Extra credit:
	printf("%s\n", firstOccurencePtr("No characters found", "!,?;"));	// ""

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
