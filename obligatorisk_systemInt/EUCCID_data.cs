using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace obligatorisk_systemInt
{
    public enum Gender { Female, Male}

    [Serializable]
    public struct EUCCIDRegisterData
    {
        public string CristianName { get; set; }
        public string FamilyName { get; set; }
        public string EU_CCID { get; set; }
        public Gender Gender { get; set; }
        public string StreetAndNumberOfHouse { get; set; }
        public string ApartmentNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string BirthCountry { get; set; }
        public string CurrentLivingCountry { get; set; }
        public string Nationality { get; set; }

        public EUCCIDRegisterData(string ChristName, string famName, string euccid, Gender gender, string streetAndnumbOfHouse, string apartNum,
            string country, string city, string birthCountry, string currentLiving, string nationality)
        {
            CristianName = ChristName;
            FamilyName = famName;
            EU_CCID = euccid;
            Gender = gender;
            StreetAndNumberOfHouse = streetAndnumbOfHouse;
            ApartmentNumber = apartNum;
            Country = country;
            City = city;
            BirthCountry = birthCountry;
            CurrentLivingCountry = currentLiving;
            Nationality = nationality;
        }
    }
}
