using System;
using System.Collections.Generic;

namespace LibraryManagementApp.MVC.Data;

public partial class Publisher
{
    public int Id { get; set; }

    public string Company { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int? Founded { get; set; }

    public string? Genres { get; set; }
}
