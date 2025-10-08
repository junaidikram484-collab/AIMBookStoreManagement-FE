using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FEBookStoreManagement.DTO;

public class CreateBookDto
{
    [ValidateNever]
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; } = string.Empty;

    [Required]
    public int Year { get; set; }


    [Required]
    public int Pages { get; set; }


    [Required]
    public Guid AuthorId { get; set; }
}