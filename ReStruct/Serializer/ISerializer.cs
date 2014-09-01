using System.IO;

namespace ReStruct.Serializer
{
    public interface IFormatter
    {
        void Serialize(Stream stream, object obj);
        T Deserialize<T>(Stream stream) where T : class;
    }
}
