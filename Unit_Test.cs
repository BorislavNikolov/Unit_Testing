namespace ParkingSystem.Tests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    public class SoftParkTest
    {
        private Car car;
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("BMW", "8587");
            this.softPark = new SoftPark();
        }

        [Test]
        public void Constructor_ShouldMakeNewCar()
        {
            Assert.That(car.Make == "BMW");
            Assert.That(car.RegistrationNumber == "8587");
        }

        [Test]
        public void Constructor_ShouldMakeEmptyParking()
        {
            Assert.That(softPark.Parking["A1"] == null);
        }

        [Test]
        public void ParkCar_ShouldThrowArgumentExceptionWhenParkingSpotDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("G22", this.car));
        }

        [Test]
        public void ParkCar_ShouldThrowArgumentExceptionWhenParkingSpotIsAlreadyTaken()
        {
            this.softPark.ParkCar("A1", new Car("Opel", "5736"));
            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("A1", car), "Parking spot is already taken!");
        }

        [Test]
        public void ParkCar_ShouldThrowInvalidOperationExceptionWhenCarExists()
        {
            this.softPark.ParkCar("A1", this.car);
            Assert.Throws<InvalidOperationException>(() => this.softPark.ParkCar("A2", this.car));

        }

        [Test]
        public void ParkCar_ShouldParkCarCorrect()
        {
            this.softPark.ParkCar("B1", this.car);
            Assert.That(this.softPark.Parking["B1"], Is.EqualTo(this.car));
        }
        

        [Test]
        public void RemoveCar_ShouldThrowArgumentExceptionWhenParkingSpotDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("C333", this.car));
        }

        [Test]
        public void RemoveCar_ShouldThrowArgumentExceptionWhenSpotIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("C1", this.car));
        }

        [Test]
        public void RemoveCar_ShouldRemoveCarFromSpot()
        {
            this.softPark.ParkCar("B1", this.car);
            this.softPark.RemoveCar("B1", this.car);
            Assert.That(this.softPark.Parking["B1"] == null);
        }
        
    }
}