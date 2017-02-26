using CRMAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMAPI.Models
{
    public class CRMRepository : ICRMRepository
    {

        static List<string> hn = new List<string>(new string[]
        {
            "11-17-000000",
            "11-17-000001",
            "11-17-000002",
            "11-17-000003",
        });

        static Dictionary<string, string> email = new Dictionary<string, string>()
        {
            { "11-17-000000", "email0@gmail.com"  },
            { "11-17-000001", "email1@gmail.com"  },
            { "11-17-000002", "email2@gmail.com"  },
            { "11-17-000003", "email3@gmail.com"  },
        };

        static List<PatientEpisode> PatientEpisode = new List<Models.PatientEpisode>()
        {
            
        };

        public IEnumerable<string> GetHospitalSite(string siteCode)
        {
            return hn;
        }

        public IEnumerable<string> GetPatient(string siteCode, string year)
        {
            return hn;
        }

        public string GetPatientEmail(string hn)
        {
            if (email.ContainsKey(hn))
            {
                return email[hn];
            }else
            {
                return "not match email";
            }
        }

        public PatientEpisode GetPatientEpisode(string hn)
        {
            throw new NotImplementedException();
        }

        public PatientInfo GetPatientInfo(string hn)
        {
            throw new NotImplementedException();
        }

        public PatientPhone GetPatientPhone(string hn)
        {
            throw new NotImplementedException();
        }
    }
}