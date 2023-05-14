using AutoBogus;
using Bogus;
using GildedRose.API.Controllers;
using GildedRose.API.ApiRequests.Items;
using GildedRose.API.Requests.Items;
using GildedRose.Repository.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Test.Controllers
{
    public class ItemsController_Should_
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ItemsController _itemsController;
        private readonly Faker _faker;

        public ItemsController_Should_()
        {
            _mediatorMock = new Mock<IMediator>();
            _itemsController = new ItemsController(_mediatorMock.Object);
            _faker = new Faker();
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithAListOfItems()
        {
            // Arrange
            var autoFaker = new AutoFaker<Item>();
            var items = autoFaker.Generate(10);
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllItemsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(items);

            // Act
            var result = await _itemsController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Item>>(okResult.Value);
            Assert.Equal(items.Count, returnValue.Count);
        }

        [Fact]
        public async Task GetById_ReturnsOkResult_WithExpectedItem()
        {
            // Arrange
            var autoFaker = new AutoFaker<Item>();
            var expectedItem = autoFaker.Generate();
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetItemByIdRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(expectedItem);

            // Act
            var result = await _itemsController.GetById(expectedItem.Id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualItem = Assert.IsType<Item>(okResult.Value);
            Assert.Equal(expectedItem.Id, actualItem.Id);
        }
    }
}
