using PV.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Practice Velocity - Coding Problem - Console Application");

            Console.WriteLine();
            Console.WriteLine();

            List<string> providerList = EventProviderManager.ProviderList();

            string choice = string.Empty;

            do
            {
                Console.WriteLine("-----------------------------------------------------------");
                
                for (int i = 0; i < providerList.Count; i++)
                {
                    EventTypeBase provider = EventProviderManager.Providers[providerList[i]];

                    Console.WriteLine(string.Format("{0}. {1}", i, provider.Name));
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter the number to generate results for event type (just hit enter to exit): ");


                choice = Console.ReadLine();

                if (choice == string.Empty)
                    break;

                int providerIndex = 0;

                if (int.TryParse(choice, out providerIndex))
                {
                    if (providerIndex >= 0 && providerIndex < providerList.Count)
                    {
                        EventTypeBase provider = EventProviderManager.Providers[providerList[providerIndex]];

                        Console.WriteLine();
                        Console.WriteLine(string.Format("The \"{0}\" event type was selected.", provider.Name));
                        Console.WriteLine();

                        List<string> results = provider.GetResults();

                        foreach (string item in results)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                
            } while (choice != string.Empty);            
        }
    }
}
