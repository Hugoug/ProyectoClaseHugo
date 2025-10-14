namespace ProyectoClaseHugo.Models;

using System;
using System.Collections.Generic;

public class Pokemon
{
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    
    public bool EsShiny { get; set; } = false; 
    
    public bool AsignarHabilidades { get; set; } = false; 
    
    public DateTime DiaCreacion { get; set; } = DateTime.Now;
    
    public string Shiny => EsShiny ? "Shiny" : "No Shiny";

    public override string ToString()
    {
        string estadoShiny = EsShiny ? "Shiny" : "No Shiny";
        return $"Nombre: {Nombre}, Tipo: {Tipo}, ¿Es Shiny?: {estadoShiny}, Creación: {DiaCreacion.ToLocalTime():d}";
    }
}