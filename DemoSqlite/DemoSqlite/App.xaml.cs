using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Linq;
using System.Collections.Generic;
using System.Text;
using DemoSqlite.Clases;
using DemoSqlite.Paginas;


[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace DemoSqlite {
	
	public partial class App : Application {

		public static BaseDatos BD;

		public App () {
			var db = "amigos.db3";
			var ruta = System.IO.Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal), db);

			BD = new BaseDatos (ruta);

			MainPage = new NavigationPage (new PaginaListaAmigos ());
			InitializeComponent ();
			//MainPage = new MainPage ();
		}

		protected override void OnStart () {
			// Handle when your app starts
		}

		protected override void OnSleep () {
			// Handle when your app sleeps
		}

		protected override void OnResume () {
			// Handle when your app resumes
		}
	}
}
