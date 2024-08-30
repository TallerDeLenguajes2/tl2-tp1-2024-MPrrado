using espacioPedidos;
namespace espacioCadetes
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private int telefono;
        private List<Pedidos> listaPedidos;

        public List<Pedidos> ListaPedidos { get => listaPedidos;}

        public Cadete(int id, string nombre, string direccion, int telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            listaPedidos = new List<Pedidos>();
        }

        public void MostrarPedidos()
        {
            foreach (var pedido in listaPedidos)
            {
                System.Console.WriteLine($"-------Pedido Nro: {pedido.NroPedido}, Estado: {pedido.Estado}");
            }
        }

        public void MostrarID()
        {
            System.Console.WriteLine($"El ID del cadete es: {id}");
        }

        public void MostrarDatos()
        {
            System.Console.WriteLine($"Nombre: {nombre}\nDirección: {direccion}\nTeléfono: {telefono}");
        }
    
        public void AgregarPedido(Pedidos pedido)
        {
            listaPedidos.Add(pedido);
        }

        public void RemoverPedido(Pedidos pedido)
        {
            listaPedidos.Remove(pedido);
        }

        public bool PertenecePedido(Pedidos pedido)
        {
            return listaPedidos.Contains(pedido);
        }

        public double JornalACobrar()
        {
            double jornal = 10000;
            foreach (var pedido in listaPedidos)
            {
                if(pedido.Estado == Estado.Entregado)
                {
                    jornal += 500;
                }

            }
            return jornal;
        }

    }

}