﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

using Google.Protobuf;

using MessagePack;

using Newtonsoft.Json;

using ProgrammerAl.Serialization.Entities.Bebop;
using ProgrammerAl.Serialization.Entities.JSON;
using ProgrammerAl.Serialization.Entities.MessagePack;
using ProgrammerAl.Serialization.Entities.Protobuf;

namespace ProgrammerAl.Serialization.Benchmarks
{
    public class CreateAndSerializeAndDeserialize_ComplexPocos
    {
        [Benchmark]
        public ComplexPocoJSON NewtonsoftJson()
        {
            var poco = JsonUtilities.GenerateComplex();
            var serialized = JsonConvert.SerializeObject(poco);
            return JsonConvert.DeserializeObject<ComplexPocoJSON>(serialized)!;
        }

        [Benchmark]
        public ComplexPocoJSON SystemTextJson()
        {
            var poco = JsonUtilities.GenerateComplex();
            var serialized = System.Text.Json.JsonSerializer.Serialize(poco);
            return System.Text.Json.JsonSerializer.Deserialize<ComplexPocoJSON>(serialized)!;
        }

        [Benchmark]
        public ComplexPocoProtobuf Protobuf()
        {
            var poco = ProtobufUtilities.GenerateComplex();
            var serialized = poco.ToByteArray();
            return ComplexPocoProtobuf.Parser.ParseFrom(serialized);
        }

        [Benchmark]
        public ComplexPocoMsgPack MessagePack()
        {
            var poco = MessagePackUtilities.GenerateComplex();
            var serialized = MessagePackSerializer.Serialize(poco);
            return MessagePackSerializer.Deserialize<ComplexPocoMsgPack>(serialized);
        }

        [Benchmark]
        public ComplexPocoBebop Bebop()
        {
            var poco = BebobUtilities.GenerateComplex();
            var serialized = poco.Encode();
            return ComplexPocoBebop.Decode(serialized);
        }
    }
}
