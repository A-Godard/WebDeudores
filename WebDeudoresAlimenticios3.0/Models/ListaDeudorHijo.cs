using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class ListaDeudorHijo
{
    public int IdHijoDeudor { get; set; }

    public string PadreDeudor { get; set; } = null!;

    public string NombreHijo { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public int Celular { get; set; }

    public bool Activo { get; set; }
}
