using espacioPedidos;
namespace espacioCadetes
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private int telefono;
        private int cantidadPedidosEntregados;
        private int cantidadPedidosAsignados;

        public int Id { get => id;}

<<<<<<< HEAD
=======

>>>>>>> f2b1b3044b45bb08714c8347cd9ff8bf7ed224db
        public Cadete(int id, string nombre, string direccion, int telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public void MostrarID()
        {
            System.Console.WriteLine($"El ID del cadete es: {Id}");
        }

        public void MostrarDatos()
        {
            System.Console.WriteLine($"Nombre: {nombre}\nDirección: {direccion}\nTeléfono: {telefono}");
        }
<<<<<<< HEAD

        public void EntregarPedido()
        {
            cantidadPedidosEntregados++;
        }
        public void AsignarPedido()
        {
            cantidadPedidosAsignados++;
        }

        public int CantidadPedidosEntregados()
        {
            return cantidadPedidosEntregados;
        }

        public int CantidadPedidosAsignados()
        {
            return cantidadPedidosAsignados;
        }
=======
>>>>>>> f2b1b3044b45bb08714c8347cd9ff8bf7ed224db
    }

}