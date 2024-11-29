using System.ComponentModel.DataAnnotations;
using WebApi_Jueves_2024II.DAL.Entities;

namespace WebApi_Jueves_2024II.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Estados/Departamentos")]
        public ICollection<State>? States { get; set; }


    }
}
