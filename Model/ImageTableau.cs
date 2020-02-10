using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ImageTableau : BaseModel
    {
        [Required]
        public string NomBase { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public int MaxImpression { get; set; }


        [ForeignKey("ImageId")]
        public ICollection<Tableau> Tableaux { get; set; }
    }
}