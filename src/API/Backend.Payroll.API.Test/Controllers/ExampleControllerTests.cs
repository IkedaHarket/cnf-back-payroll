using Backend.Payroll.API.Test;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using Xunit;

namespace Backend.Payroll.API.Controllers.Tests
{
    public class ExampleControllerTests : IClassFixture<TestConfiguration>
    {
        //ExampleController _exampleController;

        public ExampleControllerTests(TestConfiguration testConfiguration)
        {
            //_mediator = testConfiguration.ServiceProvider.GetService<IMediator>() ?? throw new NullReferenceException(nameof(testConfiguration));
            //_exampleController = new ExampleController(_mediator, new Logger<ExampleController>(new NullLoggerFactory()));
        }


        //[Fact()]
        //public async void ExampleControllerTest()
        //{
        //    var actionResult = await _exampleController.FuntionName("116144360");

        //    var okObj = actionResult as OkObjectResult;
        //    Assert.NotNull(okObj);

        //    var res = okObj?.Value as CustomerResponse;
        //    Assert.NotNull(res);

        //    Assert.True(res?.FulfillsForMandate);
        //    Assert.False(res?.HasMandate);
        //}
    }
}