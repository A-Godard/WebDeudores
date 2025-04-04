using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class AbogadoAsociado
{
    public int IdAbogado { get; set; }

    public int IdTutor { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int Celular { get; set; }

    public string Cedula { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int NumeroDeCarnet { get; set; }

    public bool Activo { get; set; }

    public virtual TutorLegal IdTutorNavigation { get; set; } = null!;
}
