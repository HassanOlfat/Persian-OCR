namespace Persian_OCR.Utilites
{
    public static class CityNameCorrector
    {
       
        private static readonly List<string> CityNames = new List<string>
    {
        // استان‌ها
        "آذربایجان شرقی", "آذربایجان غربی", "اردبیل", "اصفهان", "البرز", "ایلام", "بوشهر", "تهران",
        "چهارمحال و بختیاری", "خراسان جنوبی", "خراسان رضوی", "خراسان شمالی", "خوزستان", "زنجان", "سمنان",
        "سیستان و بلوچستان", "فارس", "قزوین", "قم", "کردستان", "کرمان", "کرمانشاه", "کهگیلویه و بویراحمد",
        "گلستان", "گیلان", "لرستان", "مازندران", "مرکزی", "هرمزگان", "همدان", "یزد",
        
        // مراکز استان‌ها
        "تبریز", "ارومیه", "اردبیل", "اصفهان", "کرج", "ایلام", "بوشهر", "تهران", "شهرکرد", "بیرجند",
        "مشهد", "بجنورد", "اهواز", "زنجان", "سمنان", "زاهدان", "شیراز", "قزوین", "قم", "سنندج", "کرمان",
        "کرمانشاه", "یاسوج", "گرگان", "رشت", "خرم‌آباد", "ساری", "اراک", "بندرعباس", "همدان", "یزد",

        "آبادان", "بندرعباس", "کرمانشاه", "لاوان", "گچساران", "خرمشهر", "سرخس", "چابهار",
        "ماهشهر", "عسلویه", "بندر امام خمینی", "مرودشت", "مهاباد", "کازرون", "فیروزآباد", "میاندوآب",
        "دزفول", "لامرد", "جم", "بجنورد"
    };

        // متد تصحیح نام شهر
        public static string Convert(string input)
        {
            input = NormalizeText(input); // نرمال‌سازی اولیه
            var bestMatch = CityNames
                .Select(city => new { City = city, Distance = LevenshteinDistance(input, city) })
                .OrderBy(x => x.Distance)
                .FirstOrDefault();

            return (bestMatch != null && bestMatch.Distance <= 2) ? bestMatch.City : input; // فقط اگر اختلاف کم باشد اصلاح کن
        }

        // حذف فاصله‌های اضافی و نرمال‌سازی متن
        private static string NormalizeText(string text)
        {
            return text.Replace("  ", "").Trim(); // حذف فاصله‌ها و فضاهای اضافی
        }

        // محاسبه فاصله لوین‌اشتاین برای مقایسه شباهت رشته‌ها
        private static int LevenshteinDistance(string s1, string s2)
        {
            int lenS1 = s1.Length, lenS2 = s2.Length;
            var dp = new int[lenS1 + 1, lenS2 + 1];

            for (int i = 0; i <= lenS1; i++)
                for (int j = 0; j <= lenS2; j++)
                    if (i == 0) dp[i, j] = j;
                    else if (j == 0) dp[i, j] = i;
                    else
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                                            dp[i - 1, j - 1] + (s1[i - 1] == s2[j - 1] ? 0 : 1));

            return dp[lenS1, lenS2];
        }
    }
}
