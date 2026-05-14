using NUnit.Framework;

namespace WpfApp9.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CorrectPassword()
        {
            WpfApp9.ValidatorService validator = new WpfApp9.ValidatorService();
            bool result = validator.CheckPassword("12345678");
            Assert.IsTrue(result);
        }
        [Test]
        public void CorrectUser()
        {
            WpfApp9.ValidatorService validator = new WpfApp9.ValidatorService();
            bool result = validator.ValidateUser("user", "12345678", "creds");
            Assert.IsTrue(result);
        }
        [Test]
        public void BlankPasswordUser()
        {
            WpfApp9.ValidatorService validator = new WpfApp9.ValidatorService();
            bool result = validator.ValidateUser("user", "", "creds");
            Assert.IsFalse(result);
        }
        [Test]
        public void BlankLoginUser()
        {
            WpfApp9.ValidatorService validator = new WpfApp9.ValidatorService();
            bool result = validator.ValidateUser("", "12345678", "creds");
            Assert.IsFalse(result);
        }
        [Test]
        public void BlankCredsUser()
        {
            WpfApp9.ValidatorService validator = new WpfApp9.ValidatorService();
            bool result = validator.ValidateUser("user", "12345678", "");
            Assert.IsFalse(result);
        }
        [Test]
        public void BlankUser()
        {
            WpfApp9.ValidatorService validator = new WpfApp9.ValidatorService();
            bool result = validator.ValidateUser("", "", "");
            Assert.IsFalse(result);
        }
        [Test]
        public void ShortPassword()
        {
            WpfApp9.ValidatorService validator = new WpfApp9.ValidatorService();
            bool result = validator.CheckPassword("1234567");
            Assert.IsFalse(result);
        }
        [Test]
        public void NullPassword()
        {
            WpfApp9.ValidatorService validator = new WpfApp9.ValidatorService();
            bool result = validator.CheckPassword("");
            Assert.IsFalse(result);
        }
    }
}