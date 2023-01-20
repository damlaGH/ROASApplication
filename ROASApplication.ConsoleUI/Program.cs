
using ROASApplication.Business;
using ROASApplication.Data;

namespace ROASApplication
{
    public class Program
    {
        public static void Main()
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. New ROAS\n2. ROAS list\n3. Search\n4. Exit");
            MenuSelection();
        }

        static void MenuSelection()
        {
            Console.Write("Please choose from Menu:");
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "1":
                    NewRoas();
                    break;
                case "2":
                    ListOfROAS();
                    break;
                case "3":
                    Search();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Choose is not valid!");
                    MenuSelection();
                    break;
            }
        }

        private static void Search()
        {

            Console.Write("Please write which chanel name do you want to see : ");
            string filterKey = Console.ReadLine();
            var data = ROASService.SearchFromChannelName(filterKey);

            WriteFromList(data);  //buraya WriteToScreen(data) demiştik ama bu ifadeyi ListOfROAS ın içinde de
                                  //kullancağımız ve kod tekrarı olacağından WriteFromList i tanımladık
            Again();
        }

        private static void ListOfROAS()
        {
            var roasList = ROASService.GetROASList();
            WriteFromList(roasList);

            Again();
        }
        private static void WriteFromList(IReadOnlyCollection<ROAS> list)
        {
            foreach (ROAS x in list)
            {
                WriteToScreen(x);
            }
        }
        private static void NewRoas()
        {
            ROAS newROAS = new ROAS();//örnek alma, türetme, instance
            Console.Write("Channel Name : ");
            newROAS.channelName = Console.ReadLine();
            Console.Write("Cost Of Advertising : ");
            newROAS.costOfAdvertising = Convert.ToDouble(Console.ReadLine());
            Console.Write("Sold Pieces : ");
            newROAS.soldPieces = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price Per Unit : ");
            newROAS.pricePerUnit = Convert.ToDouble(Console.ReadLine());

            ROASService.SaveROAS(newROAS);

            WriteToScreen(newROAS);
            Again();
        }

        private static void Again()
        {
            Console.WriteLine("Please ENTER for return to the Menu");
            Console.ReadLine();
            Menu();
        }

        static void WriteToScreen(ROAS r)
        {
            Console.WriteLine($" ROAS : {r.CalcROAS()}");
        }
    }


}




