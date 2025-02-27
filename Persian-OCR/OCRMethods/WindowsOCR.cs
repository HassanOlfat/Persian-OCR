//using Windows.Graphics.Imaging;
//using Windows.Media.Ocr;
//using Windows.Storage.Streams;

//namespace Persian_OCR
//{
//    public static class WindowsOCR
//    {
//        public static async Task<IResult> Action(string filePath1, string filePath2) {
           

//            try
//            {
//                var file = await Windows.Storage.StorageFile.GetFileFromPathAsync(filePath1);
//                using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
//                {
//                    BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
//                    SoftwareBitmap bitmap = await decoder.GetSoftwareBitmapAsync();

//                    OcrEngine ocrEngine = OcrEngine.TryCreateFromUserProfileLanguages();
//                    if (ocrEngine == null)
//                    {
//                      //  return StatusCode(500, "OCR برای زبان فارسی در دسترس نیست.");
//                        return Results.BadRequest("OCR برای زبان فارسی در دسترس نیست.");
//                    }

//                    OcrResult result = await ocrEngine.RecognizeAsync(bitmap);
//                    return Results.Ok(new { text = result.Text });
//                }
//            }
//            catch (Exception ex)
//            {
//                return Results.BadRequest($"خطا در پردازش فایل: {ex.Message}");
//            }
//        }
//    }
//}
