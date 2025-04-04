using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class AbogadoAsociadoComb
{
    public int Id { get; set; }

    public int NombreTutor { get; set; }

    public string NombreAbogado { get; set; } = null!;

    public string ApellidosAbogado { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int Celular { get; set; }

    public string Cedula { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int NumeroDeCarnet { get; set; }
}
