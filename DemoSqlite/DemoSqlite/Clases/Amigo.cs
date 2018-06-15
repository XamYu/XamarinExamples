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
