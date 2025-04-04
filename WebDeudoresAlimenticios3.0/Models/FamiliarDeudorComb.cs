using System;
using System.Collections.Generic;

namespace WebDeudoresAlimenticios3._0.Models;

public partial class FamiliarDeudorComb
{
    public int Id { get; set; }

    public string NombreFamiliarDeudor { get; set; } = null!;

    public string Parentesco { get; set; } = null!;

    public string NombreDeudor { get; set; } = null!;

    public string ApellidoDeudor { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public int Celular { get; set; }
}
