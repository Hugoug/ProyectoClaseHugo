using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoClaseHugo.Models;

namespace ProyectoClaseHugo.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   // Se mantiene la estructura de propiedades observables
    [ObservableProperty] private string mensaje  = string.Empty;
    [ObservableProperty] private bool habilidades = false; 
    [ObservableProperty] private ObservableCollection<Pokemon> pokemons = new();
    [ObservableProperty] private bool modoCrear = true; 
    [ObservableProperty] private bool modoEditar = false;
    
    public string Greeting { get; set; } = "¡CREA TU POKESPECIE!";
    
    // Inicialización simple
    [ObservableProperty] private Pokemon poke = new();
    [ObservableProperty] private Pokemon pokeSeleccionado = new();
    
    public List<string> ListaTipos { get; set; }

    //Constructor
    public MainWindowViewModel()
    {
        CargarCombo();
        CargarPokemons();
    }
    
    private void CargarPokemons()
    {
        Pokemon poke = new Pokemon();
        poke.Nombre = "Pokugo";
        poke.Tipo = "Fantasma";
        poke.EsShiny = true; 
        Pokemons.Add(poke);
        
        Pokemon poke2 = new Pokemon();
        poke2.Nombre = "ug";
        poke2.Tipo = "Fuego";
        poke2.EsShiny = false; 
        Pokemons.Add(poke2);
    }

    [RelayCommand]
    public void CargarPokeSeleccionado()
    {
        Poke = PokeSeleccionado;
        ModoCrear = false;
        ModoEditar = true;
    }

    private void CargarCombo()
    {
        ListaTipos =new()
        {
            "Agua", "Acero", "Bicho", "Dragon", "Electrico", "Fantasma", "Fuego", "Hada", "Hielo",
            "Lucha", "Normal", "Sinestro", "Planta", "Psiquico", "Roca", "Tierra", "Volador", "Veneno"  
        };
        Poke.Tipo = ListaTipos[0];
    }

    [RelayCommand]
    public void MostrarPoke(object parameter)
    {
        CheckBox check = (CheckBox)parameter;
        
        if (check.IsChecked is false)
        {
            Mensaje = "Debes marcar el check";
            Console.WriteLine("Debes marcar el check");
            return;
        }
        
        if (string.IsNullOrWhiteSpace(Poke.Nombre))
        {
            Mensaje = "Debes nombrar a tu Pokemon";
            Console.WriteLine("Debes indicar un nombre"); 
        }
        else
        {
            Console.WriteLine(Poke.Nombre+" "+Poke.Tipo+" "+Poke.EsShiny); 
            Mensaje = String.Empty;
            Pokemons.Add(Poke);
            
            Poke = new Pokemon();
            
            check.IsChecked = false;
        }
    }
    
    // NUEVO COMANDO: Cancela la edición y resetea el formulario al modo "Crear"
    [RelayCommand]
    public void CancelarEdicion()
    {
        // 1. Resetear el formulario con una nueva instancia de Pokemon
        Poke = new Pokemon();
        
        // 2. Limpiar la selección de la lista (para que nada quede marcado)
        PokeSeleccionado = null!; 
        
        // 3. Volver al modo Crear
        ModoCrear = true;
        ModoEditar = false;
        
        // Mensaje de estado
        Mensaje = "Operación editar cancelada";
    }
}