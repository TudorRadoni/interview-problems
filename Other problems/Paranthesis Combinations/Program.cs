namespace Paranthesis_Combinations
{
    internal class Program
    {
        public static int CombinatoricsChallenge(int num)
        {
            // Edge case: if num is zero, there is only one valid combination (an empty string)
            if (num == 0)
            {
                return 1;
            }

            // Use a recursive function to generate all possible combinations
            List<string> generateCombinations(int openCount, int closeCount, string combination)
            {
                // Base case: if we have used all the pairs of parentheses, the combination is valid
                if (openCount == num && closeCount == num)
                {
                    return new List<string> { combination };
                }

                var result = new List<string>();

                // If we have used fewer than num opening parentheses, we can add an opening parenthesis
                if (openCount < num)
                {
                    result.AddRange(generateCombinations(openCount + 1, closeCount, combination + "("));
                }

                // If we have used fewer closing parentheses than opening parentheses, we can add a closing parenthesis
                if (closeCount < openCount)
                {
                    result.AddRange(generateCombinations(openCount, closeCount + 1, combination + ")"));
                }

                return result;
            }

            // Call the recursive function to generate all possible combinations and return the count
            return generateCombinations(0, 0, "").Count;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CombinatoricsChallenge(3));
        }
    }
}