using System;
using static SFModule67OOPitog.Shop;
using static SFModule67OOPitog.Methods;

namespace SFModule67OOPitog
{
    
    class Program
    {
        // Осталось только дописать систему управления заказами и протестировать
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            
            WriteInColor("Спасибо за покупки в " + Shop.ShopName + ". Ждем Вас снова!", true, 12);
            WriteInColor("\nНажмите на любую клавишу для выхода из программы", true, 12);
            Console.ReadKey();
        }

       
        
    }
    

}