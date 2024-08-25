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
            System.Console.WriteLine("----------LISTA PEDIDOS ----------");
            foreach (var pedido in listaPedidos)
            {
                System.Console.WriteLine($"Pedido Nro: {pedido.NroPedido}, Estado: {pedido.Estado}");
            }
        }

        public void MostrarID()
        {
            System.Console.WriteLine($"El ID del cadete {nombre} es: {id}");
        }

        public void MostrarDatos()
        {
            System.Console.WriteLine($"Nombre: {nombre}\n Dirección: {direccion}\nTeléfono: {telefono}");
        }

        public void EntregarPedido()
        {
            int indicePedido = 0;
            int nroPedidoEntregar;
            System.Console.WriteLine("Ingrese el numero de pedido para entregar:");
            while(int.TryParse(Console.ReadLine(), out nroPedidoEntregar))
            {
                Console.WriteLine("Ingrese un numero valido de pedido:");
            }
            foreach(Pedidos pedido in listaPedidos)
            {
                if(pedido.NroPedido == nroPedidoEntregar)
                {
                    break;
                }
                indicePedido++;
            }

            listaPedidos[indicePedido].Estado = Estado.Entregado;
        }

        public void CancelarPedido()
        {
            int indicePedido = 0;
            int nroPedidoEntregar;
            System.Console.WriteLine("Ingrese el numero de pedido para cancelar:");
            while(int.TryParse(Console.ReadLine(), out nroPedidoEntregar))
            {
                Console.WriteLine("Ingrese un numero valido de pedido:");
            }
            foreach(Pedidos pedido in listaPedidos)
            {
                if(pedido.NroPedido == nroPedidoEntregar)
                {
                    break;
                }
                indicePedido++;
            }

            listaPedidos[indicePedido].Estado = Estado.Cancelado;
        }

    }

}