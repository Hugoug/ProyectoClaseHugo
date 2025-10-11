namespace ProyectoClaseHugo.Models;

public class Pokemon
{
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    
    // CAMBIO NECESARIO: Se usa 'bool' para EsShiny para enlazar al CheckBox
    public bool EsShiny { get; set; } = false; 
    
    // Propiedad para visibilidad de habilidades
    public bool AsignarHabilidades { get; set; } = false; 

    public override string ToString()
    {
        // Se ajusta para usar el estado booleano
        string estadoShiny = EsShiny ? "Shiny" : "No Shiny";
        
        return $"Nombre: {Nombre}, Tipo: {Tipo}, ¿Es Shiny?: {estadoShiny}";
    }
}