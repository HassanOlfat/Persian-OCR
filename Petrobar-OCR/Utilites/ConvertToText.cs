﻿using Petrobar_OCR.Enums;
using Petrobar_OCR.OCRMethods;

namespace Petrobar_OCR.Utilites
{
    public static class ConvertToText
    {
        public static string  Action(string filePath , CheckMethod checkMethod )
        {
            string result= string.Empty;

            switch (checkMethod)
            {
                case CheckMethod.Tesseract:
                    result = TesseractLib.Action(filePath);
                    break;
                case CheckMethod.IronOcr:
                    result = IronOcrLib.Action(filePath);
                    break;
                case CheckMethod.Easyocr:
                    break;
                case CheckMethod.TesseractAndIronOcr:
                    result = TesseractLib.Action(filePath);
                    result += " \n "+ IronOcrLib.Action(filePath);
                    break;
                case CheckMethod.All:
                    result = TesseractLib.Action(filePath);
                    result += " \n " + IronOcrLib.Action(filePath);
                    break;
                default:
                    break;
            }


            return result;
        }
    }
}
