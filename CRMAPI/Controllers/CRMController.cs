using CRMWebApi.Common;
using CRMWebApi.Models;
using CRMWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRMWebApi.Controllers
{
    public class CRMController : ApiController
    {
        CRMRepository crm = new CRMRepository();
        public IEnumerable<Hospital> GetHospitalSites()
        {
            return crm.GetHospitalSite();
        }

        public IEnumerable<PatientHN> GetPatients(string siteCode, string year)
        {
            return crm.GetPatient(siteCode, year);
        }

        public IEnumerable<PatientHN> GetPatients(string siteCode, string year, string month)
        {
            return crm.GetPatient(siteCode, year, month);
        }

        public PatientInfo GetPatientInfo(string hn)
        {
            return crm.GetPatientInfo(hn);
        }

        public IEnumerable<PatientEmail> GetPatientEmail(string hn)
        {
            return crm.GetPatientEmail(hn);
        }

        public List<PatientPhone> GetPatientPhone(string hn)
        {
            return crm.GetPatientPhone(hn);
        }

        public PatientEpisode GetPatientEpisode(string hn)
        {
            return crm.GetPatientEpisode(hn);
        }

        public IEnumerable<Location> GetAllLocation(string siteCode)
        {
            return crm.GetAllLocations(siteCode);
        }
    }
}
