using IronOcr;

namespace Petrobar_OCR
{
    public static class IronOcrLib
    {
        public static string  Action(string filePath)
        {

            var ocr = new IronTesseract();
            ocr.Language = OcrLanguage.Persian;


            //using var memoryStream = new MemoryStream();
            //await file1.CopyToAsync(memoryStream);
            //memoryStream.Position = 0;
            //using var input = new OcrInput(memoryStream);

            OcrResult result;
            try
            {
                
                result = ocr.Read(filePath);
            }
            catch
            {
                result= null;
                
            }
            if (result != null)
            {
                return result.Text;
            }
            return string.Empty;

        }
    }

    
}
