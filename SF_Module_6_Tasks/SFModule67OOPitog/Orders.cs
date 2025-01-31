using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFModule67OOPitog.Shop;
using static SFModule67OOPitog.Methods;
using static SFModule67OOPitog.Orders;
using System.Collections;

namespace SFModule67OOPitog
{
    internal class Orders
    {
        private ArrayList orderlist;
        public int OrdersCount { get { return orderlist.Count; } }
        public Orders() { }
        public void AddOrder(Order order)
        {
            orderlist.Add(order);
        }
        public void RemoveOrder(int num)
        {
            if (num != 0)
            {
                orderlist.Remove(num);
            }
        }
        public void ShowOrderList()
        {
            WriteInColor(Convert.ToString("\n! СПИСОК ЗАКАЗОВ ! Выберите действие чтобы отредактировать"), true, 2);
            foreach (Order item in orderlist)
            {
                WriteInColor("Заказ № " + Convert.ToString(item.OrderNumber) + " ", false, 6);
                WriteInColor("от " + Convert.ToString(item.DateTime), false, 3);
                WriteInColor(Convert.ToString(item.Customer.ShowInfo), false, 4);
                item.OrderBasket.;
            }
            string answear = TextQuestion("Введите букву 1 чтобы удалить, 2 чтобы добавитьб, 3 чтобы очистить корзину, 4 перейти к оформлению заказа: ");
        }





        internal class Counter
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


        public static Order GetOrder()
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
            } while (pType < 1 && pType > Enum.GetValues(typeof(PersonTypes)).Length);

            somePerson.personType = (PersonTypes)pType;
            somePerson.isEmployee = pType < 3;

            PersonParams personParams = new(somePerson);
            Person orgCustomer = new(personParams);
            Delivery delivery = new();
            Order myOrder = new();
            switch (pType < 3)
            {
                case true:
                {
                    orgCustomer = new OrgEmloyee(personParams);
                    delivery = new ShopDelivery();
                    WriteInColor("Заберите заказ по адресу: " + delivery.Address, true, 8);
                    break;
                }
                default:
                {
                    int age = NumQuestion("Введите Ваш возраст цифрами (полных лет): ");
                    string homeAdress = TextQuestion("Введите Ваш домашний адрес: ");
                    orgCustomer = new OrgCustomer(personParams, age, homeAdress);
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
                            myOrder = new ((HomeDelivery)delivery, orgCustomer);
                            break;
                        }
                        case 2:
                        {
                            myOrder = new ((PickPointDelivery)delivery, orgCustomer);
                            break;
                        }
                        default:
                        {
                            myOrder = new ((ShopDelivery)delivery, orgCustomer);
                            break;
                        }
                    }
                    break;
                }
            }
            return myOrder;

        }

        internal class Order 
        {
            public Delivery? Delivery {  get; set; }
            public Person? Customer { get; set; }
            public int OrderNumber { get; }
            public DateTime DateTime { get; }
            public FoodBasket OrderBasket = new();
            
            public Order()
            {
                Counter.IncreasingCounter++;
                OrderNumber = Counter.IncreasingCounter;
                DateTime = DateTime.Now;
            }
            public Order(Delivery delivery, Person customer)
            {
                Delivery = delivery;
                Customer = customer;
                Counter.IncreasingCounter++;
                OrderNumber = Counter.IncreasingCounter;
                DateTime = DateTime.Now;
                OrderBasket = Shop.KeepProducts();
                OrderBasket.ShowBasket();
            }

        }
        internal class Delivery
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
        internal class HomeDelivery : Delivery 
        {
            public HomeDelivery()
            {
                base.price = 500.0;
                base.Address = "Адрес заазчика";
            }
        }
        internal class PickPointDelivery : Delivery 
        {
            public PickPointDelivery()
            {
                base.price = 150.0;
                base.Address = "ПОСТОМАТ по адресу: улица Пушкина. дом Колотушкина";
            }
        }
        internal class ShopDelivery : Delivery 
        {
            public ShopDelivery()
            {
                base.price = 0.0;
                base.Address = Shop.ShopAdress;
            }
        }

    }
}
