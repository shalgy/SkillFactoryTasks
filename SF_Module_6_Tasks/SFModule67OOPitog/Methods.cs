using System;

namespace SFModule67OOPitog
{
    internal class Methods
    {
        internal static void WriteInColor(string text, bool method, int color)
        //метод выводит сообщение в консоль в заданном цвете и заданным методом
        //если числовое значение превышает допустимое в перечислении вывод в консоль - серым цветом
        {
            if (color <= 15) { Console.ForegroundColor = (ConsoleColor)color; }
            else { Console.ForegroundColor = (ConsoleColor)7; }
            if (method) { Console.WriteLine(text); }
            else { Console.Write(text); }
        }
        
        internal static string TextQuestion(string msgtext)
        //метод запрашивает у пользователя строчные данные, вызывает методы проверки и возвращает корректное значение
        {
            string consstring;
            string corrstring;
            do
            {
                WriteInColor(msgtext, false, 15);
                Console.ForegroundColor = ConsoleColor.Gray;
                var input = Console.ReadLine();
                consstring = string.IsNullOrWhiteSpace(input) ? string.Empty : input;
            } while (ChekUserText(consstring, out corrstring) == false);
            return corrstring;
        }

        internal static int NumQuestion(string msgtext)
        //метод запрашивает у пользователя числовые данные, вызывает методы проверки и возвращает корректное значение
        {
            string consint;
            int corrint;
            do
            {
                WriteInColor(msgtext, false, 15);
                Console.ForegroundColor = ConsoleColor.Gray;
                var input = Console.ReadLine();
                consint = string.IsNullOrWhiteSpace(input) ? string.Empty : input;
            } while (ChekForNumeric(consint, out corrint) == false);
            return corrint;
        }
        protected static bool ChekUserText(string userenter, out string corrtext)
        //мтод проверяет корректность заполнения строковых данных вызывает также метод проверки на числовое значение
        {

            if ((ChekForNumeric(userenter, out int corrnum2) == false) & (userenter.Length >= 2))
            {
                corrtext = userenter;
                return true;
            }
            else
            {
                corrtext = string.Empty;
                return false;
            }

        }
        protected static bool ChekForNumeric(string userenter, out int corrnumeric)
        //метод проеряет корректность заполнения числовых данных
        //метод Console.Beep(1000, 300) можно раскоментировать если код выполняется на платформе Windows
        {
            if (int.TryParse(userenter, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumeric = intnum;
                    return true;
                }
                else
                {
                    // Console.Beep(1000, 300);
                    corrnumeric = 0;
                    return false;
                }
            }
            else
            {
                // Console.Beep(1000, 300);
                corrnumeric = 0;
                return false;
            }

        }
    }
}
