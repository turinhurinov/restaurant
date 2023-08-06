using FluentAssertions;
using Moq;
using NUnit.Framework;
using Restaurant.Business.Services;
using Restaurant.Data.Repositories.Abstract;
using Restaurant.Model;
using System;
using System.Collections.Generic;

namespace Restaurant.UnitTests.Business.Services

{
    [TestFixture]
    public class TableServiceTests
    {
        #region setup

        Mock<ITableRepository> tableRepository;

        TableService service;

        [SetUp]
        public void Initialize()
        {
            tableRepository = new Mock<ITableRepository>(MockBehavior.Strict);

            service = new TableService(
                tableRepository.Object
                );
        }

        #endregion

        #region teardown

        [TearDown]
        public void VerifyMocks()
        {
            tableRepository.VerifyAll();
        }

        #endregion

        [Test]
        public void GetAvailableTables_AvailableTableNotFound_ReturnEmptyTableList()
        {
            // Arrange
            DateTime reservationDate = DateTime.Now;
            int numberOfGuests = 4;

            var tables = CreateTableList();

            tableRepository.Setup(x => x.GetAllTables()).Returns(tables);

            // Act
            var result = service!.GetAvailableTables(reservationDate, numberOfGuests);

            // Assert
            result.Count.Should().Be(0);
        }

        #region setup helpers

        List<Table> CreateTableList()
        {
            return new List<Table>();
        }

        #endregion
    }
}
