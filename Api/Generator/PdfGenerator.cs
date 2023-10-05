using Api.Dtos;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using Paragraph = iTextSharp.text.Paragraph;

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