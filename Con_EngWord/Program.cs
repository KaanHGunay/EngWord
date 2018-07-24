using System;
using DataBase;

namespace Con_EngWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EngWord'e Hoşgeldiniz!\n" +
                "Kelime eklemek için 1 e basınız");
            string Secim = Console.ReadLine();

            if (Secim == "1")
            {
                EngWord engWord = new EngWord();
                Console.WriteLine("Eklenecek İngilizce kelimeyi giriniz:    ");
                engWord.Word = Console.ReadLine();
                Console.WriteLine("Kelimenin Türkçe karşılığını giriniz:    ");
                TurWord turWord = new TurWord
                {
                    Word = Console.ReadLine()
                };                
                engWord.TurWords.Add(turWord);

                while (true)
                {
                    Console.WriteLine("Diğer anlamları giriniz (Başka girmek istemiyorsanız H yazınız)");
                    string cevap = Console.ReadLine();
                    if (cevap.ToLower() == "h") break;
                    TurWord word = new TurWord
                    {
                        Word = Console.ReadLine()
                    };
                    engWord.TurWords.Add(word);
                }

                Console.WriteLine(String.Format("İngilizce kelime: {0}\nAnlam(lar)ı: ", engWord.Word));
                foreach (var item in engWord.TurWords)
                {
                    Console.WriteLine(item.Word);
                }

                Console.WriteLine("\nKelimeyi Kabul Ediyor Musunuz? (E/H)");
                string cvp = Console.ReadLine();
                while (true)
                {
                    if (cvp.ToLower() == "e")
                    {
                        using (var db = new Context())
                        {
                            db.EngWords.Add(engWord);
                            db.SaveChanges();
                        }
                        Console.WriteLine("Kelime Başarı İle Eklendi!");
                        break;
                    }
                    else if (cvp.ToLower() == "h")
                    {
                        Console.WriteLine("Kelime Eklemeden Vazgeçildi.");
                    }
                    else
                    {
                        cvp = Console.ReadLine();
                    }
                }
            }
        }
    }
}
