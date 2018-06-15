using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using DemoSqlite.Clases;

namespace DemoSqlite.Paginas {
	
	public partial class PaginaListaAmigos : ContentPage {
		
		public PaginaListaAmigos () {
			InitializeComponent ();
		}

		//Mostrar la lista de amigos al cargar la página (se sobreescribe el método OnAppearing 
		//para asegurar que el control ha sido inicializado).
		protected override void OnAppearing () {
			base.OnAppearing ();

			lsvAmigos.ItemsSource = App.BD.ObtenerAmigos ();
		}

		private void lsvAmigos_Selected (object sender, Xamarin.Forms.SelectedItemChangedEventArgs e) {
			if (e.SelectedItem != null) {
				Amigo amigo = e.SelectedItem as Amigo;
		                PaginaAmigo pagina = new PaginaAmigo();
		                pagina.ID = amigo.ID;
		                Navigation.PushAsync(pagina);
            		}
		}

		void btnNuevo_Click (object sender, System.EventArgs e) {
			Navigation.PushAsync (new PaginaAmigo ());
		}
	}
}
