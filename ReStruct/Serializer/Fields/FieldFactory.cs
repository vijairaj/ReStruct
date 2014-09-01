using System;

namespace ReStruct.Serializer.Fields
{
    internal static class FieldFactory
    {
        public static IField NewField(Type type, object[] fieldAttributes, ReStructAttribute parentAttribute)
        {
            IField newField = null;

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Empty:
                    break;
                case TypeCode.Object:
                    newField = type.IsArray
                               ? (IField) new ArrayField(parentAttribute, type, fieldAttributes)
                               : new UserField(parentAttribute, type);
                    break;
                case TypeCode.DBNull:
                    break;
                case TypeCode.Boolean:
                    newField = new BooleanField(parentAttribute);
                    break;
                case TypeCode.Char:
                    break;
                case TypeCode.SByte:
                    break;
                case TypeCode.Byte:
                    newField = new UnsignedField(parentAttribute, typeof(Byte), 1);
                    break;
                case TypeCode.Int16:
                    break;
                case TypeCode.UInt16:
                    newField = new UnsignedField(parentAttribute, typeof(UInt16), 2);
                    break;
                case TypeCode.Int32:
                    break;
                case TypeCode.UInt32:
                    newField = new UnsignedField(parentAttribute, typeof(UInt32), 4);
                    break;
                case TypeCode.Int64:
                    break;
                case TypeCode.UInt64:
                    newField = new UnsignedField(parentAttribute, typeof(UInt64), 8);
                    break;
                case TypeCode.Single:
                    break;
                case TypeCode.Double:
                    break;
                case TypeCode.Decimal:
                    break;
                case TypeCode.DateTime:
                    break;
                case TypeCode.String:
                    break;
            }

            return newField;
        }
    }
}
