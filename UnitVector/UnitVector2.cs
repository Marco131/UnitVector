/*
 * Class that describes a Unit vector of two dimensions (x, y)
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UnitVector
{
    public class UnitVector2
    {
        // Constants
        public static readonly UnitVector2 LEFT = new UnitVector2(-1, 0);
        public static readonly UnitVector2 RIGHT = new UnitVector2(1, 0);
        public static readonly UnitVector2 UP = new UnitVector2(0, -1);
        public static readonly UnitVector2 DOWN = new UnitVector2(0, 1);

        public static readonly UnitVector2 LEFT_UP = new UnitVector2(-1, -1);
        public static readonly UnitVector2 LEFT_DOWN = new UnitVector2(-1, 1);
        public static readonly UnitVector2 RIGHT_UP = new UnitVector2(1, -1);
        public static readonly UnitVector2 RIGHT_DOWN = new UnitVector2(1, 1);


        // Field
        private float _x;
        private float _y;


        // Properties
        public float X { get => _x; set => _x = value; }
        public float Y { get => _y; set => _y = value; }


        // Ctor
        public UnitVector2(Vector2 vector2) : this(vector2.X, vector2.Y) {}
        public UnitVector2() : this(1){}
        public UnitVector2(float x) : this(x, 0) {}
        public UnitVector2(float x, float y)
        {
            // if the vector is not a zero vector
            if (x != 0 || y != 0)
            {
                // get the norm of the vector (x^2 + y^2)^0.5
                float norm = MathF.Sqrt(MathF.Pow(x, 2) + MathF.Pow(y, 2));
                
                this.X = x / norm;
                this.Y = y / norm;
            }
            else
            {
                throw new Exception("The Vector2 can't be a zero vector");
            }
        }


        // Methods
        /// <summary>
        /// Reverses the X coordinate of the Vector
        /// </summary>
        public void ReverseX()
        {
            this.X = -this.X;
        }

        /// <summary>
        /// Reverses the Y coordinate of the Vector
        /// </summary>
        public void ReverseY()
        {
            this.Y = -this.Y;
        }

        /// <summary>
        /// Reverses the coordinates of the Vector
        /// </summary>
        public void ReverseCoordinates()
        {
            this.X = -this.X;
            this.Y = -this.Y;
        }

        /// <summary>
        /// Gets the current quadrant (2d)
        /// </summary>
        /// <returns>current Quadrant (2d)</returns>
        public Quadrant2 GetCurrentQuadrant()
        {
            if (X > 0 && Y < 0) // + +
            {
                return Quadrant2.I;
            }
            else if (X < 0 && Y < 0) // - + 
            {
                return Quadrant2.II;
            }
            else if (X < 0 && Y > 0) // - -
            {
                return Quadrant2.III;
            }
            else if (X > 0 && Y > 0) // + -
            {
                return Quadrant2.IV;
            }
            else // X == 0 || Y == 0 (between quadrants)
            {
                return Quadrant2.None;
            }
        }

        /// <summary>
        /// Gets a UnitVector2 from a Vector2
        /// </summary>
        /// <param name="vector2"></param>
        /// <returns>UnitVector2</returns>
        /// <exception cref="Exception"></exception>
        public static UnitVector2 GetFromVector2(Vector2 vector2)
        {
            return new UnitVector2(vector2);
        }

        /// <summary>
        /// Gets an UnitVector2 from an angle
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>UnitVector2</returns>
        public static UnitVector2 GetFromAngle(float angle)
        {
            float x = MathF.Cos(angle);
            float y = MathF.Sin(angle);

            return new UnitVector2(x, y);
        }

        /// <summary>
        /// Converts to an angle (radian)
        /// </summary>
        /// <returns>Angle in radians</returns>
        public float ConvertToAngle()
        {
            float reversedY = -Y; // the y axis used for these methods goes the opposite way

            float angle = MathF.Atan2(reversedY, X);

            if (reversedY < 0)
            {
                angle = 2 * MathF.PI + angle;
            }

            return angle;
        }

        /// <summary>
        /// Converts to Vector2
        /// </summary>
        /// <returns>UnitVector2 converted to Vector2</returns>
        public Vector2 ConvertToVector2()
        {
            return ConvertToVector2(this);
        }

        /// <summary>
        /// Converts UnitVector2 to Vector2
        /// </summary>
        /// <returns>UnitVector2 converted to Vector2</returns>
        public static Vector2 ConvertToVector2(UnitVector2 uVector2)
        {
            return new Vector2(uVector2.X, uVector2.Y);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is null))
            {
                if (obj is UnitVector2)
                {
                    UnitVector2 uVecObj = obj as UnitVector2;
                    if (uVecObj.X == this.X &&
                        uVecObj.Y == this.Y
                        )
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ this.Y.GetHashCode(); 
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y})";
        }


        // Operators
        public static implicit operator Vector2(UnitVector2 uVector)
        {
            return new Vector2(uVector.X, uVector.Y);
        }

        public static bool operator ==(UnitVector2 uVector1, UnitVector2 uVector2)
        {
            return (
                uVector1.X == uVector2.X &&
                uVector1.Y == uVector2.Y
                );
        }

        public static bool operator !=(UnitVector2 uVector1, UnitVector2 uVector2)
        {
            return (
                uVector1.X != uVector2.X ||
                uVector1.Y != uVector2.Y
                );
        }

        public static Vector2 operator +(UnitVector2 unitVector1, UnitVector2 unitVector2)
        {
            return new Vector2(
                unitVector1.X + unitVector2.X,
                unitVector1.Y + unitVector2.Y
                );
        }

        public static Vector2 operator -(UnitVector2 unitVector1, UnitVector2 unitVector2)
        {
            return new Vector2(
                unitVector1.X - unitVector2.X,
                unitVector1.Y - unitVector2.Y
                );
        }

        public static Vector2 operator *(float scalar, UnitVector2 unitVector)
        {
            return new Vector2(
                unitVector.X * scalar,
                unitVector.Y * scalar
                );
        }

        public static Vector2 operator /(UnitVector2 unitVector, float scalar)
        {
            return new Vector2(
                unitVector.X / scalar,
                unitVector.Y / scalar
                );
        }
    }
}