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

namespace BarManager.Test
{
    public class TagTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITagRepository> _tagRepository;
        private readonly ITagService _tagService;
        private readonly TagController _tagController;

        private IList<Tag> Tags = new List<Tag>()
        {
            {new Tag() {Id = 1, Name = "TestName"}},
            {new() {Id = 2, Name = "AnotherName"}}
        };

        public TagTests()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });

            _mapper = mockMapper.CreateMapper();

            _tagRepository = new Mock<ITagRepository>();

            var logger = new Mock<ILogger>();

            _tagService = new TagService(_tagRepository.Object, logger.Object);

            _tagController = new TagController(_tagService, _mapper);
        }

        //[Fact]
        //public void Tag_GetAll_Count_Check()
        //{
        //    //setup
        //    var expectedCount = 2;

        //    var mockedService = new Mock<ITagService>();

        //    mockedService.Setup(x => x.GetAll()).Returns(Tags);

        //    //inject
        //    var controller = new TagController(mockedService.Object, _mapper);

        //    //Act
        //    var result = controller.GetAll();

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
        //    Assert.NotNull(okObjectResult);
        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        //    var tags = okObjectResult.Value as IEnumerable<Tag>;
        //    Assert.NotNull(tags);
        //    Assert.Equal(expectedCount, tags.Count());
        //}

        //[Fact]
        //public void Tag_GetById_NameCheck()
        //{
        //    //setup
        //    var tagId = 2;
        //    var expectedName = "AnotherName";

        //    _tagRepository.Setup(x => x.GetById(tagId))
        //        .Returns(Tags.FirstOrDefault(t => t.Id == tagId));

        //    //Act
        //    var result = _tagController.GetById(tagId);

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
        //    Assert.NotNull(okObjectResult);
        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        //    var response = okObjectResult.Value as TagResponse;
        //    var tag = _mapper.Map<Tag>(response);

        //    Assert.NotNull(tag);
        //    Assert.Equal(expectedName, tag.Name);
        //}

        //[Fact]
        //public void Tag_GetById_NotFound()
        //{
        //    //setup
        //    var tagId = 3;

        //    _tagRepository.Setup(x => x.GetById(tagId))
        //        .Returns(Tags.FirstOrDefault(t => t.Id == tagId));

        //    //Act
        //    var result = _tagController.GetById(tagId);

        //    //Assert
        //    var notFoundObjectResult = result as NotFoundObjectResult;
        //    Assert.NotNull(notFoundObjectResult);
        //    Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

        //    var response = (int)notFoundObjectResult.Value;
        //    Assert.Equal(tagId, response);
        //}

        //[Fact]
        //public void Tag_Update_TagName()
        //{
        //    var tagId = 1;
        //    var expectedName = "Updated Tag Name";

        //    var tag = Tags.FirstOrDefault(x => x.Id == tagId);
        //    tag.Name = expectedName;

        //    _tagRepository.Setup(x => x.GetById(tagId))
        //        .Returns(Tags.FirstOrDefault(t => t.Id == tagId));
        //    _tagRepository.Setup(x => x.Update(tag))
        //        .Returns(tag);

        //    //Act
        //    var tagUpdateRequest = _mapper.Map<TagUpdateRequest>(tag);
        //    var result = _tagController.Update(tagUpdateRequest);

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
        //    Assert.NotNull(okObjectResult);
        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        //    var val = okObjectResult.Value as Tag;
        //    Assert.NotNull(val);
        //    Assert.Equal(expectedName, val.Name);

        //}

        //[Fact]
        //public void Tag_Delete_ExistingTag()
        //{
        //    //Setup
        //    var tagId = 1;

        //    var tag = Tags.FirstOrDefault(x => x.Id == tagId);

        //    _tagRepository.Setup(x => x.Delete(tagId)).Callback(() => Tags.Remove(tag)).Returns(tag);

        //    //Act
        //    var result = _tagController.Delete(tagId);

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
        //    Assert.NotNull(okObjectResult);
        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        //    var val = okObjectResult.Value as Tag;
        //    Assert.NotNull(val);
        //    Assert.Equal(1, Tags.Count );
        //    Assert.Null(Tags.FirstOrDefault(x => x.Id == tagId));
        //}

        //[Fact]
        //public void Tag_Delete_NotExisting_Tag()
        //{
        //    //Setup
        //    var tagId = 3;

        //    var tag = Tags.FirstOrDefault(x => x.Id == tagId);

        //    _tagRepository.Setup(x => x.Delete(tagId)).Callback(() => Tags.Remove(tag)).Returns(tag);

        //    //Act
        //    var result = _tagController.Delete(tagId);

        //    //Assert
        //    var notFoundObjectResult = result as NotFoundObjectResult;
        //    Assert.NotNull(notFoundObjectResult);
        //    Assert.Equal(notFoundObjectResult.StatusCode, (int)HttpStatusCode.NotFound);

        //    var response = (int)notFoundObjectResult.Value;
        //    Assert.Equal(tagId, response);
        //}

        //[Fact]
        //public void Tag_CreateTag()
        //{
        //    //setup
        //    var tag = new Tag()
        //    {
        //        Id = 3,
        //        Name = "Name 3"
        //    };

        //    _tagRepository.Setup(x => x.GetAll()).Returns(Tags);

        //    _tagRepository.Setup(x => x.Create(It.IsAny<Tag>())).Callback(() =>
        //    {
        //        Tags.Add(tag);
        //    }).Returns(tag);

        //    //Act
        //    var result = _tagController.CreateTag(_mapper.Map<TagRequest>(tag));

        //    //Assert
        //    var okObjectResult = result as OkObjectResult;
            
        //    Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);
        //    Assert.NotNull(Tags.FirstOrDefault(x => x.Id == tag.Id));
        //    Assert.Equal(3, Tags.Count);

        //}

    }
}
