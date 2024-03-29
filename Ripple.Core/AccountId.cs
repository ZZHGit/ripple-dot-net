﻿using System;
using Newtonsoft.Json.Linq;
using Ripple.Address;
using Ripple.Core.Util;

namespace Ripple.Core
{
    public class AccountId : Hash160
    {
        private readonly string _value;

        public AccountId(byte[] hash, string encoded) : base(hash)
        {
            _value = encoded;
        }
        public AccountId(string v) : 
            this(AddressCodec.DecodeAddress(v), v) {}
        public AccountId(byte[] hash) : 
            this(hash, AddressCodec.EncodeAddress(hash)) {}

        public static implicit operator AccountId(string value)
        {
            return new AccountId(value);
        }

        public static implicit operator AccountId(uint value)
        {
            byte[] empty = new byte[20];
            var sourceArray = Bits.GetBytes(value);
            Array.Copy(sourceArray, 0, empty, 16, 4);
            return new AccountId(empty);
        }
        public static implicit operator AccountId(JToken json)
        {
            return json == null ? null : FromJson(json);
        }

        public static implicit operator JToken(AccountId v)
        {
            return v.ToString();
        }

        public override string ToString()
        {
            return _value;
        }

        public new static AccountId FromJson(JToken json)
        {
            return json?.ToString();
        }

        public static readonly AccountId Zero = 0;
        public static readonly AccountId Neutral = 1;

        public new static AccountId FromParser(BinaryParser parser, int? hint=null)
        {
            return new AccountId(parser.Read(20));
        }
    }
}