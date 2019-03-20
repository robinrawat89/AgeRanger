using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace AgeRangerWebUi.PageFactoryObjects
{
    public class AgeRangerMainPage

    {
        public AgeRangerMainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "searchText")]
        public IWebElement SearchTextField;

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement FirstName;

        [FindsBy(How = How.Name, Using = "LastName")]
        public IWebElement LastName;

        [FindsBy(How = How.Name, Using = "Age")]
        public IWebElement Age;

       [FindsBy(How = How.XPath, Using = "//div[.='People']/following-sibling::div/table")]
       public IWebElement PeopleTable { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@class='col-md-7 ng-binding']")]
        public IList<IWebElement> ExistingUserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[@class='col-md-2 ng-binding']")]
        public IList<IWebElement> ExistingUserAge { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='openEditForm(person)']")]
        public IWebElement EditPerson { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='page-wrapper']/div/div[2]/div[1]/div/div[2]/table/tbody/tr[1]/td[4]/a[2]/i")]
        public IWebElement DeletePerson1 { get; set; } 

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='openNewPersonForm()']")]
        public IWebElement AddPerson { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='help-block']")]
        public IWebElement FirstNameInlineError { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/form/div[3]/button[1]")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@ng-click='close()']")]
        public IWebElement CloseButton { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div/div[2]/button[2]")]
        public IWebElement OkButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@data-bb-handler='cancell']")]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='bootbox-close-button close']")]
        public IWebElement CrossButton { get; set; }


        


    }
}
