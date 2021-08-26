﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
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
    public class Serialize_Once_SimplePocos
    {
        private readonly SimplePocoJSON _jsonPoco;
        private readonly SimplePocoMsgPack _msgPackPoco;
        private readonly SimplePocoProtobuf _protobufPoco;
        private readonly SimplePocoBebop _bebopPoco;

        public Serialize_Once_SimplePocos()
        {
            _jsonPoco = JsonUtilities.GenerateSimple();
            _msgPackPoco = MessagePackUtilities.GenerateSimple();
            _protobufPoco = ProtobufUtilities.GenerateSimple();
            _bebopPoco = BebobUtilities.GenerateSimple();
        }

        [Benchmark]
        public string Serialize_Json_Newtonsoft()
            => JsonConvert.SerializeObject(_jsonPoco);

        [Benchmark]
        public string Serialize_Json_SystemText()
            => System.Text.Json.JsonSerializer.Serialize(_jsonPoco);

        [Benchmark]
        public byte[] Serialize_Protobuf()
            => _protobufPoco.ToByteArray();

        [Benchmark]
        public byte[] Serialize_MessagePack()
            => MessagePackSerializer.Serialize(_msgPackPoco);

        [Benchmark]
        public byte[] Serialize_Bebop()
            => _bebopPoco.Encode();
    }
}