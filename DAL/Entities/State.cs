using System.ComponentModel.DataAnnotations;

namespace WebApi_Jueves_2024II.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        //relacion de tablas
        [Display(Name = "País")]
        public Country? Country { get; set; }

        [Display(Name = "ID País")]
        public Guid CountryId { get; set; }




    }
}
