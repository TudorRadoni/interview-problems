using System;
using System.Resources;

namespace Stage_One___Starting_Off_Slowly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Stuff\Projects\Interviuri si probleme\interview-problems\Stratec Software Internship\_docs\Input_One.txt";
            ReadAndParseFile(path);
        }

        static void ReadAndParseFile(string path)
        {
            using (var sr = new StreamReader(path))
            {
                string buffer;
                while ((buffer = sr.ReadLine()) != null)
                {
                    ParseLine(buffer);
                }
            }
        }

        static void ParseLine(string line)
        {
            // Handle comments
            if (line.TrimStart().StartsWith('#'))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.White;
            }

            //Handle lists
            else if (line.Length > 1 && (
                line.Substring(1, 1) == "." ||
                line.Substring(1, 1) == ":"))
            {
                // Split line into index and text
                string[] delimiters = { ".", ":" };
                string[] parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                // Print index with different colour
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(parts[0] + " - ");

                // Print text with white
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(parts[1]);
            }

            // Default line
            else Console.WriteLine(line);



        }

        //static void ReadFile(string path)
        //{
        //    Char[] buffer;
        //    using (var sr = new StreamReader(path))
        //    {
        //        buffer = new Char[(int)sr.BaseStream.Length];
        //        sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
        //    }

        //    Console.WriteLine(new String(buffer));
        //}
    }
}