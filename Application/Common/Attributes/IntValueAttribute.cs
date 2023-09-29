using System;

namespace Wbc.Application.Common.Attributes
{
    public class IntValueAttribute : Attribute
    {
        public int IntValue { get; set; }

        public IntValueAttribute(int value)
        {
            this.IntValue = value;
        }
    }
}