﻿using System;

namespace AndaForceExtensions.com.andaforce.arazect.enumerations
{
    public static class EnumExtension
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
    }
}