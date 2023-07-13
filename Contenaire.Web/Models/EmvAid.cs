using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class EmvAid
{
    public string Version { get; set; } = null!;

    public string RidAid { get; set; } = null!;

    public string LongeurPix { get; set; } = null!;

    public string PixAid { get; set; } = null!;

    public string? NumVersionAppTpe { get; set; }

    public string? NiveauPriorite { get; set; }

    public string? Indicateur { get; set; }
}
