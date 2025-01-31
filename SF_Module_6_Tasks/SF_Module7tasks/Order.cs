using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_Module7tasks
{
    internal class Order<T> where T : Delivery
    {
        public int Number;
        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

    }
    class PremiumService<T> where T : Order<HomeDelivery>
    {
        public T Order;
    }

    internal abstract class Delivery
    {
        public string Address;
        
    }

    internal class HomeDelivery : Delivery
    {

    }

    internal class PickPointDelivery : Delivery { /* ... */ }

    internal class ShopDelivery : Delivery { /* ... */ }

 //   class Order<TDelivery, TStruct>
 //   where TDelivery : Delivery
 //   where TStruct : struct
 //   {
 //       public TDelivery Delivery;

 //       public TStruct Struct;

	//// ... Другие поля
 //   }
 //   //Для методов синтаксис ограничений является точно таким же:

 //   public static T Return<T>(int number) where T : new()
 //   {
 //       Console.WriteLine(number);

 //       return new T();
 //   }
}
    
    

