using System.Text.Json.Serialization;
using espacioCadetes;
using espacioPedidos;

namespace espacioCadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private int telefono;
        private List<Pedidos> listaPedidos;
        public string Nombre { get => nombre; }
        public int Telefono { get => telefono; }
        public string Nombre1 { get => nombre; set => nombre = value; }
        public int Telefono1 { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get; set; }
        public List<Pedidos> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }

        public Cadeteria(string nombre, int telefono, List<Cadete> listadoCadetes)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.ListadoCadetes = listadoCadetes;
            ListaPedidos = new List<Pedidos>();
        }

        public void AltaPedidos(ref int nroPedidoAlta, string[] observaciones)
        {
            Random rnd = new Random();
            Pedidos pedido = new Pedidos(nroPedidoAlta, observaciones[rnd.Next(0, 10)]);
            nroPedidoAlta++;
            ListaPedidos.Add(pedido);
        }

        public void AsignarCadeteAPedido(int idCadete, int idPedido)
        {
            //Aquí se selecciona un cadete y se le asigna el pedido
           ListaPedidos[idPedido-1].Cadete = ListadoCadetes[idCadete-1];
           ListadoCadetes[idCadete-1].AsignarPedido();
        }

        public void CambiarEstadoPedido()
        {
            int nroPedido;
            MostrarPedidosPendientes();
            System.Console.WriteLine("Seleccione el numero de pedido que desea cambiar de estado");
            while(!int.TryParse(Console.ReadLine(), out nroPedido) || nroPedido > ListaPedidos.Count || nroPedido < 1 || ListaPedidos[nroPedido-1].Estado == Estado.Entregado)
            {
                System.Console.WriteLine("Error ingrese un numero de pedido valido");
            }

            foreach (var pedido in ListaPedidos)
            {
                if(pedido.IdPedido == nroPedido)
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
                            pedido.Cadete.EntregarPedido();
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

        public void ReasignarPedidoCadete()
        {
            MostrarPedidosPendientes();

            int idPedido;
            System.Console.WriteLine("INGRESE EL NUMERO DE PEDIDO A REASIGNAR: ");
            while (!int.TryParse(Console.ReadLine(), out idPedido) || idPedido > ListaPedidos.Count)
            {
                System.Console.WriteLine("ERROR, ingrese un numero valido");
            }

            MostrarCadetes();
            System.Console.WriteLine("Seleccione el cadete para reasignar el pedido");
            int idCadete;
            while (!int.TryParse(Console.ReadLine(), out idCadete) || idCadete > ListadoCadetes.Count)
            {
                System.Console.WriteLine("ERROR, ingrese un numero valido");
            }
            if(ListaPedidos[idPedido].Cadete == ListadoCadetes[idCadete-1])
            {
                System.Console.WriteLine("El cadete seleccionado ya tiene este pedido, no se puede reasignar");
                Thread.Sleep(500);
            }else
            {
                ListaPedidos[idPedido-1].Cadete = ListadoCadetes[idCadete-1];
            }

        }

        public void MostrarPedidosPendientes()
        {
            System.Console.WriteLine("Los pedidos disponibles son:");
            System.Console.WriteLine();
            System.Console.WriteLine();
            foreach (var pedido in ListaPedidos)
            {
                if (pedido.Estado != Estado.Entregado)
                {
                    pedido.mostrarPedido();
                }
                System.Console.WriteLine("---------------------------------------");
            }
        }

        public void MostrarCadetes()
        {
            System.Console.WriteLine("----------CADETES DISPONIBLES----------");
            System.Console.WriteLine();
            foreach (var cadete in ListadoCadetes)
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
            System.Console.WriteLine($"El cadete de ID:{idCadete}");
            System.Console.WriteLine();
            ListadoCadetes[idCadete-1].MostrarDatos();
            IEnumerable<Pedidos> listaPedidosEntregados = 
            ListaPedidos
            .Where(p =>p.Estado == Estado.Entregado && p.Cadete != null);
            listaPedidosEntregados.ToList();
            foreach(var pedido in listaPedidosEntregados)
            {
                if(pedido.Cadete.Id == idCadete && pedido.Estado == Estado.Entregado)
                {
                    jornal +=500;
                }
            }
            return jornal;
        }
    }
}