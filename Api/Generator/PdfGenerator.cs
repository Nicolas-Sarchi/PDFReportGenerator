

using Api.Dtos;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace Api.Generator
{
    public class PdfGenerator
    {
        public byte[] GenerateReport(CategoriaDto categoria)
        {
            using (FileStream stream = new FileStream("ejemplo.pdf", FileMode.Create))
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, stream);

                document.Open();
                Font font = FontFactory.GetFont("Arial", 12);
                Paragraph paragraph = new Paragraph("Reporte de categoria", font);
                document.Add(paragraph);
                
                Chunk chunk = new Chunk();
                Paragraph nameParagraph = new Paragraph(categoria.Nombre, font);
                document.Add(nameParagraph);
                Paragraph addressParagraph = new Paragraph(categoria.Id, chunk);
                document.Add(addressParagraph);

                document.Close();
                // Convertir el FileStream a byte[]
                byte[] byteArray = new byte[stream.Length];
                stream.Read(byteArray, 0, (int)stream.Length);

                return byteArray;
            }
        }
    }
}