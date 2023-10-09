# PDFReportGenerator

Uso
Este proyecto consta de dos partes principales:

Generador de Reportes PDF (PdfGenerator.cs)
El archivo PdfGenerator.cs contiene la lógica para generar los reportes PDF a partir de una plantilla Razor y los datos de la factura proporcionados.

A continuación, se describen las principales partes del generador:

Obtención del Directorio Actual y la Carpeta de Plantillas: Se obtiene el directorio actual de la aplicación y se combina con la ruta relativa a la carpeta de plantillas para definir la ubicación de las plantillas Razor.

Configuración del Motor de Plantillas RazorLight: Se configura y se construye un motor de plantillas RazorLight que se utiliza para compilar y renderizar las plantillas Razor.

Generación del Contenido HTML: Se compila y renderiza la plantilla Razor utilizando los datos de la factura, lo que resulta en una cadena HTML que representa el informe.

Definición del Nombre y Ubicación del Archivo PDF de Salida: Se establece el nombre del archivo PDF de salida y se calcula la ubicación completa en la carpeta de descargas del usuario.

Creación del Archivo PDF: Se crea un flujo de archivo (FileStream) para escribir el archivo PDF y se configuran las propiedades del convertidor (ConverterProperties) para controlar la conversión de HTML a PDF.

Conversión del Contenido HTML a PDF: Se utiliza HtmlConverter.ConvertToPdf para convertir el contenido HTML en un archivo PDF y se guarda en el flujo de archivo.

Lectura y Devolución del Archivo PDF: Finalmente, se lee el archivo PDF recién creado en un arreglo de bytes (byte[]) y se devuelve como resultado.

Controlador para Generar el PDF (FacturaController.cs)
El archivo FacturaController.cs es un controlador ASP.NET Core que maneja una solicitud HTTP POST para crear una factura y generar un archivo PDF de la misma.

A continuación, se describen las principales partes del controlador:

Mapeo de Datos y Almacenamiento en la Base de Datos: Los datos de la factura se mapean desde el objeto FacturaPostDto y se almacenan en la base de datos utilizando una unidad de trabajo (UnitOfWork).

Creación de Detalles de Factura: Se crea una lista de DetallesFactura y se asocian con la factura principal.

Recuperación y Mapeo de la Factura: Se recupera nuevamente la factura de la base de datos para obtener los datos actualizados y se mapea a un objeto FacturaDto.

Generación del Archivo PDF: Se crea una instancia del generador de PDF y se genera el archivo PDF utilizando los datos de la factura.

Devolución del Archivo PDF: Finalmente, el archivo PDF se devuelve como respuesta HTTP con el tipo de contenido "application/pdf" y un nombre de archivo "factura.pdf".
