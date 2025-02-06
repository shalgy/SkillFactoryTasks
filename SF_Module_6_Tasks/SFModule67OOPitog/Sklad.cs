using System;
using System.Runtime.CompilerServices;
using static SFModule67OOPitog.Methods;
using static SFModule67OOPitog.Goods;


namespace SFModule67OOPitog
{
    public enum ProductColor { Отсутствует = 0, Красный , Зеленый, Желтый }
    public enum ProductType { Отсутствует = 0, Яблоки, Бананы, Груши, Картошка, Морковь, Консервы, Соки, Пиво }
    public enum ShapeOfTuber { Отсутствует = 0, Круглый, Овальный, Вытянутый }
    public enum AmountOfStarch { Отсутствует = 0, Низкое, Среднее, Высокое }

    internal static class Sklad
    {
        public static GoodsCollection GetAssortment()
        {
            SomeProduct<double> product1 = new SomeProduct<double>();
            product1.Variety.ParamName = "Сорт";
            product1.Variety.ParamValue = "Арго";
            product1.Weight = 3.5;
            product1.Cost = 210.0;
            product1.Type = ProductType.Картошка;
            product1.Quantity = 142.5;
            product1.WeightOrPiece = true;
            Param p1param1 = new("Форма клубня", ShapeOfTuber.Круглый);
            Param p1param2 = new("Содержание крахмала", AmountOfStarch.Среднее);
            Param[] p1params = [p1param1, p1param2];
            product1.ParamCollection = new(p1params);

            SomeProduct<double> product2 = new SomeProduct<double>();
            product2.Variety.ParamName = "Сорт";
            product2.Variety.ParamValue = "Американка";
            product2.Weight = 5.0;
            product2.Cost = 350.0;
            product2.Type = ProductType.Картошка;
            product2.Quantity = 280.0;
            product2.WeightOrPiece = true;
            Param p2param1 = new("Форма клубня", ShapeOfTuber.Вытянутый);
            Param p2param2 = new("Содержание крахмала", AmountOfStarch.Среднее);
            Param[] p2params = [p2param1, p2param2];
            product2.ParamCollection = new(p2params);

            SomeProduct<double> product3 = new SomeProduct<double>();
            product3.Variety.ParamName = "Сорт";
            product3.Variety.ParamValue = "Алтайская сахарная";
            product3.Weight = 1.0;
            product3.Cost = 180.0;
            product3.Type = ProductType.Морковь;
            product3.Quantity = 110.0;
            product3.WeightOrPiece = true;
            Param p3param1 = new("Свежесть", "молодая");
            Param p3param2 = new("Содержание сахара", "среднее");
            Param[] p3params = [p3param1, p3param2];
            product3.ParamCollection = new(p3params);

            SomeProduct<double> product4 = new SomeProduct<double>();
            product4.Variety.ParamName = "Сорт";
            product4.Variety.ParamValue = "Аленка";
            product4.Weight = 2.0;
            product4.Cost = 120.0;
            product4.Type = ProductType.Морковь;
            product4.Quantity = 200.0;
            product4.WeightOrPiece = true;
            Param p4param1 = new("Свежесть", "прошлый сезон");
            Param p4param2 = new("Содержание сахара", "низкое");
            Param[] p4params = [p4param1, p4param2];
            product4.ParamCollection = new(p4params);

            SomeProduct<double> product5 = new SomeProduct<double>();
            product5.Variety.ParamName = "Сорт";
            product5.Variety.ParamValue = "Антоновка";
            product5.Weight = 1.0;
            product5.Cost = 90.0;
            product5.Type = ProductType.Яблоки;
            product5.Quantity = 150.0;
            product5.WeightOrPiece = true;
            Param p5param1 = new("Цвет", ProductColor.Зеленый);
            Param p5param2 = new("Содержание сахара", "низкое");
            Param[] p5params = [p5param1, p5param2];
            product5.ParamCollection = new(p5params);

            SomeProduct<double> product6 = new SomeProduct<double>();
            product6.Variety.ParamName = "Сорт";
            product6.Variety.ParamValue = "Глостер";
            product6.Weight = 1.5;
            product6.Cost = 270.0;
            product6.Type = ProductType.Яблоки;
            product6.Quantity = 150.0;
            product6.WeightOrPiece = true;
            Param p6param1 = new("Цвет", ProductColor.Желтый);
            Param p6param2 = new("Содержание сахара", "высокое");
            Param[] p6params = [p6param1, p6param2];
            product6.ParamCollection = new(p6params);

            SomeProduct<double> product7 = new SomeProduct<double>();
            product7.Variety.ParamName = "Сорт";
            product7.Variety.ParamValue = "Дюшес";
            product7.Weight = 1.0;
            product7.Cost = 230.0;
            product7.Type = ProductType.Груши;
            product7.Quantity = 80.0;
            product7.WeightOrPiece = true;
            Param p7param1 = new("Цвет", ProductColor.Желтый);
            Param p7param2 = new("Содержание сахара", "высокое");
            Param p7param3 = new("Сочность", "высокая");
            Param[] p7params = [p7param1, p7param2, p7param3];
            product7.ParamCollection = new(p7params);

            SomeProduct<double> product8 = new SomeProduct<double>();
            product8.Variety.ParamName = "Сорт";
            product8.Variety.ParamValue = "Желтые";
            product8.Weight = 1.0;
            product8.Cost = 150.0;
            product8.Type = ProductType.Бананы;
            product8.Quantity = 70.0;
            product8.WeightOrPiece = true;
            Param p8param1 = new("Цвет", ProductColor.Желтый);
            Param p8param2 = new("Спелость", "высокая");
            Param[] p8params = [p8param1, p8param2];
            product8.ParamCollection = new(p8params);

            SomeProduct<int> product9 = new SomeProduct<int>();
            product9.Variety.ParamName = "Наименование";
            product9.Variety.ParamValue = "Пиво Жигулевское";
            product9.Weight = 0.6;
            product9.Cost = 90.0;
            product9.Type = ProductType.Пиво;
            product9.Quantity = 48;
            product9.WeightOrPiece = false;
            Param p9param1 = new("Содержание алкоголя", "4,8 %");
            Param p9param2 = new("Тип", "светлое");
            Param[] p9params = [p9param1, p9param2];
            product9.ParamCollection = new(p9params);

            SomeProduct<int> product10 = new SomeProduct<int>();
            product10.Variety.ParamName = "Наименование";
            product10.Variety.ParamValue = "Сок Придонье, яблочный";
            product10.Weight = 1.0;
            product10.Cost = 150.0;
            product10.Type = ProductType.Соки;
            product10.Quantity = 50;
            product10.WeightOrPiece = false;
            Param p10param1 = new("Содержание сока", "не менее 60 %");
            Param p10param2 = new("Содержание сахара", "без содержания");
            Param[] p10params = [p10param1, p10param2];
            product10.ParamCollection = new(p10params);

            SomeProduct<int> product11 = new SomeProduct<int>();
            product11.Variety.ParamName = "Наименование";
            product11.Variety.ParamValue = "Сайра натуральная";
            product11.Weight = 0.245;
            product11.Cost = 254.0;
            product11.Type = ProductType.Консервы;
            product11.Quantity = 60;
            product11.WeightOrPiece = false;
            Param p11param1 = new("Форма", "кусочки");
            Param p11param2 = new("Способ консервирования", "в собственном соку");
            Param[] p11params = [p11param1, p11param2];
            product11.ParamCollection = new(p11params);

            GoodsPosition[] positions =
            [
                new GoodsPosition(product1),
                new GoodsPosition(product2),
                new GoodsPosition(product3),
                new GoodsPosition(product4),
                new GoodsPosition(product5),
                new GoodsPosition(product6),
                new GoodsPosition(product7),
                new GoodsPosition(product8),
                new GoodsPosition(product9),
                new GoodsPosition(product10),
                new GoodsPosition(product11)
            ];
            GoodsCollection assortment = new(positions);
            return assortment;
        }

    }
}
    

