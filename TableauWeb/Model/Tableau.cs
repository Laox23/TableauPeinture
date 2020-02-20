using System.ComponentModel.DataAnnotations;

namespace TableauWeb.Model
{
    public class Tableau 
    {
        [Required]
        public int TableauId { get; set; }

        [Required]
        public int ImageTableauId { get; set; }

        [Required]
        public int DimensionId { get; set; }

        [Required]
        public int FinitionId { get; set; }

        //[Required]
        //public Utilisateur UtilisateurId { get; set; }


        [Required(ErrorMessage = "La valeur est obligatoire")]
        [Range(0, 10000, ErrorMessage = "La largeur doit être positive")]
        public int NombreImpression { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        public string NomPdf { get; set; }


        public ImageTableau Image { get; set; }
        public Dimension Dimension { get; set; }
        public Finition Finition { get; set; }
        public Utilisateur Utilisateur { get; set; }

        public string TexteImpressionAffichage
        {
            get
            {
                return string.Format("Numéro de série : {0}", NombreImpression.ToString("D4"));
            }
        }
    }
}