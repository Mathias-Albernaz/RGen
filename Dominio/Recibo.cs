namespace Dominio;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

internal class Recibo : IDocument
{
    List<Item> items;
    
    public Document Document { get; set; }
    
    
    

    public Recibo()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public void Compose(IDocumentContainer container)
    {
        throw new NotImplementedException();
    }
}