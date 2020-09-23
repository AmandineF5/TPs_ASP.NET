
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO_Dojo
{
    public class Samourai : DbEntity
    {
      
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        [DisplayName("Arts martiaux maîtrisés")]
        public virtual List<ArtMartial> ArtMartials { get; set; }
    }
}
