using Tesseract;
using Petrobar_OCR.Utilites;
namespace Petrobar_OCR
{
    public static class  TesseractLib
    {
        public static string Action(string filePath)
        {

            var ocrEngine = new TesseractEngine(@"C:\Program Files\Tesseract-OCR\tessdata", "fas+eng", EngineMode.LstmOnly);
            ocrEngine.SetVariable("tessedit_pageseg_mode", "6");

            using (var img = Pix.LoadFromFile(filePath))
            {
                return ConvertPersianArabicNumbersToEnglish.Convert(ocrEngine.Process(img).GetText());
            }

        }

      

    }
}
