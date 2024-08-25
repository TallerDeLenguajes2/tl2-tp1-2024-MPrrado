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

        public void CambiarEstadoPedido(List<Pedidos> listaPedidos)
        {
            int nroPedido;
            while(!int.TryParse(Console.ReadLine(), out nroPedido) || nroPedido > listaPedidos.Count || nroPedido < 1)
            {
                System.Console.WriteLine("Error ingrese un numero de pedido valido");
            }

            foreach (var pedido in listaPedidos)
            {
                if(pedido.NroPedido == nroPedido)
                {
                    System.Console.WriteLine("Seleccione que desea hacer con este pedido: ");
                    System.Console.WriteLine();
                    int opcion = 0;
                    while(opcion <1 || opcion > 2)
                    {
                        System.Console.WriteLine("[1] ENTREGADO");
                        System.Console.WriteLine("[2] CANCELADO");
                        int.TryParse(Console.ReadLine(), out opcion);
                        if(opcion <1 || opcion > 2)
                        {
                            System.Console.WriteLine("ERROR, ingrese una opcion válida");
                        }
                    }

                    switch(opcion)
                    {
                        case 1:
                            pedido.Estado = Estado.Entregado;
                            break;
                        case 2:
                            pedido.Estado = Estado.Cancelado;
                            break;
                    }
                }
            }
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

    }

}