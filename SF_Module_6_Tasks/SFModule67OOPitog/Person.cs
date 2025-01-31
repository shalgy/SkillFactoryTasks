using System;
using static SFModule67OOPitog.Methods;


namespace SFModule67OOPitog
{
    public enum PersonTypes : int
    {
        Администратор = 1,
        Продавец,
        Покупатель
    }

    internal class PersonParams((string firstName, string lastName, bool isEmployee, PersonTypes personType) somePerson)
    {
        public string? FirstName { get; } = somePerson.firstName;
        public string? LastName { get; } = somePerson.lastName;
        public bool IsEmployee { get; } = somePerson.isEmployee;
        public PersonTypes PersonType { get; } = somePerson.personType;
    }

    internal class Person(PersonParams personParam)
    {
        private protected string? firstName = personParam.FirstName;
        private protected string? lastName = personParam.LastName;
        private protected bool isEmployee = personParam.IsEmployee;
        private protected PersonTypes personType = personParam.PersonType;
        public virtual void ShowInfo()
        {
            WriteInColor((isEmployee ? "Сотрудник " : string.Empty) + personType + ": " + lastName + " " + firstName, true, 3);
        }
        public virtual double Discount() {  return 0.0; }
        public bool IsEmployee
        {
            get
            {
                return isEmployee;
            }
            set
            {
                isEmployee = value;
            }
        }
    }

    internal class OrgCustomer(PersonParams personParam, int age, string homeAdress) : Person(personParam)
    {
        private int age = age;
        private string homeAdress = homeAdress;

        public override void ShowInfo()
        {
            WriteInColor((isEmployee ? "Сотрудник " : string.Empty) + personType + ": " + lastName + " " + firstName + ", возраст: " + age, true, 3);
            WriteInColor("Ваша скидка: " + string.Format("{0} %", Discount() * 100), true, 3);
            WriteInColor("Домашний адрес: " + homeAdress, true, 3);
        }
        public override double Discount() 
        {
            double discount = 0.0;
            if (personType == PersonTypes.Покупатель)
            {
                if (age >= 65)
                {
                    discount = 0.05;
                }
            }
            return discount;
        }
       
    }
    internal class OrgEmloyee(PersonParams personParam) : Person(personParam)
    {
        public override void ShowInfo()
        {
            WriteInColor((isEmployee ? "Сотрудник " + Shop.ShopName : string.Empty) + " (" + personType + "): " + lastName + " " + firstName, true, 3);
            WriteInColor("Ваша скидка: " + string.Format("{0} %", Discount() * 100), true, 10);
        }
        public override double Discount()
        {
            double discount = 0.0;
            if (personType == PersonTypes.Администратор) { discount = 0.2; }
            else if (personType == PersonTypes.Продавец) { discount = 0.1; }
            return discount;

        }

    }
    

}
