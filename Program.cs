using espacioCadeteria;
using espacioCadetes;
using espacioLecturaCargaDatos;
using espacioPedidos;
using Clientes;
using System.ComponentModel;

List<Pedidos> pedidos = new List<Pedidos>(); //creamos esta lista para poder manejarnos mas facilmente con el alta de pedidos
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
        while (opcion < 1 || opcion > 5)
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
                switch(opcion)
                {
                    case 1:

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
        string observaciones = $"con sal por favor{nroPedido}";
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

