using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SFModule67OOPitog.Methods;

namespace SFModule67OOPitog
{
    internal class Goods
    {
        internal class GoodsPosition
        {
            private object position;
            public object Value { get { return position; } set { this.position = value; } }
            public GoodsPosition(object position)
            {
                this.position = position;
            }
        }

        internal class GoodsCollection
        {
            private GoodsPosition[] Collection;
            public GoodsCollection(GoodsPosition[] collection)
            {
                this.Collection = collection;
            }
            public int Lenght { get { return Collection.Length; } }
            public void Display()
            {
                SomeProduct<int> productINT;
                SomeProduct<double> productDouble;
                int i = 1;
                foreach (var item in Collection)
                {
                    WriteInColor(i + ": ", false, 10);
                    if (item.Value.GetHashCode() == 33333333)
                    {
                        productDouble = (SomeProduct<double>)item.Value;
                        productDouble.ShowInfo();
                    }
                    else
                    {
                        productINT = (SomeProduct<int>)item.Value;
                        productINT.ShowInfo();
                    }
                    i++;
                }
            }
            // Индексатор по массиву
            public GoodsPosition this[int index]
            {
                get
                {
                    // Проверяем, чтобы индекс был в диапазоне для массива
                    if (index >= 0 && index < Collection.Length)
                    {
                        return Collection[index];
                    }
                    else
                    {
                        return null;
                    }
                }

                private set
                {
                    // Проверяем, чтобы индекс был в диапазоне для массива
                    if (index >= 0 && index < Collection.Length)
                    {
                        Collection[index] = value;
                    }
                }
            }
        }

        internal abstract class Product
        {
            public abstract Param Variety { get; set; }
            public abstract double Cost { get; set; }
            public abstract bool WeightOrPiece { get; set; } // Если товар штучный тогда - false если весовой тогда - true
            public abstract ProductType Type { get; set; }
        }

        internal class SomeProduct<TQuantity> : Product
        {
            private Param variety;
            private double weight;
            private double cost;
            private bool weightorpiece;
            private ProductType type;
            private TQuantity quantity;
            private ParamCollection paramCollection;

            public SomeProduct()
            {
                this.variety = new Param("Наименование", "отсутствует");
                this.Type = ProductType.Отсутствует;
            }

            public SomeProduct(Param variety, double weight, double cost, bool weightorpiece, ProductType type)
            {
                this.variety = variety;
                this.weight = weight;
                this.cost = cost;
                this.weightorpiece = weightorpiece;
                this.type = type;
            }

            public override Param Variety { get { return this.variety; } set { this.variety = value; } }
            public override double Cost { get { return this.cost; } set { this.cost = value; } }
            public override bool WeightOrPiece { get { return this.weightorpiece; } set { this.weightorpiece = value; } }
            public override ProductType Type { get { return this.type; } set { this.type = value; } }
            public double Weight { get { return this.weight; } set { this.weight = value; } }
            public TQuantity Quantity { get { return this.quantity; } set { this.quantity = value; } }
            public ParamCollection ParamCollection { get { return this.paramCollection; } set { this.paramCollection = value; } }

            public void ShowInfo()
            {
                WriteInColor("Тип продукта: ", false, 6);
                WriteInColor(type + ", ", false, 7);
                WriteInColor(variety.ParamName + ": ", false, 6);
                WriteInColor(variety.ParamValue + ", ", false, 7);
                WriteInColor("Вес (товара/упаковки): ", false, 6);
                WriteInColor(weight + " кг., ", true, 7);
                WriteInColor("Цена : ", false, 6);
                WriteInColor(string.Format("{0:0.00}", cost) + " р.", false, 7);
                if (weightorpiece)
                {
                    WriteInColor("Товар весовой, ", false, 6);
                    WriteInColor("в наличии " + quantity + " кг. ", true, 7);
                }
                else
                {
                    WriteInColor("Товар штучный, ", false, 6);
                    WriteInColor("в наличии: " + quantity + " шт. ", true, 7);
                }

                WriteInColor("Характеристики: ", true, 2);
                paramCollection.ShowParams();
            }

            public override int GetHashCode()
            {
                if (weightorpiece)
                {
                    int hash = 33333333;
                    return hash;
                }
                else 
                {
                    int hash = 22222222;
                    return hash;
                }
                
            }

        }
    }
}