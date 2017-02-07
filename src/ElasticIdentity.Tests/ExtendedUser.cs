﻿#region MIT License

// /*
// 	The MIT License (MIT)
// 
// 	Copyright (c) 2013 Bombsquad Inc
// 	Copyright (c) 2016 ElasticIdentity
// 
// 	Permission is hereby granted, free of charge, to any person obtaining a copy of
// 	this software and associated documentation files (the "Software"), to deal in
// 	the Software without restriction, including without limitation the rights to
// 	use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// 	the Software, and to permit persons to whom the Software is furnished to do so,
// 	subject to the following conditions:
// 
// 	The above copyright notice and this permission notice shall be included in all
// 	copies or substantial portions of the Software.
// 
// 	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// 	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// 	FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// 	COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// 	IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// 	CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// */

#endregion

using System;
using Newtonsoft.Json;
using Nest;

namespace ElasticIdentity.Tests
{
    public abstract class CarBase
    {
        [Keyword]
        public string LicensePlate { get; set; }
    }

    public abstract class CarBase<TModel> : CarBase where TModel : struct, IConvertible
    {
        [Keyword]
        public TModel Model { get; set; }
    }

    public enum TeslaModel
    {
        Roadster,
        ModelS,
        ModelX
    }

    public enum KoenigseggModel
    {
        CCR,
        CCX,
        CCRX,
        Agera,
        AgeraR,
        AgeraS,
        One
    }

    public class Tesla : CarBase<TeslaModel>
    {
    }

    public class Koenigsegg : CarBase<KoenigseggModel>
    {
    }


    public class ExtendedUser : ElasticUser
    {
        public ExtendedUser(string id, string username) 
            : base(id, username)
        {
        }

        [Object]
        [JsonProperty(TypeNameHandling = TypeNameHandling.Objects)]
        public CarBase Car { get; set; }
    }
}