using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class ListaTutor
{
    public int Id { get; set; }

    public string NombreHijo { get; set; } = null!;

    public string NombreTutor { get; set; } = null!;

    public string ApellidoTutor { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int Celular { get; set; }

    public string Cedula { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool Activo { get; set; }
}
