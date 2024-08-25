using Clientes;
enum Estado 
{
    Pendiente = 0,
    Entregado = 1,
    Cancelado = 99
}


namespace espacioPedidos
{
    public class Pedidos
    {
        private int nroPedido;
        private string observaciones;
        private Cliente cliente;
        private Estado estado;

        public Pedidos(int nroPedido, string observaciones, Cliente cliente)
        {
            this.nroPedido = nroPedido;
            this.observaciones = observaciones;
            this.cliente = cliente;
            this.estado = Estado.Pendiente;
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
    }

}