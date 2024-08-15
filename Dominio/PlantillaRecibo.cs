namespace Dominio;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


public class PlantillaRecibo
{
    public List<Item> Items { get; set; }
    public Dato Dato { get; set; }
    public Document ReciboGenerado { get; set; }

    public PlantillaRecibo(Recibo recibo)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Items = recibo.Items.ToList();
        Dato = recibo.Dato;
    }
    

    public void GenerarRecibo()
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
                        fil.Item().Text($"Recibo #1").ExtraBold().FontSize(16);
                        fil.Item().Text($"NP,{Dato.Autor}").FontSize(12);
                        fil.Item().Text($"{Dato.Fecha:d}").FontSize(12);
                        fil.Item().Text("Sección Informática DIPN").FontSize(12);
                        fil.Item().Height(40);
                    });
                    row.ConstantItem(60).Image(@"..\UserInterface\Components\images\Logo.png");
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
                            fil.Item().Text("Firma: ......................................................................").FontSize(9);
                            fil.Item().Text("Contrafirma: ..........................................................").FontSize(9);
                            fil.Item().Text("Grado: .....................................................................").FontSize(9);
                        });
                        row.ConstantItem(100);
                        row.RelativeItem().Column(fil =>
                        {
                            fil.Spacing(12);
                            fil.Item().Text($"Recibe {Dato.Destinatario}").Bold().FontSize(12);
                            fil.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                            fil.Item().Text("Firma: ......................................................................").FontSize(9);
                            fil.Item().Text("Contrafirma: ..........................................................").FontSize(9);
                            fil.Item().Text("Grado: .....................................................................").FontSize(9);
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
                            header.Cell().Background(Colors.Grey.Darken1).Padding(3).Text("Descripción").FontColor("#fff").FontSize(10).Bold();
                            header.Cell().Background(Colors.Grey.Darken1).Padding(3).Text("Identificador").FontColor("#fff").FontSize(10).Bold();
                        });
                        foreach (var elem in Items)
                        {
                            if ((Items.IndexOf(elem) % 2) == 0)
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
                        col.Item().Text($"{Dato.Observacion}").FontSize(10);
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
        ReciboGenerado.GeneratePdf($"{Dato.Titulo} {Dato.Fecha:dd-MM-yy} #1.pdf");
        ReciboGenerado.GeneratePdfAndShow();
    }
    
    
    
    
}