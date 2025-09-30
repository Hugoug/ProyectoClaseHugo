namespace ProyectoClaseHugo.Models;

public class Pokemon
{
    public string Nombre { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public string Shiny { get; set; } = "Shiny";
    
    
    public override string ToString()
    {
        return "Nombre: "  + Nombre + ", Tipo: " + Tipo +  ", ¿Es Shiny?: " + Shiny;
    }
}