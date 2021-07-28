using OpenQA.Selenium;
using System.Collections.Generic;

namespace TechTest.Common
{
    public class UiComponent : AmazonHelper
    {
        protected UiComponent(Context context)
        {
            Context = context;
        }

        public Context Context { get; }

        protected void SetDropDownElement(IWebElement dropDownElement, string textToSelect)
        {
            dropDownElement.SendKeys(textToSelect);
        }

        protected IEnumerable<IWebElement> SearchTopProducts(int numberOfProducts)
        {
            numberOfProducts = numberOfProducts + 2;
            var products = new List<IWebElement>();
            
            for (int i = 0; i < numberOfProducts; i++)
            {
                if (i == 0 || i == 1)
                    continue;

                products.Add(Context.Driver.FindElement(By.XPath($"/html/body/div[1]/div[2]/div[1]/div/div[1]/div/span[3]/div[2]/div[{i}]")));
            }

            return products;
        }
    }
}