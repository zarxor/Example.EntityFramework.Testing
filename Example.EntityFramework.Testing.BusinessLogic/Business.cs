// -------------------------------------------------------------------------------------------------
// Copyright (c) Johan Boström. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------------------------

namespace Example.EntityFramework.Testing.BusinessLogic
{
    using System.Threading.Tasks;
    using Data.Db;

    public class Business
    {
        private readonly ICustomContext context;

        public Business(ICustomContext context)
        {
            this.context = context;
        }

        public void AddCustomEntity(CustomEntity testEntity)
        {
            context.CustomEntities.Add(testEntity);
            context.SaveChanges();
        }

        public async Task AddCustomEntityAsync(CustomEntity testEntity)
        {
            await context.CustomEntities.AddAsync(testEntity);
            await context.SaveChangesAsync();
        }
    }
}