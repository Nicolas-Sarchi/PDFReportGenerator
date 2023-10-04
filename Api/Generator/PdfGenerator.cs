using System;
using System.IO;
using Dominio.Entities;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Api.Generator;

public class PdfGenerator
{
    public void GenerarPdf(Cliente cliente)
    {
        using (PdfWriter writer = new PdfWriter("Factura.pdf"))
        {
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);
                
                document.Add(new Paragraph($"Cliente: {cliente.Nombre} {cliente.Apellido}"));
                document.Add(new Paragraph($"Teléfono: {cliente.Telefono}"));
                document.Add(new Paragraph($"Email: {cliente.Email}"));
                
                foreach (var factura in cliente.Facturas)
                {
                    document.Add(new Paragraph($"Fecha: {factura.Fecha.ToString()}"));
                    document.Add(new Paragraph($"Total: {factura.Total}"));

                    foreach (var detalle in factura.DetallesFactura)
                    {
                        document.Add(new Paragraph($"Producto: {detalle.Producto}"));
                        document.Add(new Paragraph($"Cantidad: {detalle.Cantidad}"));
                        document.Add(new Paragraph($"Precio Unitario: {detalle.Precio}"));
                    }

                    document.Add(new AreaBreak());
                }
            }
        }
    }
}
