// -------------------------------------------------------------------------------------------------
// Copyright (c) Johan Boström. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
// -------------------------------------------------------------------------------------------------

namespace Example.EntityFramework.Testing.Tests
{
    using System.Threading;
    using System.Threading.Tasks;
    using BusinessLogic;
    using Data.Db;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class BusinessTests
    {
        private readonly Mock<ICustomContext> testContext;
        private readonly Mock<DbSet<CustomEntity>> testEntities;

        public BusinessTests()
        {
            // Initiate ITestContext
            testContext = new Mock<ICustomContext>();
            
            // Initiate DbSet
            testEntities = new Mock<DbSet<CustomEntity>>();

            // Setup DbSet
            testContext.Setup(ctx => ctx.CustomEntities).Returns(testEntities.Object);
        }

        [Fact]
        public void AddingTestEntity()
        {
            var business = new Business(testContext.Object);
            business.AddCustomEntity(new CustomEntity
            {
                Id = 1,
                Name = "TestName"
            });

            testEntities.Verify(set => set.Add(It.Is<CustomEntity>(e => e.Id == 1 && e.Name == "TestName")), Times.Once);
            testContext.Verify(ctx => ctx.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task AddingTestEntityAsync()
        {
            var business = new Business(testContext.Object);
            await business.AddCustomEntityAsync(new CustomEntity
            {
                Id = 1,
                Name = "TestName"
            });

            testEntities.Verify(set => set.AddAsync(It.Is<CustomEntity>(e => e.Id == 1 && e.Name == "TestName"), It.IsAny<CancellationToken>()), Times.Once);
            testContext.Verify(ctx => ctx.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}