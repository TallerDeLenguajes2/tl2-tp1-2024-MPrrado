using espacioCadetes;
using espacioPedidos;

namespace espacioCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private int telefono;
        private List<Cadete> listadoCadetes;
        public string Nombre { get => nombre; }
        public int Telefono { get => telefono; }

        public Cadeteria(string nombre, int telefono, List<Cadete> listadoCadetes)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.listadoCadetes = listadoCadetes;
        }

        public Pedidos AltaPedidos(ref int nroPedidoAlta, string[] observaciones)
        {
            Random rnd = new Random();
            Pedidos pedido = new Pedidos(nroPedidoAlta, observaciones[rnd.Next(0, 10)]);
            return pedido;
        }

        public void AsignarPedido(Pedidos pedido)
        {
            int nroCadete;
            //Aquí se selecciona un cadete y se le asigna el pedido

            MostrarCadetes();

            System.Console.WriteLine("Seleccione el cadete para asignar el pedido");
            while (!int.TryParse(Console.ReadLine(), out nroCadete) || nroCadete > listadoCadetes.Count)
            {
                System.Console.WriteLine("ERROR, ingrese un numero valido");
            }
            var cadeteAsignado = listadoCadetes[nroCadete - 1];
            cadeteAsignado.AgregarPedido(pedido);
        }

        public void ReasignarPedidoCadete(List<Pedidos> listaPedidos)
        {
            System.Console.WriteLine("Los pedidos disponibles para reasignar son:");
            foreach (var pedido in listaPedidos)
            {
                if (pedido.Estado != Estado.Cancelado || pedido.Estado != Estado.Entregado)
                {
                    pedido.mostrarPedido();
                }
            }
            int nroPedido;
            while (!int.TryParse(Console.ReadLine(), out nroPedido) || nroPedido > listaPedidos.Count)
            {
                System.Console.WriteLine("ERROR, ingrese un numero valido");
            }

            MostrarCadetes();
            System.Console.WriteLine("Seleccione el cadete para reasignar el pedido");
            int nroCadete;
            while (!int.TryParse(Console.ReadLine(), out nroCadete) || nroCadete > listadoCadetes.Count)
            {
                System.Console.WriteLine("ERROR, ingrese un numero valido");
            }
            foreach (var cadete in listadoCadetes)
            {
                // foreach (var pedido in cadete.ListaPedidos)
                // {
                //     if (pedido.NroPedido == nroPedido)
                //     {
                //         listaPedidos.Remove(pedido);
                //         break;
                //     }
                // }
                if (cadete.PertenecePedido(listaPedidos[nroPedido - 1]))
                {
                    cadete.RemoverPedido(listaPedidos[nroPedido - 1]);
                    listadoCadetes[nroCadete-1].AgregarPedido(listaPedidos[nroPedido-1]);
                    break;
                }
            }

        }
        private void MostrarCadetes()
        {
            System.Console.WriteLine("----------CADETES DISPONIBLES----------");
            System.Console.WriteLine();
            foreach (var cadete in listadoCadetes)
            {
                cadete.MostrarID();
                cadete.MostrarDatos();
                System.Console.WriteLine("------------------------------------");
                System.Console.WriteLine("pedidos del cadete:");
                cadete.MostrarPedidos();
            }
            System.Console.WriteLine("------------------------------------");
        }
    }
}