using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class FamiliarDeudor
{
    public int IdFamiliarDeudor { get; set; }

    public int IdDeudor { get; set; }

    public string NombresFamiliar { get; set; } = null!;

    public string ApellidosFamiliar { get; set; } = null!;

    public string Parentesco { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public int Celular { get; set; }

    public bool Activo { get; set; }

    public virtual Deudor IdDeudorNavigation { get; set; } = null!;
}
