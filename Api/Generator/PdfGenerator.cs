using iText.Kernel.Pdf;
using iText.Layout;
using iText.Html2pdf;
using Api.Dtos;
using iText.Html2pdf.Css.Apply.Impl;

namespace Api.Generator;

public class PdfGenerator
{
    public byte[] GenerateReport(CategoriaDto categoria)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            PdfWriter writer = new PdfWriter(stream);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            string archivoHtml = "C:/Users/kevin/Desktop/Nueva carpeta/index.html"; 
            string html = File.ReadAllText(archivoHtml);

            string archivoCss = "C:/Users/kevin/Desktop/Nueva carpeta/style.css"; 
            string css = File.ReadAllText(archivoCss);

            ConverterProperties convertir = new ConverterProperties();
            convertir.SetBaseUri("C:/Users/kevin/Desktop/Nueva carpeta/index.html"); 
            convertir.SetCssApplierFactory(new DefaultCssApplierFactory());

            HtmlConverter.ConvertToPdf(html, pdf, convertir);

            document.Close();

            byte[] byteArray = stream.ToArray();

            return byteArray;
        }
    }
}