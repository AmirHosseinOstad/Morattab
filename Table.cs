using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morattab
{
    /// <summary>
    /// Defining a table, adding rows, and displaying them
    /// </summary>
    public class Table
    {
        /// <summary>
        /// A variable that indicates the length of all columns. (Suggested: 0)
        /// </summary>
        public int RowLength = 0;

        /// <summary>
        /// Should there be a separator between rows?
        /// </summary>
        public bool? RowsSeparator = false;

        /// <summary>
        /// Column separator character
        /// </summary>
        public char? SeparatorLetter = '|';

        /// <summary>
        /// Row separator character
        /// </summary>
        public char? RowSeparatorLetter = '-';

        private List<string[]> TableList = new List<string[]>();

        /// <summary>
        /// Adding rows to a table, each row is a string array and each array index is a column of the table
        /// </summary>
        /// <param name="Record">Array of columns in a row of a table</param>
        public void Add(string[] Record)
        {
            TableList.Add(Record);
        }

        /// <summary>
        /// Sort and print the table according to the added values
        /// </summary>
        public void Write()
        {
            //Find max length
            int[] MaxLength = new int[TableList.Last().Length];

            if (RowLength != 0)
            {
                for (int i = 0; i < MaxLength.Length; i++)
                {
                    MaxLength[i] = RowLength;
                }
            }
            else
            {
                foreach (var item in TableList)
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (MaxLength[i] == 0)
                        {
                            MaxLength[i] = item[i].Length;
                        }
                        else
                        {
                            if (item[i].Length > MaxLength[i])
                            {
                                MaxLength[i] = item[i].Length;
                            }
                        }
                    }
                }
            }


            foreach (var item in TableList)
            {
                string Row = "";
                for (int i = 0; i < item.Length; i++)
                {
                    string Spaces = "";
                    for (int j = 0; j < MaxLength[i] - item[i].Length; j++)
                    {
                        Spaces += " ";
                    }

                    Row += item[i] + Spaces + $" {SeparatorLetter} ";
                }

                Console.WriteLine(Row);

                if ((bool)RowsSeparator)
                {
                    for(int i = 0;i < Row.Length; i++)
                    {
                        Console.Write(RowSeparatorLetter);
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Sort and print the table according to the added values
        /// </summary>
        /// <param name="RowLength">The row length Arrey to which the spacing is adjusted (defaults to 0 for automatic mode)</param>
        public void Write(int[] RowLength)
        {
            //Find max length
            int[] MaxLength = new int[TableList.Last().Length];

            if (RowLength != null && RowLength.Length == TableList.Last().Length)
            {
                for (int i = 0; i < MaxLength.Length; i++)
                {
                    MaxLength[i] = RowLength[i];
                }
            }
            else
            {
                foreach (var item in TableList)
                {
                    for (int i = 0; i < item.Length; i++)
                    {
                        if (MaxLength[i] == 0)
                        {
                            MaxLength[i] = item[i].Length;
                        }
                        else
                        {
                            if (item[i].Length > MaxLength[i])
                            {
                                MaxLength[i] = item[i].Length;
                            }
                        }
                    }
                }
            }


            foreach (var item in TableList)
            {
                string Row = "";
                for (int i = 0; i < item.Length; i++)
                {
                    string Spaces = "";
                    for (int j = 0; j < MaxLength[i] - item[i].Length; j++)
                    {
                        Spaces += " ";
                    }

                    Row += item[i] + Spaces + $" {SeparatorLetter} ";
                }

                Console.WriteLine(Row);

                if ((bool)RowsSeparator)
                {
                    for (int i = 0; i < Row.Length; i++)
                    {
                        Console.Write(RowSeparatorLetter);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
