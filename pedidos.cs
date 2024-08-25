using Clientes;
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
        private int nroPedido;
        private string observacion;
        private Cliente cliente;
        private Estado estado;

        public int NroPedido { get => nroPedido; }
        internal Estado Estado { get => estado; set => estado = value; }

        public Pedidos(int nroPedido, string observaciones)
        {
            this.nroPedido = nroPedido;
            this.observacion = observaciones;
            cliente = new Cliente ($"matias prado{nroPedido}", "santa fe 3333", "porton negro", 381);
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

        public void mostrarPedido()
        {
            System.Console.WriteLine($"Numero de pedido: {nroPedido}");
            System.Console.WriteLine($"Observacion: {observacion}");
            System.Console.WriteLine($"Datos cliente: Nombre: {cliente.nombre}\nDireccion{cliente.direccion}\n Referencia direccion: {cliente.refDireccion}\n Telefono: {cliente.telefono}\n");
            System.Console.WriteLine($"Estado: {estado}");
        }
    }

}