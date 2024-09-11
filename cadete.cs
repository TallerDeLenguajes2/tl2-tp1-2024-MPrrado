using espacioPedidos;
using System.Text.Json.Serialization;
namespace espacioCadetes
{
    public class Cadete
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }
        [JsonPropertyName("telefono")]
        public int Telefono { get; set; }
        [JsonPropertyName("cantidadPedidosEntregados")]
        public int CantidadPedidosEntregados { get; set; }
        [JsonPropertyName("cantidadPedidosAsignados")]
        public int CantidadPedidosAsignados { get; set; }

        public Cadete(int id, string nombre, string direccion, int telefono)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        public void MostrarID()
        {
            System.Console.WriteLine($"El ID del cadete es: {Id}");
        }

        public void MostrarDatos()
        {
            System.Console.WriteLine($"Nombre: {Nombre}\nDirección: {Direccion}\nTeléfono: {Telefono}");
        }

        public void EntregarPedido()
        {
            CantidadPedidosEntregados++;
        }
        public void AsignarPedido()
        {
            CantidadPedidosAsignados++;
        }

        public int ObtenerCantidadPedidosEntregados()
        {
            return CantidadPedidosEntregados;
        }

        public int ObtenerCantidadPedidosAsignados()
        {
            return CantidadPedidosAsignados;
        }
    }

}