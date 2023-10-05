

using Api.Dtos;
using iText.Html2pdf;
using RazorLight;
using System.IO;

namespace Api.Generator
{
    public class PdfGenerator
    {
      public byte[] GenerateReport(FacturaDto factura)
{
 string currentDirectory = Directory.GetCurrentDirectory();

 Console.WriteLine(currentDirectory);
string templateFolderPath = Path.Combine(currentDirectory, "Generator", "Template");


    
    var engine = new RazorLightEngineBuilder()
        .UseFileSystemProject(templateFolderPath)
        .Build();
    
    string htmlContent = engine.CompileRenderAsync("FacturaTemplate.cshtml", factura).Result;

    string filePath = "ejemplo.pdf";
    using (FileStream stream = new FileStream(filePath, FileMode.Create))
    {
        ConverterProperties converterProperties = new ConverterProperties();
        HtmlConverter.ConvertToPdf(htmlContent, stream, converterProperties);
        byte[] byteArray = File.ReadAllBytes(filePath);

        return byteArray;
    }
}
    }
}