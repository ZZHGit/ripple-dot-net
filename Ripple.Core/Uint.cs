using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace Ripple.Core
{
    public abstract class Uint<T> : ISerializedType where T: struct, IConvertible
    {
        public readonly T Value;

        protected Uint(T value)
        {
            Value = value;
        }

        public void ToBytes(IBytesSink sink) => sink.Add(ToBytes());
        public virtual JToken ToJson() => Convert.ToUInt32(Value);
        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
        public abstract byte[] ToBytes();
    }
}