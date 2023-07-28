using System;
using System.Collections.Generic;

namespace LibraryManagementApp.MVC.Data;

public partial class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? AboutAuthor { get; set; }

    public int? BookTotal { get; set; }
}
