using System;

namespace Jeans.IdentityServer4.Server.Core
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}