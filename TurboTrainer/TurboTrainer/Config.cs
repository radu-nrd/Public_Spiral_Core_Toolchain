using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TurboTrainer
{
    public class Config
    {
        public string MachineLearnModelFilePath {  get; set; }
        public string NormalizedBatchFilePath {  get; set; }
        public int Epochs { get; set; }
        public int Iterations { get; set; }
        public double LearningRate {  get; set; }

        public Config()
        {
            MachineLearnModelFilePath = string.Empty;
            NormalizedBatchFilePath = string.Empty;
        }

        public static Config? GetConfig(string[] args)
        {
            Config cfg = new Config();
            if(!IsValidCommand(args))
            {
                Console.WriteLine("INVALID COMMAND!");
                return null;
            }

            try
            {
                cfg.Decode(args, ref cfg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }



            return cfg;
        }

        private static bool IsValidCommand(string[] args)
        {
            string[] fullCommandArguments = ["-mlm","-bfp","-e","-i","-lr"];
            return fullCommandArguments.All(arg=>args.Contains(arg));
        }

        private void Decode(string[] args, ref Config cfg)
        {
            for(int i = 0;i < args.Length;i++)
                switch (args[i])
                {
                    case "-mlm":
                        cfg.MachineLearnModelFilePath = args[i+1];
                        break;
                    case "-bfp":
                        cfg.NormalizedBatchFilePath = args[i+1];
                        break;
                    case "-e":
                        cfg.Epochs = int.Parse(args[i+1]);
                        break;
                    case "-i":
                        cfg.Iterations = int.Parse(args[i+1]);
                        break;
                    case "-lr":
                        cfg.LearningRate = double.Parse(args[i+1]);
                        break;

                }
        }
    }
}
