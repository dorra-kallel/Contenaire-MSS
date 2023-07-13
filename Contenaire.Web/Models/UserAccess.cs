using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class UserAccess
{
    public string IdUserAccess { get; set; } = null!;

    public string IdUser { get; set; } = null!;

    public string IdAccessView { get; set; } = null!;

    public int ValueUserAccess { get; set; }

    public virtual AccessView IdAccessViewNavigation { get; set; } = null!;
}
