﻿using KeyAsio.Shared.Models;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace KeyAsio.Shared.Configuration;

public class BindKeysConverter : IYamlTypeConverter
{
    private static readonly Type Type = typeof(BindKeys);
    public bool Accepts(Type type)
    {
        if (type == Type) return true;
        return false;
    }

    public object ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer)
    {
        var s = parser.Consume<Scalar>();
        var convertFrom = BindKeys.Parse(s.Value);
        return convertFrom;
    }

    public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer)
    {
        emitter.Emit(new Scalar(value?.ToString() ?? ""));
    }
}