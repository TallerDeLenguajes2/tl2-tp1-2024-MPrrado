using Clientes;
using espacioCadetes;
enum Estado 
{
    Pendiente = 0,
    Entregado = 1,
    Cancelado = 999
}


namespace espacioPedidos
{
    public class Pedidos
    {
        private int idPedido;
        private string observacion;
        private Cliente cliente;
        private Estado estado;
        private Cadete cadete;
        public int IdPedido { get => idPedido; }
        internal Estado Estado { get => estado; set => estado = value; }
        public Cadete Cadete { get => cadete; set => cadete = value; }

        public Pedidos(int nroPedido, string observaciones)
        {
            idPedido = nroPedido;
            observacion = observaciones;
            cliente = new Cliente ($"matias prado{nroPedido}", "santa fe 3333", "porton negro", 381);
            estado = Estado.Pendiente;
        }
        public void VerDireccionCliente()
        {
            System.Console.WriteLine(cliente.direccion);
        }

        public void VerDatosCliente()
        {
            System.Console.WriteLine($"Nombre: {cliente.nombre}");
            System.Console.WriteLine($"Direccion: {cliente.direccion}");
            System.Console.WriteLine($"Referencia direccion {cliente.refDireccion}");

        }

        public void mostrarPedido()
        {
            System.Console.WriteLine($"Numero de pedido: {idPedido}");
            System.Console.WriteLine($"Observacion: {observacion}");
            System.Console.WriteLine($"Datos cliente:\nNombre: {cliente.nombre}\nDireccion: {cliente.direccion}\nReferencia direccion: {cliente.refDireccion}\nTelefono: {cliente.telefono}");
            System.Console.WriteLine($"Estado: {estado}");
        }
    }

}