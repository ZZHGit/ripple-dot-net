﻿using Newtonsoft.Json.Linq;
using Ripple.Core.Util;

namespace Ripple.Core
{
    public class Hash128 : Hash
    {
        public Hash128(byte[] buffer) : base(buffer)
        {
        }

        public static Hash128 FromJson(JToken token)
        {
            return new Hash128(B16.Decode(token.ToString()));
        }

        public static Hash128 FromParser(BinaryParser parser, int? hint=null)
        {
            return new Hash128(parser.Read(16));
        }
    }
}