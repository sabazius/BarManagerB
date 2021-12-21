using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using BarManager.BL.Interfaces;
using BarManager.BL.Services;
using BarManager.Controllers;
using BarManager.DL.Interfaces;
using BarManager.Extensions;
using BarManager.Models.Requests;
using BarManager.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Serilog;
using Xunit;
using System;

namespace BarManager.Test
{
    public class BillTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBillRepository> _billRepository;
        private readonly IBillService _billService;
        private readonly BillController _billController;

        private IList<Bill> Bills = new List<Bill>()
        {
                new Bill()
            {
                Id = 1,
                Amount = 10.50,
                BillStatus = 0,
                PaymentType = 0,
                Created = new DateTime(2020, 5, 1, 8, 30, 52),
                Finished= new DateTime(2020, 5, 1, 9, 30, 52)
            },
            new Bill()
            {
                   Id = 2,
                Amount = 20.50,
                BillStatus = 0,
                PaymentType = 0,
                Created = new DateTime(2020, 5, 1, 8, 30, 52),
                Finished= new DateTime(2020, 5, 1, 9, 30, 52)
            },
            new Bill()
            {
                        Id = 3,
                Amount = 60,
                BillStatus = 0,
                PaymentType = 0,
                Created = new DateTime(2020, 5, 1, 8, 30, 52),
                Finished= new DateTime(2020, 5, 1, 9, 30, 52)
            }

        };


        public BillTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _billRepository = new Mock<IBillRepository>();

            var logger = new Mock<ILogger>();

            _billService = new BillService(_billRepository.Object);

            _billController = new BillController(_billService, _mapper);
        }

        [Fact]
        public void Bill_GetAll_Count_Check()
        {
            //setup
            var expectedCount = 3;

            var mockedService = new Mock<IBillService>();

            mockedService.Setup(x => x.GetAll()).Returns(Bills);

            //inject
            var controller = new BillController(mockedService.Object, _mapper);

            //Act
            var result = controller.GetAll();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var bills = okObjectResult.Value as IEnumerable<Bill>;
            Assert.NotNull(bills);
            Assert.Equal(expectedCount, Bills.Count());
        }

        [Fact]
        public void Bill_GetById_Amount_Check()
        {
            //setup
            var billId = 2;
            var expectedAmount = 20.50;
         
            _billRepository.Setup(x => x.GetById(billId))
                .Returns(Bills.FirstOrDefault(t => t.Id == billId));

            //Act
            var result = _billController.GetById(billId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var response = okObjectResult.Value as BillResponse;
            var bill = _mapper.Map<Bill>(response);

            Assert.NotNull(bill);
            Assert.Equal(expectedAmount, bill.Amount);
       
        }

        [Fact]
        public void Bill_GetById_NotFound()
        {
            //setup
            var billId = 4;

            _billRepository.Setup(x => x.GetById(billId))
                .Returns(Bills.FirstOrDefault(t => t.Id == billId));

            //Act
            var result = _billController.GetById(billId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(billId, response);
        }

        [Fact]
        public void Bill_Update_BillName()
        {
            var billId = 2;
            var expectedAmount =  55;

            var bill = Bills.FirstOrDefault(x => x.Id == billId);
            bill.Amount = expectedAmount;

            _billRepository.Setup(x => x.GetById(billId))
                .Returns(Bills.FirstOrDefault(t => t.Id == billId));
            _billRepository.Setup(x => x.Update(bill))
                .Returns(bill);

            //Act
            var billRequest = _mapper.Map<BillRequest>(bill);
            var result = _billController.Update(bill);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Bill;
            Assert.NotNull(val);
            Assert.Equal(expectedAmount, val.Amount);

        }

        [Fact]
        public void Bill_Delete_ExistingBill()
        {
            //Setup
            var billId = 2;

            var bill = Bills.FirstOrDefault(x => x.Id == billId);

            _billRepository.Setup(x => x.Delete(billId)).Callback(() => Bills.Remove(bill)).Returns(bill);

            //Act
            var result = _billController.Delete(billId);

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.NotNull(okObjectResult);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

            var val = okObjectResult.Value as Bill;
            Assert.NotNull(val);
            Assert.Equal(2, Bills.Count);
            Assert.Null(Bills.FirstOrDefault(x => x.Id == billId));
        }

        [Fact]
        public void Bill_Delete_NotExisting_Tag()
        {
            //Setup
            var billId = 6;

            var bill = Bills.FirstOrDefault(x => x.Id == billId);

            _billRepository.Setup(x => x.Delete(billId)).Callback(() => Bills.Remove(bill)).Returns(bill);

            //Act
            var result = _billController.Delete(billId);

            //Assert
            var notFoundObjectResult = result as NotFoundObjectResult;
            Assert.NotNull(notFoundObjectResult);
            Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

            var response = (int)notFoundObjectResult.Value;
            Assert.Equal(billId, response);
        }

        [Fact]
        public void Bill_CreateTag()
        {
            //setup
            var bill = new Bill()
            {
                    
                        Id = 7,
                Amount = 77,
                BillStatus = 0,
                PaymentType = 0,
                Created = new DateTime(2020, 5, 1, 8, 30, 52),
                Finished= new DateTime(2020, 5, 1, 9, 30, 52)
            
            };

            _billRepository.Setup(x => x.GetAll()).Returns(Bills);

            _billRepository.Setup(x => x.Create(It.IsAny<Bill>())).Callback(() =>
            {
                Bills.Add(bill);
            }).Returns(bill);

            //Act
            var result = _billController.CreateBill(_mapper.Map<BillRequest>(bill));

            //Assert
            var okObjectResult = result as OkObjectResult;

            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.NotNull(Bills.FirstOrDefault(x => x.Id == bill.Id));
            Assert.Equal(4, Bills.Count);

        }

    }
}
