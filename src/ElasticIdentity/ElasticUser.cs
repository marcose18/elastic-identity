﻿#region MIT License

/*
	The MIT License (MIT)

	Copyright (c) 2013 Bombsquad Inc

	Permission is hereby granted, free of charge, to any person obtaining a copy of
	this software and associated documentation files (the "Software"), to deal in
	the Software without restriction, including without limitation the rights to
	use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
	the Software, and to permit persons to whom the Software is furnished to do so,
	subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
	FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
	COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
	IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
	CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#endregion

using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Nest;
using Newtonsoft.Json;

namespace ElasticIdentity
{
	public class ElasticUser : IUser
	{
		private long _version;
		private string _userName;
		private readonly List<ElasticUserLoginInfo> _logins;
		private readonly HashSet<ElasticClaim> _claims;
		private readonly HashSet<string> _roles;

		public ElasticUser()
		{
			_logins = new List<ElasticUserLoginInfo>();
			_claims = new HashSet<ElasticClaim>();
			_roles = new HashSet<string>();

            Email = new ElasticUserEmail();
		}

		public ElasticUser(string id, string userName)
			: this()
		{
            Id = id;
			UserName = userName;
		}

		[JsonIgnore]
        public virtual string Id { get; set; }

        [JsonIgnore]
        public long Version
        {
            get { return _version.Equals(0) ? _version = 1 : _version; }
            set { _version = value; }
        }

        [JsonIgnore]
        public string EmailAddress => Email?.Address;

        [Keyword]
        public string UserName
		{
			get { return _userName; }
			set { _userName = value?.ToLowerInvariant(); }
		}

        [Keyword]
		public string PasswordHash { get; set; }

        [Keyword]
		public string SecurityStamp { get; set; }

		[Object]
		public List<ElasticUserLoginInfo> Logins => _logins;

	    [Nested]
		public ISet<ElasticClaim> Claims => _claims;

	    [Keyword]
		public ISet<string> Roles => _roles;

	    [Object]
		public ElasticUserEmail Email { get; set; }

		[Object]
		public ElasticUserPhone Phone { get; set; }

        [Date]
        public DateTimeOffset LockoutEndDate { get; set; }

        [Number(NumberType.Integer)]
        public int AccessFailedCount { get; set; }

        [Boolean]
        public bool Enabled { get; set; }

        [Boolean]
		public bool TwoFactorAuthenticationEnabled { get; set; }

        public override string ToString()
		{
			return UserName;
		}
	}
}