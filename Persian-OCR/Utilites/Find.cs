
namespace Persian_OCR.Utilites
{
    public class Find
    {
        public static Dictionary<string, bool> Action(string[] strings, string mainText)
        {

            var result = new Dictionary<string, bool>();
            foreach (string s in strings)
            {
                if (mainText.Contains(s))  result[s] = true; else result[s] = false;
                
            }
            return result;

        }
    }
}
