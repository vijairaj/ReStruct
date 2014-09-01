using System;
using System.Text;

namespace ReStruct.Serializer
{
    public enum Endianness
    {
        Little,
        Big
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class ReStructAttribute : Attribute
    {
        private readonly Endianness _endianness;

        public Endianness Endianness
        {
            get { return _endianness; }
        }

        public ReStructAttribute(Endianness endianness)
        {
            _endianness = endianness;
        }
    }

    public class ReStructFieldAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ReStructStringAttribute : ReStructFieldAttribute
    {
        private readonly int _length;
        private Encoding _encoding = Encoding.ASCII;

        public Encoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        public int Length
        {
            get { return _length; }
        }

        public ReStructStringAttribute(int length)
        {
            _length = length;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class ReStructArrayAttribute : ReStructFieldAttribute
    {
        private int _length;

        public int Length
        {
            get { return _length; }
        }

        public ReStructArrayAttribute(int length)
        {
            _length = length;
        }
    }
}
