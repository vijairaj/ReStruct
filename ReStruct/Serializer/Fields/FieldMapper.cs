using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ReStruct.Exceptions;

namespace ReStruct.Serializer.Fields
{
    internal class FieldMapper : IEnumerable<FieldDetail>
    {
        private readonly object _object;
        private readonly FieldInfo[] _fields;
        private readonly ReStructAttribute _attribute;

        public FieldMapper(object obj, ReStructAttribute parentAttribute)
        {
            _attribute = GetReStructAttribute(obj) ?? parentAttribute;
            if (_attribute == null) throw new NoAttributeException();

            _object = obj;
            var type = obj.GetType();
            _fields = type.GetFields();
        }

        private static ReStructAttribute GetReStructAttribute(object obj)
        {
            var attributes = obj.GetType().GetCustomAttributes(false);
            var attribute = attributes.FirstOrDefault(k => k is ReStructAttribute) as ReStructAttribute;
            return attribute;
        }

        public IEnumerator<FieldDetail> GetEnumerator()
        {
            return _fields.Select(fieldInfo => new FieldDetail(_object, fieldInfo, _attribute)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
