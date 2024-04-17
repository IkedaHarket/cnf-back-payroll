using Backend.ProyectName.API.Domain.Exceptions;
using Backend.ProyectName.API.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Backend.ProyectName.API.Application.Business.Tests
{
    public class ExampleBusinessTests : IClassFixture<TestConfiguration>
    {
        public ExampleBusinessTests(TestConfiguration testConfiguration)
        {
        }
    }
}