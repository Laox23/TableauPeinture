using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TableauWeb.Model
{
    public class Dimension 
    {
        [Required(ErrorMessage = "La valeur est obligatoire")]
        public int DimensionId { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "La hauteur doit être positive")]
        public int Hauteur { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "La largeur doit être positive")]
        public int Largeur { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        public bool EstActif { get; set; }


        [ForeignKey("DimensionId")]
        public ICollection<Tableau> Tableaux { get; set; }
    }
}