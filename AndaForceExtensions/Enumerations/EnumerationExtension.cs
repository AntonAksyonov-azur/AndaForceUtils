using System;
using System.Linq;

namespace AndaForceUtils.Enumerations
{
    public static class EnumerationExtension
    {
        public static String GetStringValue(this Enum value)
        {
            string output = null;
            var attrs = value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof (StringValue), false) as StringValue[];

            if (attrs != null && attrs.Length > 0)
            {
                output = attrs[0].Value;
            }

            return output;
        }

        public static T GetObjectValue<T>(this Enum value)
        {
            T output = default(T);
            var attrs = value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof (ObjectValue), false) as ObjectValue[];
            if (attrs != null && attrs.Length > 0)
            {
                output = (T) attrs.First().Value;
            }


            return output;
        }


        public class StringValue : Attribute
        {
            private readonly string _value;

            public StringValue(string value)
            {
                _value = value;
            }

            public string Value
            {
                get { return _value; }
            }
        }

        public class ObjectValue : Attribute
        {
            private readonly Object _value;

            public ObjectValue(Object value)
            {
                _value = value;
            }

            public Object Value
            {
                get { return _value; }
            }
        }
    }
}