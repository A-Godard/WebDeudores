using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public bool Activo { get; set; }
}
