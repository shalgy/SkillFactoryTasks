using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFModule67OOPitog.Shop;
using static SFModule67OOPitog.Methods;
using System.Collections;
using System.Runtime.CompilerServices;
using static SFModule67OOPitog.Goods;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static SFModule67OOPitog.Order;

namespace SFModule67OOPitog
{
    internal class Order
    {
        private static dynamic? orderHead;

        public static void CreateOrder()
        {

            (string firstname, string lastname, bool isEmployee, PersonTypes personType) somePerson;

            somePerson.firstname = TextQuestion("Введите Ваше имя: ");
            somePerson.lastname = TextQuestion("Введите Вашу фамилию: ");

            int pType;
            foreach (int typeval in Enum.GetValues(typeof(PersonTypes)))
            {
                Console.WriteLine("{0}: {1}", typeval, (PersonTypes)typeval);
            }
            do
            {
                pType = NumQuestion("Введите номер типа заказчика: ");
            } while (pType < 1 || pType > Enum.GetValues(typeof(PersonTypes)).Length);
            
            somePerson.personType = (PersonTypes)pType;
            somePerson.isEmployee = pType < 3;

            PersonParams personParams = new(somePerson);
            //Person orgCustomer = new(personParams);

            switch (pType < 3)
            {
                case true:
                {
                    OrgEmloyee orgCustomer = new OrgEmloyee(personParams);
                    ShopDelivery delivery = new ShopDelivery();
                    WriteInColor("Заберите заказ по адресу: " + delivery.Address, true, 8);
                    HeadOrder<ShopDelivery, OrgEmloyee> headOrder = new(delivery, orgCustomer);
                    orderHead = headOrder;
                    break;
                }
                default:
                {
                    int age = NumQuestion("Введите Ваш возраст цифрами (полных лет): ");
                    string homeAdress = TextQuestion("Введите Ваш домашний адрес: ");
                    OrgCustomer orgCustomer = new OrgCustomer(personParams, age, homeAdress);
                    int deliverytype;
                    WriteInColor("1: Доставка на дом\n2: Доставка в постомат\n3: Самовывоз", true, 8);
                    do
                    {
                        deliverytype = NumQuestion("Укажите номер варианта доставки (целое число): ");
                    }
                    while (deliverytype > 3);
                    switch (deliverytype)
                    {
                        case 1:
                            {
                                HomeDelivery delivery = new HomeDelivery();
                                HeadOrder<HomeDelivery, OrgCustomer> headOrder = new(delivery, orgCustomer);
                                orderHead = headOrder;
                                break;
                            }
                        case 2:
                            {
                                PickPointDelivery delivery = new PickPointDelivery();
                                HeadOrder<PickPointDelivery, OrgCustomer> headOrder = new(delivery, orgCustomer);
                                orderHead = headOrder;
                                break;
                            }
                        default:
                            {
                                ShopDelivery delivery = new ShopDelivery();
                                HeadOrder<ShopDelivery, OrgCustomer> headOrder = new(delivery, orgCustomer);
                                orderHead = headOrder;
                                break;
                            }
                    }
                 break;
                }
            }

            GoodsCollection showCase = Sklad.GetAssortment();
            
            int counter = 0;
            int selectedProduct = 0;
            int howMuch = 0;
            string variety = string.Empty;
            double cost = 0;
            int сustAnswear = 0;
            int removePos = 0;
            FoodBasket foodBasket = new();
            SomeProduct<int> productINT;
            SomeProduct<double> productDouble;

            do
            {
                Console.Clear();
                WriteInColor("\n! КАТАЛОГ ТОВАРОВ ! Выберите товар из каталога, укажите его номер (целое число)", true, 10);
                showCase.Display();

                do
                {
                    selectedProduct = NumQuestion("Введите номер продукта либо 222 для завершения: ");
                    if (selectedProduct <= showCase.Lenght && selectedProduct != 222)
                    {
                        counter = foodBasket.PositionCount;
                        howMuch = NumQuestion("Укажите количество выбранного продукта: ");
                        if (showCase[selectedProduct - 1].Value.GetHashCode() == 33333333)
                        {
                            productDouble = (SomeProduct<double>)showCase[selectedProduct - 1].Value;
                            variety = (string)productDouble.Variety.ParamValue;
                            cost = productDouble.Cost;
                            if (CheckBalance(((dynamic)orderHead).Customer, howMuch, cost) == true)
                            {
                                if (productDouble.Quantity > (productDouble.Weight * Convert.ToDouble(howMuch)))
                                {
                                    productDouble.Quantity -= productDouble.Weight * Convert.ToDouble(howMuch);
                                    double sum = 0;
                                    sum = cost * Convert.ToDouble(howMuch);
                                    sum -= sum * ((dynamic)orderHead).Customer.Discount();
                                    ((dynamic)orderHead).Customer.Balance -= sum;
                                    Position newPosition = new(counter + 1, selectedProduct, howMuch, variety, cost);
                                    foodBasket.AddPosition(newPosition);
                                }
                                else 
                                {
                                    WriteInColor("У нас, на складе нет достаточного количества: ", true, 12);
                                    WriteInColor("Продукта: " + productDouble.Type + " " + productDouble.Variety.ParamName + " " + productDouble.Variety.ParamValue, true, 10);
                                    WriteInColor("Вы желаете заказать - " + string.Format("{0:0.00}", productDouble.Weight * Convert.ToDouble(howMuch)) + " кг.", false, 14);
                                    WriteInColor(" Остаток: " + string.Format("{0:0.00}", productDouble.Quantity) + " кг.", true, 10);
                                }   
                            }
                        }
                        else
                        {
                            productINT = (SomeProduct<int>)showCase[selectedProduct - 1].Value;
                            variety = (string)productINT.Variety.ParamValue;
                            cost = productINT.Cost;
                            if (CheckBalance(((dynamic)orderHead).Customer, howMuch, cost) == true)
                            {
                                if (productINT.Quantity >  howMuch)
                                {

                                    productINT.Quantity -= howMuch;
                                    double sum = 0;
                                    sum = cost * Convert.ToDouble(howMuch);
                                    sum -= sum * ((dynamic)orderHead).Customer.Discount();
                                    ((dynamic)orderHead).Customer.Balance -= sum;
                                    Position newPosition = new(counter + 1, selectedProduct, howMuch, variety, cost);
                                    foodBasket.AddPosition(newPosition);
                                }
                                else
                                {
                                    WriteInColor("У нас, на складе нет достаточного количества: ", true, 12);
                                    WriteInColor("Продукта: " + productINT.Type + " " + productINT.Variety.ParamName + " " + productINT.Variety.ParamValue, true, 10);
                                    WriteInColor("Вы желаете заказать - " + howMuch + " шт.", false, 14);
                                    WriteInColor(" Остаток: " + productINT.Quantity + " шт.", true, 10);
                                }
                            }
                        }
                        
                    }
                    //else if (selectedProduct == 222 & foodBasket.PositionCount == 0) { goto ExitProg; }
                    else if (selectedProduct == 222) { break; }
                } while (selectedProduct != 0);
                
                    do
                    {
                        if (foodBasket.PositionCount == 0) { WriteInColor("Ваша корзина очищена, работа с программой завершена!", true, 13); goto ExitProg; }
                    Console.Clear();
                    foodBasket.ShowBasket(showCase);
                        сustAnswear = NumQuestion("Введите цифру: 1 - удалить позцию, 2 - добавить позицию, 3 - очистить корзину и выйти, 4 - оформить заказа: ");

                        switch (сustAnswear)
                        {
                            case 1:
                                {
                                    do
                                    {
                                        removePos = NumQuestion("Введите номер позиции для удаления из корзины: ");
                                    } while (removePos > foodBasket.PositionCount);
                                    Position pos = foodBasket.GetPosition(removePos - 1);
                                    string posVariety = pos.VarietyName;
                                    for (int i = 1; i < showCase.Lenght; i++)
                                    {
                                        if (showCase[i].Value.GetHashCode() == 33333333)
                                        {
                                            productDouble = (SomeProduct<double>)showCase[i].Value;
                                            variety = (string)productDouble.Variety.ParamValue;
                                            if(variety == posVariety)
                                            {
                                                productDouble.Quantity += Convert.ToDouble(pos.ProductCount) * productDouble.Weight;
                                            }
                                        }

                                        else 
                                        {
                                            productINT = (SomeProduct<int>)showCase[i].Value;
                                            variety = (string)productINT.Variety.ParamValue;
                                            if (variety == posVariety) 
                                            {
                                                productINT.Quantity += pos.ProductCount;
                                            }

                                        }   
                                    }
                                    foodBasket.RemovePosition(removePos - 1);
                                    break;
                                }
                            case 2:
                                {
                                    continue;
                                }
                            case 3:
                                {
                                    foodBasket = new();
                                    WriteInColor("Ваша корзина очищена, работа с программой завершена!", true, 13);
                                    goto ExitProg;
                                }
                        }
                    } while (сustAnswear == 1);
                
            } while (сustAnswear != 4);

                Console.Clear();
                WriteInColor("ВАШ ЗАКАЗ ПОД НОМЕРОМ № " + ((dynamic)orderHead).OrderNumber, false, 14);
                WriteInColor(" от " + ((dynamic)orderHead).DateTime.ToString("dd MMMM yyyy") + "г. успешно размещен.\n", true, 14);
                WriteInColor("ИНФОРМАЦИЯ ЗАКАЗЧИКА: ", true, 14);
                ((dynamic)orderHead).Customer.ShowInfo();
                WriteInColor("Доставка - " + ((dynamic)orderHead).Delivery.Address, false, 14);
                WriteInColor(", стоимость доставки: " + string.Format("{0:0.00}", ((dynamic)orderHead).Delivery.Price) + "р.\n", true, 14);
                WriteInColor("ИНФОРМАЦИЯ ПО ЗАКАЗУ", true, 14);
                foodBasket.ShowBasket(showCase);
                
        ExitProg:;
        }

