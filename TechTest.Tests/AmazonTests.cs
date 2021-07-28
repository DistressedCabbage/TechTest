using FluentAssertions;
using System;
using TechTest.Common;
using Xunit;

namespace TechTest.Tests
{
    public class AmazonTests : AmazonHelper, IDisposable
    {
        private readonly Context _context;
        private readonly AmazonNavigation _amazonNavigation;

        public AmazonTests()
        {
            _context = new Context(TechTestConfiguration.GetTestConfiguration());
            _amazonNavigation = new AmazonNavigation(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Theory]
        [InlineData("amazon.co.uk")]
        public void VerifyPage(string siteToConfirm)
        {
            var isSiteValid = _context.ConfirmSite(siteToConfirm);
            isSiteValid.Should().BeTrue();
        }


        [Theory]
        [InlineData("Harry Potter and the Cursed Child", "0751565369", "£4")]
        public void SearchForBookAndValidate(string bookToSearch, string amazonId, string price)
        {
            var results = _amazonNavigation.SearchForProducts(bookToSearch, "Books", 5);
            ValidateAmazonResults(results, bookToSearch, price, amazonId).Should().BeTrue();
        }

        [Theory]
        [InlineData("Harry Potter and the Cursed Child", "0751565369", "£4")]
        public void SearchForBookAndSelect(string bookToSearch, string amazonId, string price)
        {
            var results = _amazonNavigation.SearchForProducts(bookToSearch, "Books", 5);
            _amazonNavigation.SelectProductDetails(results, bookToSearch, price, amazonId);
        }
    }
}