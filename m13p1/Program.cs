using System.Diagnostics;

namespace m13p1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Сравнение производительности списка и связного списка

            List<char> list = new List<char>();
            LinkedList<char> linkedList = new LinkedList<char>();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText(Path.Combine(projectDirectory, "Text1.txt"));
            foreach (var item in text)
            {
                list.Add(item);
                linkedList.AddFirst(item);
            }
            // Проверяем обычный список
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < 4000; i++)
            {
                list.Insert(500, 'M');
            }
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            // Результат
            Console.WriteLine($"list: {ts.TotalMilliseconds.ToString()}");
            // Проверяем связный список
            LinkedListNode<char> node = linkedList.First;
            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            for (int i = 0; i < 4000; i++)
            {
                linkedList.AddAfter(node, 'p');
            }
            stopWatch2.Stop();
            TimeSpan ts2 = stopWatch2.Elapsed;
            // Результат
            Console.WriteLine($"LinkedList: {ts2.TotalMilliseconds}");

        }
    }
}