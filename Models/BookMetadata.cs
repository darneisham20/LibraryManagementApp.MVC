using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApp.MVC.Data;

public class BookMetadata
{
    [Display(Name = "Original Title")]
    public string BookTitle { get; set; } = null!;

    [Display(Name = "Series")]
    public string? SeriesName { get; set; }

    [Display(Name = "Author")]
    public string Author { get; set; } = null!;

    [Display(Name = "Publish Date")]
    public DateTime? OriginallyPublished { get; set; }

    [Display(Name = "Genre")]
    public string? Genres { get; set; }
}

[ModelMetadataType(typeof(BookMetadata))]
public partial class Book{}