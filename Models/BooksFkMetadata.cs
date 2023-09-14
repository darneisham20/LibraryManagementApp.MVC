using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.MVC.Data;

public class BooksFkMetadata
{
    [Display(Name = "Original Title")]
    public string OriginalTitle { get; set; } = null!;

    [Display(Name = "Series")]
    public string? SeriesTitle { get; set; }

    [Display(Name = "Author")]
    public int? AuthorId { get; set; }

    [Display(Name = "Publish Date")]
    [DataType(DataType.Date)]
    public DateTime? PublishDate { get; set; }

    [Display(Name = "Genre")]
    public string? Genre { get; set; }
}

[ModelMetadataType(typeof(BooksFkMetadata))]
public partial class BooksFk{}