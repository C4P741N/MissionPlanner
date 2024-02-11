using Spice_n_Booster_Gobler.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spice_n_Booster_Gobler.Map
{
    internal class ImportMap(IGlobal_Vals _globalVals) : IImportMap
    {
        //private string filePath = "C:\\Users\\danco\\OneDrive\\Documents\\map_coordinates.txt";
        private readonly int maxDimension = _globalVals.Max_Dimension;
        private string filePath = string.Empty;
        public char[][] GetMap()
        {
            int rows = maxDimension;
            int cols = maxDimension;
            char[][] charArray;

            //if (charArray[0] != null) return charArray;

            while (true)
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    Console.Write("Add file path e.g 'C:\\map_coordinates.txt' : ");
                    filePath = Console.ReadLine() ?? "";
                }

                charArray = new char[rows][];

                try
                {
                    using StreamReader reader = new (filePath);
                    for (int i = 0; i < rows; i++)
                    {
                        string line = reader.ReadLine();
                        if (line != null)
                        {
                            // Truncate the line if it's longer than the number of columns
                            if (line.Length > cols)
                                line = line.Substring(0, cols);

                            // Initialize the inner array
                            charArray[i] = new char[line.Length];

                            // Map each character to the char array
                            for (int j = 0; j < line.Length; j++)
                            {
                                charArray[i][j] = line[j];
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nothing found");
                            continue;
                        }
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.Write($"Error {ex.Message}");
                }
            }

            ////Print array
            //for (int i = 0; i < rows; i++)
            //{
            //    for (int j = 0; j < cols; j++)
            //    {
            //        Console.Write(charArray[i][j]);
            //    }
            //    Console.WriteLine();
            //}

            return charArray;
        }
    }
}
