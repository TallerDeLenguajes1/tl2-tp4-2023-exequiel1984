namespace Practico1
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private string telefono;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }


        public Cadete(){
            
        }
        public Cadete(string[] DatosCadete){
            this.Id = Convert.ToInt32(DatosCadete[0]);
            this.Nombre = DatosCadete[1];
            this.Direccion = DatosCadete[2];
            this.Telefono = DatosCadete[3];
        }

        public Cadete(int Id, string Nombre, string Direccion, string Telefono){
            this.Id = Id;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
        }
    }
}