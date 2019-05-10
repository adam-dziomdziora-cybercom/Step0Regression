using System;
using Microsoft.ML;
using Step0Regression.Models;

namespace Step0Regression {
    class Program {

        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");

            // 0. Create the common context for all ML.NET operations
            var mlContext = new MLContext ();
            //

            // 1. Import or create training data          
            HouseData[] houseData = new [] {
                new HouseData () { Size = 1.1F, Price = 1.2F },
                new HouseData () { Size = 1.9F, Price = 2.3F },
                new HouseData () { Size = 2.8F, Price = 3.0F },
                new HouseData () { Size = 3.4F, Price = 3.7F }
            };
            IDataView trainingData = mlContext.Data.LoadFromEnumerable (houseData);
            //

            // 1A. Preview loaded data in the debugger
            var trainingDataDebugger = trainingData.Preview ();
            //

         }
    }
}