namespace ClaimTheSquareFullStack.DbModels
{
    public class TextObjectInt
    {
        public int Index { get; set; }
        public string Text { get; set; }
        public int ForeColor { get; set; }
        public int BackColor { get; set; }

        public TextObjectInt()
        {
        }

        public TextObjectInt(int index, string text, string foreColor, string backColor)
        : this(index, text, (int)Enum.Parse<Color>(foreColor), (int)Enum.Parse<Color>(backColor))
        {
        }

        public TextObjectInt(int index, string text, int foreColor, int backColor)
        {
            Index = index;
            Text = text;
            ForeColor = foreColor;
            BackColor = backColor;
        }


    }
}
