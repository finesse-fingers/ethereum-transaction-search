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

        [Fact]
        public async Task TransactionSearch_MockTransaction_ShouldSucceed()
        {
            var mapper = new EthereumTransactionMapper();
            var ethereumServiceMock = new Mock<IEthereumService>();

            // mock returning a list of transactions
            var transactions = TestFactory.MakeSingleTransaction();
            ethereumServiceMock.Setup(s => s.GetTransactionsByBlockNumberAsync(It.IsAny<long>()))
                .ReturnsAsync(transactions);

            var action = new EthereumTransactionSearchActionHandler(ethereumServiceMock.Object, mapper);

            var searchRequest = new EthereumTransactionSearchRequest
            {
                Address = "0xc779a4bdc3696baf2a6d62ddfc2d0664d3c4fd7f",
                BlockNumber = "0x8b99c9"
            };

            // act
            var actual = await action.Search(searchRequest);

            // assert
            Assert.NotNull(actual);
            Assert.Single(actual.Transactions);
            Assert.Equal(transactions.First().BlockHash, actual.Transactions.First().BlockHash);
            Assert.Equal(transactions.First().BlockNumber, actual.Transactions.First().BlockNumber);
            Assert.Equal(transactions.First().From, actual.Transactions.First().From);
            Assert.Equal(transactions.First().To, actual.Transactions.First().To);
            Assert.Equal(transactions.First().Value, actual.Transactions.First().Value);
        }

        [Fact]
        public async Task TransactionSearch_InvalidAddress_ShouldReturnEmpty()
        {
            var mapper = new EthereumTransactionMapper();
            var ethereumServiceMock = new Mock<IEthereumService>();

            // mock returning a list of transactions
            var transactions = TestFactory.MakeSingleTransaction();
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
