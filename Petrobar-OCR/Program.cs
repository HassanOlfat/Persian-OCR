using OpenCvSharp;
using Petrobar_OCR;
using Petrobar_OCR.Enums;
using System.Linq.Expressions;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();



app.UseHttpsRedirection();

app.MapPost("/Check", async (List<string> strings, string filePath, CheckMethod checkMethod) =>
{
    
    if (string.IsNullOrEmpty(filePath))
    {
        return Results.BadRequest("filePath is required.");
    }

    

    //Mat preprocessed = DocumentPreprocessor.PreprocessDocument(filePath);
    //Cv2.ImWrite(filePath, preprocessed);

    var b=  TesseractLib.Action(filePath);

 // var c= IronOcrLib.Action("F:***\\2ca30949-89a9-4ce6-8145-80b05cc87988.jpg", "F:***\\1.jpg")[0];



    return Results.Json(b);
}).DisableAntiforgery();


app.MapPost("/upload", async (IFormFile file) =>
{
    if (file is null)
    {
        return Results.BadRequest("file is required.");
    }


    var uploadedFile = await Upload.UploadFile(file);

   

    return Results.Json(uploadedFile);
}).DisableAntiforgery();

app.Run();
