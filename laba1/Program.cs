using System.Text;
using Newtonsoft.Json;

namespace laba1._2._0
{
    internal static class Program
    {
        class Num
        {
            public int x;
            public int y;

            public Num() // конструктор який ініціалізує члени классу за замавченням
            {
                x = 2;
                y = 5;
            }

            public Num(int a, int b) // конструктор з вхідними параметрами
            {
                x = a;
                y = b;

            }
            public void Show_Vars()
            {
                Console.WriteLine($"{x}, {y}");
            }
            public int Sum()
            {
                return x + y;
            }
            public int Diff()
            {
                return x - y;
            }
            public float Multiplication()
            {
                return x * y;
            }
            public float Division()
            {
                return x / y;
            }
            public double Math_root()
            {
                return Math.Pow(x, 1.0 / y);
            }

            public Num CreatObjectFromJson(string fileName)
            {
                StreamReader r = new StreamReader(fileName);
                string jsonString = r.ReadToEnd();
                Num c = JsonConvert.DeserializeObject<Num>(jsonString);
                return c;
            }
            public void WriteObjectToJson(Num data, string fileName)
            {
                Console.WriteLine(data.x);
                try
                {
                    string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                    File.WriteAllText(fileName, json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            string fileName = "C:/Users/Windows 10/Documents/2 семестр/ОП/laba1/laba1/text1.json";
            string readyObjectFileName = "C:/Users/Windows 10/Documents/2 семестр/ОП/laba1/laba1/readeObject.json";

            Num first_num = new Num();
            Num second_num = new Num(10, 15);

            Console.WriteLine("Початкові числа:");
            second_num.Show_Vars();
            Console.WriteLine($"Сумма чисел: {second_num.Sum()}");
            Console.WriteLine($"Різниця чисел: {second_num.Diff()}");
            Console.WriteLine($"Множення чисел: {second_num.Multiplication()}");
            Console.WriteLine($"Ділення чисел: {second_num.Division()}");
            Console.WriteLine($"Корінь числа: {second_num.Math_root()}");


            first_num.WriteObjectToJson(first_num, fileName);
            Num third_num = first_num.CreatObjectFromJson(readyObjectFileName);
            Console.WriteLine("Об'єкт з json файлу:");
            third_num.Show_Vars();
        }
    }
}
