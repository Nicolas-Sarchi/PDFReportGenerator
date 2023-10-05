using Api.Dtos;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using Paragraph = iTextSharp.text.Paragraph;


using Api.Dtos;
using iText.Html2pdf;

using System.IO;

namespace Api.Generator;
public class PdfGenerator
{
    public byte[] GenerateReport(CategoriaDto categoria)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraph = new Paragraph("Reporte");
            document.Add(paragraph);
            
            Paragraph nameParagraph = new Paragraph("Nombre: " + categoria.Nombre);
            document.Add(nameParagraph);
            
            document.Close();
            
            byte[] byteArray = stream.ToArray();

            return byteArray;
        }
    }
}
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

