using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace Problem_1
{
    public class FileIOHandler
    {
        private readonly string filename;
        private readonly string filetype;

        public FileIOHandler(string filename, string filetype)
        {
            this.filename = filename;
            this.filetype = filetype;
        }

        public List<string> Read()
        {
            // Create the list of string
            List<string> lines = new List<string>();
            switch (filetype)
            {
                case "csv":
                    // I USED BRACKETS SO I CAN USE reader IN BOTH CASES
                    {
                        StreamReader reader = new StreamReader(filename);
                        // Add lines to the list
                        while (!reader.EndOfStream)
                        {
                            lines.Add(reader.ReadLine());
                        }
                    }
                    break;


                case "xml":
                    {
                        XmlTextReader reader = new XmlTextReader(filename);
                        // Read until there are no more records
                        while (reader.Read())
                        {
                            // Inspect the nodes
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element: // The node is an element
                                    Console.Write("<" + reader.Name);

                                    while (reader.MoveToNextAttribute()) // Read the attributes
                                        Console.Write(" " + reader.Name + "='" + reader.Value + "'");

                                    Console.Write(">");
                                    Console.WriteLine(">");
                                    break;

                                case XmlNodeType.Text: // Display the text in each element
                                    Console.WriteLine(reader.Value);
                                    break;

                                case XmlNodeType.EndElement: // Display the end of the element.
                                    Console.Write("</" + reader.Name);
                                    Console.WriteLine(">");
                                    break;
                            }
                        }
                    }
                    break;
            }

            return lines;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-> CSV:");
            FileIOHandler testCSV = new FileIOHandler(@"C:\Users\tudor\Desktop\test.csv", "csv");
            List<string> lines = testCSV.Read();
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\n-> XML:");
            FileIOHandler testXML = new FileIOHandler(@"C:\Users\tudor\Desktop\test.xml", "xml");
            testXML.Read();
        }
    }
}
