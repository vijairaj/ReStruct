using System;
using System.IO;
using ReStruct.Serializer.Fields;

namespace ReStruct.Serializer
{
    public class BinarySerializer : IFormatter
    {
        public void Serialize(Stream stream, object obj)
        {
            var fieldMapper = new FieldMapper(obj, null);
            foreach (var field in fieldMapper)
                field.Serialize(stream);
        }

        public T Deserialize<T>(Stream stream) where T: class
        {
            var type = typeof (T);
            var obj = Activator.CreateInstance(type) as T;
            var fieldMapper = new FieldMapper(obj, null);

            foreach (var field in fieldMapper)
                field.Deserialize(stream);

            return obj;
        }
    }
}
