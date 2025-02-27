using IronOcr;
using Persian_OCR.Utilites;

namespace Persian_OCR.OCRMethods
{
    public static class IronOcrLib
    {
        public static string Action(string filePath)
        {

            var ocr = new IronTesseract();
            ocr.Language = OcrLanguage.Persian;


            //using var memoryStream = new MemoryStream();
            //await file1.CopyToAsync(memoryStream);
            //memoryStream.Position = 0;
            //using var input = new OcrInput(memoryStream);

            OcrResult ocrresult;
            try
            {

                ocrresult = ocr.Read(filePath);
            }
            catch
            {
                ocrresult = null;

            }
            if (ocrresult != null)
            {
             
                return ocrresult.Text;
            }
            return string.Empty;

        }
    }


}
