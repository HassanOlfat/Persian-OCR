namespace Persian_OCR
{
    public static class Upload
    {
        public static async Task<IResult> UploadFile(IFormFile file1)
        {
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var filePath1 = Path.Combine(uploadPath, file1.FileName);

            using (var stream = new FileStream(filePath1, FileMode.Create))
            {
                await file1.CopyToAsync(stream);
            }

           
            if (!System.IO.File.Exists(filePath1))
            {
                return Results.BadRequest("File not found: " + filePath1);
            }

            return Results.Ok(filePath1);
        }
    }
}
