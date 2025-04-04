using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class Deudor
{
    public int IdDeudor { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public int Celular { get; set; }

    public int MesesMora { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<DeudorHijo> DeudorHijos { get; set; } = new List<DeudorHijo>();

    public virtual ICollection<FamiliarDeudor> FamiliarDeudors { get; set; } = new List<FamiliarDeudor>();
}
