using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Finition : BaseModel
    {
        [Required]
        public string Nom { get; set; }
    }
}