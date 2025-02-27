using OpenCvSharp;
using Persian_OCR;
using Persian_OCR.Enums;
using Persian_OCR.Utilites;
using System.Linq.Expressions;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();



app.UseHttpsRedirection();

app.MapPost("/ocr/Check", async (CheckRequest checkRequest) =>
{
    
    if (string.IsNullOrEmpty(checkRequest.FilePath))
    {
        return Results.BadRequest("filePath is required.");
    }

   string ocrText= ConvertToText.Action(checkRequest.FilePath, checkRequest.CheckMethod);

  //  ocrText = LicensePlateCorrector.Convert(ocrText);
    ocrText = ConvertArabicToPersian.Convert(ocrText);
    ocrText= ConvertPersianArabicNumbersToEnglish.Convert(ocrText);
    ocrText= CityNameCorrector.Convert(ocrText);
    ocrText = FixCorrectText.Convert(ocrText);

    var result=  Find.Action(checkRequest.Strings, ocrText);



    return Results.Json(result);
}).DisableAntiforgery();


app.MapPost("/ocr/upload", async (IFormFile file) =>
{
    if (file is null)
    {
        return Results.BadRequest("file is required.");
    }


    var uploadedFile = await Upload.UploadFile(file);

   

    return Results.Json(uploadedFile);
}).DisableAntiforgery();

app.Run();
