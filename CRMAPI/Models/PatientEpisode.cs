using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMAPI.Models
{
    public class PatientEpisode
    {
        public string HN { get; set; }
        List<Episode> Episodes { get; set; }
    }
}