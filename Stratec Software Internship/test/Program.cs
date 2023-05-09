using System;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text.RegularExpressions;

namespace test
{
    // Helpers for parsing
    enum LineType { Empty, Comment, Section, Item, ListItem, Unknown }
    enum SectionType { None, Machines, Features, Parts, PartOperations, Unknown }

    // Class used to store information about a parsed line
    class ParseResult
    {
        public LineType type;
        public int id;
        public string text;

        public ParseResult()
        {
            type = LineType.Unknown;
            id = 0;
            text = "";
        }
    }

    // Class used to store information about a machine
    class Machine
    {
        public int id { get; }
        public string name { get; }

        public int capacity { get; set; }
        public int cooldownTime { get; set; }

        public Machine(ParseResult pr)
        {
            this.id = pr.id;
            this.name = pr.text;
        }
        public Machine(ParseResult pr, int capacity, int cooldownTime)
        {
            this.id = pr.id;
            this.name = pr.text;
            this.capacity = capacity;
            this.cooldownTime = cooldownTime;
        }
    }

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
                SectionType currentSection = SectionType.None;
                List<Machine> machines = new List<Machine>();

                int previousIndex = 0;

                // Read line by line
                string buffer;
                while ((buffer = sr.ReadLine()) != null)
                {
                    buffer = buffer.Trim(); // Prepare for parsing
                    ParseResult pr = ParseLine(buffer);

                    switch (pr.type)
                    {
                        case LineType.Section:
                            // Reset index at new section
                            previousIndex = 0;

                            // Set current section
                            currentSection = GetSectionType(pr.text);

                            //Console.WriteLine();
                            //Console.WriteLine(pr.text);
                            break;

                        case LineType.Item:
                            if (currentSection == SectionType.Machines)
                            {
                                machines.Add(new Machine(pr));
                            }
                            // TODO: Add part list

                            //Console.WriteLine(pr.text);
                            break;

                        case LineType.ListItem:
                            // Handle index
                            if (pr.id != 0) previousIndex = pr.id;
                            else pr.id = previousIndex;

                            // Parse and add the list item to the correct section
                            if (currentSection == SectionType.Features)
                            {
                                int idx = pr.id - 1; // Since pr.id always starts from 1 in the file
                                (string, int) SpecResult = ParseSpecs(pr.text);

                                if (SpecResult.Item1 == "Capacity")
                                    machines[idx].capacity = SpecResult.Item2;

                                if (SpecResult.Item1 == "Cooldown time")
                                    machines[idx].cooldownTime = SpecResult.Item2;
                            }
                            break;

                        case LineType.Unknown:
                            Console.WriteLine("Line '{0}' is unknown.", buffer);
                            break;

                        default:
                            break;
                    }
                }

                // Print
                foreach (Machine machine in machines)
                {
                    Console.WriteLine("Name: {0}\nCapacity: {1}\nCooldown Time:{2}\n",
                        machine.name,
                        machine.capacity,
                        machine.cooldownTime);
                }
            }
        }

        static int strToInt(string str)
        {
            // Build dictionary to get capacity as an integer
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("one", 1);
            dict.Add("two", 2);
            dict.Add("three", 3);
            dict.Add("four", 4);
            dict.Add("five", 5);
            dict.Add("six", 6);
            dict.Add("seven", 7);
            dict.Add("eight", 8);
            dict.Add("nine", 9);

            if (dict.ContainsKey(str)) return dict[str];
            else return -1;
        }

        // Function to parse specifications
        static (string, int) ParseSpecs(string line)
        {
            string spec = "unknown";
            int number = -1;

            // Handle capacity
            if (line.StartsWith("Capacity"))
            {
                spec = "Capacity";
                string[] parts = line.Split(' ');
                number = strToInt(parts[1]);
            }

            // Handle cooldown time
            if (line.StartsWith("Cooldown time"))
            {
                spec = "Cooldown time";
                string[] parts = line.Split(' ');

                if (parts[2] == "none") number = 0;
                else int.TryParse(parts[2], out number);
            }

            return (spec, number);
        }

        static SectionType GetSectionType(string name)
        {
            switch (name)
            {
                case "Available machines":
                    return SectionType.Machines;

                case "Machine features":
                    return SectionType.Features;

                case "Part list":
                    return SectionType.Parts;

                case "Part operations":
                    return SectionType.PartOperations;

                default:
                    return SectionType.Unknown;
            }
        }

        /**
         * This function returns details about a line, as well as the processed text.
         * 
         * TODO: add more descriptionnnnnnnnnnnnnnnnnnnnnnnnnn
         */
        static ParseResult ParseLine(string line)
        {
            ParseResult output = new ParseResult();

            // Handle empty line
            if (line.Length == 0)
            {
                output.type = LineType.Empty;
                return output;
            }

            // Handle comments
            if (line.StartsWith('#'))
            {
                output.type = LineType.Comment;
                return output;
            }

            // Handle section
            if (line.EndsWith(":"))
            {
                output.type = LineType.Section;
                output.text = line[..^1];
                return output;
            }

            // i used > 0 because -1 means no . and index 0 is unknown line,
            // so it defaults to the return at the end of the function
            // Handle items
            int pos = line.IndexOf('.');
            if (pos > 0)
            {
                // Split line into index and text
                int index;
                if (int.TryParse(line.Substring(0, pos), out index))
                {
                    output.type = LineType.Item;
                    output.id = index;
                    output.text = line.Substring(pos + 1).Trim();
                    return output;
                }
            }

            // Handle list items with index
            pos = line.IndexOf(':');
            if (pos > 0)
            {
                // Split line into index and text
                int index;
                if (int.TryParse(line.Substring(0, pos), out index))
                {
                    output.type = LineType.ListItem;
                    output.id = index;
                    string temp = line.Substring(pos + 1).Trim();
                    output.text = temp[1..].Trim();
                    return output;
                }
            }

            // Handle list items without index
            if (line.StartsWith('-'))
            {
                output.type = LineType.ListItem;
                output.text = line[1..].Trim();
                return output;
            }

            return output;
        }
    }
}
