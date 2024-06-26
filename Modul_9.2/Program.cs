namespace Modul_9._2
{
    public class SortEventArgs : EventArgs
    {
        public int SortType { get; set; }
    }

    public class MyOwnException : System.Exception
    {
        public MyOwnException(string message)
            : base(message)
        {
        }
    }

    public class NameSorter
    {
        // Событие для сортировки
        public event EventHandler<SortEventArgs> SortEvent;

        public void OnSortEvent(int sortType)
        {
            SortEvent.Invoke(this, new SortEventArgs() { SortType = sortType });
        }

        // Метод сортировки
        public void SortNames(List<string> names, int sortType)
        {
            if (sortType == 1)
            {
                names.Sort(); // Сортировка А-Я
            }
            else if (sortType == 2)
            {
                names.Sort((a, b) => b.CompareTo(a)); // Сортировка Я-А
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var nameSorter = new NameSorter();
            nameSorter.SortEvent += (sender, e) =>
            {
                List<string> names = new List<string> { "Ли", "Ким", "Пак", "Хон", "Чо" };
                nameSorter.SortNames(names, e.SortType);
            };

            try
            {
                Console.WriteLine("Введите 1 для сортировки А-Я или 2 для сортировки Я-А:");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input != 1 && input != 2)
                    throw new MyOwnException("Неверный ввод. Введите 1 или 2.");
                nameSorter.OnSortEvent(input);
            }
            catch (MyOwnException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Операция завершена. Запустите программу еще раз");
            }
        }
    }
}
