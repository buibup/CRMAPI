using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMWebApi.CRMWebApi
{
    public class QueryString
    {

        public static string GetHospitalSites(string siteCode)
        {
            string result = @"
            
                Select HOSP_Desc
                From CT_Hospital
                Where HOSP_Code = {siteCode}

            ";

            result = result.Replace("{siteCode}", siteCode);

            return result;
        }

        public static string GetPatients(string siteCode, string year)
        {

            siteCode = siteCode.Substring(1, 2);

            string result = @"

                Select Distinct PAADM_PAPMI_DR->PAPMI_No  From Pa_Adm 
                Where Year(PAADM_AdmDate) = '{year}' and PAADM_ADMNo <>'' 
                And Substring(paadm_admno,2,2) = '{siteCode}'
                Order by PAADM_AdmDate ,paadm_rowid

            ";

            result = result.Replace("{siteCode}", siteCode);
            result = result.Replace("{year}", year);

            return result;
        }

        public static string GetPatientsHN(string siteCode, string year)
        {
            string result = @"

            select Papmi_no
            from MTINCOME
            Where Year(ori_sttdat) = '{year}' and bu_id = '{siteCode}'
            Group by Papmi_no

            ";

            result = result.Replace("{year}", year);
            result = result.Replace("{siteCode}", siteCode);

            return result;
        }

        public static string GetPatientsHN(string siteCode, string year, string month)
        {
            string result = @"

            select Papmi_no
            from MTINCOME
            Where Year(ori_sttdat) = '{year}' and month(ori_sttdat) = '{month}' and bu_id = '{siteCode}'
            Group by Papmi_no

            ";

            result = result.Replace("{year}", year);
            result = result.Replace("{month}", month);
            result = result.Replace("{siteCode}", siteCode);

            return result;
        }

        public static string GetPatientInfo(string hn)
        {
            string result = @"

                Select Papmi_No
                ,PAPMI_Sex_DR->CTSEX_Code
                ,PAPMI_DOB
                ,PAPMI_PAPER_DR->PAPER_Nation_DR->CTNAT_Desc
                ,PAPMI_PAPER_DR->PAPER_StName
                ,PAPMI_PAPER_DR->PAPER_CityArea_DR->CITAREA_Desc
                ,PAPMI_PAPER_DR->PAPER_CityCode_DR->CTCIT_Desc
                ,PAPMI_PAPER_DR->PAPER_CT_Province_DR->PROV_Desc
                ,PAPMI_PAPER_DR->PAPER_Zip_DR->CTZIP_Code
                ,PAPMI_PAPER_DR->PAPER_Education_DR->EDU_Desc
                ,PAPMI_PAPER_DR->PAPER_PrefLanguage_DR->PREFL_Desc
                ,PAPMI_Title_DR->TTL_Desc
                ,PAPMI_Name
                ,PAPMI_Name2
                From Pa_Patmas
                Where PAPMI_No = '{hn}'

            ";

            result = result.Replace("{hn}", hn);

            return result;
        }

        public static string GetPatientEmail(string hn)
        {
            string result = @"

                Select 	PAPMI_PAPER_DR->PAPER_Email
                ,PAPMI_PAPER_DR->PAPER_Email2
                ,PAPMI_GovernCardNo
                From Pa_Patmas
                Where PAPMI_No = '{hn}'

            ";

            result = result.Replace("{hn}", hn);

            return result;
        }

        public static string GetPatientPhone(string hn)
        {
            string result = @"
                
                Select 	PAPMI_PAPER_DR->PAPER_MobPhone MobPhone
                ,PAPMI_PAPER_DR->PAPER_SecondPhone SecondPhone
                ,PAPMI_PAPER_DR->PAPER_TelH Home
                ,PAPMI_PAPER_DR->PAPER_TelO Office
                From Pa_Patmas
                Where PAPMI_No = '{hn}'
                
            ";

            result = result.Replace("{hn}", hn);

            return result;
        }

        public static string GetPatientEpisodes(string hn)
        {
            string result = @"

                Select PAADM_ADMNo
                ,PAADM_AdmDate
                ,PAADM_AdmTime
                ,PAADM_DepCode_DR->CTLOC_Code
                ,PAADM_DepCode_DR->CTLOC_Desc
                ,PAADM_AdmDocCodeDR->CTPCP_Desc
                ,PAADM_AdmDocCodeDR->CTPCP_Spec_DR->CTSPC_Desc
                ,PAADM_MainMRADM_DR->MR_Diagnos->MRDIA_ICDCode_DR->MRCID_Code
                ,PAADM_MainMRADM_DR->MR_Diagnos->MRDIA_ICDCode_DR->MRCID_Desc
                From Pa_adm
                Where PAADM_PAPMI_DR->Papmi_No = '{hn}'

            ";

            result = result.Replace("{hn}", hn);

            return result;
        }

        public static string GetAllLocations(string siteCode)
        {
            if(siteCode == "012")
            {
                siteCode = "13";
            }
            else
            {
                siteCode = "12";
            }

            string result = @"

                Select CTLOC_Code,CTLOC_Desc
                From CT_Loc
                Where CTLOC_Hospital_DR = '{siteCode}'

            ";

            result = result.Replace("{siteCode}", siteCode);

            return result;
        }

        public static string GetAllergy(string hn)
        {
            string alg = @"

                SELECT ALG_Comments
                ,ALG_PHCGE_DR->PHCGE_Name
                ,ALG_Type_DR->ALG_Desc
                ,ALG_AllergyGrp_DR->ALGR_Desc
                ,ALG_PHCDRGForm_DR->PHCDF_PHCD_ParRef->PHCD_Name
                ,ALG_Ingred_DR->INGR_Desc
                FROM PA_Allergy
                WHERE ALG_PAPMI_ParRef->PAPMI_No = '{hn}'

            ";

            alg = alg.Replace("{hn}", hn);

            return alg;
        }

        public static string GetAllergyCategory(string algName)
        {
            string algCat = @"

                SELECT ALG_Type_DR->MRCAT_Desc
                FROM PAC_Allergy
                Where ALG_Desc like '{algName}%'

            ";

            algCat = algCat.Replace("{algName}", algName);

            return algCat;
        }

        public static string GetRevenueFromCache(string epino)
        {
            string result = @"

                SELECT SUM(AR_PatBillGroup->AR_PatBillGroupCharges->ITM_LineTotal) Revenue
                FROM AR_PatientBill
                WHERE AR_PatBillGroup->AR_PatBillGroupCharges->ITM_OEORI_DR->OEORI_Billed in ('B','P')
                AND ARPBL_PAADM_DR->PAADM_ADMNo = '{epino}'

            ";

            result = result.Replace("{epino}", epino);

            return result;
        }

        public static string GetRevenueFromSQL(string hn, string epi)
        {
            string result = @"

                Select sum(net_amt) Revenue
                From mtincome
                Where paadm_admno = '{epi}'
                and papmi_no = '{hn}'

            ";

            result = result.Replace("{epi}", epi);
            result = result.Replace("{hn}", hn);

            return result;
        }
    }
}