using System;
using System.Collections.Generic;

namespace LibraryManagementApp.MVC.Data;

public partial class BooksFk
{
    public int Id { get; set; }

    public string OriginalTitle { get; set; } = null!;

    public string? SeriesTitle { get; set; }

    public int? AuthorId { get; set; }

    public DateTime? PublishDate { get; set; }

    public string? Genre { get; set; }

    public virtual Author? Author { get; set; }
}
