using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class GroupPrefix
{
    public int IdPrefixGroup { get; set; }

    public string PrefixGroup { get; set; } = null!;

    public string? PrefixCode { get; set; }

    public string? Institution { get; set; }
}
