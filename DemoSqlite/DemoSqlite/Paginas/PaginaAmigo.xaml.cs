using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DemoSqlite.Clases;

using Xamarin.Forms;

namespace DemoSqlite.Paginas {
	
	public partial class PaginaAmigo : ContentPage {

		public string ID = "";

		public PaginaAmigo () {
			InitializeComponent ();
		}

		protected override void OnAppearing () {
			base.OnAppearing ();

			if(ID!= null){
				var amigo = App.BD.ObtenerAmigo (ID);
				txtNombre.Text = amigo.Nombre;
				pckSexo.SelectedIndex = amigo.Sexo;
				dppCumple.Date = amigo.Cumple;
				txtCorreo.Text = amigo.Correo;
				txtTelefono.Text = amigo.Telefono;
				swtMejorAmigo.IsToggled = amigo.EsMejorAmigo;
			}
		}

		void btnGuardar_Click (object sender, System.EventArgs e) {
			//mapeamos valores del formulario
			var nombre = txtNombre.Text;
			var sexo = pckSexo.SelectedIndex;
			var cumple = dppCumple.Date;
			var correo = txtCorreo.Text;
			var telefono = txtTelefono.Text;
			var esMejorAmigo = swtMejorAmigo.IsToggled;

			App.BD.GuardarAmigo (ID, nombre, sexo, cumple, correo, telefono, esMejorAmigo);
			Navigation.PopAsync ();
		}

		void btnEliminar_Click (object sender, System.EventArgs e) {
			if(ID != ""){
				App.BD.EliminarAmigo (ID);
				Navigation.PopAsync ();
			}
		}
	}
}
