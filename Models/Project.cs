using System.ComponentModel.DataAnnotations;

namespace PortalGestionInterna.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        [Display(Name = "Nombre del Proyecto")]
        public string Name { get; set; }

        [StringLength(500)]
        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Display(Name = "Estado")]
        public string Status { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Fin")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Última Actualización")]
        public DateTime UpdatedAt { get; set; }
    }
}
