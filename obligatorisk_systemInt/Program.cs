using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace obligatorisk_systemInt
{
    class Program
    {
        static void Main(string[] args)
        {

            EUCCID_system euccidSys = new EUCCID_system(@".\Private$\EUCCID SYSTEM");
           
       
            CPR_system cprSys = new CPR_system(@".\Private$\CPR SYSTEM");
       
          
            DataConversion(euccidSys);
      

        }

        private static void DataConversion(EUCCID_system sys)
        {
            string checkString = "t";
           
            Console.WriteLine("Original danish cpr formate:" + Environment.NewLine);
            var cprDat = new CPRRegisterData("Placeholder navn", "Hansen", "251194-1320", "Nillikevej 4", "Nillikevej 2", 8260, "Example City", AegteskabeligStatus.Unmarried, "212998-3454", "348799-9854", "348754-9876", "109612-1134", "495949-3245");
            Console.WriteLine(cprDat.Fornavn + " | " + cprDat.Efternavn + " | " + cprDat.CPRNummer + " | " + cprDat.PrimaerAdresse + " | " + cprDat.SekundaeAdresse + Environment.NewLine + " | " + cprDat.PostNummer + " | " + cprDat.By + Environment.NewLine + " | " + cprDat.AegteskabeligStatus + " | " + cprDat.AegtefaelleCPRNr + Environment.NewLine + " | " + cprDat.BoernCPRNr + " | " + cprDat.LaegeCVRNr);

            Console.WriteLine(Environment.NewLine + "Enter a random cpr in the format 'xxxxxx-xxxx' to choose the gender of the child");
            string cprInput = Console.ReadLine();

            Console.WriteLine(Environment.NewLine +"Enter the following to translate original danish formate to EUCCID formate: 't'");

        
                var input = Console.ReadLine();
               
                if (input == checkString)
                {
                   var something = new CPRRegisterData("Placeholder name", "Hansen", cprInput, "Nillikevej 4", "Nillikevej 2", 8260, "Example city", AegteskabeligStatus.Unmarried, "212998-3454", "348799-9854", "348754-9876", "109612-1134", "495949-3245");
                //Send message
                    sys.MsMq.Send(something);
                }
                if (input != checkString)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid command!" + Environment.NewLine + "-> Try again");
                }

                                        
                Console.ReadLine();
            }
            
        
    }
}
