using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using Moq;
using System.Data;
using System.Data.SqlClient;


namespace GymMembershipControllerTests
{
    [TestFixture]
    public class GymMembershipControllerTests
    {
        private GymController _controller;
        private Type controllerType;
        private Type carserviceType;
        private PropertyInfo[] properties;

        [SetUp]
        public void Setup()
        {
            // Initialize the controller before each test
            _controller = new GymController();
            carserviceType = typeof(dotnetapp.Models.GymMembership);
            properties = carserviceType.GetProperties();
            controllerType = typeof(GymController);
        }

        [Test]
        public void Test_IndexReturns_ViewResult()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsAssignableFrom<List<GymMembership>>(result.Model);
        }

        [Test]
        public void Test_CreateReturns_ViewResult()
        {
            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
public void TestIndexMethodExists()
{
    // Arrange
    var controllerType = typeof(GymController);
    var methodName = "Index";

    // Act
    var indexMethod = controllerType.GetMethod(methodName);

    // Assert
    Assert.IsNotNull(indexMethod, $"{methodName} method should exist in GymController.");
}

        [Test]
        public void TestCreateGetMethodExists()
        {
            // Arrange
            MethodInfo createGetMethod = controllerType.GetMethod("Create", new Type[0]);

            // Assert
            Assert.IsNotNull(createGetMethod, "Create method should exist in GymController.");
        }

        [Test]
        public void TestCreatePostMethodExists()
        {
            // Arrange
            MethodInfo createPostMethod = controllerType.GetMethod("Create", new Type[] { typeof(GymMembership) });

            // Assert
            Assert.IsNotNull(createPostMethod, "Create POST method should exist in GymController.");
        }

        [Test]
        public void TestGymMembershipClassExists()
        {
            // Arrange
            Type furnitureType = typeof(dotnetapp.Models.GymMembership);

            // Assert
            Assert.IsNotNull(furnitureType, "GymMembership class should exist.");            
        }

        [Test]
        public void TestGymMembershipPropertiesExist()
        {
            // Assert
            Assert.IsNotNull(properties, "GymMembership class should have properties.");
            Assert.IsTrue(properties.Length > 0, "GymMembership class should have at least one property.");
        }

        [Test]
        public void TestidProperty()
        {
            // Arrange
            PropertyInfo idProperty = properties.FirstOrDefault(p => p.Name == "id");

            // Assert
            Assert.IsNotNull(idProperty, "id property should exist.");
            Assert.AreEqual(typeof(int), idProperty.PropertyType, "id property should have data type 'int'.");
        }

        [Test]
        public void TestNameProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "Name");

            // Assert
            Assert.IsNotNull(productProperty, "Name property should exist.");
            Assert.AreEqual(typeof(string), productProperty.PropertyType, "Name property should have data type 'string'.");
        }

        [Test]
        public void TestJoiningDateProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "JoiningDate");

            // Assert
            Assert.IsNotNull(productProperty, "JoiningDate property should exist.");
            Assert.AreEqual(typeof(DateTime), productProperty.PropertyType, "JoiningDate property should have data type 'string'.");
        }

        [Test]
        public void TestExpiryDateProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "ExpiryDate");

            // Assert
            Assert.IsNotNull(productProperty, "ExpiryDate property should exist.");
            Assert.AreEqual(typeof(DateTime), productProperty.PropertyType, "ExpiryDate property should have data type 'string'.");
        }

        [Test]
        public void Test_CreateViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Gym-ADO-MVC/dotnetapp/Views/Gym", "Create.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Create.cshtml view file does not exist.");
        }

        [Test]
        public void Test_IndexViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/Gym-ADO-MVC/dotnetapp/Views/Gym", "Index.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Index.cshtml view file does not exist.");
        }

    
    }
}
