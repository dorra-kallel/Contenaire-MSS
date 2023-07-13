using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class EmvKey
{
    public string Version { get; set; } = null!;

    public string RidEmv { get; set; } = null!;

    public string IndexCle { get; set; } = null!;

    public string? LongeurExpCle { get; set; }

    public string? ExpCle { get; set; }

    public string? LongeurNca { get; set; }

    public string? ModuloCle { get; set; }
}
