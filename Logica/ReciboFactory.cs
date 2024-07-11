using Dominio;

namespace Logica;

public class ReciboFactory
{
      public void CrearRecibo(List<Item> items, Datos datos)
      {
            Recibo recibo = new Recibo(items, datos);
            PlantillaRecibo plantillaRecibo = new PlantillaRecibo(recibo);
            plantillaRecibo.GenerarRecibo();
      }
}