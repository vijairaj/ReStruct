using System;
using System.IO;
using ReStruct.Exceptions;

namespace ReStruct.Serializer.Fields
{
    public class FieldBase : IField
    {
        protected ReStructAttribute ParentAttribute;

        public FieldBase(ReStructAttribute parentAttribute)
        {
            ParentAttribute = parentAttribute;
        }

        public virtual void Serialize(System.IO.Stream stream, object obj)
        {
            throw new System.NotImplementedException();
        }

        public virtual object Deserialize(System.IO.Stream stream)
        {
            throw new System.NotImplementedException();
        }

        public byte[] Read(Stream stream, int size)
        {
            var buffer = new Byte[size];
            if (stream.Read(buffer, 0, size) != size) throw new BufferUnderflowException();
            return buffer;
        }
    }
}
