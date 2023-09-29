using System.Data.Common;

namespace Practico1;

    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private AccesoADatosCadetes accesoADatosCadetes;
        private AccesoADatosPedidos accesoADatosPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public AccesoADatosPedidos AccesoADatosPedidos { get => accesoADatosPedidos; set => accesoADatosPedidos = value; }
        public AccesoADatosCadetes AccesoADatosCadetes { get => accesoADatosCadetes; set => accesoADatosCadetes = value; }

    public Cadeteria(string Nombre, string Telefono)
        {
            this.Nombre = Nombre;
            this.Telefono = Telefono;
        }

        public Cadeteria()
        {
            
        }

        private static Cadeteria instance;

        public static Cadeteria GetInstance()
        {
            if (instance == null)
            {
                AccesoADatosCadeteria accesoADatosCadeteria = new AccesoADatosCadeteria();
                instance = accesoADatosCadeteria.Obtener();
                
                instance.AccesoADatosCadetes = new AccesoADatosCadetes();
                instance.AccesoADatosPedidos = new AccesoADatosPedidos();
            }
            return instance;
        }

        public List<Cadete> GetCadetes()
        {
            return AccesoADatosCadetes.Obtener();
        }

        public Pedido AddPedido(Pedido pedido){
            List<Pedido> listaPedidos = AccesoADatosPedidos.Obtener();
            listaPedidos.Add(pedido);
            pedido.Nro = listaPedidos.Count;
            accesoADatosPedidos.Guardar(listaPedidos);
            return pedido;
        }

        public List<Pedido> GetPedidos()
        {
            return instance.AccesoADatosPedidos.Obtener();
        }

        public Pedido AsignarPedido(int idPedido, int idCadete){
            List<Pedido> listaPedidos = AccesoADatosPedidos.Obtener();
            Pedido auxPedido = listaPedidos.FirstOrDefault(t => t.Nro == idPedido);
            auxPedido.IdCadete = idCadete;
            accesoADatosPedidos.Guardar(listaPedidos);
            return auxPedido;
        }

        public Pedido CambiarEstadoPedido(int idPedido, Estados nuevoEstado){
            List<Pedido> listaPedidos = AccesoADatosPedidos.Obtener();
            Pedido auxPedido = listaPedidos.FirstOrDefault(t => t.Nro == idPedido);
            auxPedido.Estado = nuevoEstado;
            accesoADatosPedidos.Guardar(listaPedidos);

            return auxPedido;
        }
        
        public Pedido CambiarCadetePedido(int idPedido, int idNuevoCadete){
            List<Pedido> listaPedidos = AccesoADatosPedidos.Obtener();
            Pedido auxPedido = listaPedidos.FirstOrDefault(t => t.Nro == idPedido);
            auxPedido.IdCadete = idNuevoCadete;
            accesoADatosPedidos.Guardar(listaPedidos);
            return auxPedido;
        }

        private float JornalACobrar(int IdCadete){
            float montoACobrar = 0;
            List<Pedido> listaPedidos = accesoADatosPedidos.Obtener();
            foreach (Pedido Pedido in listaPedidos)
            {   
                if (Pedido.IdCadete == IdCadete && Pedido.Estado == Estados.Entregado)
                {
                    montoACobrar+=500;
                }
            }
            return montoACobrar;
        }
        public Informe GetInforme(){
            var informe = new Informe();
            List<Cadete> listaCadetes = accesoADatosCadetes.Obtener();
            foreach (Cadete cadete in listaCadetes)
            {
                var informeCad = new InformeCadete();
               /* informe.TotalMontos.Add(JornalACobrar(cadete.Id));
               informe.EnviosPromedio.Add(JornalACobrar(cadete.Id));  */
                informeCad.Nombre = cadete.Nombre;
                informeCad.Monto = JornalACobrar(cadete.Id);

                informe.InformeCadetes.Add(informeCad);
            }
            return informe;
        }
    }
