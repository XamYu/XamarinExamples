using System;
using Xamarin.Forms;
using System.Linq;

namespace AppDemo2 {

	public class ListasDemo : ContentPage {

		public ListasDemo () {
			//inicializamos un nuevo arreglo en nuestro constructor
			var nombres = new []{
				"Omar",
				"Salmo",
				"Olga",
				"Mina",
				"Lalo",
				"Fabris",
				"Dante",
				"Oscar",
				"Jasiel",
				"Toño",
				"Razo",
				"Omar",
				"Salmo",
				"Olga",
				"Mina",
				"Lalo",
				"Fabris",
				"Dante",
				"Oscar",
				"Jasiel",
				"Toño",
				"Razo",
				"Omar",
				"Salmo",
				"Olga",
				"Mina",
				"Lalo",
				"Fabris",
				"Dante",
				"Oscar",
				"Jasiel",
				"Toño",
				"Razo"
			};

			//Utilizamos linq para poder filtrar la informacion
			//var nombre = from n in nombres
				     //where n.StartsWith ("O")
				     //select n;	

			//creamos una nueva lista
			var lista = new ListView {
				//asignamos el origen de datos al arreglo que formamos
				ItemsSource = //nombre //Podemos asignar la informacionya filtrada
					      nombres   //Asignamos todos los nombres sin filtrar
			};

			//Agregamos manejador de eventos para desplegar elementos seleccionados de la lista
			lista.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				//Validamos elementos dif de nulos, para inprimir la info del seleccionado
				if (e.SelectedItem != null){				
					DisplayAlert("Alerta","Ha seleccionado a " + e.SelectedItem,"Ok");
					lista.SelectedItem = null;//desmarcamos 
				}
			};

			//Asignamos el contenido de nuestra pagina al content que muestra 
			Content = lista;
		}
	}
}