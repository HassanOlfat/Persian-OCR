namespace Petrobar_OCR
{
    public static class Upload
    {
        public static async Task<IResult> UploadFile(IFormFile file1, IFormFile file2)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath1 = Path.Combine(uploadPath, file1.FileName);
            var filePath2 = Path.Combine(uploadPath, file2.FileName);

            using (var stream = new FileStream(filePath1, FileMode.Create))
            {
                await file1.CopyToAsync(stream);
            }

            using (var stream = new FileStream(filePath2, FileMode.Create))
            {
                await file2.CopyToAsync(stream);
            }
            if (!System.IO.File.Exists(filePath1))
            {
                return Results.BadRequest("File not found: " + filePath1);
            }

         //var a= await   WindowsOCR.Action(filePath1, filePath2);


            return Results.Ok(filePath1);
        }
    }
}
