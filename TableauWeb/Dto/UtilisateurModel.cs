using System.ComponentModel.DataAnnotations;

namespace TableauWeb.Dto
{
    public class UtilisateurModel
    {
        [Required(ErrorMessage = "La valeur est obligatoire")]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required(ErrorMessage = "La valeur est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe de confirmation")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La valeur est obligatoire")]
        public string Role { get; set; }
    }
}
