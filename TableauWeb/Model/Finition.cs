using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableauWeb.Model
{
    public class Finition 
    {
        [Required(ErrorMessage = "La valeur est obligatoire")]
        public int FinitionId { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        public bool EstActif { get; set; }


        [ForeignKey("FinitionId")]
        public ICollection<Tableau> Tableaux { get; set; }
    }
}