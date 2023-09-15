using System.Text.Json;

namespace Practico1
{
    public abstract class AccesoADatos
    {
        public abstract Cadeteria CargarDatosCadeteria();
        public abstract List<Cadete> CargarDatosCadete();

    }

    public class AccesoCSV : AccesoADatos
    {
        public override Cadeteria CargarDatosCadeteria(){
            string ArchivoCSV = "DatosCadeteria.csv";
            var LeerArchivoCSV = File.ReadAllLines(ArchivoCSV);
            var LineaCSV = (LeerArchivoCSV[0]).Split(",");
            
            Cadeteria NuevaCadeteria = new Cadeteria(LineaCSV[0], LineaCSV[1]);
            return NuevaCadeteria;
        }

        public override List<Cadete> CargarDatosCadete()
        {
            List<Cadete> ListadoCadetes = new List<Cadete>();
            string ArchivoCSV = "DatosCadetes.csv";
            var LeerArchivoCSV = File.ReadAllLines(ArchivoCSV);

            for (int i = 0; i < LeerArchivoCSV.Length; i++)
            {
                var LineaCSV = (LeerArchivoCSV[i].Split(","));
                Cadete NuevoCadete = new Cadete(LineaCSV);
                ListadoCadetes.Add(NuevoCadete);
            }
            return ListadoCadetes;
        }
    }

    public class AccesoJSON : AccesoADatos
    {
        public override Cadeteria CargarDatosCadeteria()
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

        public override List<Cadete> CargarDatosCadete(){
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
    }    
}