﻿using Newtonsoft.Json.Linq;
using Ripple.Core.Util;

namespace Ripple.Core
{
    public class Hash160: Hash
    {
        public Hash160(byte[] buffer) : base(buffer)
        {
        }
        public static Hash160 FromJson(JToken token)
        {
            return new Hash160(B16.Decode(token.ToString()));
        }
        public static Hash160 FromParser(BinaryParser parser, int? hint = null)
        {
            return new Hash160(parser.Read(20));
        }
    }
}