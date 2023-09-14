using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.MVC.Data;

public class PublisherMetadata
{
    [Display(Name ="Publisher")]
    public string Company { get; set; } = null!;

    [Display(Name ="Location")]
    public string Location { get; set; } = null!;

    [Display(Name ="Founded")]
    public int? Founded { get; set; }

    [Display(Name ="Genre of Books")]
    public string? Genres { get; set; }
}

[ModelMetadataType(typeof(PublisherMetadata))]
public partial class Publisher{}