using System;
using BookPublisher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        BookPublisherEntities db = new BookPublisherEntities();
        [TestMethod]
        public void AuthorizeTest()
        {
            AuthorizationWindow authorize = new AuthorizationWindow();
            Assert.IsTrue(authorize.Authorize("lerka", "123"));
            Assert.IsFalse(authorize.Authorize("", ""));
        }
        [TestMethod]
        public void RegistrTest()
        {
            RegistrationWindow reg = new RegistrationWindow();
            Assert.IsTrue(reg.Registr("Валерия", "lerka54", "123"));
            Assert.IsFalse(reg.Registr("", "lerka", ""));
        }

        [TestMethod]
        public void AddAuthor()
        {
            AddingAuthors ap = new AddingAuthors();
            Assert.IsTrue(ap.AddAuthor("Есенин", "Сергей", "Александрович"));
            Assert.IsFalse(ap.AddAuthor("", "", ""));
        }

        [TestMethod]
        public void DeleteAuthors()
        {
            AuthorsWindow del = new AuthorsWindow();
            Assert.IsTrue(del.DeleteAuthors(1));
            Assert.IsFalse(del.DeleteAuthors(7));
        }
    }
}
