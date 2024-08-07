using Dominio;

namespace Logica;

public class ReciboFactory
{
      public int Id { get; set; } = 1;
      public Recibo CrearRecibo(List<Item> items, Datos datos)
      {
            Recibo recibo = new Recibo(items, datos);
            recibo.Id = Id;
            PlantillaRecibo plantillaRecibo = new PlantillaRecibo(recibo);
            plantillaRecibo.GenerarRecibo();
            Id++;
            return recibo;
      }
}