        private static void CorrectBalance(double psum)
        {
            double sum = 0;
            sum = psum;
            sum -= sum * ((dynamic)orderHead).Customer.Discount();
            ((dynamic)orderHead).Customer.Balance += sum;
        }

        private static bool CheckBalance(Person orgCustomer, int howMuch, double cost)
        {
            double sum = 0;
            sum = cost * Convert.ToDouble(howMuch);
            sum -= sum * orgCustomer.Discount();
            if (orgCustomer.Balance > sum)
            {
                return true;
            }
            else 
            {
                WriteInColor("! ВНИМАНИЕ ! Не достаточно средств на счете", true, 12);
                WriteInColor("Ваш баланс счета: " + string.Format("{0:0.00}", orgCustomer.Balance) + " р.", true, 10);
                Console.ResetColor();
                return false; 
            }
        }

        internal class FoodBasket
        {
            Position[] positions;

            public int PositionCount { get { return positions is not null? positions.Length: 0; } }
            
            public Position GetPosition(int numb)
            {
                Position position;
                position = positions[numb];
                return position;
            }

            internal void AddPosition(Position position)
            {
                bool incol = false;
                if (positions is not null) 
                {
                    for (int i = 0; i < positions.Length; i++)
                    {
                        if (positions[i].VarietyName == position.VarietyName)
                        {
                            positions[i].ProductCount += position.ProductCount;
                            positions[i].PositionSum += Convert.ToDouble(position.ProductCount) * position.PositionSum;
                            incol = true;
                        }
                    }
                    if (incol == false) 
                    {
                        Array.Resize(ref positions, positions.Length + 1);
                        positions[positions.Length - 1] = position;
                    }
                }
                else
                {
                    positions = [position];
                }
                
            }
            internal void RemovePosition(int p)
            {
                CorrectBalance(positions[p].PositionSum);
                Position[] newpositions = new Position[positions.Length - 1];
                for (int i = 0; i < p; i++)
                {
                    newpositions[i] = positions[i];
                }
                for (int i = p + 1; i < positions.Length; i++)
                {
                    newpositions[i - 1] = positions[i];
                }
                positions = newpositions;

                for (int i = 0; i < positions.Length; ++i)
                {
                    positions[i].PositionNumber = i + 1;
                }
            }

