﻿using System;
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

            // 2. Specify data preparation and model training pipeline
            var pipeline = mlContext.Transforms
                .Concatenate ("Features", new [] { "Size" })
                .Append (mlContext.Regression.Trainers.Sdca (labelColumnName: "Price", maximumNumberOfIterations : 100));
            //

            // 3. Train model
            var model = pipeline.Fit (trainingData);
            //

            // 4. Make a prediction
            var size = new HouseData () { Size = 2.5F };
            var predictionEngine = mlContext.Model.CreatePredictionEngine<HouseData, Prediction> (model);
            var price = predictionEngine.Predict (size);
            //

            Console.WriteLine ($"Predicted price for size: {size.Size * 1000} sq ft= {price.Price * 100:C}");

        }
    }
}