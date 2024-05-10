using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace AT_Framework_Task_1_v_1
{
    [TestFixture]
    public class GoogleCloudEstimateAmount
    {
        private ChromeDriver driver;
        private const string url = "https://cloud.google.com/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestGoogleCalculator()
        {
            var inputComputeEngineValue = "COMPUTE ENGINE";
            var inputInstancesNumber = "4";
            var inputOperationSystem = "free-debian-centos-coreos-ubuntu";
            var inputMachineFamily = "general-purpose";
            var inputSeriesValue = "n1";
            var inputMachineTypeValue = "n1-standard-8";
            var inputGPUModelField = "GPU Model";
            var inputGPUModelValue = "nvidia-tesla-v100";
            var inputNumberOfGPUField = "Number of GPUs";
            var inputNumberOfGPUValue = "1";
            var inputLocalSSDValue = "2x375 GB";
            var inputRegionValue = "europe-west4";
            var inputCurrencySymbol = "USD";
            var inputTotalPrice = "$5,628.90";
            var inputExpectedPerTime = "/ month";
            var inputUsageTime = "1 year";
            var expectedOperationSystem = "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)";
            var expectedProvisioningModel = "Regular";
            var expectedMachineType = "n1-standard-8, vCPUs: 8, RAM: 30 GB";
            var expectedGPUModel = "NVIDIA Tesla V100";

            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl(url);

            IWebElement searchGoogleIcon = driver.FindElement(By.ClassName("YSM5S"));
            searchGoogleIcon.Click();
            IWebElement searchGoogleTextField = driver.FindElement(By.ClassName("qdOxv-fmcmS-wGMbrd"));
            searchGoogleTextField.SendKeys("Google Cloud Platform Pricing Calculator");

            IWebElement pressSearchButton = driver.FindElement(By.CssSelector(".PETVs.PETVs-OWXEXe-UbuQg"));
            pressSearchButton.Click();
            searchGoogleTextField.Click();

            IWebElement searchResultElement = wait.Until(ExpectedConditions.ElementExists(By.ClassName("K5hUy")));
            searchResultElement.Click();

            IWebElement addToEstimateButton = driver.FindElement(By.ClassName("UywwFc-vQzf8d"));
            addToEstimateButton.Click();
            IWebElement searchFieldEstimate = driver.FindElement(By.Id("yDmH0d"));
            searchFieldEstimate.SendKeys(inputComputeEngineValue);

            IWebElement computeEngineButton = wait.Until(ExpectedConditions.ElementExists(By.ClassName("BPgnDc")));
            computeEngineButton.Click();

            IWebElement numberOfInstance = wait.Until(ExpectedConditions.ElementExists(By.Id("c11")));
            numberOfInstance.Clear();
            numberOfInstance.SendKeys(inputInstancesNumber);

            IWebElement dropDownOperationSystemElement = driver.FindElement(By.Id("c19"));
            driver.ExecuteScript("arguments[0].click();", dropDownOperationSystemElement);
            IWebElement dropDownOperationSystemOption = driver.FindElement(By.XPath($"//li[contains(@data-value, '{inputOperationSystem}')]"));
            dropDownOperationSystemOption.Click();

            IWebElement regularButton = driver.FindElement(By.Id("regular"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", regularButton);
            driver.ExecuteScript("arguments[0].click();", regularButton);

            IWebElement machineFamilyElement = driver.FindElement(By.Id("c26"));
            driver.ExecuteScript("arguments[0].click();", machineFamilyElement);
            IWebElement machineFamilyOption = driver.FindElement(By.XPath($"//li[contains(@data-value, '{inputMachineFamily}')]"));
            machineFamilyOption.Click();

            IWebElement seriesElement = driver.FindElement(By.Id("c30"));
            driver.ExecuteScript("arguments[0].click();", seriesElement);
            IWebElement seriesOption = driver.FindElement(By.XPath($"//li[contains(@data-value, '{inputSeriesValue}')]"));
            seriesOption.Click();

            IWebElement machineTypeElement = driver.FindElement(By.Id("c33"));
            driver.ExecuteScript("arguments[0].click();", machineTypeElement);
            IWebElement machineTypeOption = driver.FindElement(By.XPath($"//li[contains(@data-value, '{inputMachineTypeValue}')]"));
            machineTypeOption.Click();

            IWebElement buttonAddGPUs = driver.FindElement(By.CssSelector("div.AsBIyb button[aria-label='Add GPUs']"));
            buttonAddGPUs.Click();
            Assert.That(buttonAddGPUs.GetAttribute("aria-checked"), Is.EqualTo("true"), "Switch is not turned on.");

            IWebElement gPUModelElementLabel = wait.Until(ExpectedConditions.ElementExists(By.XPath($"//span[text()='{inputGPUModelField}']")));
            IWebElement gPUModelElement = gPUModelElementLabel.FindElement(By.XPath("./.."));
            driver.ExecuteScript("arguments[0].click();", gPUModelElement);
            IWebElement gPUModelOption = driver.FindElement(By.XPath($"//li[contains(@data-value, '{inputGPUModelValue}')]"));
            gPUModelOption.Click();

            IWebElement numberOfGPUElementLabel = wait.Until(ExpectedConditions.ElementExists(By.XPath($"//span[text()='{inputNumberOfGPUField}']")));
            IWebElement numberOfGPUElement = numberOfGPUElementLabel.FindElement(By.XPath("./.."));
            driver.ExecuteScript("arguments[0].click();", numberOfGPUElement);
            IWebElement numberOfGPUOption = driver.FindElement(By.XPath($"//li[@data-value='{inputNumberOfGPUValue}']"));
            numberOfGPUOption.Click();

            IWebElement localSSDElement = wait.Until(ExpectedConditions.ElementExists(By.Id("c42")));
            driver.ExecuteScript("arguments[0].click();", localSSDElement);
            IWebElement localSSDOption = wait.Until(ExpectedConditions.ElementExists(By.XPath($"//li[contains(., '{inputLocalSSDValue}')]")));
            localSSDOption.Click();

            IWebElement regionElement = wait.Until(ExpectedConditions.ElementExists(By.Id("c46")));
            driver.ExecuteScript("arguments[0].click();", regionElement);
            IWebElement regionOption = driver.FindElement(By.XPath($"//li[@data-value='{inputRegionValue}']"));
            regionOption.Click();

            IWebElement commitedUsageElement = driver.FindElement(By.XPath($"//label[contains(text(), '{inputUsageTime}')]"));
            commitedUsageElement.Click();

            IWebElement currencyElement = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("span.AeBiU-vQzf8d")));
            Assert.That(currencyElement.Text, Is.EqualTo(inputCurrencySymbol), "Currency is not USD");

            IWebElement addEstimateButton = driver.FindElement(By.XPath("//span[text()='Add to estimate']"));
            addEstimateButton.Click();

            IWebElement closeEstimateButton = driver.FindElement(By.XPath("//button[@data-idom-class='bwApif-zMU9ub']"));
            driver.ExecuteScript("arguments[0].click();", closeEstimateButton);

            IWebElement amountElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='MyvX5d D0aEmf']")));
            wait.Until(ExpectedConditions.TextToBePresentInElement(amountElement, "$5,628.90"));
            var amount = amountElement.Text;
            Assert.That(amount, Is.EqualTo(inputTotalPrice), "Price not equal $5,628.90");

            IWebElement perTime = driver.FindElement(By.ClassName("WUm90"));
            var existPerTime = perTime.Text;
            Assert.That(existPerTime, Is.EqualTo(inputExpectedPerTime), "Price are not for per month");

            IWebElement shareButton = driver.FindElement(By.ClassName("FOBRw-vQzf8d"));
            driver.ExecuteScript("arguments[0].click();", shareButton);

            IWebElement openEstimateSummary = driver.FindElement(By.CssSelector("[track-name='open estimate summary']"));
            driver.ExecuteScript("arguments[0].click();", openEstimateSummary);

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            IWebElement numberOfInstancesElement = driver.FindElement(By.XPath("//span[contains(text(), 'Number of Instances')]/following-sibling::span[@class='Kfvdz']"));
            string numberOfInstancesExist = numberOfInstancesElement.Text;
            Assert.That(numberOfInstancesExist, Is.EqualTo(inputInstancesNumber), $"Number of istance is not {inputInstancesNumber} as expected");

            IWebElement operationSystemSoftwareElement = driver.FindElement(By.XPath("//span[contains(text(), 'Operating System / Software')]/following-sibling::span[@class='Kfvdz']"));
            string operationSystemSoftwareExist = operationSystemSoftwareElement.Text;
            Assert.That(operationSystemSoftwareExist, Does.Contain(expectedOperationSystem), $"Operation system is not {expectedOperationSystem} as expected");

            IWebElement provisioningModelElement = driver.FindElement(By.XPath("//span[contains(text(), 'Provisioning Model')]/following-sibling::span[@class='Kfvdz']"));
            string provisioningModelExist = provisioningModelElement.Text;
            Assert.That(provisioningModelExist, Is.EqualTo(expectedProvisioningModel), $"Provisioning Model is not {expectedProvisioningModel} as expected");

            IWebElement machineTypeExistElement = driver.FindElement(By.XPath("//span[contains(text(), 'Machine type')]/following-sibling::span[@class='Kfvdz']"));
            string machineTypeExist = machineTypeExistElement.Text;
            Assert.That(machineTypeExist, Is.EqualTo(expectedMachineType), $"Machine type is not {expectedMachineType} as expected");

            IWebElement gPUModelExistElement = driver.FindElement(By.XPath("//span[contains(text(), 'GPU Model')]/following-sibling::span[@class='Kfvdz']"));
            string gPUModelExist = gPUModelExistElement.Text;
            Assert.That(gPUModelExist, Is.EqualTo(expectedGPUModel), $"GPU Model is not {expectedGPUModel} as expected");

            IWebElement numberOfGPUExistElement = driver.FindElement(By.XPath("//span[contains(text(), 'Number of GPUs')]/following-sibling::span[@class='Kfvdz']"));
            string numberOfGPUExist = numberOfGPUExistElement.Text;
            Assert.That(numberOfGPUExist, Is.EqualTo(inputNumberOfGPUValue), $"Number of GPU is not {inputNumberOfGPUValue} as expected");

            IWebElement localSSDExistElement = driver.FindElement(By.XPath("//span[contains(text(), 'Local SSD')]/following-sibling::span[@class='Kfvdz']"));
            string localSSDExist = localSSDExistElement.Text;
            Assert.That(localSSDExist, Is.EqualTo(inputLocalSSDValue), $"Number of GPU is not {inputLocalSSDValue} as expected");

            IWebElement regionExistElement = driver.FindElement(By.XPath("//span[contains(text(), 'Region')]/following-sibling::span[@class='Kfvdz']"));
            string regionExist = regionExistElement.Text;
            Assert.That(regionExist, Does.Contain(inputRegionValue), $"Region is not {inputRegionValue} as expected");

            IWebElement commitedUsageExistElement = driver.FindElement(By.XPath("//span[contains(text(), 'Committed use discount options')]/following-sibling::span[@class='Kfvdz']"));
            string commitedUsageExist = commitedUsageExistElement.Text;
            Assert.That(commitedUsageExist, Is.EqualTo(inputUsageTime), $"Number of GPU is not {inputUsageTime} as expected");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}