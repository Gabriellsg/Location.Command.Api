﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Location.Command.Api.Infra.Data.Contexts.DataConfiguration;

[ExcludeFromCodeCoverage]
public class DatabaseConfig
{
    [Required(AllowEmptyStrings = false)]
    public required string ConnectionString { get; set; }
}