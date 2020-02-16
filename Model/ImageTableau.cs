using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ImageTableau
    {
        [Required(ErrorMessage = "La valeur est obligatoire")]
        public int ImageTableauId { get; set; }


        [Required(ErrorMessage = "La valeur est obligatoire")]
        public string NomBase { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        public int MaxImpression { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        public bool EstActif { get; set; }

        [ForeignKey("ImageTableauId")]
        public ICollection<Tableau> Tableaux { get; set; }
    }
}