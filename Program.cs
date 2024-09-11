﻿using espacioCadeteria;
using espacioCadetes;
using espacioLecturaCargaDatos;
using espacioPedidos;
// using Clientes;
using System.ComponentModel;
using System.Collections.Immutable;
using System.Runtime.InteropServices;

//constantes
const int PEDIDOS_A_CARGAR = 10;
// const double GANANCIA_PEDIDO_ENTREGADO = 2000;

string[] obs = { "Con sal Por favor", "Sin sal", "Con mayonesa", "sin tomate", "sin cebolla", "sin pepino", "con ketchup", "con pan", "con agua", "sin lechuga", "sin queso", "con sprite por favor" };
obs.ToImmutableArray(); //hacemos que el arreglo obs sea inmutable, asi lo puedo manejar como si fuera una cte
const int CANTIDAD_PEDIDOS = 10;
const int GANANCIA_PEDIDO_ENTREGADO = 10000;

//variables e instanciaciones
<<<<<<< HEAD
 int idPedido;
 int idCadete;
// List<Pedidos> listaPedidos = new List<Pedidos>(); //creamos esta lista para poder manejarnos mas facilmente con el alta de pedidos
// List<Cliente> listaClientes = CargarDatos.CargarDatosClientes();
List<Cadete> cadetes = CargarDatos.CargarDatosCadete();
if (cadetes != null)
=======
List<Cadete> listaCadetes = CargarDatos.CargarDatosCadete();
Random rnd = new Random();

if (listaCadetes != null)
>>>>>>> f2b1b3044b45bb08714c8347cd9ff8bf7ed224db
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
<<<<<<< HEAD
            System.Console.WriteLine("[5] MOSTRAR JORNAL A COBRAR DE UN CADETE");
            System.Console.WriteLine("[6] INFORME");
=======
            System.Console.WriteLine("[5] JORNALES A COBRAR");
            System.Console.WriteLine("[6] INFORME PEDIDOS");
