using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StandarXamarin
{
    public class MyPage : ContentPage
    {

        public MyPage()
        {

            Label Nombre = new Label {

                Text = "Luis Mario",
                FontSize = 40,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            var entryNombre = new Entry {
                Placeholder = "Escribe aqui tu nombre",
                Text = "Luis Mario"
            };

            var actualizarNombre = new Button
            {
                Text = "Actualiza el nombre",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };

            var productos = new[] {
                "Producto1",
                "Producto2",
                "Producto3",
                "Producto4",
                "Producto5",
                "Producto6"
            };

            var listaProductos = new ListView();
            listaProductos.ItemsSource = productos;

            Content = new StackLayout {

                Children = {
                    Nombre,
                    entryNombre,
                    actualizarNombre,
                    listaProductos
                }

            };

        }

    }
}
