namespace Dominio;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

public class Recibo
{
    private List<Item>? _items;
    private Datos _datos;
    public Document ReciboGenerado { get; set; }

    public Recibo(List<Item>? items, Datos? data)
    {
        _items = items;
        _datos = data;
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public void CrearRecibo()
    {
        ReciboGenerado = Document.Create(recibo =>
        {
            
            recibo.Page(page =>
            {
                page.MarginVertical(50);
                page.MarginHorizontal(70);
                page.Header().Row(row =>
                {
                    row.RelativeItem(200).Column(fil =>
                    {
                        fil.Item().Text($"Recibo #12").Bold().FontSize(16);
                        fil.Item().Text($"NP,{_datos.Autor}").FontSize(12);
                        fil.Item().Text($"{_datos.Fecha:d}").FontSize(12);
                        fil.Item().Text("Sección Informática DIPN").FontSize(12);
                        fil.Item().Height(40);
                    });
                    row.ConstantItem(80).Height(60).Width(80).Placeholder();
                });
                page.Content().Column(column =>
                {
                    column.Spacing(30);
                    column.Item().Row(row =>
                    {
                        row.RelativeItem().Column(fil =>
                        {
                        
                            fil.Spacing(12);
                            fil.Item().Text("Entrega Secc Informatica DIPN").Bold().FontSize(12);
                            fil.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                            fil.Item().Text("Firma: ...............................................").FontSize(9);
                            fil.Item().Text("Contrafirma: ...................................").FontSize(9);
                            fil.Item().Text("Grado: ..............................................").FontSize(9);
                        });
                        row.ConstantItem(100);
                        row.RelativeItem().Column(fil =>
                        {
                            fil.Spacing(12);
                            fil.Item().Text($"Recibe {_datos.Destinatario}").Bold().FontSize(12);
                            fil.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                            fil.Item().Text("Firma: ..............................................").FontSize(9);
                            fil.Item().Text("Contrafirma: ...................................").FontSize(9);
                            fil.Item().Text("Grado: ..............................................").FontSize(9);
                        });
                  
                    });
                    column.Item().Table(table =>
                    {
                        table.ColumnsDefinition(column =>
                        {
                            column.RelativeColumn();
                            column.RelativeColumn(9);
                            column.RelativeColumn(6);
                        });
                        table.Header(header =>
                        {
                            
                            header.Cell().Background(Colors.Grey.Darken1).Padding(3).Text("#").FontColor("#fff").FontSize(10).Bold();
                            header.Cell().Background(Colors.Grey.Darken1).Padding(3).Text("Detalle").FontColor("#fff").FontSize(10).Bold();
                            header.Cell().Background(Colors.Grey.Darken1).Padding(3).Text("Identificador").FontColor("#fff").FontSize(10).Bold();
                        });
                        foreach (var elem in _items)
                        {
                            if ((_items.IndexOf(elem) % 2) == 0)
                            {
                                table.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text($"{elem.Cantidad:N0}").FontSize(10);
                                table.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text($"{elem.Descripcion}" ).FontSize(10);
                                table.Cell().Background(Colors.Grey.Lighten3).Padding(2).Text($"{elem.Identificador}").FontSize(10);
                            }
                            else
                            {
                                table.Cell().Padding(2).Text($"{elem.Cantidad:N0}").FontSize(10);
                                table.Cell().Padding(2).Text($"{elem.Descripcion}" ).FontSize(10);
                                table.Cell().Padding(2).Text($"{elem.Identificador}").FontSize(10);
                            }
                        }
                    });
                    column.Item().Container().Background(Colors.Grey.Lighten3).Padding(10).Column(col =>
                    {
                        col.Spacing(5);
                        col.Item().Text("Observaciones").FontSize(10);
                        col.Item().Text($"{_datos.Detalle}").FontSize(10);
                    });
                });
                
                page.Footer().Column(col =>
                {
                    col.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);
                    col.Item().Text("20304561").AlignCenter();
                    col.Item().Text("Maldonado 1121").AlignCenter();
                });
            });
            
        });
        ReciboGenerado.GeneratePdf($"C:\\Users\\mathi\\Desktop\\{_datos.Titulo}.pdf");
        ReciboGenerado.GeneratePdfAndShow();
    }
    
    
    
    
}