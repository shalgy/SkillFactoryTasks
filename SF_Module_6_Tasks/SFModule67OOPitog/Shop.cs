using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFModule67OOPitog.Methods;
using static SFModule67OOPitog.Product;
using static SFModule67OOPitog.Orders;
using static SFModule67OOPitog.Shop;

namespace SFModule67OOPitog
{
    internal class Shop
    {
        internal static string ShopName = "Продмаг Шестерочка";
        internal static string ShopAdress = "Адрес магазина Шестерочка в городе Икс";

        internal static void CreateOrder() 
        {
            Orders orders = new Orders();
            Order order = GetOrder();
          

        }

        public FoodBasket KeepProducts()
        {
            var array = new Product[]
              {
                new Potato 
                {
                    Variety = "Арго",
                    Weight = 3.5,
                    Cost = 210.0,
                    VegetableType = VegetableType.Картошка,
                    Tuber = ShapeOfTuber.Круглый,
                    Starch = AmountOfStarch.Среднее 
                },
                new Potato
                {
                    Variety = "Американка",
                    Weight = 5.0,
                    Cost = 350.0,
                    VegetableType = VegetableType.Картошка,
                    Tuber = ShapeOfTuber.Вытянутый,
                    Starch = AmountOfStarch.Среднее
                },
                new Potato
                {
                    Variety = "Алый парус",
                    Weight = 1.5,
                    Cost = 90.0,
                    VegetableType = VegetableType.Картошка,
                    Tuber = ShapeOfTuber.Овальный,
                    Starch = AmountOfStarch.Высокое
                },
                new Carrot
                {
                    Variety = "Алтайская сахарная",
                    Weight = 2.0,
                    Cost = 180.0,
                    VegetableType = VegetableType.Морковь,
                    Fresh = true,
                    Sweet = true
                },
                new Carrot
                {
                    Variety = "Аленка",
                    Weight = 2.0,
                    Cost = 110.0,
                    VegetableType = VegetableType.Морковь,
                    Fresh = false,
                    Sweet = false
                },
                new Apple
                {
                    Variety = "Антоновка",
                    Weight = 1.0,
                    Cost = 90.0,
                    FructColor = FrutColor.Зеленый,
                    FructType = FructType.Яблоко,
                    Sweet = false
                },
                new Apple
                {
                    Variety = "Гольден",
                    Weight = 1.0,
                    Cost = 120.0,
                    FructColor = FrutColor.Желтый,
                    FructType = FructType.Яблоко,
                    Sweet = true
                },
                new Apple
                {
                    Variety = "Глостер",
                    Weight = 1.5,
                    Cost = 270.0,
                    FructColor = FrutColor.Красный,
                    FructType = FructType.Яблоко,
                    Sweet = true
                },
                new Pear
                {
                    Variety = "Дюшес",
                    Weight = 1.0,
                    Cost = 230.0,
                    FructColor = FrutColor.Желтый,
                    FructType = FructType.Груша,
                    Juicy = true
                },
                new Pear
                {
                    Variety = "Конкорд",
                    Weight = 1.0,
                    Cost = 170.0,
                    FructColor = FrutColor.Зеленый,
                    FructType = FructType.Груша,
                    Juicy = false
                },
                new Pear
                {
                    Variety = "Вильямс",
                    Weight = 1.0,
                    Cost = 190.0,
                    FructColor = FrutColor.Красный,
                    FructType = FructType.Груша,
                    Juicy = false
                },
                new Banana
                {
                    Variety = "Карликовые",
                    Weight = 1.0,
                    Cost = 350.0,
                    FructColor = FrutColor.Желтый,
                    FructType = FructType.Банан,
                    Size = false,
                    Ripe = true
                },
                new Banana
                {
                    Variety = "Желтые",
                    Weight = 1.0,
                    Cost = 150.0,
                    FructColor = FrutColor.Желтый,
                    FructType = FructType.Банан,
                    Size = true,
                    Ripe = false
                },
              };
            
            int counter = 0;
            int selectedProduct = -1;
            int howMuch = 0;
            FoodBasket foodBasket = new();
            WriteInColor("\n! КАТАЛОГ ТОВАРОВ ! Выберите товар из каталога, укажите его номер (целое число)", true, 10);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}: ", i + 1);
                array[i].ShowInfo();
            }
            do
            {
                selectedProduct = NumQuestion("Введите номер продукта либо 222 для завершения: ");
                if (selectedProduct < array.Length && selectedProduct != 222)
                {
                    counter += counter;
                    howMuch = NumQuestion("Укажите количество выбранного продукта: ");
                    ArrayList arrLst = new ArrayList(array);
                    Position newPosition = new(counter, arrLst, howMuch);
                    foodBasket.SetPosition(newPosition);
                }
                else if (selectedProduct == 222) { break; }
            } while (selectedProduct !=0);

        return foodBasket;
        }

        internal class FoodBasket
        {
            private ArrayList positions = [];
            public int PositionCount { get { return positions.Count; } }

            public void SetPosition(Position position)
            {
                positions.Add(position.SelectedPosition.);
            }
            public void RemovePosition(int num)
            {
                if (num != 0) 
                {
                    positions.Remove(num - 1);
                }
            }

            public void ShowBasket()
            {
                WriteInColor(Convert.ToString("\n! КОРЗИНА ! Выберите действие чтобы отредактировать"), true, 2);
                foreach (Position item in positions)
                {
                    WriteInColor(Convert.ToString(item.PositionNumber) + ": ", false, 6);
                    WriteInColor(Convert.ToString(item.SelectedPosition.ShowInfo), true, 3);
                    WriteInColor(Convert.ToString(item.ProductCount), false, 4);
                    WriteInColor(Convert.ToString(", На сумму: " + item.PositionSum), false, 8);
                }
                string answear = TextQuestion("Введите букву 1 чтобы удалить, 2 чтобы добавитьб, 3 чтобы очистить корзину, 4 перейти к оформлению заказа: ");
            }
        }
        internal class Position
        {
            private int positionNumber;
            private ArrayList selectedPosition;
            private int productCount;
            private double positionSum;
            internal int PositionNumber { get { return positionNumber; } }
            internal ArrayList SelectedPosition { get { return selectedPosition; } }
            internal int ProductCount { get { return productCount; } }
            internal double PositionSum { get { return positionSum; } }
            public Position (int positionNumber, ArrayList selectedPosition, int productCount)
            {
                this.positionNumber = positionNumber;
                this.selectedPosition = selectedPosition;
                this.productCount = productCount;
                this.positionSum = selectedPosition. * Convert.ToDouble(productCount); 
            }
        }

    }
}