            internal void ShowBasket(GoodsCollection showCase)
            {
                SomeProduct<int> productINT;
                SomeProduct<double> productDouble;
                WriteInColor(Convert.ToString("\n! ВАША КОРЗИНА ! Выберите действие чтобы отредактировать или оформить заказ."), true, 14);
                double sum = 0;
                int count = 0;
                int posnum = 0;
                double SumWeight = 0;
                
                for (int i = 0; i < positions.Length; i++)
                {
                    posnum = positions[i].SelectedProduct - 1;
                    if (showCase[posnum].Value.GetHashCode() == 33333333)
                    {
                        productDouble = (SomeProduct<double>)showCase[posnum].Value;
                        WriteInColor(Convert.ToString(positions[i].PositionNumber + ": "), false, 10);
                        productDouble.ShowInfo();
                        sum += positions[i].PositionSum;
                        count += positions[i].ProductCount;
                        SumWeight += Convert.ToDouble(count) * productDouble.Weight;
                        WriteInColor(Convert.ToString("Всего: " + count + " упаковок."), false, 6);
                        WriteInColor(Convert.ToString(" на сумму: " + string.Format("{0:0.00}", sum) + "р."), true, 6);
                    }
                    else if (showCase[posnum].Value.GetHashCode() == 22222222)
                    {
                        productINT = (SomeProduct<int>)showCase[posnum].Value;
                        WriteInColor(Convert.ToString(positions[i].PositionNumber + ": "), false, 10);
                        productINT.ShowInfo();
                        sum += positions[i].PositionSum;
                        count += positions[i].ProductCount;
                        SumWeight += Convert.ToDouble(count) * productINT.Weight;
                        WriteInColor(Convert.ToString("Всего: " + count + " шт."), false, 6);
                        WriteInColor(Convert.ToString(" на сумму: " + string.Format("{0:0.00}", sum) + "р."), true, 6);
                    }
                        
                }
                double discount = ((dynamic)orderHead).Customer.Discount();
                sum -= sum * discount;
                discount = discount * 100;
                WriteInColor(Convert.ToString("Ваш текущий баланс: " + string.Format("{0:0.00}", ((dynamic)orderHead).Customer.Balance)) + "р.", false, 10);
                WriteInColor(Convert.ToString("Ваш скидка: " + discount + "%"), true, 10);
                WriteInColor(Convert.ToString("Вы заказали товаров в количестве: " + count + " шт., "), false, 14);
                WriteInColor(Convert.ToString("на общую сумму: " + string.Format("{0:0.00}", sum) + "р."), false, 14);
                WriteInColor(Convert.ToString(", общим весом: " + string.Format("{0:0.00}", SumWeight) + " кг."), true, 14);
                
            }
        }
        internal class Position
        {
            private int positionNumber;
            private int selectedProduct;
            private int productCount;
            private string varietyName;
            private double positionSum;
            internal int PositionNumber { get { return positionNumber; } set { positionNumber = value; } }
            internal int SelectedProduct { get { return selectedProduct; } set { selectedProduct = value; } }
            internal int ProductCount { get { return productCount; } set { productCount = value; } }
            internal string VarietyName { get { return varietyName; } set { varietyName = value; } }
            internal double PositionSum { get { return positionSum; } set { positionSum = value; } }
            public Position(int positionNumber, int selectedProduct, int productCount, string varietyName, double productCost)
            {
                this.positionNumber = positionNumber;
                this.selectedProduct = selectedProduct;
                this.productCount = productCount;
                this.varietyName = varietyName;
                this.positionSum = productCost * Convert.ToDouble(productCount);
            }
        }

