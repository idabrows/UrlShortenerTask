using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlShortener.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Services.Tests
{
    [TestClass()]
    public class ShortUrlSeviceTests
    {
        [TestMethod()]
        public void CreateUrlTest()
        {
            // ARRANGE
            var mock = new Mock<IFoo>();
            mock.Setup(p => p.DoSomething(It.IsAny<string>())).Returns(true);
            var sut = new Service(mock.Object);

            // ACT
            sut.Ping();

            // ASSERT
            mock.Verify(p => p.DoSomething("PING"), Times.Once());
        }
    }
}