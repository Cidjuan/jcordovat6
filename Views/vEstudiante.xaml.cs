namespace jcordovat6.Views;
using jcordovat6.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System;
public partial class vEstudiante : ContentPage
{
	private const string url = "http://192.168.1.14/moviles/wsestudiantes.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> est;

    public vEstudiante()
    {
        InitializeComponent();
        est = new ObservableCollection<Estudiante>();
        ObtenerDatos();
    }

    private async void ObtenerDatos()
    {
        try
        {
            var content = await cliente.GetStringAsync(url);
            var estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(content);
            foreach (var estudiante in estudiantes)
            {
                est.Add(estudiante);
            }

            CargarDatosInterfaz();
        }
        catch (Exception ex)
        {

            await DisplayAlert("Error", $"Error al obtener datos: {ex.Message}", "OK");
        }
    }

    private void CargarDatosInterfaz()
    {

        for (int i = 0; i < est.Count; i++)
        {
            gridEstudiantes.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });


            Label lblCodigo = new Label
            {
                Text = est[i].Codigo,
                Padding = new Thickness(10)
            };
            Grid.SetRow(lblCodigo, i + 1);
            Grid.SetColumn(lblCodigo, 0);
            gridEstudiantes.Children.Add(lblCodigo);

            Label lblNombre = new Label
            {
                Text = est[i].Nombre,
                Padding = new Thickness(10)
            };
            Grid.SetRow(lblNombre, i + 1);
            Grid.SetColumn(lblNombre, 1);
            gridEstudiantes.Children.Add(lblNombre);

     
            Label lblApellido = new Label
            {
                Text = est[i].Apellido,
                Padding = new Thickness(10)
            };
            Grid.SetRow(lblApellido, i + 1);
            Grid.SetColumn(lblApellido, 2);
            gridEstudiantes.Children.Add(lblApellido);

 
            Label lblEdad = new Label
            {
                Text = est[i].Edad.ToString(),
                Padding = new Thickness(10)
            };
            Grid.SetRow(lblEdad, i + 1);
            Grid.SetColumn(lblEdad, 3);
            gridEstudiantes.Children.Add(lblEdad);
        }
    }
}



