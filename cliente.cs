namespace Clientes
{
    public class Cliente
    {
        public string? nombre;
        public string? direccion;
        public string? refDireccion;
        public int? telefono;
        public Cliente(string nombre, string direccion,string refDireccion,int telefono)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.refDireccion = refDireccion;
            this.telefono = telefono;
        }
    }
}