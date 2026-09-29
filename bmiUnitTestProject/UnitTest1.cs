```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMICalculator;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace bmiUnitTestProject
{
    [TestClass]
    public class BMITests
    {
        // Test the BMI calculation
        [TestMethod]
        public void BMIValue_ValidInput_ReturnsCorrectBMI()
        {
            // 11 stones, 0 pounds, 5 feet 10 inches
            BMI bmi = new BMI
            {
                #WeightStones = 11,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 10
            };

            // Expected BMI is approximately 22.15
            Assert.AreEqual(22.15, bmi.BMIValue, 0.01);
        }

        // Test Underweight category
        [TestMethod]
        public void BMICategory_Underweight_ReturnsUnderweight()
        {
            BMI bmi = new BMI
            {
                WeightStones = 8,
                WeightPounds = 2,
                HeightFeet = 5,
                HeightInches = 6
            };

            Assert.AreEqual(BMICategory.Underweight, bmi.BMICategory);
        }

        // Test Normal category
        [TestMethod]
        public void BMICategory_Normal_ReturnsNormal()
        {
            BMI bmi = new BMI
            {
                WeightStones = 11,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 10
            };

            Assert.AreEqual(BMICategory.Normal, bmi.BMICategory);
        }

        // Test Overweight category
        [TestMethod]
        public void BMICategory_Overweight_ReturnsOverweight()
        {
            BMI bmi = new BMI
            {
                WeightStones = 13,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 8
            };

            Assert.AreEqual(BMICategory.Overweight, bmi.BMICategory);
        }

        // Test Obese category
        [TestMethod]
        public void BMICategory_Obese_ReturnsObese()
        {
            BMI bmi = new BMI
            {
                WeightStones = 20,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 8
            };

            Assert.AreEqual(BMICategory.Obese, bmi.BMICategory);
        }

        // Test valid model values
        [TestMethod]
        public void BMI_ValidValues_PassesValidation()
        {
            BMI bmi = new BMI
            {
                WeightStones = 11,
                WeightPounds = 5,
                HeightFeet = 5,
                HeightInches = 10
            };

            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                bmi,
                new ValidationContext(bmi),
                validationResults,
                true
            );

            Assert.IsTrue(isValid);
        }

        // Test invalid weight in stones
        [TestMethod]
        public void BMI_InvalidWeightStones_FailsValidation()
        {
            BMI bmi = new BMI
            {
                WeightStones = 51,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 10
            };

            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                bmi,
                new ValidationContext(bmi),
                validationResults,
                true
            );

            Assert.IsFalse(isValid);
        }

        // Test invalid pounds
        [TestMethod]
        public void BMI_InvalidWeightPounds_FailsValidation()
        {
            BMI bmi = new BMI
            {
                WeightStones = 11,
                WeightPounds = 14,
                HeightFeet = 5,
                HeightInches = 10
            };

            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                bmi,
                new ValidationContext(bmi),
                validationResults,
                true
            );

            Assert.IsFalse(isValid);
        }

        // Test invalid height in feet
        [TestMethod]
        public void BMI_InvalidHeightFeet_FailsValidation()
        {
            BMI bmi = new BMI
            {
                WeightStones = 11,
                WeightPounds = 0,
                HeightFeet = 8,
                HeightInches = 0
            };

            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                bmi,
                new ValidationContext(bmi),
                validationResults,
                true
            );

            Assert.IsFalse(isValid);
        }

        // Test invalid height in inches
        [TestMethod]
        public void BMI_InvalidHeightInches_FailsValidation()
        {
            BMI bmi = new BMI
            {
                WeightStones = 11,
                WeightPounds = 0,
                HeightFeet = 5,
                HeightInches = 12
            };

            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(
                bmi,
                new ValidationContext(bmi),
                validationResults,
                true
            );

            Assert.IsFalse(isValid);
        }
    }
}
```
