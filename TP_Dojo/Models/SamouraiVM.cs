using BO_Dojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Dojo.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }

        public List<Arme> ListeArmes { get; set; }

        public int? ArmeId { get; set; }

        public List<Samourai> ListeSamourais { get; set; }

        public List<int> ListeArtMartialsId { get; set; }

        public List<ArtMartial> ListeArtMartials { get; set; }

        public int? SamouraiId { get; set; }

        public Arme Arme { get; set; }
    }
}