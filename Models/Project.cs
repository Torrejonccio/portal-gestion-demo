// Models/Project.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PortalGestionInterna.Models
{
    public class Project
    {
        public int Id { get; set; } // Clave Primaria

        [Required(ErrorMessage = "El nombre del proyecto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        [Display(Name = "Nombre del Proyecto")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string? Description { get; set; } // Nullable si la descripción es opcional

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(50)]
        [Display(Name = "Estado")]
        public string Status { get; set; } = string.Empty; // Ej: Planificado, En Curso, Completado

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Fin")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Última Actualización")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Podrías añadir relaciones aquí, por ejemplo, con un modelo de Empleado
        // public string? AssignedToUserId { get; set; }
        // public virtual ApplicationUser? AssignedToUser { get; set; }
    }
}
