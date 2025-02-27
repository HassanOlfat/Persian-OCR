using System.Text.RegularExpressions;

namespace Persian_OCR.Utilites
{
    public static class LicensePlateCorrector
    {
        private static readonly Regex PlatePattern = new Regex(@"(\d{2})\s*([بپتجچحخدذرزسشصطعفقکگلمنوهی])\s*(\d{3})\s*ایران\s*(\d{2})", RegexOptions.Compiled);

        public static string Convert(string input)
        {
            input = NormalizeText(input); 


            Dictionary<char, char> replacements = new Dictionary<char, char>
        {
            {'O', '0'}, {'o', '0'}, {'I', '1'}, {'l', '1'}, {'Z', '2'}, {'S', '5'}, {'B', '8'}
        };

            input = new string(input.Select(c => replacements.ContainsKey(c) ? replacements[c] : c).ToArray());


            Match match = PlatePattern.Match(input);
            if (match.Success)
            {
                return $"{match.Groups[1].Value} {match.Groups[2].Value} {match.Groups[3].Value} ایران {match.Groups[4].Value}";
            }

            return input; 
        }

        
        private static string NormalizeText(string text)
        {
            return Regex.Replace(text, @"\s+", ""); 
        }

       
    }
}
