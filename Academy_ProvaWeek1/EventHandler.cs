using Academy_ProvaWeek1.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_ProvaWeek1
{
    class EventHandler
    {
        public static List<Spesa> elencoSpese = new List<Spesa>();

        internal static void Monitor()
        {
            FileSystemWatcher fsw = new FileSystemWatcher
            {
                Path = @"C:\Users\laura.martines\Desktop\progetti\Academy\Prove\Academy_TestWeek1\",
                Filter = "spese.txt"
            };
            fsw.EnableRaisingEvents = true;

            //fsw.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.FileName;


            fsw.Created += Read;

            Console.WriteLine("Premi q per uscire");
            while (Console.Read() != 'q') ;
        }

        internal static void Read(object sender, FileSystemEventArgs e)
        {
            elencoSpese = ReadFile(e);
            Console.WriteLine($"File {e.Name} letto con successo");
        }

        private static List<Spesa> ReadFile(FileSystemEventArgs e)
        {
            List<Spesa> elSpese = new List<Spesa>();
            try
            {
                using (StreamReader reader = File.OpenText(e.FullPath))
                {
                    string header = reader.ReadLine();
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        Spesa s = new Spesa();
                        var dati = line.Split(";");
                        s.Data = DateTime.Parse(dati[0]);
                        s.Categoria = estraiCategoria(dati[1].Trim());
                        s.Descrizione = dati[2];
                        s.Importo = double.Parse(dati[3]);
                        line = reader.ReadLine();
                        elencoSpese.Add(s);
                    }
                }
                return elencoSpese;
            }
            catch (IOException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private static Categoria estraiCategoria(string cat)
        {
            Categoria newCat = new Categoria();
            switch (cat)
            {
                case "Viaggio":
                    newCat = Categoria.Viaggio;
                    break;
                case "Alloggio":
                    newCat = Categoria.Alloggio;
                    break;
                case "Vitto":
                    newCat = Categoria.Vitto;
                    break;
                case "Altro":
                    newCat = Categoria.Altro;
                    break;
                default:
                    break;
            }
            return newCat;
        }
    }
}
