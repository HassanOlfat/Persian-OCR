using OpenCvSharp;
using Petrobar_OCR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();



app.UseHttpsRedirection();

app.MapPost("/upload", async (IFormFile file1, IFormFile file2) =>
{
    if (file1 == null || file2 == null)
    {
        return Results.BadRequest("Both images are required.");
    }
    var imgAddress = "C:\\Users\\***\\Desktop\\Temp Project\\EasyOCRProject\\img\\";

    var u = await Upload.UploadFile(file1, file2);

  //  Mat preprocessed = DocumentPreprocessor.PreprocessDocument($"{imgAddress}2ca30949-89a9-4ce6-8145-80b05cc87988.jpg");

   // Cv2.ImWrite($"{imgAddress}document_preprocessed.jpg", preprocessed);

    var b=  TesseractLib.Action($"{imgAddress}3.jpg", $"{imgAddress}1.jpg");
 // var c= IronOcrLib.Action("F:***\\2ca30949-89a9-4ce6-8145-80b05cc87988.jpg", "F:***\\1.jpg")[0];



    return Results.Json(b);
})
.WithName("UploadImages").DisableAntiforgery();

app.Run();
