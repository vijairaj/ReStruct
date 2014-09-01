using System;
using System.IO;
using System.Linq;

namespace ReStruct.Serializer.Fields
{
    public class UnsignedField : FieldBase
    {
        private readonly int _size;
        private readonly Type _type;

        public UnsignedField(ReStructAttribute parentAttribute, Type type, int size) : base(parentAttribute)
        {
            ParentAttribute = parentAttribute;
            _type = type;
            _size = size;
        }

        public override void Serialize(Stream stream, object obj)
        {
            var bytes = new byte[_size];
            var value = (ulong) Convert.ChangeType(obj, typeof (ulong));
            for (var i = 0; i < _size; ++i)
                bytes[i] = (byte) (((value) >> (i*8)) & 0xFF);
            if (ParentAttribute.Endianness == Endianness.Big) Array.Reverse(bytes);
            stream.Write(bytes, 0, bytes.Length);
        }

        public override object Deserialize(Stream stream)
        {
            var bytes = Read(stream, _size);
            if (ParentAttribute.Endianness == Endianness.Little) Array.Reverse(bytes);
            var value = bytes.Aggregate<byte, ulong>(0, (current, b) => (current << 8) + b);
            return Convert.ChangeType(value, _type);
        }
    }
}
