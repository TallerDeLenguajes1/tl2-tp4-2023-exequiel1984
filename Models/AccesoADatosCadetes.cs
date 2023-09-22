namespace Practico1
{
    public class AccesoADatosCadetes
    {
        public abstract class AccesoADatos
        {
            public abstract List<Cadete> CargarDatosCadete();
        }

        public class AccesoCSV : AccesoADatos
    {
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
    }
}