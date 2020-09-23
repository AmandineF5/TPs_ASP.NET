
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO_Dojo
{
    public class Arme : DbEntity
    {
       
        public string Nom { get; set; }
        [DisplayName("Dégâts")]
        public int Degats { get; set; }
    }
}