        class Counter
        {
            private static int increasingCounter;
            public static int IncreasingCounter
            {
                get
                {
                    return increasingCounter;
                }
                set
                {
                    if (value > increasingCounter)
                    {
                        increasingCounter = value;
                    }
                }
            }
        }

        class HeadOrder<TDelivery,TPerson>
        {
            public TDelivery? Delivery { get; set; }
            public TPerson? Customer { get; set; }
            public int OrderNumber { get; }
            public DateTime DateTime { get; }

            public HeadOrder()
            {
                Counter.IncreasingCounter++;
                OrderNumber = Counter.IncreasingCounter;
                DateTime = DateTime.Now;
            }
            public HeadOrder(TDelivery delivery, TPerson customer)
            {
                Delivery = delivery;
                Customer = customer;
                Counter.IncreasingCounter++;
                OrderNumber = Counter.IncreasingCounter;
                DateTime = DateTime.Now;
            }

        }

             
        class Delivery
        {
            private protected double price;
            public string Address;
            public Delivery()
            {
                price = 500.00;
                Address = string.Empty;
            }
            public double Price
            {
                get { return price; }
            }
            
        }
        class HomeDelivery : Delivery 
        {
            public HomeDelivery()
            {
                base.price = 500.0;
                base.Address = "Адрес заазчика";
            }
        }
        class PickPointDelivery : Delivery 
        {
            public PickPointDelivery()
            {
                base.price = 150.0;
                base.Address = "ПОСТОМАТ по адресу: улица Пушкина. дом Колотушкина";
            }
        }
        class ShopDelivery : Delivery 
        {
            public ShopDelivery()
            {
                base.price = 0.0;
                base.Address = Shop.ShopAdress;
            }
        }

    }
}
