using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using TestSoft.TaxCalculate.Application.Commands.TaxCalculate;
using TestSoft.TaxCalculate.Service;
using Xunit;

namespace TestSoft.TaxCalculate.UnitTests.Applications
{
    public class TaxCalculateCommandHandlerTest
    {
        private readonly ITaxCalculateService _taxCalculateServiceMock;
        private readonly TaxCalculateCommandHandler _handler;
        
        public TaxCalculateCommandHandlerTest()
        {
            _taxCalculateServiceMock = Substitute.For<ITaxCalculateService>();
            _handler = new TaxCalculateCommandHandler(_taxCalculateServiceMock);
        }

        [Fact]
        public async Task TaxCalculateCommandHandler_ShouldReturn_InternalServerError()
        {
            const string message = "Has a error to get tax rate";
            _taxCalculateServiceMock.GetTaxRate().Returns(new int?());

            var command = new TaxCalculateCommand(10, 2);
            var result = await _handler.Handle(command, new CancellationToken());
            
            result.StatusCode.Should().BeEquivalentTo(HttpStatusCode.InternalServerError);
            (result.Response as string).Should().BeEquivalentTo(message);
        }

        [Theory]
        [InlineData(100,5,0.01, 105.10)]
        [InlineData(10,2,0.02, 10.40)]
        public async Task TaxCalculateCommandHandler_ShouldReturn_OK(double value, int month, double tax, decimal total)
        {
            _taxCalculateServiceMock.GetTaxRate().Returns(tax);
            
            var command = new TaxCalculateCommand(value, month);
            var result = await _handler.Handle(command, new CancellationToken());
            
            result.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);
        
            (result.Response as decimal?)?.Should().Be(total);
        }


    }
}