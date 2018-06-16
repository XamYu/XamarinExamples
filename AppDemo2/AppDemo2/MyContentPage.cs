using System;
using Xamarin.Forms;



namespace AppDemo2 {
	
	public class MyContentPage : ContentPage {
		
		public MyContentPage () {
			//Indicamos los elementos del content page
			//Generamos el codigo por medio de un formulario
			var label = new Label { 
				Text = "Escribe tu nombre"
			};

			var txtNombre = new Entry {
				Placeholder = "Escribe tu nombre"
			};

			var btnPrimerBoton = new Button {
				//Inicializamos unas propiedades basicas
				Text="Click Me!"
			};

			//Agregamos manejador de eventos al boton por sentencia lambda
			btnPrimerBoton.Clicked += (object sender, EventArgs e) => {
				DisplayAlert ("Alerta", "Se ha producido un error", "ok","Cancelar");
			};


			//La propiedad de content solo admite un elemento
			//Le indicamos a la propiedad que tenga otro contenedor que a su vez va a permitir tener otros controles
			Content = new StackLayout {//Stacklayout nos permitira agrupar diferentes tipos de controles
				Padding = 30,
				Spacing = 10,
				Children = { label, txtNombre, btnPrimerBoton } //La propiedad Children de stacklayout puede contener un conjunto de N elementos

			};




		}
	}
}
