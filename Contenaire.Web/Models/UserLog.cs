using System;
using System.Collections.Generic;

namespace Contenaire.Web.Models;

public partial class UserLog
{
    public string IdLog { get; set; } = null!;

    public string IdUser { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string FieldId { get; set; } = null!;

    public string? ListFieldName { get; set; }

    public string Action { get; set; } = null!;

    public DateTime ActionDate { get; set; }
}
