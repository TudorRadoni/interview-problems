namespace Subject_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Test ProblemA
            Console.WriteLine(ProblemA("alabalaportocala")); // output: b
            Console.WriteLine(ProblemA("aaaaaa")); // output: nothing

            // Test ProblemB
            List<string> list = new List<string>(
                new string[] { "alabalaportocala", "all", "ana", "nelu", "ananas", "stea", "solar" }
                );
            Console.WriteLine(ProblemB(list)); // output: bannsss

            // Test ProblemC
            Dictionary<char, int> dict = ProblemC(list);
            Console.Write("{ ");
            foreach (KeyValuePair<char, int> kvp in dict)
            {
                Console.Write("{0}: {1}, ", kvp.Key, kvp.Value);
            }
            Console.Write("}\n"); // output: { b: 1, a: 1, n: 2, s: 3 }
        }

        // Write a function that takes a string as input and returns the first
        // non-repeating character in the string. If all characters repeat, return
        // None/null/nil/undefined(depending on the language of choice).
        static char ProblemA(string str)
        {
            for (int i = 0; i < str.Length; ++i)
            {
                int cnt = 0;
                for (int j = 0; j < str.Length; ++j)
                {
                    // If we find a match, increment cnt.
                    if (str[i] == str[j]) cnt++;

                    // If we find a second match, break out of the loop.
                    if (cnt == 2) break;
                }

                // If we reach the end of the string and cnt is still 1, we found
                // the first non-repeating character.
                if (cnt == 1) return str[i];
            }
            return (char)0;
        }

        // Write a function that takes as parameter a list of strings.The output of the
        // function should 1 string, made of the first non-repeating character from each
        // string in the list.
        static string ProblemB(List<string> strings)
        {
            string result = null;
            foreach (string str in strings)
            {
                result += ProblemA(str);
            }
            return result;
        }

        // Write a function that takes as parameter a list of strings.The output of the
        // function should 1 hash, with keys each first non-repeating character from the
        // list & the value → the number it appears.
        static Dictionary<char, int> ProblemC(List<string> strings)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach (string str in strings)
            {
                char c = ProblemA(str);
                // Test for null character.
                if (c == 0) continue;

                if (result.ContainsKey(c))
                {
                    // If the character is already in the dictionary, increment its value.
                    result[c]++;
                }
                else
                {
                    // If the character is not in the dictionary, add it.
                    result[c] = 1;
                }
            }
            return result;
        }
    }
}
