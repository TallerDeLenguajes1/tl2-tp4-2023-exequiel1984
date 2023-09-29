using System.Text.Json;

namespace Practico1
{
    public class AccesoADatosPedidos
    {
        public AccesoADatosPedidos(){
            
        }

        /*static void CrearYEscribirArchivoJson(List<producto> Lista, string NombreNuevoArchivoJson)
        {
            string ListaSerealizada = JsonSerializer.Serialize(Lista);//Cargo datos

            using (var NuevoArchivoJson = new FileStream(NombreNuevoArchivoJson, FileMode.Create))
            {
                using (var strWriter = new StreamWriter(NuevoArchivoJson))
                {
                    strWriter.WriteLine("{0}", ListaSerealizada);
                    strWriter.Close();
                }
            }
        }*/

        /* public List<Pedido> Obtener()
        {
            List<Pedido> ListadoPedidos = new List<Pedido>();
            string ArchivoCSV = "DatosPedidos.csv";
            var LeerArchivoCSV = File.ReadAllLines(ArchivoCSV);

            for (int i = 0; i < LeerArchivoCSV.Length; i++)
            {
                var LineaCSV = (LeerArchivoCSV[i].Split(","));
                Pedido NuevoPedido = new Pedido(LineaCSV);
                ListadoPedidos.Add(NuevoPedido);
            }
            return ListadoPedidos;
        } */
    }
}