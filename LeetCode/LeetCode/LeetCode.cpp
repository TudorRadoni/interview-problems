// LeetCode.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>

int main()
{
	const int len = 7;
	int nums[len] = { 1, 7, 3, 6, 5, 6 };

	int leftSum = 0;
	int rightSum = 0;

	for (int i = 0; i < len; i++)
	{
		for (int ls = 0; ls < i; ls++)
		{
			leftSum += nums[ls];
		}

		for (int rs = i + 1; rs < len; rs++)
		{
			rightSum += nums[rs];
		}

		if (leftSum == rightSum)
		{
			return i;
		}
		else
		{
			leftSum = 0;
			rightSum = 0;
		}
	}

	if (leftSum == 0 && rightSum == 0)
	{
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
