using System.Text.Json;

namespace Practico1
{
    public class AccesoADatosPedidos
    {
        public AccesoADatosPedidos(){
            
        }

        public void Guardar(List<Pedido> listaPedidos){
            var json = JsonSerializer.Serialize(listaPedidos);
            File.WriteAllText("Pedidos.json", json);
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

        /* public List<Pedido> Obtener(){
            List<Pedido> ListaDeserealizada;
            string StringADeserealizar;
            using (var ArchivoOpen = new FileStream("Pedidos.json", FileMode.Open))
            {
                using (var strReader = new StreamReader(ArchivoOpen))
                {
                    StringADeserealizar = strReader.ReadToEnd();
                    ArchivoOpen.Close();
                }
                ListaDeserealizada = JsonSerializer.Deserialize<List<Pedido>>(StringADeserealizar);
            }
            return ListaDeserealizada;
        } */

        public List<Pedido> Obtener() {
            var path = "Pedidos.json";
            if (File.Exists(path)) {
                string json = File.ReadAllText(path);
                var pedidos = JsonSerializer.Deserialize<List<Pedido>>(json);
                return pedidos;
            }
            return null;
        }
    }
}