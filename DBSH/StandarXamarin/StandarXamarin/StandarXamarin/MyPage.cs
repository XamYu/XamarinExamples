using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StandarXamarin
{
   public class MyPage : ContentPage
    {
        public MyPage() {
            var vProductos = new[] {
                "Producto1",
                "Producto2",
                "Producto3",
                "Producto4",
                "Producto5",
                "Producto6",
            };

            Label Nombre = new Label
            {
                Text = "Daniela",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            var entryNombre = new Entry
            {
                Placeholder = "Escribe aqui tu nombre",
                Text = "Daniela Sánchez"
            };

            var actualizarNombre = new Button
            {
                Text = "Actualiza nombre",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };

            var vListaProductos = new ListView();
            vListaProductos.ItemsSource = vProductos;

            Content = new StackLayout
            {
                Children = {
                    Nombre,
                    entryNombre,
                    actualizarNombre,
                    vListaProductos
                }
            };
        }
    }
}
