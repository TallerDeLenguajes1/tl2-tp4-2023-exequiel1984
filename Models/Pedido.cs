

namespace Practico1
{
    public enum Estados
    {
        Registrado,
        Asignado,
        Entregado
    };

    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private Estados estado;
        private int idCadete;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Estados Estado { get => estado; set => estado = value; }
        public int IdCadete { get => idCadete; set => idCadete = value; }

        public Pedido(int Nro, string Obs, Cliente NuevoCliente)
        {
            this.Nro = Nro;
            this.Obs = Obs;
            this.Cliente = NuevoCliente;
            this.Estado = Estados.Registrado;
        }

        public Pedido()
        {
            this.cliente = new Cliente();
        }

        public string VerDireccionCliente(){
            return Cliente.Direccion;
        }
    }
}