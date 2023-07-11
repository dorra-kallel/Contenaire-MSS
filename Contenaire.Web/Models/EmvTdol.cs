using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class EmvTdol
{
    public string Version { get; set; } = null!;

    public string RidEmv { get; set; } = null!;

    public string? LongeurTdol { get; set; }

    public string? DefaultTdol { get; set; }
}
