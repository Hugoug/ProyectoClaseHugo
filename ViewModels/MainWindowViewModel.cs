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
    [ObservableProperty] private bool habilidades = false; // Para IsVisible del StackPanel
    [ObservableProperty] private ObservableCollection<Pokemon> pokemons = new();
    [ObservableProperty] private bool modoCrear = true; 
    [ObservableProperty] private bool modoEditar = false;
    
    public string Greeting { get; set; } = "¡CREA TU POKESPECIE!";
    
    [ObservableProperty] private Pokemon poke = new();
    [ObservableProperty] private Pokemon pokeSeleccionado = new();
    
    public List<string> ListaTipos { get; set; }

    //Constructor
    public MainWindowViewModel()
    {
        CargarCombo();
        CargarPokemons();
    }
    
    // Se mantiene la estructura solicitada, ajustando el valor a 'EsShiny' (bool)
    private void CargarPokemons()
    {
        Pokemon poke = new Pokemon();
        poke.Nombre = "Pokugo";
        poke.Tipo = "Fantasma";
        poke.EsShiny = true; // Ajuste por cambio a bool
        Pokemons.Add(poke);
        
        Pokemon poke2 = new Pokemon();
        poke2.Nombre = "ug";
        poke2.Tipo = "Fuego";
        poke2.EsShiny = false; // Ajuste por cambio a bool
        Pokemons.Add(poke2);
    }

    [RelayCommand]
    public void CargarPokeSeleccionado()
    {
        Poke = PokeSeleccionado;
        ModoCrear = false;
        ModoEditar = true;
    }

    // ELIMINADO: asignarHabilidades (se reemplaza por Binding en XAML)
    // ELIMINADO: estadoInicialCheck (contenía lógica de UI y se elimina)
    
    private void CargarCombo()
    {
        ListaTipos =new()
        {
            "Agua", "Acero", "Bicho", "Dragon", "Electrico", "Fantasma", "Fuego", "Hada", "Hielo",
            "Lucha", "Normal", "Sinestro", "Planta", "Psiquico", "Roca", "Tierra", "Volador", "Veneno"  
        };
        Poke.Tipo = ListaTipos[0];
    }

    // Método MANTENIDO y CORREGIDO (sin manipulación de UI)
    [RelayCommand]
    public void MostrarPoke(object parameter)
    {
        // Se mantiene el casting y el uso del parámetro object
        CheckBox check = (CheckBox)parameter;
        
        if (check.IsChecked is false)
        {
            Mensaje = "Debes marcar el check";
            Console.WriteLine("Debes marcar el check");
            // Lógica de UI (Foreground, FontWeight) ELIMINADA.
            return;
        }
        
        // Se mantiene string.IsNullOrWhiteSpace
        if (string.IsNullOrWhiteSpace(Poke.Nombre))
        {
            Mensaje = "Debes nombrar a tu Pokemon";
            Console.WriteLine("Debes indicar un nombre"); 
        }
        else
        {
            // SE CREA EL POKEMON
            // Se mantiene la concatenación, ajustando la propiedad 'Shiny' a 'EsShiny'
            Console.WriteLine(Poke.Nombre+" "+Poke.Tipo+" "+Poke.EsShiny); 
            Mensaje = String.Empty;
            Pokemons.Add(Poke);
            Poke = new Pokemon();
            check.IsChecked = false;
        }
    }
}