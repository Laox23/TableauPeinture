using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Tableau : BaseModel
    {
        public int ImageId { get; set; }

        public ImageTableau Image { get; set; }

        public Dimension Dimension { get; set; }

        public Finition Finition { get; set; }

        [Required]
        public int NombreImpression { get; set; }

        public string TexteImpressionAffichage
        {
            get
            {
                return string.Format("Numéro de série : {0}", NombreImpression.ToString("D4"));
            }
        }
    }
}