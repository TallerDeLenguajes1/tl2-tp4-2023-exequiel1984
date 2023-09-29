using System.Text.Json;

namespace Practico1
{
    public class AccesoADatosCadeteria
    {
        public AccesoADatosCadeteria(){
            
        }
        
        public Cadeteria Obtener()
        {
            Cadeteria NuevaCadeteria;
            string StringADeserealizar;
            using(var ArchivoOpen = new FileStream("DatosCadeteria.json", FileMode.Open)){
                using(var strReader = new StreamReader(ArchivoOpen)){
                    StringADeserealizar = strReader.ReadToEnd();
                    ArchivoOpen.Close();
                }
                NuevaCadeteria = JsonSerializer.Deserialize<Cadeteria>(StringADeserealizar); 
            }
            return NuevaCadeteria;
        }
    }
}