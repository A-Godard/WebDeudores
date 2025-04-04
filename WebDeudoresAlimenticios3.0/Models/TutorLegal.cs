using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class TutorLegal
{
    public int IdTutor { get; set; }

    public int IdHijoDeudor { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int Celular { get; set; }

    public string Cedula { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<AbogadoAsociado> AbogadoAsociados { get; set; } = new List<AbogadoAsociado>();

    public virtual DeudorHijo IdHijoDeudorNavigation { get; set; } = null!;
}
