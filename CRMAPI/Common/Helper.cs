using CRMWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CRMWebApi.CRMWebApi
{
    public class Helper
    {

        public static List<PatientHN> DataTableToPatientList(DataTable dt)
        {
            List<PatientHN> patients = new List<PatientHN>();

            foreach (DataRow row in dt.Rows)
            {
                PatientHN pthn = new PatientHN();
                pthn.HN = row["Papmi_no"].ToString();
                patients.Add(pthn);
            }

            return patients;
        }

        public static PatientInfo DataTableToPatientInfo(DataTable dt)
        {
            PatientInfo result = new PatientInfo();

            foreach (DataRow row in dt.Rows)
            {
                DateTime dob = Convert.ToDateTime(row["PAPMI_DOB"]);
                string dobString = Convert.ToString(dob.Day + "/" + dob.Month + "/" + dob.Year);
                string hn = row["Papmi_No"].ToString();
                result.HN = hn;
                result.Gender = row["CTSEX_Code"].ToString();
                result.DOB = Convert.ToDateTime(row["PAPMI_DOB"]);
                result.Nationality = row["CTNAT_Desc"].ToString();
                result.Address = row["PAPER_StName"].ToString();
                result.CityArea = row["CITAREA_Desc"].ToString();
                result.City = row["CTCIT_Desc"].ToString();
                result.Province = row["PROV_Desc"].ToString();
                result.ZipCode = row["CTZIP_Code"].ToString();
                result.Allergens = GetData.GetAllergens(hn);
                result.Education = row["EDU_Desc"].ToString();
                result.Ethnicity = row["CTNAT_Desc"].ToString();
                result.PreferredLanguage = row["PREFL_Desc"].ToString();
                result.TitleName = row["TTL_Desc"].ToString();
                result.FirstName = row["PAPMI_Name"].ToString();
                result.LastName = row["PAPMI_Name2"].ToString();
            }

            return result;
        }

        public static List<Allergen> DataTableToAllergen(DataTable dt)
        {
            List<Allergen> algs = new List<Allergen>();

            foreach(DataRow row in dt.Rows)
            {
                Allergen alg = new Allergen();
                string algName = string.Empty;
                if (!string.IsNullOrEmpty(row["ALG_Comments"].ToString()))
                {
                    algName = row["ALG_Comments"].ToString();
                    alg.Name = algName;
                    alg.Category = GetData.GetAllergenCategory(algName);
                    algs.Add(alg);
                }
                else if (!string.IsNullOrEmpty(row["PHCGE_Name"].ToString()))
                {
                    algName = row["PHCGE_Name"].ToString();
                    alg.Name = algName;
                    alg.Category = GetData.GetAllergenCategory(algName);
                    algs.Add(alg);
                }
                else if (!string.IsNullOrEmpty(row["ALG_Desc"].ToString()))
                {
                    algName = row["ALG_Desc"].ToString();
                    alg.Name = algName;
                    alg.Category = GetData.GetAllergenCategory(algName);
                    algs.Add(alg);
                }
                else if (!string.IsNullOrEmpty(row["ALGR_Desc"].ToString()))
                {
                    algName = row["ALGR_Desc"].ToString();
                    alg.Name = algName;
                    alg.Category = GetData.GetAllergenCategory(algName);
                    algs.Add(alg);
                }
                else if (!string.IsNullOrEmpty(row["PHCD_Name"].ToString()))
                {
                    algName = row["PHCD_Name"].ToString();
                    alg.Name = algName;
                    alg.Category = GetData.GetAllergenCategory(algName);
                    algs.Add(alg);
                }
                else if (!string.IsNullOrEmpty(row["INGR_Desc"].ToString()))
                {
                    algName = row["INGR_Desc"].ToString();
                    alg.Name = algName;
                    alg.Category = GetData.GetAllergenCategory(algName);
                    algs.Add(alg);
                }

            }

            return algs;
        }

        public static List<PatientEmail> DataTableToEmailList(DataTable dt)
        {
            List<PatientEmail> result = new List<PatientEmail>();
            string[] email = { };
            string[] email2 = { };
            string[] email3 = { };

            foreach (DataRow row in dt.Rows)
            {
                if (!string.IsNullOrEmpty(row["PAPER_Email"].ToString()))
                {
                    email = SplitMailToList(row["PAPER_Email"].ToString());
                    foreach (var m in email)
                    {
                        PatientEmail em = new PatientEmail();
                        em.Email_Address = m;
                        result.Add(em);
                    }
                }

                if (!string.IsNullOrEmpty(row["PAPER_Email2"].ToString()))
                {
                    email2 = SplitMailToList(row["PAPER_Email2"].ToString());
                    foreach (var m2 in email2)
                    {
                        PatientEmail em = new PatientEmail();
                        em.Email_Address = m2;
                        result.Add(em);
                    }
                }

                if (!string.IsNullOrEmpty(row["PAPMI_GovernCardNo"].ToString()))
                {
                    email3 = SplitMailToList(row["PAPMI_GovernCardNo"].ToString());
                    foreach (var m3 in email3)
                    {
                        PatientEmail em = new PatientEmail();
                        em.Email_Address = m3;
                        result.Add(em);
                    }
                }
            }

            return result;
        }

        public static List<PatientPhone> DataTableToPatientPhon(DataTable dt)
        {
            List<PatientPhone> result = new List<PatientPhone>();


            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    PatientPhone ptPhone = new PatientPhone();
                    if(col.ColumnName == "MobPhone")
                    {
                        if(!string.IsNullOrEmpty(row["MobPhone"].ToString()))
                        {
                            ptPhone.PhoneCategory = "Mobile";
                            ptPhone.PhoneNumber = row["MobPhone"].ToString();
                            result.Add(ptPhone);
                        }
                    }
                    if (col.ColumnName == "Home")
                    {
                        
                        if (!string.IsNullOrEmpty(row["Home"].ToString()))
                        {
                            ptPhone.PhoneCategory = "Home";
                            ptPhone.PhoneNumber = row["Home"].ToString();
                            result.Add(ptPhone);
                        }
                    }
                    if (col.ColumnName == "SecondPhone")
                    {
                        if (!string.IsNullOrEmpty(row["SecondPhone"].ToString()))
                        {
                            ptPhone.PhoneCategory = "SecondPhone";
                            ptPhone.PhoneNumber = row["SecondPhone"].ToString();
                            result.Add(ptPhone);
                        }
                    }
                    if (col.ColumnName == "Office")
                    {
                        if (!string.IsNullOrEmpty(row["Office"].ToString()))
                        {
                            ptPhone.PhoneCategory = "Office";
                            ptPhone.PhoneNumber = row["Office"].ToString();
                            result.Add(ptPhone);
                        }
                    }
                }
            }


            return result;
        }

        public static PatientEpisode DataTablePatientEpisode(DataTable dt, string hn)
        {
            PatientEpisode ptEpi = new PatientEpisode();
            List<Episode> epis = new List<Episode>();

            if (!hn.Contains("-"))
            {
                hn = Regex.Replace(hn, @"^(.{2})(.{2})(.{6})$", "$1-$2-$3");
            }

            #region ByQueryString
            //foreach (DataRow row in dt.Rows)
            //{
            //    Episode epi = new Episode();
            //    string epino = row["PAADM_ADMNo"].ToString().Trim();
            //    if (!string.IsNullOrEmpty(epino))
            //    {
            //        epi.EpisodeNo = epino;
            //        epi.EpisodeDate = Convert.ToDateTime(row["PAADM_AdmDate"].ToString());
            //        epi.EpisodeTime = Convert.ToDateTime(row["PAADM_AdmTime"].ToString());
            //        epi.LocCode = row["CTLOC_Code"].ToString();
            //        epi.LocDesc = row["CTLOC_Desc"].ToString();
            //        epi.IPD_OPD = IPD_OPD(epino);
            //        epi.DoctorName = row["CTPCP_Desc"].ToString();
            //        epi.DoctorSpecialty = row["CTSPC_Desc"].ToString();
            //        epi.Revenue = GetData.GetRevenueByEPI(epino);
            //        epi.PaymentMethod = "";
            //        epi.ICD10 = row["MRCID_Code"].ToString();
            //        epi.ICPC2 = "";
            //        epi.DepartmentGroup = "";
            //        epi.Hospital = GetHospital(epino);
            //        epi.HospitalDRGCategory = "";
            //        epi.Interpreter = "";
            //        epis.Add(epi);
            //    }
            //}
            #endregion

            #region By Store Procedure
            foreach (DataRow row in dt.Rows)
            {
                Episode epi = new Episode();
                string epino = row["admNo"].ToString().Trim();
                if (!string.IsNullOrEmpty(epino))
                {
                    epi.EpisodeNo = epino;
                    epi.EpisodeDate = DateTime.Parse(row["admDate"].ToString()).ToString("dd/MM/yyyy");
                    epi.LocCode = row["admLocCode"].ToString();
                    epi.LocDesc = row["admLocDesc"].ToString();
                    epi.IPD_OPD = IPD_OPD(epino);
                    epi.DoctorName = row["admDocDesc"].ToString();
                    epi.DoctorSpecialty = row["admSpec"].ToString();
                    epi.Revenue = Convert.ToDouble(row["titmLineTotal"].ToString());
                    epi.PaymentMethod = row["PayorDesc"].ToString(); 
                    epi.ICD10 = row["icd10"].ToString();
                    epi.ICPC2 = row["icd9"].ToString();
                    epi.DepartmentGroup = row["DepartmentGrp"].ToString();
                    epi.Hospital = row["CTHospital"].ToString(); 
                    epi.HospitalDRGCategory = row["CTHospitalDRG"].ToString();
                    epi.Interpreter = row["interpreter"].ToString();
                    epis.Add(epi);
                }
            }
            #endregion

            

            ptEpi.HN = hn;
            ptEpi.Episodes = epis;

            return ptEpi;
        }

        static string GetHospital(string epino)
        {
            string hos = string.Empty;
            if(epino.Substring(1,2) == "12")
            {
                hos = "รพ.สมิติเวชศรีนครินทร์";
            }
            else
            {
                hos = "รพ.สมิติเวชสุขุมวิท";
            }
            return hos;
        }

        static string IPD_OPD(string Epi)
        {
            string result = string.Empty;

            if (Epi.Substring(0, 1).ToUpper() == "I")
            {
                result = "IPD";
            }else
            {
                result = "OPD";
            }

            return result;
        }

        public static List<Location> DataTableToLocationsList(DataTable dt)
        {
            List<Location> Locations = new List<Location>();

            foreach (DataRow row in dt.Rows)
            {
                Location Loc = new Location();
                Loc.LocCode = row["CTLOC_Code"].ToString();
                Loc.LocDesc = row["CTLOC_Desc"].ToString();
                Locations.Add(Loc);
            }

            return Locations;
        }

        public static string[] SplitMailToList(string mails)
        {
            string[] result = { };
            if (string.IsNullOrEmpty(mails))
            {
                return result;
            }
            result = mails.Split(new Char[] {
                Convert.ToChar(";"),
                Convert.ToChar(",")
            });

            return result;
        }
    }
}