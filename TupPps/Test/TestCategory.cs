using Xunit;
using DataModels.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TupPps.Test
{
    public class TestCategory
    {
        [Fact]
        public void Category_Name_SetCorrectly()
        {
            var category = new Category();
            string expectedName = "Teclado";

            category.Name = expectedName;

            Assert.Equal(expectedName, category.Name);
        }

        [Fact]
        public void Category_Products_Initialized()
        {
            var category = new Category();

            Assert.NotNull(category.Products);
            Assert.IsType<List<Product>>(category.Products);
        }

        

        [Fact]
        public void Category_InvalidProperties_ReturnValidationError()
        {
            var category = new Category();

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(category, null, null);
            bool isValid = Validator.TryValidateObject(category, context, validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

    }
}
