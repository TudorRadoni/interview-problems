// Binary Search.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int main()
{
	const int len = 12;
	int nums[12] = { -1, 0, 3, 5, 9, 12 };
	int target = 9;

	int start = len / 2;
	int end = len;
	for (int idx = start; idx < end; i++)
	{
		if (target < nums[idx]) {
			end = idx; 
		}
		else if (target > nums[idx]) {
			start = idx;
		}
		else if (target == nums[idx]) {
			std::cout << idx;
			return idx;
		}
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
