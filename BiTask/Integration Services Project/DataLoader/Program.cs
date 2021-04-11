namespace DataLoader
{
    public class Program
    {
        static void Main(string[] args)
        {
            var isBiTestDwContext = new IsBiTestDwContext();

            //firs we go through all input file to create dimensions only
            //isBiTestDwContext.CreateDimentions(new FileReader(), new DataParser());

            //on the second go we create facts
            isBiTestDwContext.CreateFacts(new FileReader(), new DataParser());
        }
    }
}
