using System;
using NUnit.Framework;
using ModelParameters;


namespace OrsaprBed.UnitTests
{
	// TODO: XML
	[TestFixture]
    public class ParameterTests
    {
        [TestCase(TestName = "Позитивный метод для NameParameter, производится ввод и считывание " +
                             "параметров ")]
        public void NameParameter_GoodName_ReturnsSameName()
        {
            // Setup
            var parameter = new Parameter();
            var sourceName = "Name";
            var expectedName = sourceName;

            // Act
            parameter.NameParameter = sourceName;
            var actualName = parameter.NameParameter;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(TestName = "Позитивный метод для Value, производится ввод и считывание " +
                             "параметров ")]
        public void Value_GoodValue_ReturnsSameValue()
        {
            // Setup
            var parameter = new Parameter("Width", 10, 60, 50);
            var sourceValue = 50.5;
            var expectedValue = sourceValue;

            // Act
            parameter.Value = sourceValue;
            var actualValue = parameter.Value;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(9.5, TestName = "Позитивный метод для Value, производится ввод и считывание " +
                                  "параметров ")]
        [TestCase(60.5, TestName = "Позитивный метод для Value, производится ввод и считывание " +
                                   "параметров ")]
        public void Value_BadValue_ThrowsException(double sourceValue)
        {
            // Setup
            var parameter = new Parameter("Width", 10, 60, 50);

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.Value = sourceValue;
            }
            );
        }

        [TestCase("", TestName = "Позитивный метод для Value, производится ввод и считывание " +
                                 "параметров ")]
        [TestCase("width", TestName = "Позитивный метод для Value, производится ввод и считывание " +
                                      "параметров ")]
        public void Value_EmptyNameParameter_ThrowsException(string sourceName)
        {
            // Setup
            var parameter = new Parameter();
            parameter.NameParameter = sourceName;
            var sourceValue = 5;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.Value = sourceValue;
            }
            );
        }

        [TestCase(TestName = "Позитивный метод для MaxValue, производится ввод и считывание \" +\r\n                             \"параметров"
                                      )]
        public void Value_EmptyMaxParameter_ThrowsException()
        {
            // Setup
            var parameter = new Parameter();
            parameter.NameParameter = "Test Parameter";
            var sourceValue = 5;
            parameter.MinimumValue = 2;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.Value = sourceValue;
            }
            );
        }

        [TestCase(TestName = "Позитивный метод для MinValue, производится ввод и считывание \" +\r\n                             \"параметров")]
        public void Value_EmptyMinParameter_ThrowsException()
        {
            // Setup
            var parameter = new Parameter();
            parameter.NameParameter = "Test Parameter";
            var sourceValue = 5;
            parameter.MaximumValue = 10;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.Value = sourceValue;
            }
            );
        }

        [TestCase(0, 50, TestName = "Позитивный метод для MaxValue и MinValue, производится ввод и считывание " +
                                    "параметров ")]
        [TestCase(4, 50, TestName = "Позитивный метод для MaxValue и MinValue, производится ввод и считывание " +
                                    "параметров ")]
        public void MaximumValue_GoodMaximumValue_ReturnsSameMaximumValue(double sourceMinimumValue,
            double sourceMaximumValue)
        {
            // Setup
            var parameter = new Parameter();
            parameter.NameParameter = "width";
            if (sourceMinimumValue > 0)
            {
                parameter.MinimumValue = sourceMinimumValue;
            }
            var expectedMaximumValue = sourceMaximumValue;

            // Act
            parameter.MaximumValue = sourceMaximumValue;
            var actualMaximumValue = parameter.MaximumValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedMaximumValue, actualMaximumValue);
        }

        [TestCase(100, 50, TestName = "Позитивный метод для MaxValue и MinValue, производится ввод и считывание " +
                                      "параметров ")]
        [TestCase(0, -1, TestName = "Позитивный метод для MaxValue и MinValue, производится ввод и считывание " +
                                    "параметров ")]
        public void MaximumValue_MaximumValueBad_ThrowsException(double sourceMinimumValue,
            double sourceMaximumValue)
        {
            // Setup
            var parameter = new Parameter();
            parameter.NameParameter = "width";
            if (sourceMinimumValue > 0)
            {
                parameter.MinimumValue = sourceMinimumValue;
            }

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.MaximumValue = sourceMaximumValue;
            }
            );
        }

        [TestCase(50, 0, TestName = "Позитивный метод для MaxValue и MinValue, производится ввод и считывание " +
                                    "параметров ")]
        [TestCase(20, 50, TestName = "Позитивный метод для MaxValue и MinValue, производится ввод и считывание " +
                                     "параметров ")]
        public void MinimumValue_GoodMinimumValue_ReturnsSameMinimumValue(double sourceMinimumValue,
            double sourceMaximumValue)
        {
            // Setup
            var parameter = new Parameter();
            parameter.NameParameter = "width";
            if (sourceMaximumValue > 0)
            {
                parameter.MaximumValue = sourceMaximumValue;
            }
            var expectedMinimumValue = sourceMinimumValue;

            // Act
            parameter.MinimumValue = sourceMinimumValue;
            var actualMinimumValue = parameter.MinimumValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedMinimumValue, actualMinimumValue);
        }

        [TestCase(100, 50, TestName = "Позитивный метод для MaxValue и MinValue, производится ввод и считывание " +
                                      "параметров ")]
        [TestCase(-1, 0, TestName = "Позитивный метод для MaxValue и MinValue, производится ввод и считывание " +
                                    "параметров ")]
        public void MinimumValue_MinimumValueBad_ThrowsException(double sourceMinimumValue,
            double sourceMaximumValue)
        {
            // Setup
            var parameter = new Parameter();
            parameter.NameParameter = "width";
            if (sourceMaximumValue > 0)
            {
                parameter.MaximumValue = sourceMaximumValue;
            }

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.MinimumValue = sourceMinimumValue;
            }
            );
        }


     
        [TestCase(20, TestName = "Позитивный метод для DefaultValue, производится ввод и считывание " +
                                 "параметров ")]
        [TestCase(0.5, TestName = "Позитивный метод для DefaultValue, производится ввод и считывание " +
                                  "параметров ")]
        public void DefaultValue_BadDefaultValue_ThrowsException(double sourceDefaultValue)
        {
            // Setup
            var parameter = new Parameter();

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.DefaultValue = sourceDefaultValue;
            }
            );
        }

        [TestCase(TestName = "Позитивный метод для DefaultValue, MaxValue и MinValue производится ввод и считывание " +
                             "параметров ")]
        public void DefaultValue_EmptyMaximumAndMinimumValue_ThrowsException()
        {
            var parameter = new Parameter();
            parameter.NameParameter = "Width";
            var sourceDefaultValue = 5;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.DefaultValue = sourceDefaultValue;
            }
            );
        }

        [TestCase(TestName = "Позитивный метод для DefaultValue, MaxValue, производится ввод и считывание " +
                             "параметров ")]
        public void DefaultValue_EmptyMaxParameter_ThrowsException()
        {
            // Setup
            var parameter = new Parameter();
            parameter.NameParameter = "";
            var sourceValue = 5;
            parameter.MinimumValue = 2;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.DefaultValue = sourceValue;
            }
            );
        }

        [TestCase(TestName = "Позитивный метод для DefaultValue, MinValue, производится ввод и считывание " +
                             "параметров ")]
        public void DefaultValue_EmptyMinParameter_ThrowsException()
        {
            // Setup
            var parameter = new Parameter();
            parameter.NameParameter ="Name";
            var sourceValue = 5;
            parameter.MaximumValue = 10;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.DefaultValue = sourceValue;
            }
            );
        }
    }
}