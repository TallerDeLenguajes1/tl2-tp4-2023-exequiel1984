namespace Practico1
{
    public class AccesoADatosPedidos
    {
        public AccesoADatosPedidos(){
            
        }
        public List<Pedido> Obtener()
        {
            List<Pedidos> ListadoPedidos = new List<Pedidos>();
            string ArchivoCSV = "DatosPedidos.csv";
            var LeerArchivoCSV = File.ReadAllLines(ArchivoCSV);

            for (int i = 0; i < LeerArchivoCSV.Length; i++)
            {
                var LineaCSV = (LeerArchivoCSV[i].Split(","));
                Pedido NuevoPedido = new Cadete(LineaCSV);
                ListadoPedidos.Add(NuevoPedido);
            }
            return ListadoPedidos;
        }
    }
}