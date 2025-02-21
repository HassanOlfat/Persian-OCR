using IronOcr;

namespace Petrobar_OCR
{
    public static class IronOcrLib
    {
        public static string[]  Action(string filePath1 , string filePath2)
        {

            var ocr = new IronTesseract();
            ocr.Language = OcrLanguage.Persian;


            //using var memoryStream = new MemoryStream();
            //await file1.CopyToAsync(memoryStream);
            //memoryStream.Position = 0;
            //using var input = new OcrInput(memoryStream);

            OcrInput[] ocrInputs = new OcrInput[] { new OcrInput(filePath1), new OcrInput(filePath2) };


            OcrResult[] results;
            try
            {
                results = ocr.ReadMultithreaded(ocrInputs);
                //  result2 = ocr.Read(filePath2);
            }
            catch
            {
                results = new OcrResult[] { };
                //  result2 = null;
            }
            
            return new string[] { results[0]?.Text, results[1]?.Text };
           

        }
    }

    
}
