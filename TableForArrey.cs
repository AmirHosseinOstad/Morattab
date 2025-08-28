namespace Morattab
{
    /// <summary>
    /// Drawing a table according to a predefined Array
    /// </summary>
    public class TableForArrey
    {
        /// <summary>
        /// Automatically adjusts spacing for better table display
        /// </summary>
        /// <param name="Input">One-dimensional array of values ​​of a row from a table</param>
        /// <param name="AddSpace">Add extra space (optional)</param>
        /// <returns>Returns a Array with spaces added to the items for better display</returns>
        public string[] FixSpacesAuto(string[] Input, int? AddSpace = 0)
        {
            //Find max length
            int RowLength = 0;

            foreach (string InputItem in Input)
            {
                if (InputItem.Length > RowLength)
                {
                    RowLength = InputItem.Length;
                }
            }

            //Continue function
            string[] Output = new string[Input.Length];

            for (int i = 0; i < Input.Length; i++)
            {
                string Spaces = "";
                for (int j = 0; j < RowLength - Input[i].Length; j++)
                {
                    Spaces = Spaces + " ";
                }
                Output[i] = Input[i] + Spaces;

                //optioanl
                if (AddSpace != null)
                {
                    Spaces = "";
                    for (int j = 0; j < AddSpace; j++)
                    {
                        Spaces = Spaces + " ";
                    }
                    Output[i] = Output[i] + Spaces;
                }
            }

            return Output;
        }
        /// <summary>
        /// Adjusts spacing for better table display
        /// </summary>
        /// <param name="Input">One-dimensional array of values ​​of a row from a table</param>
        /// <param name="RowLength">The length of the row to sort by</param>
        /// <returns>Returns a Array with spaces added to the items for better display</returns>
        public string[] FixSpaces(string[] Input, int RowLength)
        {
            string[] Output = new string[Input.Length];

            for (int i = 0; i < Input.Length; i++)
            {
                string Spaces = "";
                for (int j = 0; j < RowLength - Input[i].Length; j++)
                {
                    Spaces = Spaces + " ";
                }
                Output[i] = Input[i] + Spaces;
            }

            return Output;
        }
        /// <summary>
        /// Adjusts spacing for better table display
        /// </summary>
        /// <param name="Input">Two-dimensional array of values ​​of a row from a table</param>
        /// <param name="RowLength">An array of the length of the table rows, each indexed according to the input data array</param>
        /// <returns>Returns a Array with spaces added to the items for better display</returns>
        public string[] FixSpaces(string[] Input, int[] RowLength)
        {
            string[] Output = new string[Input.Length];

            for (int i = 0; i < Input.Length; i++)
            {
                string Spaces = "";
                for (int j = 0; j < RowLength[i] - Input[i].Length; j++)
                {
                    Spaces = Spaces + " ";
                }
                Output[i] = Input[i] + Spaces;
            }

            return Output;
        }
        /// <summary>
        /// Automatically adjusts spacing for better table display
        /// </summary>
        /// <param name="Input">One-dimensional array of values ​​of a table</param>
        /// <param name="AddSpace">Add extra space (optional)</param>
        /// <returns>Returns a two-dimensional Array with spaces added to the items for better display</returns>
        public string[,] FixSpacesAuto(string[,] Input, int? AddSpace = 0)
        {
            int Rows = Input.GetLength(0);
            int Columns = Input.GetLength(1);

            string[,] Output = new string[Rows, Columns];

            for (int i = 0; i < Columns; i++)
            {
                //Find max length in column
                int RowLength = 0;

                for (int j = 0; j < Rows; j++)
                {
                    if (Input[j,i].Length > RowLength)
                    {
                        RowLength = Input[j, i].Length;
                    }
                }

                for (int j = 0; j < Rows; j++)
                {
                    string Spaces = "";
                    for (int k = 0; k < RowLength - Input[j,i].Length; k++)
                    {
                        Spaces = Spaces + " ";
                    }
                    Output[j,i] = Input[j,i] + Spaces;

                    //optioanl
                    if (AddSpace != null)
                    {
                        Spaces = "";
                        for (int k = 0; k < AddSpace; k++)
                        {
                            Spaces = Spaces + " ";
                        }
                        Output[j,i] = Output[j,i] + Spaces;
                    }
                }
            }

            return Output;
        }
        /// <summary>
        /// Adjusts spacing for better table display
        /// </summary>
        /// <param name="Input">Two-dimensional array of values ​​of a row from a table</param>
        /// <param name="RowLength">The length of the row to sort by</param>
        /// <returns>Returns a two-dimensional Array with spaces added to the items for better display</returns>
        public string[,] FixSpaces(string[,] Input, int RowLength)
        {
            int Rows = Input.GetLength(0);
            int Columns = Input.GetLength(1);

            string[,] Output = new string[Rows, Columns];

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    string Spaces = "";
                    for (int k = 0; k < RowLength - Input[j, i].Length; k++)
                    {
                        Spaces = Spaces + " ";
                    }
                    Output[j, i] = Input[j, i] + Spaces;
                }
            }

            return Output;
        }
        /// <summary>
        /// Adjusts spacing for better table display
        /// </summary>
        /// <param name="Input">Two-dimensional array of values ​​of a row from a table</param>
        /// <param name="RowLength">An array of the length of the table rows, each indexed according to the input data array</param>
        /// <returns>Returns a two-dimensional Array with spaces added to the items for better display</returns>
        public string[,] FixSpaces(string[,] Input, int[] RowLength)
        {
            int Rows = Input.GetLength(0);
            int Columns = Input.GetLength(1);

            string[,] Output = new string[Rows, Columns];

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    string Spaces = "";
                    for (int k = 0; k < RowLength[i] - Input[j, i].Length; k++)
                    {
                        Spaces = Spaces + " ";
                    }
                    Output[j, i] = Input[j, i] + Spaces;
                }
            }

            return Output;
        }
        /// <summary>
        /// Automatically sorts the table according to the data Array and prints it to the console
        /// </summary>
        /// <param name="Input">Two-dimensional Array of input data</param>
        /// <param name="RowsSeparator">Show or hide table row separator line</param>
        /// <param name="SeparatorLetter">Column separator character</param>
        /// <param name="RowSeparatorLetter">Row separator character</param>
        public void WriteAuto(string[,] Input, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')
        {
            int Rows = Input.GetLength(0);
            int Columns = Input.GetLength(1);

            string[,] Output = new string[Rows, Columns];

            for (int i = 0; i < Columns; i++)
            {
                //Find max length in column
                int RowLength = 0;

                for (int j = 0; j < Rows; j++)
                {
                    if (Input[j, i].Length > RowLength)
                    {
                        RowLength = Input[j, i].Length;
                    }
                }

                for (int j = 0; j < Rows; j++)
                {
                    string Spaces = "";
                    for (int k = 0; k < RowLength - Input[j, i].Length; k++)
                    {
                        Spaces = Spaces + " ";
                    }
                    Output[j, i] = Input[j, i] + Spaces;
                }
            }

            for (int i = 0; i < Output.GetLength(0); i++)
            {
                string Row = "";
                for (int j = 0;j < Output.GetLength(1); j++)
                {
                    Row += Output[i, j] + $" {SeparatorLetter} ";
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
        /// <summary>
        /// Sorts the table according to the data Array and prints it to the console
        /// </summary>
        /// <param name="Input">Two-dimensional Array of input data</param>
        /// <param name="RowLength">The length of each field in the table that is being sorted by</param>
        /// <param name="RowsSeparator">Show or hide table row separator line</param>
        /// <param name="SeparatorLetter">Column separator character</param>
        /// <param name="RowSeparatorLetter">Row separator character</param>
        public void Write(string[,] Input, int RowLength, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')
        {
            int Rows = Input.GetLength(0);
            int Columns = Input.GetLength(1);

            string[,] Output = new string[Rows, Columns];

            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    string Spaces = "";
                    for (int k = 0; k < RowLength - Input[j, i].Length; k++)
                    {
                        Spaces = Spaces + " ";
                    }
                    Output[j, i] = Input[j, i] + Spaces;
                }
            }

            for (int i = 0; i < Output.GetLength(0); i++)
            {
                string Row = "";
                for (int j = 0; j < Output.GetLength(1); j++)
                {
                    Row += Output[i, j] + $" {SeparatorLetter} ";
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
