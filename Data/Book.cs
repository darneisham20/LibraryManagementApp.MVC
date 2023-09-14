﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApp.MVC.Data;

public partial class Book
{
    public int Id { get; set; }

    public string BookTitle { get; set; } = null!;

    public string? SeriesName { get; set; }

    public string Author { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime? OriginallyPublished { get; set; }

    public string? Genres { get; set; }
}
