using System.Data.Common;

namespace Practico1;

    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        private List<Pedido> ListadoPedidos;
        private AccesoADatosCadeteria accesoADatosCadeteria;
        private AccesoADatosCadetes accesoADatosCadetes;
        private AccesoADatosPedidos accesoADatosPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public AccesoADatosPedidos AccesoADatosPedidos { get => accesoADatosPedidos; set => accesoADatosPedidos = value; }
        public AccesoADatosCadeteria AccesoADatosCadeteria { get => accesoADatosCadeteria; set => accesoADatosCadeteria = value; }
        public AccesoADatosCadetes AccesoADatosCadetes { get => accesoADatosCadetes; set => accesoADatosCadetes = value; }

    public Cadeteria(string Nombre, string Telefono)
        {
            this.Nombre = Nombre;
            this.Telefono = Telefono;
            this.ListadoCadetes = new List<Cadete>();
            this.ListadoPedidos = new List<Pedido>();
        }

        public Cadeteria()
        {
            
        }

        private static Cadeteria instance;

        public static Cadeteria GetCadeteria()
        {
            if (instance == null)
            {
                instance = new Cadeteria();
                //instance.AccesoADatosCadeteria = new AccesoADatosCadeteria().Obtener;
                AccesoADatosCadeteria accesoADatosCadeteria = new AccesoADatosCadeteria();
                AccesoADatosCadetes accesoADatosCadetes = new AccesoADatosCadetes();
                instance = accesoADatosCadeteria.Obtener();
                instance.ListadoCadetes = accesoADatosCadetes.Obtener();





                //AccesoADatosPedidos AccesoADatosPedidos = new AccesoADatosPedidos();
                //instance.AccesoADatosPedidos = new AccesoADatosPedidos();
                //cadeteriaSingleton.ListadoPedidos = AccesoADatosPedidos.Obtener();
            }
            return instance;
        }

        public List<Cadete> GetCadetes()
        {
            return ListadoCadetes;
        }

        public Pedido AddPedido(Pedido pedido){
            ListadoPedidos.Add(pedido);
            pedido.Nro = ListadoPedidos.Count;
            //Acceso
            return pedido;
        }

        public List<Pedido> GetPedidos()
        {
            return ListadoPedidos;
        }

        public Pedido AsignarPedido(int idPedido, int idCadete){
            Pedido auxPedido = ListadoPedidos.FirstOrDefault(t => t.Nro == idPedido);
            auxPedido.IdCadete = idCadete;
            return auxPedido;
        }

        public Pedido CambiarEstadoPedido(int idPedido, Estados nuevoEstado){
            Pedido auxPedido = ListadoPedidos.FirstOrDefault(t => t.Nro == idPedido);
            auxPedido.Estado = nuevoEstado;
            return auxPedido;
        }
        
        public Pedido CambiarCadetePedido(int idPedido, int idNuevoCadete){
            Pedido auxPedido = ListadoPedidos.FirstOrDefault(t => t.Nro == idPedido);
            auxPedido.IdCadete = idNuevoCadete;
            return auxPedido;
        }

        private float JornalACobrar(int IdCadete){
            float montoACobrar = 0;
            foreach (Pedido Pedido in ListadoPedidos)
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

            foreach (Cadete cadete in ListadoCadetes)
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
