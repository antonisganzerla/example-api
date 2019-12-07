using System.ComponentModel.DataAnnotations;

namespace apief.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
    
        [Required(ErrorMessage = "Esta campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter no máximo 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter no mínimo 3 caracteres")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve ter no máximo 1024 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Esta campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Esta campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}