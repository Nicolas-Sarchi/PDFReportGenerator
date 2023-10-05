using iText.Kernel.Pdf;
using iText.Layout;
using iText.Html2pdf;
using Api.Dtos;
using iText.Html2pdf.Css.Apply.Impl;

namespace Api.Generator;

public class PdfGenerator
{
    // public byte[] GenerateReport(CategoriaDto categoria)
    // {
    //     using (MemoryStream stream = new MemoryStream())
    //     {
    //         PdfWriter writer = new PdfWriter(stream);
    //         PdfDocument pdf = new PdfDocument(writer);
    //         Document document = new Document(pdf);

    //         string archivoHtml = "C:/Users/APT01-48/Desktop/Nueva carpeta/index.html"; 
    //         string html = File.ReadAllText(archivoHtml);

    //         string archivoCss = "C:/Users/APT01-48/Desktop/Nueva carpeta/style.css"; 
    //         string css = File.ReadAllText(archivoCss);

    //         ConverterProperties convertir = new ConverterProperties();
    //         convertir.SetBaseUri("C:/Users/APT01-48/Desktop/Nueva carpeta/index.html"); 
    //         convertir.SetCssApplierFactory(new DefaultCssApplierFactory());

    //         HtmlConverter.ConvertToPdf(html, pdf, convertir);

    //         document.Close();

    //         byte[] byteArray = stream.ToArray();

    //         return byteArray;
    //     }
    // }
    public byte[] GenerateReport(FacturaDto factura)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                string archivoHtml = "C:/Users/APT01-48/Desktop/Nueva carpeta/index.html";
                string html = File.ReadAllText(archivoHtml);

                var idFactura = factura.Id;
                var nombreCliente = factura.Cliente.Nombre + " " + factura.Cliente.Apellido;
                var telefonoCliente = factura.Cliente.Telefono;
                var emailCliente = factura.Cliente.Email;
                var fechaFactura = factura.Fecha.ToString("yyyy-MM-dd");
                var totalFactura = factura.Total;
                var nombreProducto = factura.DetallesFactura.First().Producto.Nombre;
                var precioProducto = factura.DetallesFactura.First().Producto.Precio;
                var cantidadProducto = factura.DetallesFactura.First().Cantidad;

                html = html.Replace("Nro: ", "Nro: " + idFactura);
                html = html.Replace("Cliente:", "Cliente: " + nombreCliente);
                html = html.Replace("Documento:", "Documento: " + telefonoCliente);
                html = html.Replace("Fecha:", "Fecha: " + fechaFactura);
                html = html.Replace("Descripcion", nombreProducto);
                html = html.Replace("Valor Unitario", precioProducto.ToString());
                html = html.Replace("Cantidad", cantidadProducto.ToString());
                html = html.Replace("SubTotal", (precioProducto * cantidadProducto).ToString());

                string archivoTemporalHtml = "C:/Users/APT01-48/Desktop/Nueva carpeta/temp.html";
                File.WriteAllText(archivoTemporalHtml, html);

                ConverterProperties convertir = new ConverterProperties();
                convertir.SetBaseUri("file:///" + archivoTemporalHtml);
                convertir.SetCssApplierFactory(new DefaultCssApplierFactory());

                HtmlConverter.ConvertToPdf(html, pdf, convertir);

                document.Close();

                byte[] byteArray = stream.ToArray();

                File.Delete(archivoTemporalHtml);

                return byteArray;
            }
        }
}