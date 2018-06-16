# Paso a paso practica SQLite


1.- Crear proyecto DemoSqlite, en crossplatform y net standard

2.- * Crear en estructura de proyecto sin extension, tres carpetas:
    *Clases
    *Datos
    *Paginas

3.- Agregar imagenes al proyecto Android en /Resources/Drawable/
    *agregar
    *modificar
    *eliminar

4.- Agreagar imagenes al proyecto iOS en /Resources/
    *agregar
    *modificar
    *eliminar








5.- En proyecto compartido Net Standar agregar nuevo Forms Content Page "/Paginas/PaginaAmigo.xaml"
    En esta vista sera visualizada la informacion que se desea almacenar:
        *Nombre                     Entry     
        *Sexo(hombre/mujer)         Picker
        *Cumpleaños                 DatePicker
        *Correo                     Entry
        *Numero                     Entry
        *Es mejor Amigo             Switch

    Tambien se agregara la barra superior con los iconos agregar, elliminar y modificar, acorde a cada plataforma

6.- El codigo xaml para "/Paginas/PaginaAmigo.xaml" es :

```
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="DemoSqlite.Paginas.PaginaAmigo">
    <ContentPage.Content>
        
        <StackLayout Spacing="20" Padding="20">
            <Entry x:Name="txtNombre" Placeholder="Nombre"/>
            <Picker x:Name="pckSexo" Title="Sexo">
                <Picker.Items>
                    <x:String>
                        Hombre
                    </x:String>
                    <x:String>
                        Mujer
                    </x:String>
                </Picker.Items>
            </Picker>

            <StackLayout Orientation="Horizontal">
                <Label Text="Cumpleaños" 
                       VerticalOptions="CenterAndExpand"/>
                <DatePicker x:Name="dppCumple"
                            Format="dd \de MMMM"
                            VerticalOptions="CenterAndExpand"
                            HeightRequest="50"/>
            </StackLayout>

            <Entry x:Name="txtCorreo" Placeholder="Correo"/>
            <Entry x:Name="txtTelefono" Placeholder="Telefono"/>

            <StackLayout Orientation="Horizontal">
                <Label Text="Es mejor amigo?" VerticalOptions="CenterAndExpand"/>
                <Switch x:Name="swtMejorAmigo" VerticalOptions="CenterAndExpand"/>
            </StackLayout>
            
        </StackLayout>
        
    </ContentPage.Content>

    <!-- indicamos content del toolbar superior  -->
    <ContentPage.ToolbarItems>
        <ToolbarItem x:Name="btnGuardar" Text="Guardar" Priority="0"
                     Clicked="btnGuardar_Click" Order="Primary" Icon="guardar.png"/>
        <ToolbarItem x:Name="btnEliminar" Text="Eliminar" Priority="1"
                     Clicked="btnEliminar_Click" Order="Primary"" Icon="eliminar.png"/>
    </ContentPage.ToolbarItems>

    
</ContentPage>

```

7.- Modificamos el archivo correspondiente "PaginaAmigo.cs", para añadir el comportamiento a la vista : 

```
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

		void btnGuardar_Click (object sender, System.EventArgs e) {

		}

		void btnEliminar_Click (object sender, System.EventArgs e) {

		}
	}
}

```

8.- A continuacion agregaremos un nuevo contenido para la lista de los amigos en la aplicacion, conteniendo :
        *Titulo (Amigos)                                                    Label
        *Lista de amigos almacenada                                         ListView
        *Barra de herramientas que permitira agregar nuevos amigos          ToolbarItem

    En proyecto compartido Net Standar agregar nuevo Forms Content Page "/Paginas/PaginaListaAmigos.xaml" : 

