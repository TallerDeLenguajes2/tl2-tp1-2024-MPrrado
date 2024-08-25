using espacioCadeteria;
using espacioCadetes;
using espacioLecturaCargaDatos;
using espacioPedidos;
using Clientes;
using System.ComponentModel;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

//constantes

string[] obs = { "Con sal Por favor", "Sin sal", "Con mayonesa", "sin tomate", "sin cebolla", "sin pepino", "con ketchup", "con pan", "con agua", "sin lechuga", "sin queso", "con sprite por favor" };
obs.ToImmutableArray();


//variables e instanciaciones
Pedidos pedido = null;
List<Pedidos> listaPedidos = new List<Pedidos>(); //creamos esta lista para poder manejarnos mas facilmente con el alta de pedidos
// List<Cliente> listaClientes = CargarDatos.CargarDatosClientes();
List<Cadete> cadetes = CargarDatos.CargarDatosCadete();
if (cadetes != null)
{
    Cadeteria cadeteria = CargarDatos.CargarDatosCadeteria(cadetes);
    if (cadeteria != null)
    {
        System.Console.WriteLine("CADETERIA CARGADA CON ÉXITO");
        int nroPedido = 1;
        int opcion = 0;
        bool salir = false;
        while (opcion < 1 || opcion > 5 || !salir)
        {
            System.Console.WriteLine("-----MENU-----");
            System.Console.WriteLine("[1] ALTA PEDIDOS");
            System.Console.WriteLine("[2] ASIGNAR PEDIDO A CADETE");
            System.Console.WriteLine("[3] CAMBIAR ESTADO PEDIDO");
            System.Console.WriteLine("[4]REASIGNAR PEDIDO");
            System.Console.WriteLine("[5] SALIR");
            System.Console.Write("Ingrese una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 5)
            {
                switch (opcion)
                {
                    case 1:
                        pedido = cadeteria.AltaPedidos(ref nroPedido, obs);
                        listaPedidos.Add(pedido);
                        System.Console.WriteLine("PEDIDO CARGADO CON EXITO!");
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                    case 2:
                        if (pedido != null)
                        {
                            cadeteria.AsignarPedido(pedido);
                        }
                        else
                        {
                            System.Console.WriteLine("ERROR, PRIMERO DEBE HABER PEDIDO DADOS DE ALTA");
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

