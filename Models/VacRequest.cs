// Models/VacationRequest.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace PortalGestionInterna.Models
{
    public class VacationRequest : IValidatableObject
    {
        public int Id { get; set; } // Clave Primaria

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Fin")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "El motivo es obligatorio.")]
        [StringLength(300, ErrorMessage = "El motivo no puede exceder los 300 caracteres.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "DES")]
        public string Reason { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Estado")]
        public string Status { get; set; } = string.Empty; // Ej: Pendiente, Aprobada, Rechazada

        [Display(Name = "Fecha de Solicitud")]
        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Fecha de Actualización de Estado")]
        public DateTime? StatusUpdatedAt { get; set; }

        // Clave foránea para el empleado que solicita (asumiendo que tienes un sistema de usuarios)
        // public string RequestingUserId { get; set; }
        // public virtual ApplicationUser RequestingUser { get; set; }

        // Validación personalizada (ejemplo)
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult(
                    "La fecha de fin no puede ser anterior a la fecha de inicio.",
                    new[] { nameof(EndDate), nameof(StartDate) });
            }
        }
    }
}
