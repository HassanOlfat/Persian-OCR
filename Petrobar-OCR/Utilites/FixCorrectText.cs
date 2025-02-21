using System.Text;

namespace Petrobar_OCR.Utilites
{
    public static class FixCorrectText
    {
        public static string Convert(string text)
        {
            Dictionary<string, string> corrections = new Dictionary<string, string>()
        {
            {"اییمانکار", "پیمانکار"},
            {"امقصد", "مقصد"},
            {"اشماره", "شماره"},
            {"اکد", "کد"},
            {"نوزین", "توزین"},
            {"مبداء", "مبدأ"},
            {"قوق الذکر", "فوق‌الذکر"},
            {"پیشگامان داده افزار اسپادانا", "پیشگامان داده‌افزار اسپادانا"}
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

