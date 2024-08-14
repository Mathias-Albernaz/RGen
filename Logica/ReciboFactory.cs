using Dominio;

namespace Logica;

public class ReciboFactory
{
      public Recibo Crear(List<Item> items, Dato dato)
      {
            Recibo recibo = new Recibo(items, dato);
            PlantillaRecibo plantillaRecibo = new PlantillaRecibo(recibo);
            plantillaRecibo.GenerarRecibo();
            return recibo;
      }
}