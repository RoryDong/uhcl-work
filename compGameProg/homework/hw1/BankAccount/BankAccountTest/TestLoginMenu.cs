using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;

namespace BankAccountTest
{
    [TestClass]
    public class TestLoginMenu
    {
        [TestMethod]
        public void TestInitialize()
        {
            LoginMenu loginMenu = new LoginMenu();
            Assert.AreEqual(loginMenu.MenuOptionsList[0].displayOption(), "L -> Login\n");
            Assert.AreEqual(loginMenu.MenuOptionsList[1].displayOption(), "C -> Create New Account\n");
            Assert.AreEqual(loginMenu.MenuOptionsList[2].displayOption(), "Q -> Quit\n");
        }

        [TestMethod]
        public void TestDisplayMenu()
        {
            LoginMenu loginMenu = new LoginMenu();
            String menuDisplay = loginMenu.displayMenu();
            Assert.AreEqual(menuDisplay, "L -> Login\nC -> Create New Account\nQ -> Quit\n");
        }

    }
}
