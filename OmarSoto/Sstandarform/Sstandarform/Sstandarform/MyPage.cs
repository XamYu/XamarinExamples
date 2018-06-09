using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Sstandarform
{
    public class MyPage: ContentPage
    {
        public MyPage()
        {
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


            Content = listaProductos;
        }

    }
}
