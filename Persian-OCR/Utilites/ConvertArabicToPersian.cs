namespace Persian_OCR.Utilites
{
    public static class ConvertArabicToPersian
    {
        public static string Convert(string input)
        {
            return input
                .Replace('ي', 'ی').Replace('ك', 'ک').Replace('ۀ', 'ه').Replace('ة', 'ه');


        }
    }
}
