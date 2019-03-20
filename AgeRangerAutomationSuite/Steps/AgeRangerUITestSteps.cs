using AgeRangerWebUi.PageFactoryObjects;
using AgeRangerWebUi.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace AgeRangerWebUi.Steps
{
    [Binding]
    public class AgeRangerUITestSteps : BaseClass
    {
        [Given(@"I am on Age Ranger Home Page")]

        public void GoToHomePage()
        {
            //driver = DriverFactory.InitiateWebDriver(CommonConstants.DriverSettings.ChromeBrowser);
            driver.Navigate().GoToUrl(CommonConstants.ApplicationSettings.BaseUrl);
            //Sleep(500);
        }

        [When(@"I click Add New Person button")]
        public void AddNewPerson()
        {
            var pageObject = new AgeRangerMainPage(driver);
            pageObject.AddPerson.Click();
            //Sleep(500);
        }

        [When(@"I Submit the form")]
        public void SubmitForm()
        {
            var pageObject = new AgeRangerMainPage(driver);
            pageObject.SubmitButton.Click();
           
        }

        [When(@"I confirm the action$")]
        public void ConfirmAction()
        {
            var pageObject = new AgeRangerMainPage(driver);
            pageObject.OkButton.Click();
           // Sleep(500);
        }


        [When(@"I enter (.*), (.*) and (.*) in the form")]
        public void EnterNewPersonDetails(String firstName, String lastName, String age)
        {
            var pageObject = new AgeRangerMainPage(driver);
            if (!firstName.Equals("NoChange"))
            {
                pageObject.FirstName.Clear();
                pageObject.FirstName.SendKeys(firstName);
            }
            if (!lastName.Equals("NoChange"))
            {
                pageObject.LastName.Clear();
                pageObject.LastName.SendKeys(lastName);
            }
            if (!age.Equals("NoChange"))
            {
                pageObject.Age.Clear();
                pageObject.Age.SendKeys(age.ToString());
            }
        }

        [When(@"I delete created person (.*), (.*) and (.*)")]
        [Then(@"I delete created person (.*), (.*) and (.*)")]
        public void DeletePerson(String firstName, String lastName, String age)
        {
            // Search using First Name

            SearchUsingFirstName(firstName);
            Sleep(1);
            var pageObject1 = new AgeRangerMainPage(driver);
            string firstLastName = (firstName + ' ' + lastName);
            bool userFound = false;
            
            IWebElement tableElement = driver.FindElement(By.XPath("//div[.='People']/following-sibling::div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.XPath("//div[.='People']/following-sibling::div/table/tbody/tr"));

            var q = tableRow[0].Text;
            if (tableRow[0].Text.Contains(firstLastName) && tableRow[0].Text.Contains(age.ToString()))
            {
                pageObject1.DeletePerson1.Click();
                Sleep(1);
                var OK = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/button[2]"));
                OK.Click();
                Sleep(1);
                userFound = true;
            }
            
            Assert.True(userFound, "User not Found.");


          
        }

        [Given(@"I created a new person with (.*), (.*) and (.*)")]
        public void CreateNewPerson(String firstName, String lastName, String age)
        {
            GoToHomePage();
            AddNewPerson();
            EnterNewPersonDetails(firstName, lastName, age);
            SubmitForm();
            ConfirmAction();
        }

        public void SearchUsingFirstName(String firstName)
        {
            var pageObject = new AgeRangerMainPage(driver);
            pageObject.SearchTextField.Clear();
            pageObject.SearchTextField.SendKeys(firstName);
            pageObject.SearchTextField.SendKeys(Keys.Enter);
            //Sleep(2000);
        }

        [When(@"I update the (.*), (.*) and (.*) with (.*), (.*) and (.*)")]
        public void UpdatePerson(String oldFirstName, String oldLastName, String oldAge, String newFirstName, String newLastName, String newAge)
        {
            //Search using First Name
            SearchUsingFirstName(oldFirstName);
            Sleep(2);
            var pageObject2 = new AgeRangerMainPage(driver);
            IWebElement tableElement = driver.FindElement(By.XPath("//div[.='People']/following-sibling::div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.XPath("//div[.='People']/following-sibling::div/table/tbody/tr"));
           // IList<IWebElement> tableRows = pageObject2.PeopleTable.FindElements(By.TagName("td"));
            string firstLastName = (oldFirstName + " " + oldLastName);
            foreach (IWebElement row in tableRow)
            {
                if (row.Text.Contains(firstLastName) && row.Text.Contains(oldAge.ToString()))
                {
                    row.FindElement(By.XPath("//i[contains(@class, 'fa-pencil')]")).Click();
                    Sleep(2);
                    EnterNewPersonDetails(newFirstName, newLastName, newAge);
                    break;
                }
            }
        }

        [Then(@"I should see (.*) and (.*) in the People view with correct (.*) instead of (.*) (.*) and (.*)")]
        public void UserExistVerification(String newFirstName, String newLastName, String newAge, String oldFirstName, String oldLastName, String oldAge)
        {
            SearchUsingFirstName(newFirstName);
            Sleep(2);
            var pageObject = new AgeRangerMainPage(driver);
            string firstLastName = (newFirstName + " " + newLastName);
            bool userFound = false;
            IWebElement tableElement = driver.FindElement(By.XPath("//div[.='People']/following-sibling::div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.XPath("//div[.='People']/following-sibling::div/table/tbody/tr"));
            
            var q = tableRow[0].Text;
            foreach (IWebElement row in tableRow)
            {
                var p = row.Text;
                if (row.Text.Contains(firstLastName) && row.Text.Contains(newAge.ToString()) )
                {
                    userFound = true;
                    Sleep(2);
                    break;
                }
            }
            Assert.True(userFound, "User exists.");
        }

        
        [Then(@"I should see (.*) and (.*) in the People view with correct (.*) and the correct (.*)")]
        public void VerifyPerson(String firstName, String lastName, String age, String ageGroup)
        {
            // Search using First Name
            SearchUsingFirstName(firstName);
            Sleep(2);
            var pageObject = new AgeRangerMainPage(driver);
            string firstLastName = (firstName + " " + lastName);
            bool userFound = false;
            IWebElement tableElement = driver.FindElement(By.XPath("//div[.='People']/following-sibling::div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.XPath("//div[.='People']/following-sibling::div/table/tbody/tr"));
            foreach (IWebElement row in tableRow)
             {                
                var p = row.Text;
                if (row.Text.Contains(firstLastName) && row.Text.Contains(age.ToString()) && row.Text.Contains(ageGroup))
                {
                    userFound = true;
                    break;
                }
            }
            Assert.True(userFound, "User exists.");

        }

        [Then(@"I should not see (.*), (.*) and (.*) record anymore")]
        public void UserNotExistVerification(String firstName, String lastName, String age)
        {
            // Search using First Name
            SearchUsingFirstName(firstName);

            var pageObject = new AgeRangerMainPage(driver);
            IList<IWebElement> tableRows = pageObject.PeopleTable.FindElements(By.TagName("td"));
            string firstLastName = (firstName + " " + lastName);
            bool userFound = false;

            foreach (IWebElement row in tableRows)
            {
                if (row.Text.Contains(firstLastName) && row.Text.Contains(age.ToString()))
                {
                    userFound = true;
                    break;
                }
            }

            Assert.True(userFound, "User exists.");
        }
        
        [Then(@"I should not see (.*), (.*) and (.*) anymore")]
        public void DeleteUser(String firstName, String lastName, String Age)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement tableElement = driver.FindElement(By.XPath("//div[.='People']/following-sibling::div/table"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.XPath("//div[.='People']/following-sibling::div/table/tbody/tr"));
            bool userFound = false;
            //int count = tableRow.size();

            foreach (IWebElement row in tableRow)
            {
                if (row.Text.Contains(firstName) && row.Text.Contains(Age.ToString()) && row.Text.Contains(lastName))
                {
                    userFound = true;
                    break;
                }
            }

            Assert.False(userFound, "User was not exists.");

           
        }

    }
}