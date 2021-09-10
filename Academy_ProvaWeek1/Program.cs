using Academy_ProvaWeek1.Entities;
using Academy_ProvaWeek1.Handler_Approvazione;
using System;
using System.Collections.Generic;
using System.IO;

namespace Academy_ProvaWeek1
{
    class Program
    {

        static void Main(string[] args)
        {
                //gestione evento creazione del file
                EventHandler.Monitor();
            if (EventHandler.elencoSpese.Count==0)
            {
                Console.WriteLine("non ci sono spese nel file inserito!;");
                    return;
            }
                // Controllo per approvazione 
                IHandler manager = new ManagerHandler();
                IHandler opManager = new OpManagerHandler();
                IHandler ceo = new CEOHandler();
                manager.SetNext(opManager).SetNext(ceo);

                foreach (Spesa s in EventHandler.elencoSpese)
                {
                    Console.WriteLine();
                    Console.WriteLine($"La richiesta di rimborso {s.Descrizione} di euro {s.Importo} è stata: ");
                    string result = manager.Handle(s);
                    Console.WriteLine(result);
                    //Console.WriteLine(s.Approvata + " DA " + s.LvlApprovazione);

                    //Calcolo rimborso
                    if (s.Approvata)
                    {
                        CategoriaFactory catFactory = new CategoriaFactory(s);
                        ICategoria currCategoria = catFactory.CatRimborso();
                        currCategoria.CalcolaRimborso(s);
                    }
                    Console.WriteLine($"Verrà rimborsato l'importo: {s.ImportoRimborsato}");
                }

                //Creazione nuovo file 
                WriteOnFile(EventHandler.elencoSpese);

                
            
        }

        private static void WriteOnFile(List<Spesa> elencoSpese)
        {
            string filePath = @"C:\Users\laura.martines\Desktop\progetti\Academy\Prove\Academy_TestWeek1\spese_elaborate.txt";
            try
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {

                    writer.WriteLine("Data;Categoria;Stato;LvlApprov;ImportoRimborsato");
                    foreach (Spesa s in elencoSpese)
                    {
                        if (s.Approvata)
                        {
                            writer.WriteLine($"{s.Data.ToShortDateString()};{s.Categoria};{s.Descrizione}; APPROVATA;" +
                                $"{s.LvlApprovazione};{s.ImportoRimborsato}");
                        }
                        else
                        {
                            writer.WriteLine($"{s.Data.ToShortDateString()};{s.Categoria};{s.Descrizione}; RESPINTA;-;-");
                        }
                    }


                }
            }
            catch (IOException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            Console.WriteLine("Scrittura file avvenuta con successo");
        }
    }
}

