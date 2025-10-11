namespace ProyectoClaseHugo.Models;

using System;
using System.Collections.Generic;

public class Pokemon
{
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    
    // Propiedad booleana para el estado Shiny
    public bool EsShiny { get; set; } = false; 
    
    // Propiedad para visibilidad de habilidades
    public bool AsignarHabilidades { get; set; } = false; 
    
    // Propiedad estable para el DatePicker
    public DateTimeOffset DiaCreacion { get; set; } = DateTimeOffset.Now;

    // Propiedad de solo lectura para mostrar el texto "Shiny" o "No Shiny" en la lista
    public string ShinyText => EsShiny ? "Shiny" : "No Shiny";

    public override string ToString()
    {
        string estadoShiny = EsShiny ? "Shiny" : "No Shiny";
        // Usamos ToLocalTime():d para formatear y mostrar solo la fecha
        return $"Nombre: {Nombre}, Tipo: {Tipo}, ¿Es Shiny?: {estadoShiny}, Creación: {DiaCreacion.ToLocalTime():d}";
    }
}