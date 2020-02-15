namespace Telecom.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void Constructor_ShouldInitializeNewPhone()
        {
            var phone = new Phone("Samsung", "A3");

            Assert.That(phone.Make == "Samsung");
            Assert.That(phone.Model == "A3");
            Assert.IsInstanceOf<Phone>(phone);
        }

        [Test]
        public void Make_ShouldThrowArgumentExceptionWhenIsNull()
        {
            Phone phone;

            Assert.Throws<ArgumentException>(() => phone = new Phone(null, "A3"));
        }

        [Test]
        public void Make_ShouldThrowArgumentExceptionWhenIsEmpty()
        {
            Phone phone;

            Assert.Throws<ArgumentException>(() => phone = new Phone("", "A3"));
        }

        [Test]
        public void Model_ShouldThrowArgumentExceptionWhenIsNull()
        {
            Phone phone;

            Assert.Throws<ArgumentException>(() => phone = new Phone("Iphone", null));
        }

        [Test]
        public void Model_ShouldThrowArgumentExceptionWhenIsEmpty()
        {
            Phone phone;

            Assert.Throws<ArgumentException>(() => phone = new Phone("LG", ""));
        }

        [Test]
        public void Count_GetPhoneBookCountCorrect()
        {
            var phone = new Phone("LG", "L-Fino");

            Assert.That(phone.Count == 0);
        }

        [Test]
        public void AddContact_ShouldAddContactsuccessfully()
        {
            var phone = new Phone("Lenovo", "510");

            phone.AddContact("Kiro", "0887098291");

            Assert.That(phone.Count == 1);
        }

        [Test]
        public void AddContact_ShouldThrowInvalidOperationExceptionWhenTryToAddExistingContact()
        {
            var phone = new Phone("Lenovo", "510");

            phone.AddContact("Kiro", "0887098291");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Kiro", "0889030510"));
        }

        [Test]
        public void Call_ShouldThrowInvalidOperationExceptionWhenCallDoesntExistingContact()
        {
            var phone = new Phone("Lenovo", "510");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }

        [Test]
        public void Call_ShouldCallContactCorect()
        {
            var phone = new Phone("Lenovo", "510");

            phone.AddContact("Kiro", "0887098291");

            Assert.That(() => phone.Call("Kiro") == "Calling Kiro - 0887098291...");
        }
    }
}