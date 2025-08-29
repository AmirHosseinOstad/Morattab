namespace Morattab
{
    /// <summary>
    /// Drawing a table according to a predefined Array
    /// </summary>
    public class TableForArrey
    {
        /// <summary>
        /// Adjusts spacing for better table display
        /// </summary>
        /// <param name="Input">One-dimensional array of values ​​of a row from a table</param>
        /// <param name="AddSpace">Add extra space (optional)</param>
        /// <returns>Returns a Array with spaces added to the items for better display</returns>
        public string[] FixSpaces(string[] Input, int RowLength = 0, int? AddSpace = 0)
        {
            if (RowLength == 0)
            {
                foreach (string InputItem in Input)
                {
                    if (InputItem.Length > RowLength)
                    {
                        RowLength = InputItem.Length;
                    }
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
        /// Adjusts spacing for better table display
        /// </summary>
        /// <param name="Input">One-dimensional array of values ​​of a table</param>
        /// <param name="RowLengthInput">The row length to which the spacing is adjusted (defaults to 0 for automatic mode)</param>
        /// <param name="AddSpace">Add extra space (optional)</param>
        /// <returns>Returns a two-dimensional Array with spaces added to the items for better display</returns>
        public string[,] FixSpaces(string[,] Input, int RowLengthInput = 0, int? AddSpace = 0)
        {
            int Rows = Input.GetLength(0);
            int Columns = Input.GetLength(1);

            string[,] Output = new string[Rows, Columns];

            for (int i = 0; i < Columns; i++)
            {
                int RowLength = RowLengthInput;
                if (RowLength == 0)
                {
                    //Find max length in column
                    RowLength = 0;

                    for (int j = 0; j < Rows; j++)
                    {
                        if (Input[j, i].Length > RowLength)
                        {
                            RowLength = Input[j, i].Length;
                        }
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
        /// Sorts the table according to the data Array and prints it to the console
        /// </summary>
        /// <param name="InputArray">Two-dimensional Array of input data</param>
        /// <param name="RowLength">The row length to which the spacing is adjusted (defaults to 0 for automatic mode)</param>
        /// <param name="RowsSeparator">Show or hide table row separator line</param>
        /// <param name="SeparatorLetter">Column separator character</param>
        /// <param name="RowSeparatorLetter">Row separator character</param>
        public void Write(string[,] InputArray, int RowLength = 0, bool? RowsSeparator = false, char? SeparatorLetter = '|', char? RowSeparatorLetter = '-')
        {
            string[,] Input = FixSpaces(InputArray, RowLength);


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
    }
}
