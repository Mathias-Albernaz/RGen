using Dominio;

namespace Logic;

public class RecipitFactory
{
      public void CrearRecibo(List<Item> items, Data data)
      {
            //TryCatch
            Recipit recipit = new Recipit(items, data);
      }
}