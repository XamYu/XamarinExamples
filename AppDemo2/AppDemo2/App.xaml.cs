using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace AppDemo2 {
	public partial class App : Application {
		public App () {
			InitializeComponent ();

			//·Ejemplo con layout tipo grilla
			MainPage = new EjemploGridLayout ();

			//·Ejemplo con layout tipo Absoluto
			//MainPage = new EjemploAbsoluteLayout ();

			//·Vista con ejemplo scroll layout
			//MainPage = new EjemploScrollLayout ();

			//·Nueva vista con demo de Binding de Datos
			//MainPage = new ListasDemo ();

			//·Nueva vista con Binding de datos prueba
			//MainPage = new MainPage ();

			//·Nueva pagina que construimos sin eventos, solo controles de prueba
			//MainPage = new MyContentPage ();

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
