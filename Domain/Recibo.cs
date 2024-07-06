namespace Dominio;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

public class Recibo
{
    private List<Item> _items;
    private Datos _datos;
    public Document ReciboGenerado { get; set; }

    public Recibo(List<Item>? items, Datos? data)
    {
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
                        fil.Item().Text("Recibo #12").Bold().FontSize(16);
                        fil.Item().Text("NP,ma").FontSize(12);
                        fil.Item().Text("24/11/2024").FontSize(12);
                        fil.Item().Text("Sección Informática DIPN").FontSize(12);
                        fil.Item().Height(40);
                    });
                    row.ConstantItem(80).Height(60).Width(80).Placeholder();
                });
                page.Content().Row(row =>
                {
                    
                    row.RelativeItem().Column(fil =>
                    {
                        
                        fil.Spacing(8);
                        fil.Item().Text("Entrega Secc Informatica DIPN").Bold().FontSize(12);
                        fil.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                        fil.Item().Text("Firma:").FontSize(9);
                        fil.Item().Text("Contrafirma:").FontSize(9);
                        fil.Item().Text("Grado:").FontSize(9);
                    });
                    row.ConstantItem(100);
                    row.RelativeItem().Column(fil =>
                    {
                        fil.Spacing(8);
                        fil.Item().Text("Recibe UCC").Bold().FontSize(12);
                        fil.Item().PaddingVertical(5).LineHorizontal(1).LineColor(Colors.Grey.Medium);
                        fil.Item().Text("Firma:").FontSize(9);
                        fil.Item().Text("Contrafirma:").FontSize(9);
                        fil.Item().Text("Grado:").FontSize(9);
                    });
                });
            });
        });
        ReciboGenerado.ShowInPreviewerAsync();
    }
    
    
    
    
}