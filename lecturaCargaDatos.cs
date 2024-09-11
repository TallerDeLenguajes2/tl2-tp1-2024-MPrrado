using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Clientes;
using espacioCadeteria;
using espacioCadetes;

namespace espacioLecturaCargaDatos
{

    public abstract class AccesoADatos
    {
        public abstract List<Cadete> CargarDatosCadetes();
        public abstract Cadeteria CargarDatosCadeteria(List<Cadete>cadetes);

        protected abstract void CrearArchivos(int nroArchivo);
    }

    public class AccesoCSV : AccesoADatos
    {
        private static string carpetaCSV = "CSV_src";
        private static string CSV_Cadete = "CSV_cadete.csv";
        private static string CSV_Cadeteria = "CSV_cadeteria.csv";
        public override List<Cadete> CargarDatosCadetes()
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

        public override Cadeteria CargarDatosCadeteria(List<Cadete>cadetes)
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

        protected override void CrearArchivos(int nroCSV)
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
            }
        }
    
    }
    public class AccesoJSON : AccesoADatos
    {
        private static string carpetaJSON = "JSON_src";
        private static string JSON_Cadete = "JSON_cadetes.json";
        private static string JSON_Cadeteria = "JSON_cadeteria.json";
        public override List<Cadete> CargarDatosCadetes()
        {
            // Implementacion código para cargar datos de cadetes desde un archivo CSV

            CrearArchivos(1);
            string textoJsonCadetes = File.ReadAllText(Path.Combine(carpetaJSON, JSON_Cadete));
            return JsonSerializer.Deserialize<List<Cadete>>(textoJsonCadetes);
        }

        public override Cadeteria CargarDatosCadeteria(List<Cadete>cadetes)
        {
            Cadeteria cadeteriaTemp = null;
            // Implementacion código para cargar datos de cadetes desde un archivo JSON

            CrearArchivos(2);
            
            string textoJsonCadeteria = File.ReadAllText(Path.Combine(carpetaJSON, JSON_Cadeteria));
            cadeteriaTemp = JsonSerializer.Deserialize<Cadeteria>(textoJsonCadeteria);
            Cadeteria cadeteria = new Cadeteria(cadeteriaTemp.Nombre, cadeteriaTemp.Telefono, cadetes);
            return cadeteria;
        }

        protected override void CrearArchivos(int nroCSV)
        {
             //comprobamos que exista la carpeta donde estaran los CSV
            if (!Directory.Exists(carpetaJSON))
            {
                Directory.CreateDirectory(carpetaJSON);
            }
            switch(nroCSV)
            {
                case 1:
                    if (!File.Exists(Path.Combine(carpetaJSON, JSON_Cadete)))
                    {
                        File.Create(Path.Combine(carpetaJSON, JSON_Cadete));
                    }
                    break;
                case 2:
                    if (!File.Exists(Path.Combine(carpetaJSON, JSON_Cadeteria)))
                    {
                        File.Create(Path.Combine(carpetaJSON, JSON_Cadeteria));
                    }
                    break;
            }
        }
    
    }
}