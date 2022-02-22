using TechTalk.SpecFlow;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CurrencyApi.Specs.Steps
{
    [Binding]
    public class CurrencyConversionValidatorSteps
    {
        private APIService _api = null;

        [Given(@"I have initialized API service call for Currency Conversion API")]
        public void GivenIHaveInitializedAPIServiceCallForCurrencyConversionAPI()
        {
            _api = new APIService();
        }
        
        [Given(@"I want to convert (.*) (.*) to (.*)")]
        public void GivenIWantToConvertTo(string amount, string from, string to)
        {
            if (_api != null)
            {
                _api.Amount = int.Parse(amount);
                _api.From = from;
                _api.To = to;
            }
        }
        
        [When(@"Curency Conversion API is Invoked for given data")]
        public async Task WhenCurencyConversionAPIIsInvokedForGivenData()
        {
            if (_api != null)
            {
                await _api.invokeApiCall();
            }
        }
        
        [Then(@"Verify that the response after conversion is valid")]
        public void ThenVerifyThatTheResponseAfterConversionIsValid()
        {
            if (_api != null)
            {
                Assert.IsTrue(_api.isResponseValid());
            } else
            {
                Assert.Fail("Api is not initialized!");
            }
        }
        
        [Then(@"Verify that the response after conversion is invalid")]
        public void ThenVerifyThatTheResponseAfterConversionIsInvalid()
        {
            if (_api != null)
            {
                Assert.IsTrue(_api.isResponseInvalid());
            }
            else
            {
                Assert.Fail("Invalid response");
            }
        }
    }
}
