public class Informe{
    // public List<double> EnviosPromedio {get;set;} = new List<double>();
    // public List<double> TotalMontos {get;set;}= new List<double>();
    // public List<string> NombreCadetes {get;set;}= new List<string>();
    //public double MontoTotal;
    public List<InformeCadete> InformeCadetes {get;set;} = new List<InformeCadete>();

    //public void AgregarInformeCadete(InformeCadete)
}
public class InformeCadete{
    private string nombre;
    private double monto;

    public string Nombre { get => nombre; set => nombre = value; }
    public double Monto { get => monto; set => monto = value; }

    public InformeCadete(){
    }
}