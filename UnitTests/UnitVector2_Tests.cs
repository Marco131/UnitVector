using UnitVector;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UnitTests
{
    [TestClass]
    public class UnitVector2_Tests
    {
        #region Ctor
        [TestMethod]
        public void Ctor()
        {
            // Arrange
            UnitVector2 uVector2;

            // Act
            uVector2 = new UnitVector2();

            // Assert
            Assert.AreEqual(1, uVector2.X);
            Assert.AreEqual(0, uVector2.Y);
        }

        [TestMethod]
        public void Ctor_1()
        {
            // Arrange
            UnitVector2 uVector2;

            // Act
            uVector2 = new UnitVector2(1);

            // Assert
            Assert.AreEqual(1, uVector2.X);
            Assert.AreEqual(0, uVector2.Y);
        }

        [TestMethod]
        public void Ctor_5()
        {
            // Arrange
            UnitVector2 uVector2;

            // Act
            uVector2 = new UnitVector2(5);

            // Assert
            Assert.AreEqual(1, uVector2.X);
            Assert.AreEqual(0, uVector2.Y);
        }

        [TestMethod]
        public void Ctor_10()
        {
            // Arrange
            UnitVector2 uVector2;

            // Act
            uVector2 = new UnitVector2(10);

            // Assert
            Assert.AreEqual(1, uVector2.X);
            Assert.AreEqual(0, uVector2.Y);
        }

        [TestMethod]
        public void Ctor_1_0()
        {
            // Arrange
            UnitVector2 uVector2;

            // Act
            uVector2 = new UnitVector2(1, 0);

            // Assert
            Assert.AreEqual(1, uVector2.X);
            Assert.AreEqual(0, uVector2.Y);
        }

        [TestMethod]
        public void Ctor_3_4()
        {
            // Arrange
            UnitVector2 uVector2;

            // Act
            uVector2 = new UnitVector2(3, 4);

            // Assert
            Assert.AreEqual(0.6f, uVector2.X);
            Assert.AreEqual(0.8f, uVector2.Y);
        }

        [TestMethod]
        public void Ctor_Vector_1_0()
        {
            // Arrange
            UnitVector2 uVector2;
            Vector2 vector2 = new Vector2(1, 0);

            // Act
            uVector2 = new UnitVector2(vector2);

            // Assert
            Assert.AreEqual(1, uVector2.X);
            Assert.AreEqual(0, uVector2.Y);
        }

        [TestMethod]
        public void Ctor_Vector_3_4()
        {
            // Arrange
            UnitVector2 uVector2;
            Vector2 vector2 = new Vector2(3, 4);

            // Act
            uVector2 = new UnitVector2(vector2);

            // Assert
            Assert.AreEqual(0.6f, uVector2.X);
            Assert.AreEqual(0.8f, uVector2.Y);
        }
        #endregion

        #region Methods
        [TestMethod]
        public void ReverseX_1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(1, 0);

            // Act
            uVector2.ReverseX();

            // Assert
            Assert.AreEqual(-1, uVector2.X);
        }

        [TestMethod]
        public void ReverseX_m1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(-1, 0);

            // Act
            uVector2.ReverseX();

            // Assert
            Assert.AreEqual(1, uVector2.X);
        }

        [TestMethod]
        public void ReverseY_1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(0, 1);

            // Act
            uVector2.ReverseY();

            // Assert
            Assert.AreEqual(-1, uVector2.Y);
        }

        [TestMethod]
        public void ReverseY_m1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(0, -1);

            // Act
            uVector2.ReverseY();

            // Assert
            Assert.AreEqual(1, uVector2.Y);
        }

        [TestMethod]
        public void ReverseCoordinates_3_4()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(3, 4);

            // Act
            uVector2.ReverseCoordinates();

            // Assert
            Assert.AreEqual(-0.6f, uVector2.X);
            Assert.AreEqual(-0.8f, uVector2.Y);
        }

        [TestMethod]
        public void ReverseCoordinates_m3_4()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(-3, 4);

            // Act
            uVector2.ReverseCoordinates();

            // Assert
            Assert.AreEqual(0.6f, uVector2.X);
            Assert.AreEqual(-0.8f, uVector2.Y);
        }

        [TestMethod]
        public void ConvertToAngle_1_0()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(1, 0);

            // Act
            float angle = uVector2.ConvertToAngle();

            // Assert
            Assert.AreEqual(0, angle);
        }

        [TestMethod]
        public void ConvertToAngle_0_1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(0, 1);
            float expectedAngle = MathF.PI / 2f;

            // Act
            float angle = uVector2.ConvertToAngle();

            // Assert
            Assert.AreEqual(expectedAngle, angle, 0.1);
        }

        [TestMethod]
        public void ConvertToAngle_1_m1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(1, -1);
            float expectedAngle = 7 / 4f * MathF.PI;

            // Act
            float angle = uVector2.ConvertToAngle();

            // Assert
            Assert.AreEqual(expectedAngle, angle, 0.1);
        }

        [TestMethod]
        public void GetCurrentQuadrant_1_0()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(1, 0);

            // Act
            Quadrant2 quadrant = uVector2.GetCurrentQuadrant();

            // Assert
            Assert.AreEqual(Quadrant2.None, quadrant);
        }

        [TestMethod]
        public void GetCurrentQuadrant_1_m1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(1, -1);

            // Act
            Quadrant2 quadrant = uVector2.GetCurrentQuadrant();

            // Assert
            Assert.AreEqual(Quadrant2.I, quadrant);
        }

        [TestMethod]
        public void GetCurrentQuadrant_m1_m1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(-1, -1);

            // Act
            Quadrant2 quadrant = uVector2.GetCurrentQuadrant();

            // Assert
            Assert.AreEqual(Quadrant2.II, quadrant);
        }

        [TestMethod]
        public void GetCurrentQuadrant_m1_1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(-1, 1);

            // Act
            Quadrant2 quadrant = uVector2.GetCurrentQuadrant();

            // Assert
            Assert.AreEqual(Quadrant2.III, quadrant);
        }

        [TestMethod]
        public void GetCurrentQuadrant_1_1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(1, 1);

            // Act
            Quadrant2 quadrant = uVector2.GetCurrentQuadrant();

            // Assert
            Assert.AreEqual(Quadrant2.IV, quadrant);
        }

        [TestMethod]
        public void GetFromVector2_Vector2_10_0() 
        {
            // Arrange
            Vector2 vector2 = new Vector2(10, 0);
            UnitVector2 uVector2;

            // Act
            uVector2 = UnitVector2.GetFromVector2(vector2);

            // Assert
            Assert.AreEqual(1, uVector2.X);
            Assert.AreEqual(0, uVector2.Y);
        }

        [TestMethod]
        public void GetFromVector2_Vector2_3_4()
        {
            // Arrange
            Vector2 vector2 = new Vector2(3, 4);
            UnitVector2 uVector2;

            // Act
            uVector2 = UnitVector2.GetFromVector2(vector2);

            // Assert
            Assert.AreEqual(0.6f, uVector2.X);
            Assert.AreEqual(0.8f, uVector2.Y);
        }

        [TestMethod]
        public void GetFromAngle_0()
        {
            // Arrange
            UnitVector2 uVector2;

            // Act
            uVector2 = UnitVector2.GetFromAngle(0);

            // Assert
            Assert.AreEqual(1, uVector2.X);
            Assert.AreEqual(0, uVector2.Y);
        }

        [TestMethod]
        public void GetFromAngle_Pi()
        {
            // Arrange
            UnitVector2 uVector2;
            
            // Act
            uVector2 = UnitVector2.GetFromAngle(MathF.PI);

            // Assert
            Assert.AreEqual(-1, uVector2.X, 0.1);
            Assert.AreEqual(0, uVector2.Y, 0.1);
        }

        [TestMethod]
        public void GetFromAngle_7d4Pi()
        {
            // Arrange
            UnitVector2 uVector2;

            // Act
            uVector2 = UnitVector2.GetFromAngle(7/4f*MathF.PI);

            // Assert
            Assert.AreEqual(0.7f, uVector2.X, 0.1);
            Assert.AreEqual(-0.7f, uVector2.Y, 0.1);
        }

        [TestMethod]
        public void ConvertToVector2_1_0()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(1, 0);

            // Act
            Vector2 vector2 = uVector2.ConvertToVector2();
            
            // Assert
            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(0, vector2.Y);
        }

        [TestMethod]
        public void ConvertToVector2_m3_4()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(-3, 4);

            // Act
            Vector2 vector2 = uVector2.ConvertToVector2();

            // Assert
            Assert.AreEqual(-0.6f, vector2.X);
            Assert.AreEqual(0.8f, vector2.Y);
        }

        [TestMethod]
        public void Equals_null()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2();

            // Act
            bool areEqual = uVector2.Equals(null);

            // Assert
            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void Equals_Vector2()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2();

            // Act
            bool areEqual = uVector2.Equals(Vector2.Zero);

            // Assert
            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void Equals_1_0_0_1()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2();

            // Act
            bool areEqual = uVector2.Equals(new UnitVector2(0, 1));

            // Assert
            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void Equals_1_0_1_0()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2();

            // Act
            bool areEqual = uVector2.Equals(new UnitVector2());

            // Assert
            Assert.AreEqual(true, areEqual);
        }

        [TestMethod]
        public void GetHashCode_Different()
        {
            // Arrange
            UnitVector2 uVector2_1 = new UnitVector2(24, 7);
            UnitVector2 uVector2_2 = new UnitVector2(5, 15);

            // Act
            int hashCode1 = uVector2_1.GetHashCode();
            int hashCode2 = uVector2_2.GetHashCode();
            bool areEqual = hashCode1 == hashCode2;

            // Assert
            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void ToString_1_0()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2();

            // Act
            string result = uVector2.ToString();

            // Assert
            Assert.AreEqual("(1, 0)", result);
        }

        [TestMethod]
        public void ToString_3_4()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(3, 4);

            // Act
            string result = uVector2.ToString();

            // Assert
            Assert.AreEqual("(0.6, 0.8)", result);
        }

        [TestMethod]
        public void ToString_m3_m4()
        {
            // Arrange
            UnitVector2 uVector2 = new UnitVector2(-3, -4);

            // Act
            string result = uVector2.ToString();

            // Assert
            Assert.AreEqual("(-0.6, -0.8)", result);
        }
        #endregion

        #region Operators
        [TestMethod]
        public void EqualsOperator_0_1_0_1()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(0, 1);

            // Act
            bool areEqual = uV1 == uV2;

            // Assert
            Assert.AreEqual(true, areEqual);
        }

        [TestMethod]
        public void EqualsOperator_0_1_1_0()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(1, 0);

            // Act
            bool areEqual = uV1 == uV2;

            // Assert
            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void EqualsOperator_0_1_0_m1()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(0, -1);

            // Act
            bool areEqual = uV1 == uV2;

            // Assert
            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void NotEqualsOperator_0_1_0_1()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(0, 1);

            // Act
            bool areEqual = uV1 != uV2;

            // Assert
            Assert.AreEqual(false, areEqual);
        }

        [TestMethod]
        public void NotEqualsOperator_0_1_1_0()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(1, 0);

            // Act
            bool areEqual = uV1 != uV2;

            // Assert
            Assert.AreEqual(true, areEqual);
        }

        [TestMethod]
        public void NotEqualsOperator_0_1_0_m1()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(0, -1);

            // Act
            bool areEqual = uV1 != uV2;

            // Assert
            Assert.AreEqual(true, areEqual);
        }

        [TestMethod]
        public void PlusOperator_0_1_1_0()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(1, 0);

            // Act
            Vector2 resultVector = uV1 + uV2;

            // Assert
            Assert.AreEqual(1, resultVector.X);
            Assert.AreEqual(1, resultVector.Y);
        }

        [TestMethod]
        public void PlusOperator_0_1_0_m1()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(0, -1);

            // Act
            Vector2 resultVector = uV1 + uV2;

            // Assert
            Assert.AreEqual(0, resultVector.X);
            Assert.AreEqual(0, resultVector.Y);
        }

        [TestMethod]
        public void MinusOperator_0_1_1_0()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(1, 0);

            // Act
            Vector2 resultVector = uV1 - uV2;

            // Assert
            Assert.AreEqual(-1, resultVector.X);
            Assert.AreEqual(1, resultVector.Y);
        }

        [TestMethod]
        public void MinusOperator_0_1_0_1()
        {
            // Arrange
            UnitVector2 uV1 = new UnitVector2(0, 1);
            UnitVector2 uV2 = new UnitVector2(0, 1);

            // Act
            Vector2 resultVector = uV1 - uV2;

            // Assert
            Assert.AreEqual(0, resultVector.X);
            Assert.AreEqual(0, resultVector.Y);
        }

        [TestMethod]
        public void MultiplyOperator_5_0_1()
        {
            // Arrange
            int scalar = 5;
            UnitVector2 uVector2 = new UnitVector2(0, 1);

            // Act
            Vector2 resultVector = scalar * uVector2;

            // Assert
            Assert.AreEqual(0, resultVector.X);
            Assert.AreEqual(5, resultVector.Y);
        }

        [TestMethod]
        public void MultiplyOperator_5_1_0()
        {
            // Arrange
            int scalar = 5;
            UnitVector2 uVector2 = new UnitVector2(1, 0);

            // Act
            Vector2 resultVector = scalar * uVector2;

            // Assert
            Assert.AreEqual(5, resultVector.X);
            Assert.AreEqual(0, resultVector.Y);
        }

        [TestMethod]
        public void DivideOperator_5_0_1()
        {
            // Arrange
            int scalar = 5;
            UnitVector2 uVector2 = new UnitVector2(0, 1);

            // Act
            Vector2 resultVector = uVector2 / scalar;

            // Assert
            Assert.AreEqual(0, resultVector.X);
            Assert.AreEqual(1/5f, resultVector.Y);
        }

        [TestMethod]
        public void DivideOperator_5_1_0()
        {
            // Arrange
            int scalar = 5;
            UnitVector2 uVector2 = new UnitVector2(1, 0);

            // Act
            Vector2 resultVector = uVector2 / scalar;

            // Assert
            Assert.AreEqual(1/5f, resultVector.X);
            Assert.AreEqual(0, resultVector.Y);
        }
        #endregion
    }
}