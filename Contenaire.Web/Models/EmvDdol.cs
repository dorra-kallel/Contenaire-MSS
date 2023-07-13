using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class EmvDdol
{
    public string Version { get; set; } = null!;

    public string RidEmv { get; set; } = null!;

    public string? LongeurPix { get; set; }

    public string PixEmv { get; set; } = null!;

    public string? LongeurDdol { get; set; }

    public string? DefaultDdol { get; set; }
}
