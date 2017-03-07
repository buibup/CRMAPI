using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMWebApi.Models
{
    public class PatientEpisode
    {
        public string HN { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}