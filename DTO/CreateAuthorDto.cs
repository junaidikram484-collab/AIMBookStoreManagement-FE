using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FEBookStoreManagement.DTO;

// --- NEW: 1. Model for the Add Author Form (includes validation) ---
public class CreateAuthorDto
{
    [ValidateNever]
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name must be less than 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Biography must be less than 500 characters.")]
    public string BioGraphy { get; set; } = string.Empty;
}