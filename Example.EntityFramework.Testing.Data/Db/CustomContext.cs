// -------------------------------------------------------------------------------------------------
// Copyright (c) Johan Boström. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------------------------

namespace Example.EntityFramework.Testing.Data.Db
{
    using Microsoft.EntityFrameworkCore;

    public class CustomContext : DbContext, ICustomContext
    {
        public virtual DbSet<CustomEntity> CustomEntities { get; set; }
    }
}