>>>>>>> f2b1b3044b45bb08714c8347cd9ff8bf7ed224db
            System.Console.WriteLine("[7] SALIR");
            System.Console.Write("Ingrese una opción: ");
            if (int.TryParse(Console.ReadLine(), out opcion) && opcion >= 1 && opcion <= 7)
            {
                switch (opcion)
                {
                    case 1:
<<<<<<< HEAD
                        for(int i = 0 ; i < CANTIDAD_PEDIDOS; i++)
=======
                        for(int i = 0; i < PEDIDOS_A_CARGAR; i++)
>>>>>>> f2b1b3044b45bb08714c8347cd9ff8bf7ed224db
                        {
                            cadeteria.AltaPedidos(ref nroPedido, obs);
                        }
                        System.Console.WriteLine("PEDIDOS CARGADOS CON EXITO!");
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                    case 2:
<<<<<<< HEAD
                        if (cadeteria.listaPedidos.Count() != 0)
                        {
                            idPedido = SolicitudIdPedido(cadeteria);
                            idCadete = SolicitudIdCadete(cadetes, cadeteria);
                            cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
                            System.Console.WriteLine("CADETE ASIGNADO CON EXITO!");
                            Thread.Sleep(500);
                            Console.Clear();
                        }
                        else
=======
                        try
                        {
                            int i = 0;
                            int n = 2*i+1;
                            while(n <= cadeteria.listaPedidos.Count)
                            {
                                cadeteria.AsignarCadeteAPedido(rnd.Next(0,10), n);
                                i++;
                                n = 2*i+1;
                            }
                            System.Console.WriteLine("ASGINACION CON EXITO!");
                            Thread.Sleep(500);
                            Console.Clear();
                        }catch(Exception e)
>>>>>>> f2b1b3044b45bb08714c8347cd9ff8bf7ed224db
                        {
                            System.Console.WriteLine("ERROR, PRIMERO DEBE HABER PEDIDOS DADOS DE ALTA");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        break;
                    case 3:
                        cadeteria.CambiarEstadoPedido();
<<<<<<< HEAD
                        Thread.Sleep(500);
                        Console.Clear();
                        break;
                    case 4:
                        cadeteria.ReasignarPedidoCadete();
                        break;
                    case 5:
                        System.Console.WriteLine("-----------JORNAL A COBRAR-----------");
                        double jornal = cadeteria.JornalACobrar(SolicitudIdCadete(cadetes,cadeteria));
                        System.Console.WriteLine($"El jornal a cobrar es: ${jornal}");
                        System.Console.WriteLine("presione cualquier tecla para continuar.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        //generamos un informe a traves de las sentencias Linq
                        IEnumerable<Pedidos> pedidosEntregados =  //aqui obtenemos los pedidos que fueron entregados de la lista de pedidos que manejamos exteriormente
                        cadeteria.listaPedidos
                        .Where(pedido => pedido.Estado == Estado.Entregado);
                        

                        System.Console.WriteLine("-----------------------------------------");
                        System.Console.WriteLine("INFORME PEDIDOS:");
                        System.Console.WriteLine();
                        System.Console.WriteLine("PEDIDOS REALIZADOS POR CADA CADETE");
                        System.Console.WriteLine();
                        System.Console.WriteLine("-----------------------------------------");
                        foreach (var pedido in pedidosEntregados)
                        {
                           
                            double promedioPedidos = (double) pedido.Cadete.CantidadPedidosEntregados() / pedido.Cadete.CantidadPedidosAsignados()*100;
                            System.Console.WriteLine("Datos cadete: ");
                            pedido.Cadete.MostrarDatos();
                            System.Console.WriteLine($"Pedidos entregados:{pedido.Cadete.CantidadPedidosEntregados()}");
                            System.Console.WriteLine($"Promedio de entrega:{Math.Round(promedioPedidos,2)}%");
                            System.Console.WriteLine("---------------------");
                        }

                        System.Console.WriteLine($"PEDIDOS TOTAL REALIZADOS EN ESTA JORNADA: {pedidosEntregados.Count()}");
                        System.Console.WriteLine($"GANANCIA TOTAL DE LA JORNADA: ${pedidosEntregados.Count() * GANANCIA_PEDIDO_ENTREGADO}");
                        System.Console.WriteLine("presione cualquier tecla para continuar.....");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        salir=true;
                        System.Console.WriteLine("saliendo....");
                        Thread.Sleep(500);
                        Console.Clear();
=======
                        break;
                    case 4:
                        // cadeteria.ReasignarPedidoCadete();
                        break;
                    case 5:
                        Console.Clear();
                        System.Console.WriteLine("Ingrese el id del cadete para ver el jornal a cobrar:");
                        int idCadete = 0;
                        while(int.TryParse(Console.ReadLine(), out idCadete) && idCadete <= 0 && idCadete>listaCadetes.Count)
                        {
                            System.Console.WriteLine("ERROR, ingrese un numero valido");
                        }
                        System.Console.WriteLine("----------------------------");
                        System.Console.WriteLine($"JORNAL A COBRAR:${cadeteria.JornalACobrar(idCadete)}");
                        System.Console.WriteLine("presione una tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    // case 6:
                    //     //generamos un informe a traves de las sentencias Linq
                    //     IEnumerable<Pedidos> pedidosEntregados =  //aqui obtenemos los pedidos que fueron entregados de la lista de pedidos que manejamos exteriormente
                    //     listaPedidos
                    //     .Where(pedido => pedido.Estado == Estado.Entregado);
                        

                    //     IEnumerable<Cadete> cadetesConPedidosEntregados = //tener cuidado con esta expresion query de linq por como procesa las query
                    //     from cadete in listaCadetes
                    //     where cadete.ListaPedidos != null && cadete.ListaPedidos.Any(x => x.Estado == Estado.Entregado)
                    //     select cadete;

                    //     System.Console.WriteLine("-----------------------------------------");
                    //     System.Console.WriteLine("INFORME PEDIDOS:");
                    //     System.Console.WriteLine();
                    //     System.Console.WriteLine("PEDIDOS REALIZADOS POR CADA CADETE");
                    //     foreach (var cadete in cadetesConPedidosEntregados)
                    //     {
                    //         int contador = 0;
                    //         System.Console.WriteLine("---------------------");
                    //         cadete.MostrarDatos();
                    //         foreach (var pedidoEntregado in cadete.ListaPedidos)
                    //         {
                    //             if(pedidoEntregado.Estado == Estado.Entregado)
                    //             {
                    //                 contador++;
                    //             }
                    //         }
                    //         double promedioPedidos = (double)contador / cadete.ListaPedidos.Count * 100;
                    //         Math.Round(promedioPedidos,2);
                    //         System.Console.WriteLine($"Pedidos entregados:{contador}");
                    //         System.Console.WriteLine($"Promedio de entrega:{promedioPedidos}%");
                    //         System.Console.WriteLine("---------------------");
                    //     }

                    //     System.Console.WriteLine($"PEDIDOS TOTAL REALIZADOS EN ESTA JORNADA: {pedidosEntregados.Count()}");
                    //     System.Console.WriteLine($"GANANCIA TOTAL DE LA JORNADA: {pedidosEntregados.Count() * GANANCIA_PEDIDO_ENTREGADO}");

                    //     break;
                    case 7:
                        salir = true;
>>>>>>> f2b1b3044b45bb08714c8347cd9ff8bf7ed224db
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
<<<<<<< HEAD
}

static int SolicitudIdPedido(Cadeteria cadeteria)
{
    int idPedido;
    cadeteria.MostrarPedidosPendientes();
    System.Console.WriteLine("Ingrese el id del pedido: ");
    while (!int.TryParse(Console.ReadLine(), out idPedido) || !cadeteria.listaPedidos.Exists(p => p.IdPedido == idPedido))
    {
        System.Console.WriteLine("ERROR, INGRESE UN ID VALIDO");
    }

    return idPedido;
}

static int SolicitudIdCadete(List<Cadete> cadetes, Cadeteria cadeteria)
{
    int idCadete;
    cadeteria.MostrarCadetes();
    System.Console.WriteLine("Ingrese el id del cadete: ");
    while (!int.TryParse(Console.ReadLine(), out idCadete) || !cadetes.Exists(c => c.Id == idCadete))
    {
        System.Console.WriteLine("ERROR, INGRESE UN ID VALIDO");
    }

    return idCadete;
}
=======
}
>>>>>>> f2b1b3044b45bb08714c8347cd9ff8bf7ed224db
