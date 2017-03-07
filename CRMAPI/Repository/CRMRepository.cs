using CRMWebApi.Common;
using CRMWebApi.CRMWebApi;
using CRMWebApi.Models;
using CRMWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMWebApi.Repository
{
    public class CRMRepository : ICRMRepository
    {
        public IEnumerable<Location> GetAllLocations(string siteCode)
        {
            return GetData.GetAllLocations(siteCode);
        }

        public List<Hospital> GetHospitalSite()
        {
            List<Hospital> hospitals = new List<Hospital>
            {
                new Hospital { Code = "011", Description = "รพ.สมิติเวชสุขุมวิท" },
                new Hospital { Code = "012", Description = "รพ.สมิติเวชศรีนครินทร์" }
            };
            return hospitals;
        }

        public IEnumerable<PatientHN> GetPatient(string siteCode, string year)
        {
            return GetData.GetPatients(siteCode, year);
        }

        public IEnumerable<PatientHN> GetPatient(string siteCode, string year, string month)
        {
            return GetData.GetPatients(siteCode, year, month);
        }

        public List<PatientEmail> GetPatientEmail(string hn)
        {
            return GetData.GetPatientEmail(hn);
        }

        public PatientEpisode GetPatientEpisode(string hn)
        {
            return GetData.GetPatientEpisodes(hn);
        }

        public PatientInfo GetPatientInfo(string hn)
        {
            return GetData.GetPatientInfo(hn);
        }

        public List<PatientPhone> GetPatientPhone(string hn)
        {
            return GetData.GetPatientPhone(hn);
        }
    }
}