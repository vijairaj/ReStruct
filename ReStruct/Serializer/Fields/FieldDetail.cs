using System.IO;
using System.Reflection;

namespace ReStruct.Serializer.Fields
{
    internal class FieldDetail
    {
        private readonly object _object;
        private readonly FieldInfo _fieldInfo;
        private readonly ReStructAttribute _parentAttribute;

        public FieldDetail(object obj, FieldInfo fieldInfo, ReStructAttribute parentAttribute)
        {
            _object = obj;
            _fieldInfo = fieldInfo;
            _parentAttribute = parentAttribute;
        }

        private object[] GetCustomAttribute()
        {
            return _fieldInfo.GetCustomAttributes(false);
        }

        private IField GetField()
        {
            return FieldFactory.NewField(_fieldInfo.FieldType,
                                         GetCustomAttribute(),
                                         _parentAttribute);
        }

        public void Serialize(Stream stream)
        {
            var field = GetField();
            var value = _fieldInfo.GetValue(_object);
            field.Serialize(stream, value);
        }

        public void Deserialize(Stream stream)
        {
            var field = GetField();
            var value = field.Deserialize(stream);
            _fieldInfo.SetValue(_object, value);
        }
    }
}
