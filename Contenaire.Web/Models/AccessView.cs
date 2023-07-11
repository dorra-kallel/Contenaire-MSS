using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class AccessView
{
    public string IdAccessView { get; set; } = null!;

    public string? DescriptionAccessView { get; set; }

    public virtual ICollection<UserAccess> UserAccesses { get; set; } = new List<UserAccess>();
}
