using OpenQA.Selenium;
using System.Collections.Generic;

namespace TechTest.Common
{
    public class AmazonHelper
    {
        public bool ValidateAmazonResults(IEnumerable<IWebElement> resultsToValidate,
            string textToVerify,
            string price,
            string amazonId)
        {
            foreach (var result in resultsToValidate)
            {
                if (Validate(result, textToVerify, price, amazonId) != null)
                    return true;
            }

            return false;
        }

        public IWebElement ProductToSelect(IEnumerable<IWebElement> resultsToValidate,
            string textToVerify,
            string price,
            string amazonId)
        {
            foreach (var result in resultsToValidate)
            {
                if (Validate(result, textToVerify, price, amazonId) != null)
                    return result;
            }

            return null;
        }

        private IWebElement Validate(IWebElement validate,
                string textToVerify,
                string price,
                string amazonId)
        {
            if (validate.Text.Contains(textToVerify) &&
                validate.Text.Contains(price) &&
                validate.GetAttribute("data-asin").Contains(amazonId))
                return validate;

            return null;
        }
    }
}