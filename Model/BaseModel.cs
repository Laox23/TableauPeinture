using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class BaseModel
    {
        [Required]
        public int Id { get; set; }

        //public override string ToString()
        //{
        //    return JsonSerializer.Serialize(this);
        //}
    }
}