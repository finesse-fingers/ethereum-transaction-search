using WebApp.Mapping;
using WebApp.Models;
using Xunit;

namespace WebApp.UnitTests
{
    public class EthereumTransactionMappingTests
    {
        [Fact]
        public void MapTransactionToDton_EmptySource_ShouldSucceed()
        {
            var mapper = new EthereumTransactionMapper();
            var source = new EthereumTransaction();

            // act
            var actual = mapper.Map(source);

            // assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void MapTransactionToDto_BlockHash_ShouldSucceed()
        {
            var mapper = new EthereumTransactionMapper();
            var source = new EthereumTransaction
            {
                BlockHash = "12345"
            };

            // act
            var actual = mapper.Map(source);

            // assert
            Assert.NotNull(actual);
            Assert.Equal("12345", actual.BlockHash);
        }

        [Fact]
        public void MapTransactionToDto_BlockNumber_ShouldSucceed()
        {
            var mapper = new EthereumTransactionMapper();
            var source = new EthereumTransaction
            {
                BlockNumber = "12345"
            };

            // act
            var actual = mapper.Map(source);

            // assert
            Assert.NotNull(actual);
            Assert.Equal("12345", actual.BlockNumber);
        }

        /*
            Note:   the rest of the mapping tests are omitted
                    hopefully the tests above demonstrate the idea
         */
    }
}
