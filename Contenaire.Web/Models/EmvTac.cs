using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class EmvTac
{
    public string Version { get; set; } = null!;

    public string RidEmv { get; set; } = null!;

    public string? LongeurPid { get; set; }

    public string PixEmv { get; set; } = null!;

    public string? TacRejetTrans { get; set; }

    public string? TacTraitOnline { get; set; }

    public string? TacRejetApresRejet { get; set; }
}
