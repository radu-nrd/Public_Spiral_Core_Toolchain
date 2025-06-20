

namespace TurboTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var inputFile = Directory.GetFiles("Input", "*.batch", SearchOption.AllDirectories).FirstOrDefault();
            //var mlModelFile = Directory.GetFiles("MLMs", "*.nn", SearchOption.AllDirectories).FirstOrDefault();
            //string[] simArgs =
            //    $"-mlm {mlModelFile} -bfp {inputFile} -e 1000 -i 10 -lr 0.01".Split(" ");

            var config = Config.GetConfig(args);

            if (config is null)
                return;

            var trainer = new Trainer(config);
            trainer.Start();
        }


    }
}