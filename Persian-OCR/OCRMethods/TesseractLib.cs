using Tesseract;
using Persian_OCR.Utilites;
namespace Persian_OCR.OCRMethods
{
    public static class TesseractLib
    {
        public static string Action(string filePath)
        {

            var ocrEngine = new TesseractEngine(@"C:\Program Files\Tesseract-OCR\tessdata", "fas+eng", EngineMode.LstmOnly);
            ocrEngine.SetVariable("tessedit_pageseg_mode", "6");

            using (var img = Pix.LoadFromFile(filePath))
            {
               
                return ocrEngine.Process(img).GetText();
            }

        }



    }
}
