using CRMWebApi.Common;
using CRMWebApi.CRMWebApi;
using InterSystems.Data.CacheClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CRMWebApi.DA.InterSystems
{
    public class InterSystemsDA
    {
        public static DataTable DTBindDataCommand(string cmdString, string conString)
        {
            DataTable dt = new DataTable();

            using(var con = new CacheConnection(conString))
            {
                using(var adp = new CacheDataAdapter(cmdString, con))
                {
                    adp.Fill(dt);
                }
            }

            return dt;
        }

        public static DataSet DSBindDataCommand(string cmdString, string conString)
        {
            DataSet ds = new DataSet();

            using(var con = new CacheConnection(conString))
            {
                using(var adp = new CacheDataAdapter(cmdString, conString))
                {
                    adp.Fill(ds);
                }
            }

            return ds;
        }

        public static string BindDataCommand(string cmdString, string conString)
        {
            string result = string.Empty;

            using(var con = new CacheConnection(conString))
            {
                con.Open();
                using(var cmd = new CacheCommand(cmdString, con))
                {
                    result = cmd.ExecuteScalar().ToString();
                }
            }

            return result;
        }

        public static DataTable GetDTGetPatientEpisode(string hn)
        {
            //string dateFrom = DateTime.Now.ToString("yyyy-MM-dd");
            //string dateTo = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                DataTable dt = new DataTable();
                //string CommandText = "{CALL \"Custom_THSV_Report_ZEN_StoredProc\".\"SVNHSendEmailCSI2_GetData\".('" + dateFrom + "','" + dateTo + "')}";
                string CommandText = "{CALL \"Custom_THSV_Report_ZEN_StoredProc\".\"SVNHrptMTincomeByHN_getData\".('" + hn + "')}";
                dt = DTBindDataCommand(CommandText, Constants.Chache89);
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}