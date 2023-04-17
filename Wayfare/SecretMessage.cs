using System.Text;

namespace Caesar_Cipher
{
    internal class Program
    {
        public static string Encrypt(string str, int key)
        {
            StringBuilder result = new StringBuilder();

            // Iterate through each character in the string
            foreach (char c in str)
            {
                // Check if the character is an uppercase or lowercase letter
                if (char.IsLetter(c))
                {
                    // Get the ASCII code for the character
                    int asciiCode = (int)c;

                    // Calculate the shifted ASCII code
                    int shiftedAsciiCode = asciiCode + key;

                    // Check if the shifted ASCII code is out of range for letters
                    if ((char.IsLower(c) && shiftedAsciiCode > (int)'z') || (char.IsUpper(c) && shiftedAsciiCode > (int)'Z'))
                    {
                        // Wrap around to the beginning of the alphabet
                        shiftedAsciiCode -= 26;
                    }

                    // Convert the shifted ASCII code back to a character and append it to the result
                    char shiftedChar = (char)shiftedAsciiCode;
                    result.Append(shiftedChar);
                }
                else
                {
                    // Append non-letter characters to the result as-is
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public static string Decrypt(string str, int key)
        {
            StringBuilder result = new StringBuilder();

            // Iterate through each character in the string
            foreach (char c in str)
            {
                // Check if the character is an uppercase or lowercase letter
                if (char.IsLetter(c))
                {
                    // Get the ASCII code for the character
                    int asciiCode = (int)c;

                    // Calculate the shifted ASCII code
                    int shiftedAsciiCode = asciiCode - key;

                    // Check if the shifted ASCII code is out of range for letters
                    if ((char.IsLower(c) && shiftedAsciiCode < (int)'a') || (char.IsUpper(c) && shiftedAsciiCode < (int)'A'))
                    {
                        // Wrap around to the beginning of the alphabet
                        shiftedAsciiCode += 26;
                    }

                    // Convert the shifted ASCII code back to a character and append it to the result
                    char shiftedChar = (char)shiftedAsciiCode;
                    result.Append(shiftedChar);
                }
                else
                {
                    // Append non-letter characters to the result as-is
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        public static string SecretMessage(string str, int key, int operation)
        {
            string result;
            switch (operation)
            {
                case 0:
                    result = Encrypt(str, key);
                    break;

                case 1:
                    result = Decrypt(str, key);
                    break;
                default:
                    result = "error";
                    break;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(SecretMessage("this is a special cypher", 10, 0));
            Console.WriteLine(SecretMessage("drsc gkc k combod", 10, 1));
        }
    }
}