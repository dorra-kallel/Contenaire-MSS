using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class EmvRandCall
{
    public string Version { get; set; } = null!;

    public string RidEmv { get; set; } = null!;

    public string? LongeurPix { get; set; }

    public string PixEmv { get; set; } = null!;

    public string? CodeMonnaie { get; set; }

    public string? SeuilAppelEmv { get; set; }

    public string? NbrTransInfPlafond { get; set; }

    public string? NbrMaxTrans { get; set; }
}
