using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class EmvTcc
{
    public string Version { get; set; } = null!;

    public string RidEmv { get; set; } = null!;

    public string? LongeurPix { get; set; }

    public string PixEmv { get; set; } = null!;

    public string? TccAutorise { get; set; }
}
