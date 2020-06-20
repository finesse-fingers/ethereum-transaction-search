using WebApp.Factories;
using Xunit;

namespace WebApp.UnitTests
{
    public class InfuraRequestBuilderTests
    {
        [Fact]
        public void BuildRequest_ShuoldSucceed()
        {
            var requestBuilder = new InfuraRequestBuilder();

            // act
            var request = requestBuilder.MakeGetBlockByNumber(123456, true);

            // assert
            Assert.NotNull(request);
            Assert.Equal(2, request.Params.Length);
            Assert.Equal("0x1E240", request.Params[0]);
            Assert.Equal(true, request.Params[1]);
        }
    }
}
