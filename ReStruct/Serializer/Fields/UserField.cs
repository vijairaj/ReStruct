using System;
using System.IO;

namespace ReStruct.Serializer.Fields
{
    public class UserField : FieldBase
    {
        private readonly Type _type;

        public UserField(ReStructAttribute parentAttribute, Type type) : base(parentAttribute)
        {
            _type = type;
        }

        public override void Serialize(Stream stream, object obj)
        {
            foreach (var field in new FieldMapper(obj, ParentAttribute))
                field.Serialize(stream);
        }

        public override object Deserialize(Stream stream)
        {
            var obj = Activator.CreateInstance(_type);
            var fieldMapper = new FieldMapper(obj, ParentAttribute);

            foreach (var field in fieldMapper)
                field.Deserialize(stream);

            return obj;
        }
    }
}
