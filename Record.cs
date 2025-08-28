namespace Morattab
{
    /// <summary>
    /// Class for sorting table field records according to the requested number
    /// </summary>
    public class Record
    {
        /// <summary>
        /// Sort fields by fixed length by adding required spaces
        /// </summary>
        /// <param name="Input">The value of the desired field record</param>
        /// <param name="RowLength">The length of the request according to which the intervals are adjusted</param>
        /// <returns>Field value with required spacing</returns>
        public string FixSpaces(string Input, int RowLength)
        {
            string Output = "";

            if (Input.Length <= RowLength)
            {
                string Spaces = "";
                for (int i = 0; i < RowLength - Input.Length; i++)
                {
                    Spaces = Spaces + " ";
                }
                Output = Input + Spaces;
            }
            else
            {
                Output = Input.Substring(0, RowLength);
            }

            return Output;
        }
    }
}
