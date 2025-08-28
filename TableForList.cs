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
        /// Automatically adjusts spacing for better table display
        /// </summary>
        /// <typeparam name="T">List type (may be class)</typeparam>
        /// <param name="Input">List of input data</param>
        /// <param name="AddSpace">Add extra space (optional)</param>
        /// <returns>Returns a list with spaces added to the items for better display</returns>
        public List<T> FixSpacesAuto<T>(List<T> Input, int? AddSpace = 0)
        {
            PropertyInfo[] Props = typeof(T).GetProperties();
            List<T> Output = new List<T>();

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


                for (int j = 0; j < Input.Count; j++)
                {
                    int RecordLength = Props[i].GetValue(Input[j]).ToString().Length;

                    string Spaces = "";
                    for (int k = 0; k < RowLength - RecordLength; k++)
                    {
                        Spaces = Spaces + " ";
                    }
                    Props[i].SetValue(Output[j], Props[i].GetValue(Input[j]) + Spaces);

                    //optioanl
                    if (AddSpace != null)
                    {
                        Spaces = "";
                        for (int k = 0; k < AddSpace; k++)
                        {
                            Spaces = Spaces + " ";
                        }
                        Props[i].SetValue(Output[j], Props[i].GetValue(Output[j]) + Spaces);
                    }
                }
            }

            return Output;
        }

        /// <summary>
        /// Automatically sorts the table according to the data list and prints it to the console
        /// </summary>
        /// <typeparam name="T">List type (may be class)</typeparam>
        /// <param name="Input">List of input data</param>
        /// <param name="ShowPropsSubject">Show or hide list column headings</param>
        /// <param name="RowsSeparator">Show or hide table row separator line</param>
        /// <param name="SeparatorLetter">Column separator character</param>
        /// <param name="RowSeparatorLetter">Row separator character</param>
        public void WriteAuto<T>(List<T> Input, bool? ShowPropsSubject = true, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')
        {
            PropertyInfo[] Props = typeof(T).GetProperties();
            var Output = Input;

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

                for (int j = 0; j < Input.Count; j++)
                {
                    int RecordLength = Props[i].GetValue(Input[j]).ToString().Length;

                    string Spaces = "";
                    for (int k = 0; k < RowLength - RecordLength; k++)
                    {
                        Spaces = Spaces + " ";
                    }
                    Props[i].SetValue(Output[j], Props[i].GetValue(Input[j]) + Spaces);
                }
            }

            //For Show Props Subject
            string PropsSubject = "";

            for (int i = 0; i < Props.Length; i++)
            {
                //Find max length in column
                int RowLength = 0;
                for (int j = 0; j < Input.Count; j++)
                {
                    int RecordLengthSpacces = Props[i].GetValue(Input[j]).ToString().Length;

                    if (RecordLengthSpacces > RowLength)
                    {
                        RowLength = RecordLengthSpacces;
                    }
                }

                int RecordLength = Props[i].Name.Length;

                string Spaces = "";
                for (int k = 0; k < RowLength - RecordLength; k++)
                {
                    Spaces = Spaces + " ";
                }

                PropsSubject += Props[i].Name + Spaces + $" {SeparatorLetter} ";
            }

            Console.WriteLine(PropsSubject);

            PropertyInfo[] OutputProps = typeof(T).GetProperties();

            if ((bool)RowsSeparator)
            {
                for (int j = 0; j < PropsSubject.Length; j++)
                {
                    Console.Write(RowSeparatorLetter);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < Output.Count; i++)
            {
                string Row = "";

                for (int j = 0; j < OutputProps.Length; j++)
                {
                    Row += OutputProps[j].GetValue(Output[i]) + $" {SeparatorLetter} ";
                }
                Console.WriteLine(Row);

                if ((bool)RowsSeparator)
                {
                    for (int j = 0;j < Row.Length; j++)
                    {
                        Console.Write(RowSeparatorLetter);
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Sorts the table according to the data list and prints it to the console
        /// </summary>
        /// <typeparam name="T">List type (may be class)</typeparam>
        /// <param name="Input">List of input data</param>
        /// <param name="RowLength">The length of each field in the table that is being sorted by</param>
        /// <param name="ShowPropsSubject">Show or hide list column headings</param>
        /// <param name="RowsSeparator">Show or hide table row separator line</param>
        /// <param name="SeparatorLetter">Column separator character</param>
        /// <param name="RowSeparatorLetter">Row separator character</param>
        public void Write<T>(List<T> Input, int RowLength, bool? ShowPropsSubject = true, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')
        {
            PropertyInfo[] Props = typeof(T).GetProperties();
            var Output = Input;

            for (int i = 0; i < Props.Length; i++)
            {
                for (int j = 0; j < Input.Count; j++)
                {
                    int RecordLength = Props[i].GetValue(Input[j]).ToString().Length;

                    string Spaces = "";
                    for (int k = 0; k < RowLength - RecordLength; k++)
                    {
                        Spaces = Spaces + " ";
                    }
                    Props[i].SetValue(Output[j], Props[i].GetValue(Input[j]) + Spaces);
                }
            }

            //For Show Props Subject
            string PropsSubject = "";
            for (int i = 0; i < Props.Length; i++)
            {
                int RecordLength = Props[i].Name.Length;

                string Spaces = "";
                for (int k = 0; k < RowLength - RecordLength; k++)
                {
                    Spaces = Spaces + " ";
                }

                PropsSubject += Props[i].Name + Spaces + $" {SeparatorLetter} ";
            }

            Console.WriteLine(PropsSubject);

            PropertyInfo[] OutputProps = typeof(T).GetProperties();

            if ((bool)RowsSeparator)
            {
                for (int j = 0; j < PropsSubject.Length; j++)
                {
                    Console.Write(RowSeparatorLetter);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < Output.Count; i++)
            {
                string Row = "";

                for (int j = 0; j < OutputProps.Length; j++)
                {
                    Row += OutputProps[j].GetValue(Output[i]) + $" {SeparatorLetter} ";
                }
                Console.WriteLine(Row);

                if ((bool)RowsSeparator)
                {
                    for (int j = 0; j < Row.Length; j++)
                    {
                        Console.Write(RowSeparatorLetter);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