```
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="DemoSqlite.Paginas.PaginaListaAmigos">
    <ContentPage.Content>
        <StackLayout BackgroundColor="White">
            <Label Text="Amigos" FontSize="40" HorizontalOptions="Center"/>
            <ListView x:Name="lsvAmigos" ItemSelected="lsvAmigos_Selected" RowHeight="50">
                <ListView.ItemTemplate>
                    
                    <!-- El DataTemplate es una plantilla de como se muestran los elementos -->
                    <DataTemplate>
                        <!-- Informaciòn a mostrar a traves del enlace a datos "Binding" -->
                        <!-- La informacion sera tomada de una clase que se crea de manera independiente, en otra clase -->
                        <ViewCell>
                            <StackLayout Orientation="Horizontal">
                                <Label Text="{Binding Nombre}"
                                       TextColor="Blue" FontSize="16"/>
                                <Switch IsToggled="{Binding EsMejorAmigo}"
                                        HorizontalOptions="EndAndExpand"/>
                            </StackLayout>

                            <StackLayout Orientation="Horizontal">
                                <Label Text="{Binding Telefono}" HorizontalOptions="StartAndExpand" 
                                       TextColor="Green" FontSize="12"/>
                                <Label Text="{Binding Correo}" HorizontalOptions="EndAndExpand"
                                       TextColor="Green" FontSize="12"/>
                                    
                            </StackLayout>
                            
                        </ViewCell>
                    </DataTemplate>
                    
                </ListView.ItemTemplate>
            </ListView>
        </StackLayout>
    </ContentPage.Content>

    <!-- Creamos toolbar -->

    <ContentPage.ToolbarItems>
        <ToolbarItem x:Name="btnNuevo" Text="Nuevo" 
                     Priority="0" Clicked="btnNuevo_Click"
                     Order="Primary" Icon="agregar.png"/>
    </ContentPage.ToolbarItems>

    
</ContentPage>
```

9.- Agregamos comportamiento a la vista "/Paginas/PaginaListaAmigos.xaml.cs" solo el compartamiento de los dos botones:


```
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

		private void lsvAmigos_Selected (object sender, Xamarin.Forms.SelectedItemChangedEventArgs e) {

		}

		void btnNuevo_Click (object sender, System.EventArgs e) {

		}
	}
}

```

10.- Agregamos referencia de SQLite-net (https://github.com/praeclarum/sqlite-net), mediante package con VS o creando el archivo de manera manual:
    *Agregamos referencia mediante nuget a proyecto sin extension de plataforma y proyecto android (iOS no presenta inconvenientes)
    *NOTA : Proyectos Shared y Net Standard funciona hasta Android 6.0, superiores presenta problemas, modificando manifest en android.

11.- Agregamos nueva clase /Clases/Amigo.cs, nos servira de entidad para llenar los datos de cada registro.
    *Contendra las propiedades que requerimos almacenar, mediante atributo Table con datos a almacenar en nuestra base:

```
using System;
using SQLite;

namespace DemoSqlite.Clases {
	
	[Table ("Amigo")]
	public class Amigo {
		[PrimaryKey]
		public string ID { get; set; }
		public string Nombre { get; set; }
		public int Sexo { get; set; }
		public DateTime Cumple { get; set; }
		public string Correo { get; set; }
		public string Telefono { get; set; }
		public bool EsMejorAmigo { get; set; }
	}
}

```

12.- Agregamos una nueva clase "/Clases/BaseDatos.cs", contendra el CRUD(create,read,update,delete) de nuestra aplicación:

```
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

```

13.- Modificamos la pàgina base del proyecto compartido "/App.xaml":
    *Cambiamos el contentPage oringal por un navigationPage:
        *NOTA_NavigationPage : Permite navegar por mas de una pagina y compartir informacion entre ellas, usando un esquema tipo Stack.
                               Mostrando cada nueva pagina encima de la anterior(push)
                               Regresando a la pagina anterior presionando el boton de atras(pop)
                               NavigationPage requiere se le indique la vista que utilizara al inicio
    *Establecemos la ruta del archivo de nuestra base de datos (permitiendo llamar de nuestro CRUD desde cualquier parte de la app)

```
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

```

14.- Volvemos a modificar los metodos de codebehind de "/Paginas/PaginaListaAmigos.xaml.cs" buscando lo siguiente : 
    *Mostrar la lista de amigos actual en cuanto cargue la aplicacion, mediante la sobrecarga de "OnAppearing"
    *Navegar a la pagina "/Paginas/PaginaAmigos.xaml.cs" cuando se seleccione un amigo de la lista, enviando los datos del amigo seleccionado
    *Navegar a la misma pagina "/Paginas/PaginaAmigos.xaml.cs" cuando se seleccione la opcion "Nuevo amigo", sin enviar informacion

Codigo completo: 

```
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

```


15.- Continuamos con el comportamiento de la pagina de amigo indiviudal "/Paginas/PaginaAmigo.xaml.cs" buscando lo siguiente : 
    *Mostrar la informacion del amigo selecccionado, sobrecargando el metodo "OnAppearing", asegurando el renderizado de los controles
    *Guardar los datos ingresados mediante el boton guardar
    *Eliminar el amigo actualmente seleccionado mediante el boton eliminar

Codigo Completo : 
```
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

```    

16.- Compilar la aplicacion y validar su funcionamiento
