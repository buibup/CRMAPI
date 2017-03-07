using CRMWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMWebApi.Repository
{
    public interface ICRMRepository
    {
        List<Hospital> GetHospitalSite();
        IEnumerable<PatientHN> GetPatient(string siteCode, string year);
        IEnumerable<PatientHN> GetPatient(string siteCode, string year, string month);
        PatientInfo GetPatientInfo(string hn);
        List<PatientEmail> GetPatientEmail(string hn);
        List<PatientPhone> GetPatientPhone(string hn);
        PatientEpisode GetPatientEpisode(string hn);
        IEnumerable<Location> GetAllLocations(string siteCode);
    }
}