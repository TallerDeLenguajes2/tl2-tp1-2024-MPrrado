using espacioPedidos;
namespace espacioCadetes
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private int telefono;

        public int Id { get => id;}

        // private List<Pedidos> listaPedidos;

        // public List<Pedidos> ListaPedidos { get => listaPedidos;}

        public Cadete(int id, string nombre, string direccion, int telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            // listaPedidos = new List<Pedidos>();
        }

        // public void MostrarPedidos()
        // {
        //     foreach (var pedido in listaPedidos)
        //     {
        //         System.Console.WriteLine($"-------Pedido Nro: {pedido.NroPedido}, Estado: {pedido.Estado}");
        //     }
        // }

        public void MostrarID()
        {
            System.Console.WriteLine($"El ID del cadete es: {Id}");
        }

        public void MostrarDatos()
        {
            System.Console.WriteLine($"Nombre: {nombre}\nDirección: {direccion}\nTeléfono: {telefono}");
        }
    
        // public void AgregarPedido(Pedidos pedido)
        // {
        //     listaPedidos.Add(pedido);
        // }

        // public void RemoverPedido(Pedidos pedido)
        // {
        //     listaPedidos.Remove(pedido);
        // }

        // public bool PertenecePedido(Pedidos pedido)
        // {
        //     return listaPedidos.Contains(pedido);
        // }

    }

}