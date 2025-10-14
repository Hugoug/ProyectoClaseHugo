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
    //Propiedas observables
    [ObservableProperty] private string mensaje  = string.Empty;
    [ObservableProperty] private bool habilidades = false; 
    [ObservableProperty] private ObservableCollection<Pokemon> pokemons = new();
    [ObservableProperty] private bool modoCrear = true; 
    [ObservableProperty] private bool modoEditar = false;
    
    //Titulo del formulario
    public string Greeting { get; set; } = "¡CREA TU POKESPECIE!";
    
    [ObservableProperty] private Pokemon poke = new() { DiaCreacion = DateTime.Now };
    [ObservableProperty] private Pokemon pokeSeleccionado = new();
    
    public List<string> ListaTipos { get; set; }

    //Constructor
    public MainWindowViewModel()
    {
        CargarCombo();
        CargarPokemons();
    }
    
    //Pokemons de prueba o ejemplo ya cargados
    private void CargarPokemons()
    {
        Pokemon poke = new Pokemon();
        poke.Nombre = "Pokugo";
        poke.Tipo = "Fantasma";
        poke.EsShiny = true; 
        poke.DiaCreacion = DateTime.Now; 
        Pokemons.Add(poke);
        
        Pokemon poke2 = new Pokemon();
        poke2.Nombre = "Fran";
        poke2.Tipo = "Fuego";
        poke2.EsShiny = false; 
        poke2.DiaCreacion = DateTime.Now; 
        Pokemons.Add(poke2);
        
        Pokemon poke3 = new Pokemon();
        poke3.Nombre = "Pepe";
        poke3.Tipo = "Tierra";
        poke3.EsShiny = false; 
        poke3.DiaCreacion = DateTime.Now; 
        Pokemons.Add(poke3);
    }

    [RelayCommand]
    public void CargarPokeSeleccionado()
    {
        Poke = PokeSeleccionado;
        ModoCrear = false;
        ModoEditar = true;
    }

    // Lista de todos los tipos
    private void CargarCombo()
    {
        ListaTipos = new()
        {
            "Agua", "Acero", "Bicho", "Dragon", "Electrico", "Fantasma", "Fuego", "Hada", "Hielo",
            "Lucha", "Normal", "Sinestro", "Planta", "Psiquico", "Roca", "Tierra", "Volador", "Veneno"
        };
        Poke.Tipo = ListaTipos[0];
    }

    // Mostrar Pokemon creado en la lista, con validaciones
    [RelayCommand]
    public void MostrarPoke(object parameter)
    {
        CheckBox check = (CheckBox)parameter;
        
        if (check.IsChecked is false)
        {
            Mensaje = "Debes aceptar las condiciones";
            Console.WriteLine("Debes aceptar las condiciones");
            return;
        }
        
        if (string.IsNullOrWhiteSpace(Poke.Nombre))
        {
            Mensaje = "Debes nombrar a tu Pokemon";
            Console.WriteLine("Debes indicar un nombre"); 
        }
        else
        {
            Console.WriteLine(Poke.Nombre+" "+Poke.Tipo+" "+Poke.EsShiny+" "+Poke.DiaCreacion.ToLocalTime().Date); 
            Mensaje = String.Empty;
            Pokemons.Add(Poke);
            
            Poke = new Pokemon() { DiaCreacion = DateTime.Now };
            
            check.IsChecked = false;
        }
    }
    
    // Cancelar operacion editar
    [RelayCommand]
    public void CancelarEdicion()
    {
        Poke = new Pokemon() { DiaCreacion = DateTime.Now }; 
        PokeSeleccionado = null!; 
        ModoCrear = true;
        ModoEditar = false;
        Mensaje = "Operación editar cancelada";
    }
}