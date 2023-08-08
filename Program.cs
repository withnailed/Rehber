using System.ComponentModel;
using System.Text.Json;

namespace SerializeToFile
{

    public class Person
    {
        public int KayitNo { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Rehber
    {
        public List<Person> Person { get; set; } = new();
    }
    public class Program
    {
        public static void Main()
        {
            Rehber rehber = new Rehber();
            string fileName = @"c:\Temp\Rehber.json";
            string jsonString = File.ReadAllText(fileName);
            string x = null;
            int sacac = 0;

            if (jsonString != null && jsonString != string.Empty && jsonString.Length != 13)
            {
                rehber = JsonSerializer.Deserialize<Rehber>(jsonString);
            }
            else
            {
                Console.WriteLine("Rehberin içi boş kayıt giriniz");
            }

            while (x != "q")
            {
                Console.WriteLine("Ekleme yapmak için 'a' basınız. ");
                Console.WriteLine("Listeleme yapmak için 'l' basınız. ");
                Console.WriteLine("Silme yapmak için 'r' basınız. ");
                Console.WriteLine("Arama yapmak için 's' basınız. ");
                Console.WriteLine("Çıkış yapmak için 'q' basınız. ");
                x = Console.ReadLine();
                if (x == "a")
                {
                    appened(rehber);
                }
                if (x == "r")
                {
                    remove(sacac, rehber);
                }
                if(x == "l") 
                {
                    foreach (var item in rehber.Person)
                    {
                        Console.WriteLine($"Kayıt No: {item.KayitNo}");
                        Console.WriteLine($"İsim: {item.Name}");
                        Console.WriteLine($"Numara: {item.Number}");
                    }
                }
                if (x == "s")
                {
                    search(rehber);
                }

            }

            jsonString = JsonSerializer.Serialize(rehber);

            File.WriteAllText(fileName, jsonString);

            Console.WriteLine(File.ReadAllText(fileName));

        }

        
        public static void appened(Rehber rehber)
        {
            int sayac;
            if (rehber == null )
            {
                sayac = 0;
            }
            else
            {
                sayac = rehber.Person.Last().KayitNo + 1;
            }
            Person person = new();
            Console.WriteLine("-----------------------------");
            Console.Write("Önce isim giriniz: ");
            person.KayitNo = sayac;
            person.Name = Console.ReadLine();
            Console.Write("Numara giriniz: ");
            int b = Convert.ToInt32(Console.ReadLine());
            person.Number = b;
            rehber.Person.Add(person);
        }
        public static void remove(int sacac, Rehber rehber)
        {
            Console.WriteLine("İsme göre silmek için 1 e basınız, numaraya göre silmek için 2 ye basınız.");
            int c=Convert.ToInt32(Console.ReadLine());
            if (c == 1)
            {
                Console.Write("isim giriniz: ");
                string ad=Console.ReadLine();
                var test = rehber.Person.FirstOrDefault(x => x.Name == ad);
                bool son = rehber.Person.Remove(test);
                if (son == true)
                {
                    Console.WriteLine("Öğe silindi...");
                }
                else
                {
                    Console.WriteLine("Başarısız silinemedi.");
                }
            }
            else if (c == 2)
            {
                Console.Write("Numara giriniz: ");
                int num=Convert.ToInt32(Console.ReadLine());
                var test = rehber.Person.FirstOrDefault(x => x.Number == num);
                bool son = rehber.Person.Remove(test);
                if (son== true)
                {
                    Console.WriteLine("Öğe silindi...");
                }
                else
                {
                    Console.WriteLine("Başarısız silinemedi.");
                }
                
            }
            else if (c !=1 || c!=2) 
            {
                Console.WriteLine("Hatalı giriş ana menüye yönlendiriyoruz.");
            }
        }
        public static void search(Rehber rehber)
        {
            Console.Write("Arama yapılacak isimi giriniz: ");
            string ara= Console.ReadLine();
            foreach (var item in rehber.Person)
            {
                if (item.Name ==ara)
                {
                    Console.WriteLine("Bulundu no: "+ item.Number);
                    break;
                }
            }

        }
       
    }
}





