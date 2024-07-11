using Dominio;

namespace Logica;

public class ReciboFactory
{
      public void CrearRecibo(List<Item> items, Datos datos)
      {
            //TryCatch
            Recibo recibo = new Recibo(items, datos);
      }
}