using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AutoBiz.DAL.CoreDAL
{
    public class DbParamTypeMapper
    {

        static DbParamTypeMapper _singletonInstance = new DbParamTypeMapper();
        
        private DbParamTypeMapper(){}
        
        public static DbParamTypeMapper GetInstance
        {
            get
            {
                return _singletonInstance;
            }
        }


        public DbType this[SqlDbType type]
        {
            get
            {
                return TypeToDbType[SqlDbTypeToType[type]];
            }
        }

        private static readonly Dictionary<Type, DbType> TypeToDbType
        = new Dictionary<Type, DbType>
              {
                  {typeof (byte), DbType.Byte},
                  {typeof (sbyte), DbType.SByte},
                  {typeof (short), DbType.Int16},
                  {typeof (ushort), DbType.UInt16},
                  {typeof (int), DbType.Int32},
                  {typeof (uint), DbType.UInt32},
                  {typeof (long), DbType.Int64},
                  {typeof (ulong), DbType.UInt64},
                  {typeof (float), DbType.Single},
                  {typeof (double), DbType.Double},
                  {typeof (decimal), DbType.Decimal},
                  {typeof (bool), DbType.Boolean},
                  {typeof (string), DbType.String},
                  {typeof (char), DbType.StringFixedLength},
                  {typeof (Guid), DbType.Guid},
                  {typeof (DateTime), DbType.DateTime},
                  {typeof (DateTimeOffset), DbType.DateTimeOffset},
                  {typeof (byte[]), DbType.Binary},
                  {typeof (byte?), DbType.Byte},
                  {typeof (sbyte?), DbType.SByte},
                  {typeof (short?), DbType.Int16},
                  {typeof (ushort?), DbType.UInt16},
                  {typeof (int?), DbType.Int32},
                  {typeof (uint?), DbType.UInt32},
                  {typeof (long?), DbType.Int64},
                  {typeof (ulong?), DbType.UInt64},
                  {typeof (float?), DbType.Single},
                  {typeof (double?), DbType.Double},
                  {typeof (decimal?), DbType.Decimal},
                  {typeof (bool?), DbType.Boolean},
                  {typeof (char?), DbType.StringFixedLength},
                  {typeof (Guid?), DbType.Guid},
                  {typeof (DateTime?), DbType.DateTime},
                  {typeof (DateTimeOffset?), DbType.DateTimeOffset}                  
              };

        private static readonly Dictionary<SqlDbType, Type> SqlDbTypeToType
            = new Dictionary<SqlDbType, Type>
              {
                  {SqlDbType.BigInt, typeof (long)},
                  {SqlDbType.Binary, typeof (byte[])},
                  {SqlDbType.Image, typeof (byte[])},
                  {SqlDbType.Timestamp, typeof (byte[])},
                  {SqlDbType.VarBinary, typeof (byte[])},
                  {SqlDbType.Bit, typeof (bool)},
                  {SqlDbType.Char, typeof (string)},
                  {SqlDbType.NChar, typeof (string)},
                  {SqlDbType.NText, typeof (string)},
                  {SqlDbType.NVarChar, typeof (string)},
                  {SqlDbType.Text, typeof (string)},
                  {SqlDbType.VarChar, typeof (string)},
                  {SqlDbType.Xml, typeof (string)},
                  {SqlDbType.DateTime, typeof (DateTime)},
                  {SqlDbType.SmallDateTime, typeof (DateTime)},
                  {SqlDbType.Date, typeof (DateTime)},
                  {SqlDbType.Time, typeof (DateTime)},
                  {SqlDbType.DateTime2, typeof (DateTime)},
                  {SqlDbType.Decimal, typeof (decimal)},
                  {SqlDbType.Money, typeof (decimal)},
                  {SqlDbType.SmallMoney, typeof (decimal)},
                  {SqlDbType.Float, typeof (double)},
                  {SqlDbType.Int, typeof (int)},
                  {SqlDbType.Real, typeof (float)},
                  {SqlDbType.UniqueIdentifier, typeof (Guid)},
                  {SqlDbType.SmallInt, typeof (short)},
                  {SqlDbType.TinyInt, typeof (byte)},
                  {SqlDbType.Variant, typeof (object)},
                  {SqlDbType.Udt, typeof (object)},
                  {SqlDbType.Structured, typeof (DataTable)},
                  {SqlDbType.DateTimeOffset, typeof (DateTimeOffset)}
              };

    }
}