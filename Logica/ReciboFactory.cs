using Dominio;

namespace Logica;

public class ReciboFactory
{
      public void CrearRecibo(List<Item> items, Datos datos)
      {
            //TryCatch
            PlantillaRecibo plantillaRecibo = new PlantillaRecibo(items, datos);
      }
}