public class Main {
    public static void main(String[] args) {
        int arr[] = { 64, 34, 25, 12, 22, 11, 90 };
        bubbleSort(arr);
    }

    // Optimized bubble sort
    static void bubbleSort(int arr[]) {
        // Use a flag to check if any swap is done in the current iteration
        boolean swapped = true;

        // Repeat until no swap is done
        while (swapped) {
            swapped = false;

            for (int i = 1; i < arr.length; i++) {
                if (arr[i - 1] > arr[i]) {
                    // Swap elements
                    int temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;

                    // Set flag to true
                    swapped = true;
                }
            }
        }

        for (int i = 0; i < arr.length; i++)
            System.out.print(arr[i] + " ");
        System.out.println();
    }
}
