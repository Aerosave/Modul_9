using System;

namespace ExceptionFromModulNine
{

    // 1.Создайте свой тип исключения
    public class MyOwnException : System.Exception
    {
        public MyOwnException(string message) 
            : base(message)
        {
        }
    }
    // Массив из пяти различных видов исключений с моим
    class Program
    {
        static void Main()
        {
            // Массив исключений
            Exception[] exceptions = new System.Exception[]
            {
            new MyOwnException("Мое исключение"),
            new ArgumentException("Непустой аргумент, передаваемый в метод, является недопустимым."),
            new IndexOutOfRangeException("Индекс вне диапазона"),
            new ArgumentNullException("Аргумент со значением null"),
            new DivideByZeroException("Деление на ноль")
            };

            // Итерация по массиву исключений
            foreach (var ex in exceptions)
            {
                try
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Исключение: {e.Message}");
                }
                finally
                {
                    // Блок finally по желанию
                    Console.WriteLine("Блок finally выполнен.");
                }
            }
        }
    }

}

