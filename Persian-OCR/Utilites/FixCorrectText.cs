using System.Text;

namespace Persian_OCR.Utilites
{
    public static class FixCorrectText
    {
        public static string Convert(string text)
        {
            Dictionary<string, string> corrections = new Dictionary<string, string>()
        {
            {"غلی", "علی"},
           
        };

            StringBuilder result = new StringBuilder(text);

            foreach (var item in corrections)
            {
                
                result.Replace(item.Key, item.Value);
            }

            return result.ToString();
        }
    }
}

