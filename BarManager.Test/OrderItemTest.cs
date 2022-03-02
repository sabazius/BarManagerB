using AutoMapper;
using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Extensions;
using BarManager.Host.Controllers;
using BarManager.Models.DTO;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using BarManager.BL.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Net;
using BarManager.Models.Responses;
using BarManager.Models.Requests;

namespace BarManager.Test
{
    public class OrderItemTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IOrderItemRepository> _orderItemRepository;
        private readonly IOrderItemService _orderItemService;
        private readonly OrderItemController _orderItemController;

        private IList<OrderItem> OrderItems = new List<OrderItem>()
        {
            {
                new OrderItem()
                {
                    Id = 1,
                    Name = "a",
                    Price = 1.25,
                    Tags = new List<Tag>(){
                    new Tag()
                    {
                        Id = 1,
                        Name = "a"
                    }
                    },
                    Type = Models.Enums.OrderType.Water
                } },
                new OrderItem()
                {
                    Id = 2,
                    Name = "b",
                    Price = 2.55,
                    Tags = new List<Tag>()
                    {
                        new Tag()
                        {
                            Id = 2,
                            Name = "b",
                        }
                    },
                    Type = Models.Enums.OrderType.Juice
                }
            };

        public OrderItemTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _orderItemRepository = new Mock<IOrderItemRepository>();

            var logger = new Mock<ILogger>();

            _orderItemService = new OrderItemService(_orderItemRepository.Object, logger.Object);

            _orderItemController = new OrderItemController(_orderItemService, _mapper);
        }

        //[Fact]
        //public void OrderItem_GetAll_Count_Check()
        //{
        //    //setup
        //    var expectedCount = 2;

        //    var mockedService = new Mock<IOrderItemService>();

        //    mockedService.Setup(x => x.GetAll()).Returns(OrderItems);

        //    //inject
        //    var controller = new OrderItemController(mockedService.Object, _mapper);

        //    //Act
        //    var result = controller.GetAll();

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
        //    Assert.NotNull(okObjectResult);
        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        //    var orderItems = okObjectResult.Value as IEnumerable<OrderItem>;
        //    Assert.NotNull(orderItems);
        //    Assert.Equal(expectedCount, orderItems.Count());
        //}
        
        //[Fact]
        //public void OrderItem_GetById_NameCheck()
        //{
        //    //setup
        //    var orderItemId = 2;
        //    var expectedName = "b";

        //    _orderItemRepository.Setup(x => x.GetById(orderItemId))
        //        .Returns(OrderItems.FirstOrDefault(t => t.Id == orderItemId));

        //    //Act
        //    var result = _orderItemController.GetById(orderItemId);

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
        //    Assert.NotNull(okObjectResult);
        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        //    var response = okObjectResult.Value as OrderItemResponse;
        //    var tag = _mapper.Map<OrderItem>(response);

        //    Assert.NotNull(tag);
        //    Assert.Equal(expectedName, tag.Name);
        //}

        //[Fact]
        //public void OrderItem_GetById_NotFound()
        //{
        //    //setup
        //    var orderItemId = 3;

        //    _orderItemRepository.Setup(x => x.GetById(orderItemId))
        //        .Returns(OrderItems.FirstOrDefault(t => t.Id == orderItemId));

        //    //Act
        //    var result = _orderItemController.GetById(orderItemId);

        //    //Assert
        //    var notFoundObjectResult = result as NotFoundObjectResult;
        //    Assert.NotNull(notFoundObjectResult);
        //    Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

        //    var response = (int)notFoundObjectResult.Value;
        //    Assert.Equal(orderItemId, response);
        //}
        //[Fact]
        //public void OrderItem_Update_OrderItemName()
        //{
        //    var orderItemId = 1;
        //    var expectedName = "Updated OrderItem Name";

        //    var orderItem = OrderItems.FirstOrDefault(x => x.Id == orderItemId);
        //    orderItem.Name = expectedName;

        //    _orderItemRepository.Setup(x => x.GetById(orderItemId))
        //        .Returns(OrderItems.FirstOrDefault(t => t.Id == orderItemId));
        //    _orderItemRepository.Setup(x => x.Update(orderItem))
        //        .Returns(orderItem);

        //    //Act
        //    var orderItemUpdateRequest = _mapper.Map<OrderItem>(orderItem);
        //    var result = _orderItemController.Update(orderItemUpdateRequest);

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
        //    Assert.NotNull(okObjectResult);
        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        //    var val = okObjectResult.Value as OrderItem;
        //    Assert.NotNull(val);
        //    Assert.Equal(expectedName, val.Name);

        //}
        //[Fact]
        //public void OrderItem_Delete_ExistingTag()
        //{
        //    //Setup
        //    var orderItemId = 1;

        //    var orderItem = OrderItems.FirstOrDefault(x => x.Id == orderItemId);

        //    _orderItemRepository.Setup(x => x.Delete(orderItemId)).Callback(() => OrderItems.Remove(orderItem)).Returns(orderItem);

        //    //Act
        //    var result = _orderItemController.Delete(orderItemId);

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
        //    Assert.NotNull(okObjectResult);
        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        //    var val = okObjectResult.Value as OrderItem;
        //    Assert.NotNull(val);
        //    Assert.Equal(1, OrderItems.Count);
        //    Assert.Null(OrderItems.FirstOrDefault(x => x.Id == orderItemId));
        //}

        //[Fact]
        //public void OrderItem_Delete_NotExisting_Tag()
        //{
        //    //Setup
        //    var orderItemId = 3;

        //    var orderItem = OrderItems.FirstOrDefault(x => x.Id == orderItemId);

        //    _orderItemRepository.Setup(x => x.Delete(orderItemId)).Callback(() => OrderItems.Remove(orderItem)).Returns(orderItem);

        //    //Act
        //    var result = _orderItemController.Delete(orderItemId);

        //    //Assert
        //    var notFoundObjectResult = result as NotFoundObjectResult;
        //    Assert.NotNull(notFoundObjectResult);
        //    Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

        //    var response = (int)notFoundObjectResult.Value;
        //    Assert.Equal(orderItemId, response);
        //}


        //[Fact]
        //public void OrderItem_CreateTag()
        //{
        //    //setup
        //    var orderItem = new OrderItem()
        //    {
        //        Id = 3,
        //        Name = "c",
        //        Price = 2.60,
        //        Tags = new List<Tag>
        //        {
        //            new Tag()
        //            {
        //                Id = 3,
        //                Name = "c"
        //            }
        //        }

        //    };

        //    _orderItemRepository.Setup(x => x.GetAll()).Returns(OrderItems);

        //    _orderItemRepository.Setup(x => x.Create(It.IsAny<OrderItem>())).Callback(() =>
        //    {
        //        OrderItems.Add(orderItem);
        //    }).Returns(orderItem);

        //    //Act
        //    var result = _orderItemController.CreateTag(_mapper.Map<OrderItemRequest>(orderItem));

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;

        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
        //    Assert.NotNull(OrderItems.FirstOrDefault(x => x.Id == orderItem.Id));
        //    Assert.Equal(3, OrderItems.Count);

        //}
    }
}
