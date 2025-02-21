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
    var imgAddress = "F:\\uploads\\";

    var u = await Upload.UploadFile(file1, file2);

    Mat preprocessed = DocumentPreprocessor.PreprocessDocument($"{imgAddress}2ca30949-89a9-4ce6-8145-80b05cc87988.jpg");

    Cv2.ImWrite($"{imgAddress}document_preprocessed.jpg", preprocessed);

    var b=  TesseractLib.Action($"{imgAddress}document_preprocessed.jpg", $"{imgAddress}1.jpg");
 // var c= IronOcrLib.Action("F:\\spot\\petrobar\\Petrobar-OCR\\Petrobar-OCR\\uploads\\2ca30949-89a9-4ce6-8145-80b05cc87988.jpg", "F:\\spot\\petrobar\\Petrobar-OCR\\Petrobar-OCR\\uploads\\1.jpg")[0];



    return Results.Json(u);
})
.WithName("UploadImages").DisableAntiforgery();

app.Run();
