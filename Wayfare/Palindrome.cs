using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Palindrome
{
    internal class Program
    {
        public static bool isPalindrome(int number)
        {
            int inverse = 0;

            // Get length of number
            int len = 0;
            int saveNumber = number;
            while (number != 0)
            {
                len++;
                number /= 10;
            }
            number = saveNumber;

            // Build inverse
            for (int i = 0; i < len; i++)
            {
                inverse = inverse * 10 + number % 10;
                number /= 10;
            }

            return inverse == saveNumber ? true : false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(isPalindrome(12345) ? "True" : "False");
            Console.WriteLine(isPalindrome(12321) ? "True" : "False");
            Console.WriteLine(isPalindrome(122221) ? "True" : "False");
            Console.WriteLine(isPalindrome(122001) ? "True" : "False");
        }
    }
}