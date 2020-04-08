﻿using System;
using System.Collections.Generic;

namespace LJ.Ids4.Core.Domain.Resources
{
    /// <summary>
    /// Api作用域
    /// </summary>
    public class ApiScope : BaseEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; } = true;
        public List<ApiScopeClaim> ApiScopeClaims { get; set; }

        public Guid ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}