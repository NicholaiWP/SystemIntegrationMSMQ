using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace obligatorisk_systemInt
{
    public static class Translator
    {
        public static EUCCIDRegisterData CPRRegisterDataTranslation(CPRRegisterData cprData)
        {
            //from cpr format to euccid format
           
         
            string[] boyNames = new string[5] { "Mikkel", "Thomas", "Bob", "Ib", "Soeren" };
            string[] girlNames = new string[5] { "Line", "Camilla", "Britney", "Josephine", "Fie" };

            string[] addressOne = cprData.PrimaerAdresse.Split(',');
            string[] addressTwo = cprData.SekundaeAdresse.Split(',');

            string[] cprFormat = cprData.CPRNummer.Split('-');

            Gender peopleGender;
            Random rand = new Random();
            if (int.Parse(cprFormat[1]) % 2 == 0)
            {
                peopleGender = Gender.Female;
               
                int index = rand.Next(boyNames.Length);
                cprData.Fornavn = girlNames[index];
                
            }
            else
            {
                peopleGender = Gender.Male;
              
               int index = rand.Next(girlNames.Length);
                cprData.Fornavn = boyNames[index];                             
            }


            int length = 2;
            int start = 2;
            string yy = cprFormat[0].Substring(cprFormat[0].Length - start, length);

            string time = DateTime.Now.Year.ToString();

            int length2 = 2;
            int start2 = 2;
            time = time.Substring(time.Length - start2, length2);

            string EUCCID = "";
            Random cprExtendRandom = new Random();

            if (int.Parse(yy) <= int.Parse(time))
            {
                
                cprFormat[0] = cprFormat[0].Remove(cprFormat[0].Length - 2) + cprExtendRandom.Next(11,22) + yy;

                EUCCID = cprFormat[0] + "-" + cprFormat[1] + cprExtendRandom.Next(10, 101).ToString();
            }
            else
            {
                cprFormat[0] = cprFormat[0].Remove(cprFormat[0].Length - 2) + cprExtendRandom.Next(11,22) + yy;

                EUCCID = cprFormat[0] + "-" + cprFormat[1] + cprExtendRandom.Next(10, 101).ToString();
            }


            if(addressOne.Length > 1)
            {
                if (addressTwo.Length > 1)
                {
                    return new EUCCIDRegisterData(cprData.By, cprData.PostNummer.ToString(), EUCCID, peopleGender, cprData.Efternavn, cprData.Fornavn, addressOne[0] + "-" + addressTwo[0],
                        cprData.CPRNummer, "DK", addressOne[1] + "-" + addressTwo[1], "Danish");
                }
            }

            if(addressTwo.Length > 1)
            {
                return new EUCCIDRegisterData(cprData.By, cprData.PostNummer.ToString(), EUCCID, peopleGender, cprData.Efternavn, cprData.Fornavn, cprData.PrimaerAdresse + "-" + addressTwo[0],
                    cprData.CPRNummer, "Denmark", "None-" + addressTwo[1], "Danish");
            }

            return new EUCCIDRegisterData(cprData.By, cprData.PostNummer.ToString(), EUCCID, peopleGender, cprData.Efternavn, cprData.Fornavn, cprData.PrimaerAdresse + "-" + cprData.SekundaeAdresse,
               cprData.CPRNummer, "Denmark", "None", "Danish");

        }
    }
}
