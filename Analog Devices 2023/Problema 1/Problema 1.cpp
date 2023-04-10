#include <iostream>

void withdraw(int n) {
	const int bancnote[] = { 1, 5, 10, 50, 100, 200, 500 };
	int len = sizeof(bancnote) / sizeof(bancnote[0]);

	for (int i = len - 1; i >= 0; --i) {
		if (n >= bancnote[i]) {
			int cnt = 0;
			while (n >= bancnote[i]) {
				n -= bancnote[i];
				cnt++;
			}

			printf("%d %d ", bancnote[i], cnt);
		}
	}

	printf("\n");
}

int main()
{
	withdraw(7645);
	withdraw(1750);
	withdraw(200);
	withdraw(123);

	return 0;
}
