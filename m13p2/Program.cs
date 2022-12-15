
using static System.Net.Mime.MediaTypeNames;

namespace m13p2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            List<char> list = new List<char>();
            LinkedList<char> linkedList = new LinkedList<char>();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            // читаем весь файл с рабочего стола в строку текста
            string text = File.ReadAllText(Path.Combine(projectDirectory, "Text1.txt"));
            string cleaned = text.Replace("\n", " ");
            var noPunctuationText = new string(cleaned.Where(c => !char.IsPunctuation(c)).ToArray());
            //Разобьем на массив слов
            string[] words = noPunctuationText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            SortedDictionary<string, int> wordCountPair = new SortedDictionary<string, int>();
            foreach (var word in words)
            {
                if (wordCountPair.ContainsKey(word))
                    wordCountPair[word]++;
                else
                    wordCountPair.Add(word, 1);
            }
            int maxValue = wordCountPair.Values.Max();
            
            var mRep = from wc in wordCountPair
                       where wc.Value == maxValue
                       select wc.Key;
            foreach (var item in mRep)
            {
                Console.WriteLine($"Слово -{item}- встречается {maxValue} раз в этом тексте.");
            }
            
            


        }
    }
}