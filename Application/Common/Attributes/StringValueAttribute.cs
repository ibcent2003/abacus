﻿using System;

namespace Wbc.Application.Common.Attributes
{
    public class StringValueAttribute : Attribute
    {

        public string StringValue { get; set; }
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

    }
}