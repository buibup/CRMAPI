using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMAPI.Models
{
    public class PatientInfo
    {
        public string HN { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Nationality { get; set; }
        public string Address { get; set; }
        public string CityArea { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Allergen { get; set; }
        public string AllergenCategory { get; set; }
        public string Education { get; set; }
        public string Ethnicity { get; set; }
        public string PreferredLanguage { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}