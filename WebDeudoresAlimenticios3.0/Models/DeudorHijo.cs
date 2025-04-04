using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class DeudorHijo
{
    public int IdHijoDeudor { get; set; }

    public int IdDeudor { get; set; }

    public string Nombres { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int Celular { get; set; }

    public bool Activo { get; set; }

    public virtual Deudor IdDeudorNavigation { get; set; } = null!;

    public virtual ICollection<TutorLegal> TutorLegals { get; set; } = new List<TutorLegal>();
}
