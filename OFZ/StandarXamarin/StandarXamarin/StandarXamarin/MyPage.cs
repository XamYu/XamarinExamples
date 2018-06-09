using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StandarXamarin
{
    public class MyPage : ContentPage
    {
        public MyPage() {
            var produtos = new[] {
                "Producto1",
                "Producto2",
                "Producto3",
                "Producto4",
                "Producto5",
                "Producto6"
            };

            var listaProductos = new ListView();
            listaProductos.ItemsSource = produtos;

            Content = listaProductos;





        }

    }
}
