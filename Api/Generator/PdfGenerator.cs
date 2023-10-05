

using Api.Dtos;
using iText.Html2pdf;

using System.IO;

namespace Api.Generator
{
    public class PdfGenerator
    {
      public byte[] GenerateReport(CategoriaDto categoria)
{
    string filePath = "ejemplo.pdf";
            using FileStream stream = new FileStream(filePath, FileMode.Create);
            ConverterProperties converterProperties = new ();



            HtmlConverter.ConvertToPdf("<html><body>" +
                                        "<h1>Reporte de categoría</h1>" +
                                        "<p>Nombre de la categoría: " + categoria.Nombre + "</p>" +
                                        "<p>ID de la categoría: " + categoria.Id + "</p>" +
                                        "</body></html>", stream, converterProperties);


            byte[] byteArray = File.ReadAllBytes(filePath);

            return byteArray;
        }
}}