// -------------------------------------------------------------------------------------------------
// Copyright (c) Johan Boström. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------------------------

namespace Example.EntityFramework.Testing.Data.Db
{
    using Abstract;
    using Microsoft.EntityFrameworkCore;

    public interface ICustomContext : IDbContext
    {
        DbSet<CustomEntity> CustomEntities { get; set; }
    }
}