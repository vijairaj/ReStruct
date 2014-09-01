using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ReStruct.Exceptions;

namespace ReStruct.Serializer.Fields
{
    public class ArrayField : FieldBase
    {
        private readonly Type _type;
        private readonly object[] _fieldAttributes;

        private ReStructArrayAttribute GetArrayAttribute()
        {
            var arrayAttribute = _fieldAttributes.FirstOrDefault(k => k is ReStructArrayAttribute) as ReStructArrayAttribute;
            if (arrayAttribute == null) throw new NoArrayAttributeException();
            return arrayAttribute;
        }

        public ArrayField(ReStructAttribute parentAttribute, Type type, object[] fieldAttributes)
            : base(parentAttribute)
        {
            _type = type;
            _fieldAttributes = fieldAttributes;
        }

        public override void Serialize(Stream stream, object obj)
        {
            var items = (Array) obj;
            var arrayAttribute = GetArrayAttribute();

            if (items.Length != arrayAttribute.Length) throw new ArrayLengthMismatchException();

            foreach (var item in items)
            {
                var field = FieldFactory.NewField(_type.GetElementType(), null, ParentAttribute);
                field.Serialize(stream, item);
            }
        }

        public override object Deserialize(Stream stream)
        {
            var arrayAttribute = GetArrayAttribute();
            var items = Array.CreateInstance(_type.GetElementType(), arrayAttribute.Length);

            for (var i = 0; i < arrayAttribute.Length; ++i)
            {
                var field = FieldFactory.NewField(_type.GetElementType(), null, ParentAttribute);
                var item = field.Deserialize(stream);
                items.SetValue(item, i);
            }

            return items;
        }
    }
}
