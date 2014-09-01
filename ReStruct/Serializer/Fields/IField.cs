using System.IO;

namespace ReStruct.Serializer.Fields
{
    internal interface IField
    {
        void Serialize(Stream stream, object obj);
        object Deserialize(Stream stream);
    }
}
