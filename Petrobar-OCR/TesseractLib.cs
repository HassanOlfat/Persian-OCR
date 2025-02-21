using Tesseract;

namespace Petrobar_OCR
{
    public static class  TesseractLib
    {
        public static string Action(string filePath1, string filePath2)
        {
            string resultText;



            var ocrEngine = new TesseractEngine(@"C:\Program Files\Tesseract-OCR\tessdata", "fas+eng", EngineMode.LstmOnly);
            ocrEngine.SetVariable("tessedit_pageseg_mode", "6");

            // ocrEngine.SetVariable("tessedit_pageseg_mode", "1"); 
            // ocrEngine.SetVariable("tessedit_char_whitelist", "۰۱۲۳۴۵۶۷۸۹0123456789");

            using (var img = Pix.LoadFromFile(filePath1))
            {
              //  Pix imageToProcess = img.Depth == 32 ? img : img.ConvertTo32();

                //   using (var binary = img.ConvertRGBToGray(100, 200, 255))
                // {
                var result = ocrEngine.Process(img);
                    resultText= result.GetText();
               // }
            }

        


            return ConvertPersianArabicNumbersToEnglish(resultText);


        }

        public static string ConvertPersianArabicNumbersToEnglish(string input)
        {
            return input
                .Replace('۰', '0').Replace('۱', '1').Replace('۲', '2').Replace('۳', '3')
                .Replace('۴', '4').Replace('۵', '5').Replace('۶', '6').Replace('۷', '7')
                .Replace('۸', '8').Replace('۹', '9')
                .Replace('٠', '0').Replace('١', '1').Replace('٢', '2').Replace('٣', '3')
                .Replace('٤', '4').Replace('٥', '5').Replace('٦', '6').Replace('٧', '7')
                .Replace('٨', '8').Replace('٩', '9');
        }

    }
}
