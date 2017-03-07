using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMWebApi.Models
{
    public class Episode
    {
        public string EpisodeNo { get; set; }
        public string EpisodeDate { get; set; }
        //public DateTime EpisodeTime { get; set; }
        public string LocCode { get; set; }
        public string LocDesc { get; set; }
        public string IPD_OPD { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpecialty { get; set; }
        public double Revenue { get; set; }
        public string PaymentMethod { get; set; }
        public string ICD10 { get; set; }
        public string ICPC2 { get; set; }
        public string DepartmentGroup { get; set; }
        public string Hospital { get; set; }
        public string HospitalDRGCategory { get; set; }
        public string Interpreter { get; set; }
    }
}