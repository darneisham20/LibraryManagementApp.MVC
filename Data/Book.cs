using System;
using System.Collections.Generic;

namespace LibraryManagementApp.MVC.Data;

public partial class Book
{
    public int Id { get; set; }

    public string BookTitle { get; set; } = null!;

    public string? SeriesName { get; set; }

    public string Author { get; set; } = null!;

    public DateTime? OriginallyPublished { get; set; }

    public string? Genres { get; set; }
}
