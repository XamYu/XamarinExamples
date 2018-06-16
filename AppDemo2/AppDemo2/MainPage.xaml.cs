using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AppDemo2 {

	//Archivo para comportamiento del Xaml
	public partial class MainPage : ContentPage {

		public Empleado NuevoEmpledo { get; set; }
		public MainPage () {
			//Inicializamos algunas propiedades del nuevo empleado 
			NuevoEmpledo = new Empleado {
				Nombre = "Omar Fuentes",
				Email = "omar.fuentes@omarfuentes.com"
			};

			//Asignamos el valor de los datos de nuestra clase entidad
			BindingContext = NuevoEmpledo;


			InitializeComponent ();

		}


	}
}
