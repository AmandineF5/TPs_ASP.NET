using BO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO_Dojo
{
    public class Samourai : DbEntity
    {
      
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
    }
}
