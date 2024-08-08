using Dominio;

namespace Logica;

public class ReciboFactory
{
      public int IdNueva { get; set; } = 1;
      public Recibo Crear(List<Item> items, Dato dato)
      {
            Recibo recibo = new Recibo(items, dato);
            recibo.Id = IdNueva;
            PlantillaRecibo plantillaRecibo = new PlantillaRecibo(recibo);
            plantillaRecibo.GenerarRecibo();
            IdNueva++;
            return recibo;
      }
}