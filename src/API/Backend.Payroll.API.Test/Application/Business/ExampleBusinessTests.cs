using Backend.Payroll.API.Domain.Exceptions;
using Backend.Payroll.API.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Backend.Payroll.API.Application.Business.Tests
{
    public class ExampleBusinessTests : IClassFixture<TestConfiguration>
    {
        public ExampleBusinessTests(TestConfiguration testConfiguration)
        {
        }
    }
}