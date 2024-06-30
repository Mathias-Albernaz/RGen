namespace Dominio;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;


public class Recibo
{
    List<Item> items;
    
    public Document Document { get; set; }
    
    
    

    public Recibo()
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(12));
                
                
            });
            
        });
        Document.ShowInPreviewerAsync();
    }
}