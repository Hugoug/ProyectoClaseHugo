using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoClaseHugo.Models;

namespace ProyectoClaseHugo.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
   // Tenemos que poner el decorador
    // La variable u objeto tiene que ser privado
    // Tiene que empezar por minuscula
    // No tiene que tener get y set
    [ObservableProperty]
    private string mensaje  = string.Empty;

    [ObservableProperty] private bool habilidades = false;
    
    [ObservableProperty] private ObservableCollection<Pokemon> pokemons = new();

    [ObservableProperty] private bool modoCrear = true; 
    [ObservableProperty] private bool modoEditar = false;
    
    
    public string Greeting { set; get; } = "¡CREA TU POKESPECIE!";
    
    [ObservableProperty]
    private Pokemon poke = new();
    
    [ObservableProperty] private Pokemon pokeSeleccionado = new();
    
    public List<string> ListaTipos { set; get; }

    //Constructor
    public MainWindowViewModel()
    {
        CargarCombo();
        CargarPokemons();
    }
    
   

    /*[RelayCommand]
    public void ComprobarFecha()
    {
        CheckDate();
    }*/
    
   /* private bool CheckDate()
    {
        if (Poke.Fecha < DateTime.Today)
        {
            Mensaje = "La fecha no debe ser inferior a hoy";
            return false;
        }
        else
        {
            Mensaje = "";
            return true;
        }
    }*/
    private void CargarPokemons()
    {
        Pokemon poke = new Pokemon();
        poke.Nombre = "Pokugo";
        poke.Tipo = "Fantasma";
        poke.Shiny = "Shiny";
        Pokemons.Add(poke);
        
        Pokemon poke2 = new Pokemon();
        poke2.Nombre = "ug";
        poke2.Tipo = "Fuego";
        poke2.Shiny = "No Shiny";
        Pokemons.Add(poke2);
        

    }

    //Al usar RelayCommand, en la vista aparece como CargarPokeSeleccionadoCommand
    [RelayCommand]
    public void CargarPokeSeleccionado()
    {
        Poke = PokeSeleccionado;
        ModoCrear = false;
        ModoEditar = true;
    }

    [RelayCommand]
    public void asignarHabilidades()
    {
        if (Habilidades)
        {
            Habilidades = false;
        }
        else
        {
            Habilidades = true;
        }
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
    public void estadoInicialCheck(Object parameter)
    {
        // Castear el parametro a checkbox
        CheckBox check = (CheckBox)parameter;
        
        //Establecer valores iniciales
        if (check.IsChecked == true)
        {
            check.Foreground = Brushes.Black;
            check.FontWeight = FontWeight.Normal;
        }
        else
        {
            check.Foreground = Brushes.Red;
            check.FontWeight = FontWeight.Bold;
        }

    }
    
    [RelayCommand]
    public void MostrarPoke(object parameter)
    {
        /* Si es falso (devuelve false), no continuo creando
        if (!CheckDate())
        {
            return;
        }*/
        
        CheckBox check = (CheckBox)parameter;
        
        if (check.IsChecked is false)
        {
            Mensaje = "Debes marcar el check";
            Console.WriteLine("Debes marcar el check");
            check.Foreground = Brushes.Red;
            check.FontWeight = FontWeight.Bold;
            return;
        }
        
        if (string.IsNullOrWhiteSpace(Poke.Nombre))
        {
            Mensaje = "Debes nombrar a tu Pokemon";
            Console.WriteLine("Debes indicar un nombre"); 
        }
        else
        {
            // SE CREA EL POKEMON
            Console.WriteLine(Poke.Nombre+" "+Poke.Tipo+" "+Poke.Shiny);
            Mensaje = String.Empty;
            Pokemons.Add(Poke);
            Poke = new Pokemon();
            check.IsChecked = false;
        }
        
    }
}