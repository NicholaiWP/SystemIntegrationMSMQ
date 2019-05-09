using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace obligatorisk_systemInt
{
    public enum AegteskabeligStatus { Unmarried, Married, None}

    [Serializable]
    public struct CPRRegisterData
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string CPRNummer { get; set; }
        public string PrimaerAdresse { get; set; }
        public string SekundaeAdresse { get; set; }
        public int PostNummer { get; set; }
        public string By { get; set; }
        public AegteskabeligStatus AegteskabeligStatus { get; set; }
        public string AegtefaelleCPRNr { get; set; }
        public string BoernCPRNr { get; set; }
        public string ForaeldresCPRNr { get; set; }
        public string LaegeCVRNr { get; set; }
        public string EU_CCID { get; set; }

        public CPRRegisterData(string fornavn, string efternavn, string cprNum, string addresse1, string addresse2, int postNum,string by,
            AegteskabeligStatus marriedStatus, string aegtefaelleCPR, string boernCPR, string foraeldreCPR, string lægeCVR, string euccid)
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            CPRNummer = cprNum;
            PrimaerAdresse = addresse1;
            SekundaeAdresse = addresse2;
            PostNummer = postNum;
            By = by;
            AegteskabeligStatus = marriedStatus;
            AegtefaelleCPRNr = aegtefaelleCPR;
            BoernCPRNr = boernCPR;
            ForaeldresCPRNr = foraeldreCPR;
            LaegeCVRNr = lægeCVR;
            EU_CCID = euccid;
        }
    }
}
