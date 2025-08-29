using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Morattab
{
    /// <summary>
    /// Drawing a table according to a predefined list
    /// </summary>
    public class TableForList
    {
        /// <summary>
        /// Adjusts spacing for better table display
        /// </summary>
        /// <typeparam name="T">List type (may be class)</typeparam>
        /// <param name="Input">List of input data</param>
        /// <param name="RowLengthInput">The row length to which the spacing is adjusted (defaults to 0 for automatic mode)</param>
        /// <param name="AddSpace">Add extra space (optional)</param>
        /// <returns>Returns a Array with spaces added to the items for better display</returns>
        public string[,] FixSpaces<T>(List<T> Input, int RowLengthInput = 0, int? AddSpace = 0)
        {
            PropertyInfo[] Props = typeof(T).GetProperties();
            string[,] Output = new string[Input.Count, Props.Length];

            for (int i = 0; i < Props.Length; i++)
            {
                int RowLength = RowLengthInput;
                //Find max length in column
                if (RowLength == 0)
                {
                    for (int j = 0; j < Input.Count; j++)
                    {
                        int RecordLength = Props[i].GetValue(Input[j]).ToString().Length;

                        if (RecordLength > RowLength)
                        {
                            RowLength = RecordLength;
                        }
                    }

                    if (Props[i].Name.Length > RowLength)
                    {
                        RowLength = Props[i].Name.Length;
                    }
                }


                for (int j = 0; j < Input.Count; j++)
                {
                    int RecordLength = Props[i].GetValue(Input[j]).ToString().Length;

                    string Spaces = "";
                    for (int k = 0; k < RowLength - RecordLength; k++)
                    {
                        Spaces = Spaces + " ";
                    }

                    Output[j, i] = Props[i].GetValue(Input[j]) + Spaces;

                    //optioanl
                    if (AddSpace != null)
                    {
                        Spaces = "";
                        for (int k = 0; k < AddSpace; k++)
                        {
                            Spaces = Spaces + " ";
                        }
                        Output[j, i] = Output[j, i] + Spaces;
                    }
                }
            }

            return Output;
        }

        /// <summary>
        /// Sorts the table according to the data list and prints it to the console
        /// </summary>
        /// <typeparam name="T">List type (may be class)</typeparam>
        /// <param name="InputList">List of input data</param>
        /// <param name="RowLength">The row length to which the spacing is adjusted (defaults to 0 for automatic mode)</param>
        /// <param name="ShowPropsSubject">Show or hide list column headings</param>
        /// <param name="RowsSeparator">Show or hide table row separator line</param>
        /// <param name="SeparatorLetter">Column separator character</param>
        /// <param name="RowSeparatorLetter">Row separator character</param>
        public void Write<T>(List<T> InputList, int RowLength = 0,bool? ShowPropsSubject = true, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')
        {
            //show props subject
            if ((bool)ShowPropsSubject)
            {
                var SubjectsArray = GetPropsSubject(InputList, RowLength);
                string Row = "";
                for (int j = 0; j < SubjectsArray.Length; j++)
                {
                    Row += SubjectsArray[j] + $" {SeparatorLetter} ";
                }
                Console.WriteLine(Row);

                if ((bool)RowsSeparator)
                {
                    for (int k = 0; k < Row.Length; k++)
                    {
                        Console.Write(RowSeparatorLetter);
                    }
                    Console.WriteLine();
                }
            }

            string[,] Input = FixSpaces(InputList, RowLength);


            for (int i = 0; i < Input.GetLength(0); i++)
            {
                string Row = "";
                for (int j = 0; j < Input.GetLength(1); j++)
                {
                    Row += Input[i, j] + $" {SeparatorLetter} ";
                }
                Console.WriteLine(Row);

                if ((bool)RowsSeparator)
                {
                    for (int k = 0; k < Row.Length; k++)
                    {
                        Console.Write(RowSeparatorLetter);
                    }
                    Console.WriteLine();
                }
            }
        }

        private int[] GetMaxLength<T>(List<T> Input)
        {
            PropertyInfo[] Props = typeof(T).GetProperties();



            int[] Output = new int[Props.Length];

            for (int i = 0; i < Props.Length; i++)
            {            
                //Find max length in column
                int RowLength = 0;


                for (int j = 0; j < Input.Count; j++)
                {
                    int RecordLength = Props[i].GetValue(Input[j]).ToString().Length;

                    if (RecordLength > RowLength)
                    {
                        RowLength = RecordLength;
                    }
                }

                if (Props[i].Name.Length > RowLength)
                {
                    RowLength = Props[i].Name.Length;
                }

                Output[i] = RowLength;
            }

            return Output;
        }
        private string[] GetPropsSubject<T>(List<T> Input, int RowLength = 0)
        {
            PropertyInfo[] Props = typeof(T).GetProperties();
            int[] inputLength = GetMaxLength(Input);

            //if RowLength == 0 Auto; else
            if (RowLength != 0)
            {
                for (int i = 0; inputLength.Length > i; i++)
                {
                    inputLength[i] = RowLength;
                }
            }

            string[] Output = new string[Props.Length];

            for (int i = 0; i < Props.Length; i++)
            {
                string Spaces = "";

                for (int j = 0;j < inputLength[i] - Props[i].Name.Length; j++)
                {
                    Spaces += " ";
                }

                Output[i] = Props[i].Name + Spaces;
            }

            return Output;
        }

    }
}
