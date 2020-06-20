using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.UnitTests
{
    internal static class TestFactory
    {
        public static IEnumerable<EthereumTransaction> MakeMockTransactions()
        {
            return new List<EthereumTransaction>()
            {
                new EthereumTransaction
                {
                    BlockHash = "0x6dbde4b224013c46537231c548bd6ff8e2a2c927c435993d351866d505c523f1",
                    BlockNumber = "0x8b99c9",
                    From = "0xc779a4bdc3696baf2a6d62ddfc2d0664d3c4fd7f",
                    To = "0x92d44b6b3a23b48a93b1bce4d206c0280f96b1cd",
                    Gas = "0x5208",
                    GasPrice = "0x12a05f2000",
                    Hash = "0x827c9a4a1ae2cf9c20fa1dad305b4b8f8f336aab52ff9563379a8a9dbf0d1727",
                    Value = "0x4115f164490000"
                },
                new EthereumTransaction
                {
                    BlockHash = "0x6dbde4b224013c46537231c548bd6ff8e2a2c927c435993d351866d505c523f1",
                    BlockNumber = "0x8b99c9",
                    From = "0x9648a2f7e70ed5492f46d4485c17ff7bc20f64b4",
                    To = "0xdf8751a689387136d79a1ff54349f7db681b5b86",
                    Gas = "0x5208",
                    GasPrice = "0x12a05f2000",
                    Hash = "0x827c9a4a1ae2cf9c20fa1dad305b4b8f8f336aab52ff9563379a8a9dbf0d1727",
                    Value = "0x4115f164490000"
                }
            };
        }
    }
}
