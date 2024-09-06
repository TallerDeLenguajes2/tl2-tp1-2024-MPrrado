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
        public List<Pedidos> listaPedidos ;

        public Cadeteria(string nombre, int telefono, List<Cadete> listadoCadetes)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.listadoCadetes = listadoCadetes;
            listaPedidos = new List<Pedidos>();
        }

        public void AltaPedidos(ref int nroPedidoAlta, string[] observaciones)
        {
            Random rnd = new Random();
            Pedidos pedido = new Pedidos(nroPedidoAlta, observaciones[rnd.Next(0, 10)]);
            nroPedidoAlta++;
            listaPedidos.Add(pedido);
        }

        public void AsignarCadeteAPedido(int idCadete, int idPedido)
        {
            //Aquí se selecciona un cadete y se le asigna el pedido
            listaPedidos[idPedido-1].Cadete = listadoCadetes[idCadete];

        }

        public void CambiarEstadoPedido()
        {
            int nroPedido;
            System.Console.WriteLine("Los pedidos disponibles son:");
            System.Console.WriteLine();
            System.Console.WriteLine();
            foreach (var pedido in listaPedidos)
            {
                if (pedido.Estado != Estado.Cancelado || pedido.Estado != Estado.Entregado)
                {
                    pedido.mostrarPedido();
                }
                System.Console.WriteLine("---------------------------------------");
            }
            System.Console.WriteLine("Seleccione el numero de pedido que desea cambiar de estado");
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
                            System.Console.WriteLine("PEDIDO ENTREGADO CON EXITO!");
                            Thread.Sleep(500);
                            break;
                        case 2:
                            pedido.Estado = Estado.Cancelado;
                            System.Console.WriteLine("PEDIDO CANCELADO CON EXITO!");
                            Thread.Sleep(500);
                            break;
                    }
                }
            }
        }

        // public void ReasignarPedidoCadete()
        // {
        //     System.Console.WriteLine("Los pedidos disponibles para reasignar son:");
        //     System.Console.WriteLine();
        //     System.Console.WriteLine();
        //     foreach (var pedido in listaPedidos)
        //     {
        //         if (pedido.Estado != Estado.Cancelado || pedido.Estado != Estado.Entregado)
        //         {
        //             pedido.mostrarPedido();
        //         }
        //         System.Console.WriteLine("---------------------------------------");
        //     }
        //     int nroPedido;
        //     System.Console.WriteLine("INGRESE EL NUMERO DE PEDIDO A REASIGNAR: ");
        //     while (!int.TryParse(Console.ReadLine(), out nroPedido) || nroPedido > listaPedidos.Count)
        //     {
        //         System.Console.WriteLine("ERROR, ingrese un numero valido");
        //     }

        //     MostrarCadetes();
        //     System.Console.WriteLine("Seleccione el cadete para reasignar el pedido");
        //     int nroCadete;
        //     while (!int.TryParse(Console.ReadLine(), out nroCadete) || nroCadete > listadoCadetes.Count)
        //     {
        //         System.Console.WriteLine("ERROR, ingrese un numero valido");
        //     }
        //     foreach (var pedido in listaPedidos)
        //     {
        //         if (pedido.Cadete.Id == nroCadete)
        //         {
        //             cadete.RemoverPedido(listaPedidos[nroPedido - 1]);
        //             listadoCadetes[nroCadete-1].AgregarPedido(listaPedidos[nroPedido-1]);
        //             break;
        //         }
        //     }

        // }
        private void MostrarCadetes()
        {
            System.Console.WriteLine("----------CADETES DISPONIBLES----------");
            System.Console.WriteLine();
            foreach (var cadete in listadoCadetes)
            {
                cadete.MostrarID();
                cadete.MostrarDatos();
                System.Console.WriteLine("------------------------------------");
                System.Console.WriteLine();
            }
        }

        public double JornalACobrar(int idCadete)
        {
            double jornal = 5000;
            System.Console.WriteLine($"El cadete de ID:{idCadete} cobra en motivo de jornal:");
            foreach(var pedido in listaPedidos)
            {
                if(pedido.Cadete.Id == idCadete && pedido.Estado == Estado.Entregado)
                {
                    jornal+=500;
                }
            }
            return jornal;
        }
    }
}