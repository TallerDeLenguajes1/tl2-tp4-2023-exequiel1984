using System.Text.Json;

namespace Practico1
{
    public class AccesoADatosCadetes
    {
        public AccesoADatosCadetes(){
            
        }
        
        public List<Cadete> Obtener(){
            List<Cadete> ListaDeserealizada;
            string StringADeserealizar;
            using (var ArchivoOpen = new FileStream("DatosCadetes.json", FileMode.Open))
            {
                using (var strReader = new StreamReader(ArchivoOpen))
                {
                    StringADeserealizar = strReader.ReadToEnd();
                    ArchivoOpen.Close();
                }
                ListaDeserealizada = JsonSerializer.Deserialize<List<Cadete>>(StringADeserealizar);
            }
            return ListaDeserealizada;
        }

        public void Guardar(List<Cadete> listaCadetes){
            var json = JsonSerializer.Serialize(listaCadetes);
            File.WriteAllText("DatosCadetes.json", json);
        }
    }
}