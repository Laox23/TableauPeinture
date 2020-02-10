using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Dimension : BaseModel
    {
        [Required]
        [Range(0, 10000, ErrorMessage ="La hauteur doit être positive")]
        public int Hauteur { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "La largeur doit être positive")]
        public int Largeur { get; set; }

        [Required]
        public string Nom { get; set; }
    }
}   