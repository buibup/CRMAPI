using CRMWebApi.Common;
using CRMWebApi.DA.InterSystems;
using CRMWebApi.DA.SqlServer;
using CRMWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMWebApi.CRMWebApi
{
    public class GetData
    {
        public static string GetHospitalSite(string siteCode)
        {
            string hos = string.Empty;

            var cmdString = QueryString.GetHospitalSites(siteCode);
            hos = InterSystemsDA.BindDataCommand(cmdString, Constants.Chache89);

            return hos;
        }

        public static List<PatientHN> GetPatients(string siteCode, string year)
        {
            List<PatientHN> patietns = new List<PatientHN>();

            var cmdString = QueryString.GetPatientsHN(siteCode, year);
            //var dt = InterSystemsDA.DTBindDataCommand(cmdString, Constants.Chache89);

            var dt = SqlServerDA.DataTableBindDataCommand(cmdString, Constants.svhsql3);

            patietns = Helper.DataTableToPatientList(dt);

            return patietns;
        }

        public static List<PatientHN> GetPatients(string siteCode, string year, string month)
        {
            List<PatientHN> patietns = new List<PatientHN>();

            var cmdString = QueryString.GetPatientsHN(siteCode, year, month);
            //var dt = InterSystemsDA.DTBindDataCommand(cmdString, Constants.Chache89);

            var dt = SqlServerDA.DataTableBindDataCommand(cmdString, Constants.svhsql3);

            patietns = Helper.DataTableToPatientList(dt);

            return patietns;
        }

        public static PatientInfo GetPatientInfo(string hn)
        {
            PatientInfo ptInfo = new PatientInfo();

            var cmdString = QueryString.GetPatientInfo(hn);
            var dt = InterSystemsDA.DTBindDataCommand(cmdString, Constants.Chache89);

            ptInfo = Helper.DataTableToPatientInfo(dt);

            return ptInfo;
        }

        public static List<Allergen> GetAllergens(string hn)
        {
            List<Allergen> results = new List<Allergen>();

            var cmdString = QueryString.GetAllergy(hn);
            var dtAlg = InterSystemsDA.DTBindDataCommand(cmdString, Constants.Chache89);

            results = Helper.DataTableToAllergen(dtAlg);

            return results;
        }

        public static string GetAllergenCategory(string algName)
        {
            string result = string.Empty;

            var cmdString = QueryString.GetAllergyCategory(algName);
            result = InterSystemsDA.BindDataCommand(cmdString, Constants.Chache89);

            return result;
        }

        public static List<PatientEmail> GetPatientEmail(string hn)
        {
            List<PatientEmail> result = new List<PatientEmail>();

            var cmdString = QueryString.GetPatientEmail(hn);
            var dt = InterSystemsDA.DTBindDataCommand(cmdString, Constants.Chache89);

            result = Helper.DataTableToEmailList(dt);

            return result;
        }

        public static List<PatientPhone> GetPatientPhone(string hn)
        {
            List<PatientPhone> result = new List<PatientPhone>();

            var cmdString = QueryString.GetPatientPhone(hn);
            var dt = InterSystemsDA.DTBindDataCommand(cmdString, Constants.Chache89);

            result = Helper.DataTableToPatientPhon(dt);

            return result;
        }

        public static PatientEpisode GetPatientEpisodes(string hn)
        {
            PatientEpisode ptEpi = new PatientEpisode();

            var cmdString = QueryString.GetPatientEpisodes(hn);
            //var dt = InterSystemsDA.DTBindDataCommand(cmdString, Constants.Chache89);
            var dt = InterSystemsDA.GetDTGetPatientEpisode(hn);

            ptEpi = Helper.DataTablePatientEpisode(dt, hn);

            return ptEpi;
        }

        public static List<Location> GetAllLocations(string siteCode)
        {
            List<Location> locs = new List<Location>();

            var cmdString = QueryString.GetAllLocations(siteCode);
            var dt = InterSystemsDA.DTBindDataCommand(cmdString, Constants.Chache89);

            locs = Helper.DataTableToLocationsList(dt);

            return locs;
        }

        public static double GetRevenueByEPI(string epino)
        {
            double revenue = 0.0;

            var cmdString = QueryString.GetRevenueFromCache(epino);
            var rev = InterSystemsDA.BindDataCommand(cmdString, Constants.Chache89);
            var result = double.TryParse(rev, out revenue) ? revenue : 0.0;

            return result;
        }
    }
}