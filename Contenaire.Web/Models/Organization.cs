using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class Organization
{
    public string IdOrganization { get; set; } = null!;

    public string NameOrganization { get; set; } = null!;

    public string? LogoOrganization { get; set; }

    public int ConventionOrganization { get; set; }

    public string? IdBk { get; set; }

    public virtual ICollection<AspNetUser> AspNetUsers { get; set; } = new List<AspNetUser>();
}
