using CRMAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMAPI.Repository
{
    public interface ICRMRepository
    {
        IEnumerable<string> GetHospitalSite(string siteCode);
        IEnumerable<string> GetPatient(string siteCode, string year);
        PatientInfo GetPatientInfo(string hn);
        string GetPatientEmail(string hn);
        PatientPhone GetPatientPhone(string hn);
        PatientEpisode GetPatientEpisode(string hn);
    }
}