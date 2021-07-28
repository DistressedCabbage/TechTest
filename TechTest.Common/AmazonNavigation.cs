using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechTest.Common
{
    public class AmazonNavigation : UiComponent
    {
        public AmazonNavigation(Context context) : base(context)
        {

        }

        private IWebElement SearchBar() => Context.Driver.FindElement(By.Id("twotabsearchtextbox"));

        private IWebElement SearchBarDropDown() => Context.Driver.FindElement(By.CssSelector("[aria-describedby=searchDropdownDescription]"));

        private IWebElement SubmitSearch() => Context.Driver.FindElement(By.Id("nav-search-submit-button"));

        private IWebElement ProductToSelect(string id) => Context.Driver.FindElement(By.Id(id));

        private IWebElement CookieBarOk() => Context.Driver.FindElement(By.Id("sp-cc-accept"));

        public void SearchFor(string searchFor)
        {
            SearchBar().SendKeys(searchFor);
            SubmitSearch().Click();
        }

        public IEnumerable<IWebElement> SearchForProducts(string searchFor, 
            string subCategory,
            int numberOfProductsToSearch)
        {
            CookieBarOk().Click();
            SetDropDownElement(SearchBarDropDown(), subCategory);
            SearchBar().SendKeys(searchFor);
            SubmitSearch().Click();
            return SearchTopProducts(numberOfProductsToSearch);
        }

        public void SelectProductDetails(IEnumerable<IWebElement> resultsToValidate,
            string textToVerify,
            string price,
            string amazonId)
        {
            ProductToSelect(resultsToValidate,
                textToVerify,
                price,
                amazonId).Click();
        }
    }
}