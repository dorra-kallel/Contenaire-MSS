using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class Fuseau
{
    public string Countrycode { get; set; } = null!;

    public string? Nom { get; set; }

    public int? Diffhorraire { get; set; }
}
