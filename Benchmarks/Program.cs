﻿using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace ProgrammerAl.Serialization.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var runConfig = DefaultConfig.Instance
                                        .AddDiagnoser(MemoryDiagnoser.Default)
                                        .AddExporter(MarkdownExporter.Default)
                                        .AddValidator(ExecutionValidator.FailOnError);

            _ = BenchmarkRunner.Run<CreateAndSerialize_TinyPocos>(runConfig);
            _ = BenchmarkRunner.Run<CreateAndSerialize_SimplePocos>(runConfig);

            _ = BenchmarkRunner.Run<Serialize_Once_TinyPocos>(runConfig);
            _ = BenchmarkRunner.Run<Serialize_Once_SimplePocos>(runConfig);

            _ = BenchmarkRunner.Run<Serialize_Multiple_TinyPocos>(runConfig);
            _ = BenchmarkRunner.Run<Serialize_Multiple_SimplePocos>(runConfig);
        }
    }
}