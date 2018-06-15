using System;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;


namespace DemoSqlite.Clases {


	//indicamos el CRUD base


	public class BaseDatos :SQLiteConnection {

		//constructor
		public BaseDatos (string path) : base(path) {
			CrearTablas ();
		}

		void CrearTablas(){
			CreateTable<Amigo> ();
		}

		public ObservableCollection<Amigo> ObtenerAmigos(){

			return new ObservableCollection<Amigo> (this.Table<Amigo> ().ToList ());
		}

		public Amigo ObtenerAmigo(string id){
			return (id == "") ? new Amigo () : Table<Amigo> ().Where (t => t.ID == id).First ();
		}

		public void GuardarAmigo(string id, string nombre, int sexo, DateTime cumple, string correo, string telefono, bool esMejorAmigo){
			var amigo = ObtenerAmigo (id);
			amigo.Nombre = nombre;
			amigo.Sexo = sexo;
			amigo.Cumple = cumple;
			amigo.Correo = correo;
			amigo.Telefono = telefono;
			amigo.EsMejorAmigo = esMejorAmigo;

			if (id == "")
				AgregarAmigo (amigo);
			else
				ActualizarAmigo (amigo);
				
		}

		public void AgregarAmigo(Amigo amigo){
			//creamos nuevo identificador de amigo
			amigo.ID = Guid.NewGuid ().ToString ();
			this.Insert (amigo);
		}

		public void ActualizarAmigo(Amigo amigo){
			this.Update (amigo);
		}

		public void EliminarAmigo(string id){
			var amigo = Table<Amigo> ().Where (t => t.ID == id).First ();
			this.Delete (amigo);

		}
	}
}
