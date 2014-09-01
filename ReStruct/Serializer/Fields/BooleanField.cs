using System.IO;

namespace ReStruct.Serializer.Fields
{
    public class BooleanField : FieldBase
    {
        public BooleanField(ReStructAttribute parentAttribute) : base(parentAttribute)
        {
        }

        public override void Serialize(Stream stream, object obj)
        {
            var buffer = new [] {(bool) obj ? (byte) 0x00 : (byte) 0x01};
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
