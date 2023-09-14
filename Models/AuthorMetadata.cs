using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.MVC.Data;

public class AuthorMetadata
{
    [Display(Name ="First Name")]
    public string FirstName { get; set; } = null!;

    [Display(Name ="Last Name")]
    public string LastName { get; set; } = null!;
    
    [Display(Name ="Bio")]
    public string? AboutAuthor { get; set; }

    [Display(Name ="Book Total")]
    public int? BookTotal { get; set; }
}

[ModelMetadataType(typeof(AuthorMetadata))]
public partial class Author{}