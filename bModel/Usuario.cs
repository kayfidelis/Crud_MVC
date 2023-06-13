using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bModel
{
    public class Usuario
    {
        [DisplayName("Código")]
        [Key]
        public int IdUsu { get; set; }


        [Required(ErrorMessage = "O  campo Nome é obrigatorio")]
        [StringLength(50, ErrorMessage = "Não pode conter mais que 50 caracteres")]
        [DisplayName("Nome")]
        public string NomeUsu { get; set; }


        [StringLength(50, ErrorMessage = "Não pode conter mais que 50 caracteres")]
        [Required(ErrorMessage = "O  campo Cargo é obrigatorio")]
        [DisplayName("Cargo")]
        public string Cargo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }
    }
}
