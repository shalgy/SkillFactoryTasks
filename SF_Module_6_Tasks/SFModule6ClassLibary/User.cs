using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFModule6ClassLibrary
{
    public class User
    {
        private int age;
        private string login;
        private string email;

        
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 18)
                {
                    Console.WriteLine("Возраст должен быть не меньше 18");
                }
                else
                {
                    age = value;
                }
            }
        }
        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                if (value.Length < 4)
                {
                    Console.WriteLine("Логин должен состоять не менеее чем из 3 символов");
                }
                else
                {
                    login = value;
                }
            }
        }
        public string EMail
        {
            get
            {
                return email;
            }

            set
            {
                if (value.Contains('@') && value.Contains('.') && chInString(value, '@') > chInString(value, '.'))
                {
                    email = value;
                }
                else
                {
                    Console.WriteLine("Введенные данные не являются почтовым адресом");
                }
            }
        }
        private static int chInString(string s, char c)// обьявление метода
        {
            int i = 0;//переменная-счетчик
            foreach (char ch in s)//проходим по всем символам строки
            {
                i++;//увеличиваем переменную каждый раз
                if (ch == c)
                {
                    break;//если символ совпал, выходим из цикла
                }
            }
            if (i == s.Length)
            {
                return 0;//если строка пройдена, но символы не совпали, возвращаем 0
            }
            else 
            {
                if (c=='@') { Console.WriteLine("Позиция @ = {0}", i); }
                if (c == '.') { Console.WriteLine("Позиция . = {0}", i); }
                return i;
            }
            
        }
    }
}
