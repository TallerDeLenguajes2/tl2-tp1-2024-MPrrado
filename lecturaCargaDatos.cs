using System.Runtime.CompilerServices;
using Clientes;
using espacioCadeteria;
using espacioCadetes;

namespace espacioLecturaCargaDatos
{
    public static class CargarDatos
    {
        private static string carpetaCSV = "CSV_src";
        private static string CSV_Cadete = "CSV_cadete.csv";
        private static string CSV_Cadeteria = "CSV_cadeteria.csv";
        private static string CSV_Cliente = "CSV_Cliente.csv";
        public static List<Cadete> CargarDatosCadete()
        {
            List<Cadete> cadetes = new List<Cadete>();

            // Implementacion código para cargar datos de cadetes desde un archivo CSV

            CrearArchivos(1);

            // Leer el archivo CSV y crear objetos de cadete
            using (StreamReader sr = new StreamReader(Path.Combine(carpetaCSV, CSV_Cadete)))
            {
                string linea;
                while (!sr.EndOfStream)
                {
                    linea = sr.ReadLine();
                    string[] valores = linea.Split(',');
                    // Crear objeto de cadete y agregarlo a la lista
                    try
                    {
                        int.TryParse(valores[0], out int id);
                        string nombre = valores[1];
                        string direccion = valores[2];
                        int.TryParse(valores[3], out int telefono);
                        Cadete cadete = new Cadete(id, nombre, direccion, telefono);
                        cadetes.Add(cadete);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("Error, el tipo de dato de algun campo del CSV no coinciden con el tipo que acepta el objeto cadete");
                    }
                }
            }
            return cadetes;
        }
        public static Cadeteria CargarDatosCadeteria(List<Cadete>cadetes)
        {
            Cadeteria cadeteria = null;
            // Implementacion código para cargar datos de cadetes desde un archivo CSV

            CrearArchivos(2);

            // Leer el archivo CSV y crear objetos de cadete
            using (StreamReader sr = new StreamReader(Path.Combine(carpetaCSV, CSV_Cadeteria)))
            {
                string linea;
                while (!sr.EndOfStream)
                {
                    linea = sr.ReadLine();
                    string[] valores = linea.Split(',');
                    // Crear objeto de cadeteria 
                    try
                    {
                        string nombre = valores[0];
                        int.TryParse(valores[1], out int telefono);
                        cadeteria = new Cadeteria(nombre, telefono, cadetes);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("Error, el tipo de dato de algun campo del CSV no coinciden con el tipo que acepta el objeto cadete");
                    }
                }
            }
            return cadeteria;
        }

        // public static List<Cliente> CargarDatosClientes()
        // {
        //     List<Cliente> listaClientes = null;
        //     // Implementacion código para cargar datos de cadetes desde un archivo CSV

        //     CrearArchivos(2);

        //     // Leer el archivo CSV y crear objetos de cadete
        //     using (StreamReader sr = new StreamReader(Path.Combine(carpetaCSV, CSV_Cliente)))
        //     {
        //         string linea;
        //         while (!sr.EndOfStream)
        //         {
        //             linea = sr.ReadLine();
        //             string[] valores = linea.Split(',');
        //             // Crear objeto de cadeteria 
        //             try
        //             {
        //                 string nombre = valores[0];
        //                 string direccion = valores[1];
        //                 string refDireccion = valores[2];
        //                 int.TryParse(valores[3], out int telefono);
        //                 Cliente cliente = new Cliente(nombre, direccion,refDireccion,telefono);
        //                 listaClientes.Add(cliente);
        //             }
        //             catch (Exception e)
        //             {
        //                 System.Console.WriteLine("Error, el tipo de dato de algun campo del CSV no coinciden con el tipo que acepta el objeto cadete");
        //             }
        //         }
        //     }
        //     return listaClientes;
        // }

        private static void CrearArchivos(int nroCSV)
        {
            //comprobamos que exista la carpeta donde estaran los CSV
            if (!Directory.Exists(carpetaCSV))
            {
                Directory.CreateDirectory(carpetaCSV);
            }
            switch(nroCSV)
            {
                case 1:
                    if (!File.Exists(Path.Combine(carpetaCSV, CSV_Cadete)))
                    {
                        File.Create(Path.Combine(carpetaCSV, CSV_Cadete));
                    }
                    break;
                case 2:
                    if (!File.Exists(Path.Combine(carpetaCSV, CSV_Cadeteria)))
                    {
                        File.Create(Path.Combine(carpetaCSV, CSV_Cadeteria));
                    }
                    break;
                case 3:
                    if (!File.Exists(Path.Combine(carpetaCSV, CSV_Cliente)))
                    {
                        File.Create(Path.Combine(carpetaCSV, CSV_Cliente));
                    }
                    break;
            }

            
        }
    }
}