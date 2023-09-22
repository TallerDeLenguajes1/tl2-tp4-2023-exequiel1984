namespace Practico1
{
    public class AccesoADatosCadeteria
    {
        public Cadeteria CargarDatosCadeteria(){
            string ArchivoCSV = "DatosCadeteria.csv";
            var LeerArchivoCSV = File.ReadAllLines(ArchivoCSV);
            var LineaCSV = (LeerArchivoCSV[0]).Split(",");
            
            Cadeteria NuevaCadeteria = new Cadeteria(LineaCSV[0], LineaCSV[1]);
            return NuevaCadeteria;
        }

        
    }
}