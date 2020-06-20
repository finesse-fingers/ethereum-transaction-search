using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Actions;
using WebApp.Mapping;
using WebApp.Models;
using WebApp.Services;
using Xunit;

namespace WebApp.UnitTests
{
    public class TransactionSearchHandlerTests
    {
        [Fact]
        public async Task TransactionSearch_EmptySearchResult_ShouldSucceed()
        {
            var mapper = new EthereumTransactionMapper();
            var ethereumServiceMock = new Mock<IEthereumService>();

            // mock returning an empty list
            ethereumServiceMock.Setup(s => s.GetTransactionsByBlockNumberAsync(It.IsAny<long>()))
                .ReturnsAsync(new List<EthereumTransaction>());

            var action = new EthereumTransactionSearchActionHandler(ethereumServiceMock.Object, mapper);

            var searchRequest = new EthereumTransactionSearchRequest
            {
                Address = "0x12345",
                BlockNumber = "12345"
            };

            // act
            var result = await action.Search(searchRequest);

            // assert
            Assert.NotNull(result);
            Assert.Empty(result.Transactions);
        }

        [Theory]
        [InlineData("0xc779a4bdc3696baf2a6d62ddfc2d0664d3c4fd7f")]
        [InlineData("0x9648a2f7e70ed5492f46d4485c17ff7bc20f64b4")]
        public async Task TransactionSearch_ShouldMatchOneTransaction_UsingFromField(string addressToMatch)
        {
            var mapper = new EthereumTransactionMapper();
            var ethereumServiceMock = new Mock<IEthereumService>();

            // mock returning a list of transactions
            var transactions = TestFactory.MakeMockTransactions();
            ethereumServiceMock.Setup(s => s.GetTransactionsByBlockNumberAsync(It.IsAny<long>()))
                .ReturnsAsync(transactions);

            var action = new EthereumTransactionSearchActionHandler(ethereumServiceMock.Object, mapper);

            var searchRequest = new EthereumTransactionSearchRequest
            {
                Address = addressToMatch,
                BlockNumber = "0x8b99c9"
            };

            // act
            var actual = await action.Search(searchRequest);

            // assert
            Assert.NotNull(actual);
            Assert.Single(actual.Transactions);
        }

        [Theory]
        [InlineData("0x92d44b6b3a23b48a93b1bce4d206c0280f96b1cd")]
        [InlineData("0xdf8751a689387136d79a1ff54349f7db681b5b86")]
        public async Task TransactionSearch_ShouldMatchOneTransaction_UsingToField(string addressToMatch)
        {
            var mapper = new EthereumTransactionMapper();
            var ethereumServiceMock = new Mock<IEthereumService>();

            // mock returning a list of transactions
            var transactions = TestFactory.MakeMockTransactions();
            ethereumServiceMock.Setup(s => s.GetTransactionsByBlockNumberAsync(It.IsAny<long>()))
                .ReturnsAsync(transactions);

            var action = new EthereumTransactionSearchActionHandler(ethereumServiceMock.Object, mapper);

            var searchRequest = new EthereumTransactionSearchRequest
            {
                Address = addressToMatch,
                BlockNumber = "0x8b99c9"
            };

            // act
            var actual = await action.Search(searchRequest);

            // assert
            Assert.NotNull(actual);
            Assert.Single(actual.Transactions);
        }

        [Fact]
        public async Task TransactionSearch_InvalidAddress_ShouldReturnEmpty()
        {
            var mapper = new EthereumTransactionMapper();
            var ethereumServiceMock = new Mock<IEthereumService>();

            // mock returning a list of transactions
            var transactions = TestFactory.MakeMockTransactions();
            ethereumServiceMock.Setup(s => s.GetTransactionsByBlockNumberAsync(It.IsAny<long>()))
                .ReturnsAsync(transactions);

            var action = new EthereumTransactionSearchActionHandler(ethereumServiceMock.Object, mapper);

            var searchRequest = new EthereumTransactionSearchRequest
            {
                Address = "invalidAddress",
                BlockNumber = "0x8b99c9"
            };

            // act
            var actual = await action.Search(searchRequest);

            // assert
            Assert.NotNull(actual);
            Assert.Empty(actual.Transactions);
        }
    }
}
