
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BO_Dojo
{
    public class Samourai : DbEntity
    {
      
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        [DisplayName("Arts martiaux maîtrisés")]
        public virtual List<ArtMartial> ArtMartials { get; set; } = new List<ArtMartial>();
        [NotMapped]
        private int potentiel;
        [NotMapped]
        public int Potentiel
        {
            get {
                if (this.Arme == null)
                {
                    potentiel = (this.Force) * (this.ArtMartials.Count() + 1);
                }
                else
                {
                    potentiel = (this.Force + this.Arme.Degats) * (this.ArtMartials.Count() + 1);
                }
                return potentiel; 
            }
            
        }

    }
}
