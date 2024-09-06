using espacioCadeteria;
using espacioCadetes;
using espacioLecturaCargaDatos;
using espacioPedidos;
// using Clientes;
using System.ComponentModel;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

//constantes
const int PEDIDO_A_CARGAR = 10;
const double GANANCIA_PEDIDO_ENTREGADO = 2000;

string[] obs = { "Con sal Por favor", "Sin sal", "Con mayonesa", "sin tomate", "sin cebolla", "sin pepino", "con ketchup", "con pan", "con agua", "sin lechuga", "sin queso", "con sprite por favor" };
obs.ToImmutableArray(); //hacemos que el arreglo obs sea inmutable, asi lo puedo manejar como si fuera una cte


//variables e instanciaciones
Pedidos pedido = null;
List<Pedidos> listaPedidos = new List<Pedidos>(); //creamos esta lista para poder manejarnos mas facilmente con el alta de pedidos
// List<Cliente> listaClientes = CargarDatos.CargarDatosClientes();
List<Cadete> listaCadetes = CargarDatos.CargarDatosCadete();
if (listaCadetes != null)
{
    Cadeteria cadeteria = CargarDatos.CargarDatosCadeteria(listaCadetes);
    if (cadeteria != null)
    {
        System.Console.WriteLine("CADETERIA CARGADA CON ÉXITO");
        int nroPedido = 1;
        int opcion = 0;
        bool salir = false;
        while (opcion < 1 || opcion > 7 || !salir)
        {
            System.Console.WriteLine("-----MENU-----");
            System.Console.WriteLine("[1] ALTA PEDIDOS");
            System.Console.WriteLine("[2] ASIGNAR PEDIDOS A CADETES");
            System.Console.WriteLine("[3] CAMBIAR ESTADO PEDIDO");
            System.Console.WriteLine("[4] REASIGNAR PEDIDO");
            System.Console.WriteLine("[5] JORNALES A COBRAR");
            System.Console.WriteLine("[6] INFORME PEDIDOS");
            System.Console.WriteLine("[7] SALIR");
            System.Console.Write("Ingrese una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 7)
            {
                switch (opcion)
                {
                    case 1:
                        for(int i = 0; i < PEDIDO_A_CARGAR; i++)
                        {
                            pedido = cadeteria.AltaPedidos(ref nroPedido, obs);
                            listaPedidos.Add(pedido);
                        }
                        System.Console.WriteLine("PEDIDOS CARGADOS CON EXITO!");
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                    case 2:
                        if (pedido != null)
                        {
                            foreach(var pedidoAlta in listaPedidos)
                            {
                                cadeteria.AsignarPedido(pedidoAlta);
                            }
                            System.Console.WriteLine("ASGINACION CON EXITO!");
                            Thread.Sleep(500);
                            Console.Clear();
                        }
                        else
                        {
                            System.Console.WriteLine("ERROR, PRIMERO DEBE HABER PEDIDOS DADOS DE ALTA");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        break;
                    case 3:
                        cadeteria.CambiarEstadoPedido(listaPedidos);
                        break;
                    case 4:
                        cadeteria.ReasignarPedidoCadete(listaPedidos);
                        break;
                    case 5:
                        Console.Clear();
                        System.Console.WriteLine("----------------------------");
                        System.Console.WriteLine("JORNALES A COBRAR:");
                        foreach(var cadete in listaCadetes)
                        {
                            cadete.MostrarDatos();
                            System.Console.WriteLine($"Jornal a cobrar: ${cadete.JornalACobrar()}");
                            System.Console.WriteLine("----------------------------");
                        }
                        System.Console.WriteLine("presione una tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        //generamos un informe a traves de las sentencias Linq
                        IEnumerable<Pedidos> pedidosEntregados =  //aqui obtenemos los pedidos que fueron entregados de la lista de pedidos que manejamos exteriormente LO ESTA ARMANDO MAL!!
                        listaPedidos.TakeWhile(pedido => pedido.Estado == Estado.Entregado);

                        IEnumerable<Cadete> cadetesConPedidosEntregados = 
                        from cadete in listaCadetes
                        where cadete.ListaPedidos != null && cadete.ListaPedidos.Any(x => x.Estado == Estado.Entregado)
                        select cadete;

                        System.Console.WriteLine("-----------------------------------------");
                        System.Console.WriteLine("INFORME PEDIDOS:");
                        System.Console.WriteLine();
                        System.Console.WriteLine("PEDIDOS REALIZADOS POR CADA CADETE");
                        foreach (var cadete in cadetesConPedidosEntregados)
                        {
                            int contador = 0;
                            System.Console.WriteLine("---------------------");
                            cadete.MostrarDatos();
                            System.Console.WriteLine("Pedidos entregados:");
                            foreach (var pedidoEntregado in cadete.ListaPedidos)
                            {
                                if(pedidoEntregado.Estado == Estado.Entregado)
                                {
                                    contador++;
                                }
                            }
                            double promedioPedidos = cadete.ListaPedidos.Count / (double)contador;
                            Math.Round(promedioPedidos,2);
                            System.Console.WriteLine(contador);
                            System.Console.WriteLine($"Promedio de entrega:{promedioPedidos}");
                            System.Console.WriteLine("---------------------");
                        }

                        System.Console.WriteLine($"PEDIDOS TOTAL REALIZADOS EN ESTA JORNADA: {pedidosEntregados.Count()}");
                        System.Console.WriteLine($"GANANCIA TOTAL DE LA JORNADA: {pedidosEntregados.Count() * GANANCIA_PEDIDO_ENTREGADO}");

                        break;
                    case 7:
                        salir = true;
                        break;
                }

            }
            else
            {
                System.Console.WriteLine("ERROR, INGRESE UNA OPCION VALIDA");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
    else
    {
        System.Console.WriteLine("ERROR LOS DATOS DE LA CADETERIA NO SE PUDIERON CARGAR CON EXITO. LO SENTIMOS");
    }
}
else
{
    System.Console.WriteLine("ERROR LA LISTA DE CADETES NO SE PUDO CREAR CORRECTAMENTE. LO SENTIMOS");
}

