///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Elementary Math Library.
//
// The MIT License (MIT)
// Copyright (c) 2014 Ibuprogames.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace MathLibrary.Elementary
{
  /// <summary>
  /// Matrix 4x4.
  /// </summary>
  public struct Matrix4
  {
    public double m11, m12, m13, m14,
                  m21, m22, m23, m24,
                  m31, m32, m33, m34,
                  m41, m42, m43, m44;

    public static Matrix4 Identity = new Matrix4(1.0, 0.0, 0.0, 0.0,
                                                 0.0, 1.0, 0.0, 0.0,
                                                 0.0, 0.0, 1.0, 0.0,
                                                 0.0, 0.0, 0.0, 1.0);

    /// <summary>
    /// Indexer.
    /// </summary>
    public double this[int index]
    {
      get
      {
        switch (index)
        {
          case 0: return m11;
          case 1: return m12;
          case 2: return m13;
          case 3: return m14;
          case 4: return m21;
          case 5: return m22;
          case 6: return m23;
          case 7: return m24;
          case 8: return m31;
          case 9: return m32;
          case 10: return m33;
          case 11: return m34;
          case 12: return m41;
          case 13: return m42;
          case 14: return m43;
          case 15: return m44;
        }
        
        throw new ArgumentOutOfRangeException();
      }

      set
      {
        switch (index)
        {
          case 0: m11 = value; break;
          case 1: m12 = value; break;
          case 2: m13 = value; break;
          case 3: m14 = value; break;
          case 4: m21 = value; break;
          case 5: m22 = value; break;
          case 6: m23 = value; break;
          case 7: m24 = value; break;
          case 8: m31 = value; break;
          case 9: m32 = value; break;
          case 10: m33 = value; break;
          case 11: m34 = value; break;
          case 12: m41 = value; break;
          case 13: m42 = value; break;
          case 14: m43 = value; break;
          case 15: m44 = value; break;
          
          default: throw new ArgumentOutOfRangeException();
        }
      }
    }

    /// <summary>
    /// Indexer.
    /// </summary>
    public double this[int row, int column]
    {
      get
      {
        return this[(row * 4) + column];
      }

      set
      {
        this[(row * 4) + column] = value;
      }
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public Matrix4(double m11, double m12, double m13, double m14,
                   double m21, double m22, double m23, double m24,
                   double m31, double m32, double m33, double m34,
                   double m41, double m42, double m43, double m44)
    {
      this.m11 = m11;
      this.m12 = m12;
      this.m13 = m13;
      this.m14 = m14;
      this.m21 = m21;
      this.m22 = m22;
      this.m23 = m23;
      this.m24 = m24;
      this.m31 = m31;
      this.m32 = m32;
      this.m33 = m33;
      this.m34 = m34;
      this.m41 = m41;
      this.m42 = m42;
      this.m43 = m43;
      this.m44 = m44;
    }

    /// <summary>
    /// Matrix + Matrix.
    /// </summary>
    public static Matrix4 Add(Matrix4 matrix1, Matrix4 matrix2)
    {
      matrix1.m11 += matrix2.m11;
      matrix1.m12 += matrix2.m12;
      matrix1.m13 += matrix2.m13;
      matrix1.m14 += matrix2.m14;
      matrix1.m21 += matrix2.m21;
      matrix1.m22 += matrix2.m22;
      matrix1.m23 += matrix2.m23;
      matrix1.m24 += matrix2.m24;
      matrix1.m31 += matrix2.m31;
      matrix1.m32 += matrix2.m32;
      matrix1.m33 += matrix2.m33;
      matrix1.m34 += matrix2.m34;
      matrix1.m41 += matrix2.m41;
      matrix1.m42 += matrix2.m42;
      matrix1.m43 += matrix2.m43;
      matrix1.m44 += matrix2.m44;

      return matrix1;
    }

    /// <summary>
    /// Matrix + Matrix.
    /// </summary>
    public static void Add(ref Matrix4 matrix1, ref Matrix4 matrix2, out Matrix4 result)
    {
      result.m11 = matrix1.m11 + matrix2.m11;
      result.m12 = matrix1.m12 + matrix2.m12;
      result.m13 = matrix1.m13 + matrix2.m13;
      result.m14 = matrix1.m14 + matrix2.m14;
      result.m21 = matrix1.m21 + matrix2.m21;
      result.m22 = matrix1.m22 + matrix2.m22;
      result.m23 = matrix1.m23 + matrix2.m23;
      result.m24 = matrix1.m24 + matrix2.m24;
      result.m31 = matrix1.m31 + matrix2.m31;
      result.m32 = matrix1.m32 + matrix2.m32;
      result.m33 = matrix1.m33 + matrix2.m33;
      result.m34 = matrix1.m34 + matrix2.m34;
      result.m41 = matrix1.m41 + matrix2.m41;
      result.m42 = matrix1.m42 + matrix2.m42;
      result.m43 = matrix1.m43 + matrix2.m43;
      result.m44 = matrix1.m44 + matrix2.m44;
    }

    /// <summary>
    /// Matrix * scalar.
    /// </summary>
    public static Matrix4 Multiply(Matrix4 matrix, double factor)
    {
      matrix.m11 *= factor;
      matrix.m12 *= factor;
      matrix.m13 *= factor;
      matrix.m14 *= factor;
      matrix.m21 *= factor;
      matrix.m22 *= factor;
      matrix.m23 *= factor;
      matrix.m24 *= factor;
      matrix.m31 *= factor;
      matrix.m32 *= factor;
      matrix.m33 *= factor;
      matrix.m34 *= factor;
      matrix.m41 *= factor;
      matrix.m42 *= factor;
      matrix.m43 *= factor;
      matrix.m44 *= factor;

      return matrix;
    }

    /// <summary>
    /// Matrix * scalar.
    /// </summary>
    public static void Multiply(ref Matrix4 matrix, double factor, out Matrix4 result)
    {
      result.m11 = matrix.m11 * factor;
      result.m12 = matrix.m12 * factor;
      result.m13 = matrix.m13 * factor;
      result.m14 = matrix.m14 * factor;
      result.m21 = matrix.m21 * factor;
      result.m22 = matrix.m22 * factor;
      result.m23 = matrix.m23 * factor;
      result.m24 = matrix.m24 * factor;
      result.m31 = matrix.m31 * factor;
      result.m32 = matrix.m32 * factor;
      result.m33 = matrix.m33 * factor;
      result.m34 = matrix.m34 * factor;
      result.m41 = matrix.m41 * factor;
      result.m42 = matrix.m42 * factor;
      result.m43 = matrix.m43 * factor;
      result.m44 = matrix.m44 * factor;
    }

    /// <summary>
    /// Matrix * Matrix.
    /// </summary>
    public static Matrix4 Multiply(Matrix4 matrix1, Matrix4 matrix2)
    {
      double m11 = (((matrix1.m11 * matrix2.m11) + (matrix1.m12 * matrix2.m21)) + (matrix1.m13 * matrix2.m31)) + (matrix1.m14 * matrix2.m41);
      double m12 = (((matrix1.m11 * matrix2.m12) + (matrix1.m12 * matrix2.m22)) + (matrix1.m13 * matrix2.m32)) + (matrix1.m14 * matrix2.m42);
      double m13 = (((matrix1.m11 * matrix2.m13) + (matrix1.m12 * matrix2.m23)) + (matrix1.m13 * matrix2.m33)) + (matrix1.m14 * matrix2.m43);
      double m14 = (((matrix1.m11 * matrix2.m14) + (matrix1.m12 * matrix2.m24)) + (matrix1.m13 * matrix2.m34)) + (matrix1.m14 * matrix2.m44);
      double m21 = (((matrix1.m21 * matrix2.m11) + (matrix1.m22 * matrix2.m21)) + (matrix1.m23 * matrix2.m31)) + (matrix1.m24 * matrix2.m41);
      double m22 = (((matrix1.m21 * matrix2.m12) + (matrix1.m22 * matrix2.m22)) + (matrix1.m23 * matrix2.m32)) + (matrix1.m24 * matrix2.m42);
      double m23 = (((matrix1.m21 * matrix2.m13) + (matrix1.m22 * matrix2.m23)) + (matrix1.m23 * matrix2.m33)) + (matrix1.m24 * matrix2.m43);
      double m24 = (((matrix1.m21 * matrix2.m14) + (matrix1.m22 * matrix2.m24)) + (matrix1.m23 * matrix2.m34)) + (matrix1.m24 * matrix2.m44);
      double m31 = (((matrix1.m31 * matrix2.m11) + (matrix1.m32 * matrix2.m21)) + (matrix1.m33 * matrix2.m31)) + (matrix1.m34 * matrix2.m41);
      double m32 = (((matrix1.m31 * matrix2.m12) + (matrix1.m32 * matrix2.m22)) + (matrix1.m33 * matrix2.m32)) + (matrix1.m34 * matrix2.m42);
      double m33 = (((matrix1.m31 * matrix2.m13) + (matrix1.m32 * matrix2.m23)) + (matrix1.m33 * matrix2.m33)) + (matrix1.m34 * matrix2.m43);
      double m34 = (((matrix1.m31 * matrix2.m14) + (matrix1.m32 * matrix2.m24)) + (matrix1.m33 * matrix2.m34)) + (matrix1.m34 * matrix2.m44);
      double m41 = (((matrix1.m41 * matrix2.m11) + (matrix1.m42 * matrix2.m21)) + (matrix1.m43 * matrix2.m31)) + (matrix1.m44 * matrix2.m41);
      double m42 = (((matrix1.m41 * matrix2.m12) + (matrix1.m42 * matrix2.m22)) + (matrix1.m43 * matrix2.m32)) + (matrix1.m44 * matrix2.m42);
      double m43 = (((matrix1.m41 * matrix2.m13) + (matrix1.m42 * matrix2.m23)) + (matrix1.m43 * matrix2.m33)) + (matrix1.m44 * matrix2.m43);
      double m44 = (((matrix1.m41 * matrix2.m14) + (matrix1.m42 * matrix2.m24)) + (matrix1.m43 * matrix2.m34)) + (matrix1.m44 * matrix2.m44);

      matrix1.m11 = m11;
      matrix1.m12 = m12;
      matrix1.m13 = m13;
      matrix1.m14 = m14;
      matrix1.m21 = m21;
      matrix1.m22 = m22;
      matrix1.m23 = m23;
      matrix1.m24 = m24;
      matrix1.m31 = m31;
      matrix1.m32 = m32;
      matrix1.m33 = m33;
      matrix1.m34 = m34;
      matrix1.m41 = m41;
      matrix1.m42 = m42;
      matrix1.m43 = m43;
      matrix1.m44 = m44;

      return matrix1;
    }

    /// <summary>
    /// Matrix * Matrix.
    /// </summary>
    public static void Multiply(ref Matrix4 matrix1, ref Matrix4 matrix2, out Matrix4 result)
    {
      double m11 = (((matrix1.m11 * matrix2.m11) + (matrix1.m12 * matrix2.m21)) + (matrix1.m13 * matrix2.m31)) + (matrix1.m14 * matrix2.m41);
      double m12 = (((matrix1.m11 * matrix2.m12) + (matrix1.m12 * matrix2.m22)) + (matrix1.m13 * matrix2.m32)) + (matrix1.m14 * matrix2.m42);
      double m13 = (((matrix1.m11 * matrix2.m13) + (matrix1.m12 * matrix2.m23)) + (matrix1.m13 * matrix2.m33)) + (matrix1.m14 * matrix2.m43);
      double m14 = (((matrix1.m11 * matrix2.m14) + (matrix1.m12 * matrix2.m24)) + (matrix1.m13 * matrix2.m34)) + (matrix1.m14 * matrix2.m44);
      double m21 = (((matrix1.m21 * matrix2.m11) + (matrix1.m22 * matrix2.m21)) + (matrix1.m23 * matrix2.m31)) + (matrix1.m24 * matrix2.m41);
      double m22 = (((matrix1.m21 * matrix2.m12) + (matrix1.m22 * matrix2.m22)) + (matrix1.m23 * matrix2.m32)) + (matrix1.m24 * matrix2.m42);
      double m23 = (((matrix1.m21 * matrix2.m13) + (matrix1.m22 * matrix2.m23)) + (matrix1.m23 * matrix2.m33)) + (matrix1.m24 * matrix2.m43);
      double m24 = (((matrix1.m21 * matrix2.m14) + (matrix1.m22 * matrix2.m24)) + (matrix1.m23 * matrix2.m34)) + (matrix1.m24 * matrix2.m44);
      double m31 = (((matrix1.m31 * matrix2.m11) + (matrix1.m32 * matrix2.m21)) + (matrix1.m33 * matrix2.m31)) + (matrix1.m34 * matrix2.m41);
      double m32 = (((matrix1.m31 * matrix2.m12) + (matrix1.m32 * matrix2.m22)) + (matrix1.m33 * matrix2.m32)) + (matrix1.m34 * matrix2.m42);
      double m33 = (((matrix1.m31 * matrix2.m13) + (matrix1.m32 * matrix2.m23)) + (matrix1.m33 * matrix2.m33)) + (matrix1.m34 * matrix2.m43);
      double m34 = (((matrix1.m31 * matrix2.m14) + (matrix1.m32 * matrix2.m24)) + (matrix1.m33 * matrix2.m34)) + (matrix1.m34 * matrix2.m44);
      double m41 = (((matrix1.m41 * matrix2.m11) + (matrix1.m42 * matrix2.m21)) + (matrix1.m43 * matrix2.m31)) + (matrix1.m44 * matrix2.m41);
      double m42 = (((matrix1.m41 * matrix2.m12) + (matrix1.m42 * matrix2.m22)) + (matrix1.m43 * matrix2.m32)) + (matrix1.m44 * matrix2.m42);
      double m43 = (((matrix1.m41 * matrix2.m13) + (matrix1.m42 * matrix2.m23)) + (matrix1.m43 * matrix2.m33)) + (matrix1.m44 * matrix2.m43);
      double m44 = (((matrix1.m41 * matrix2.m14) + (matrix1.m42 * matrix2.m24)) + (matrix1.m43 * matrix2.m34)) + (matrix1.m44 * matrix2.m44);

      result.m11 = m11;
      result.m12 = m12;
      result.m13 = m13;
      result.m14 = m14;
      result.m21 = m21;
      result.m22 = m22;
      result.m23 = m23;
      result.m24 = m24;
      result.m31 = m31;
      result.m32 = m32;
      result.m33 = m33;
      result.m34 = m34;
      result.m41 = m41;
      result.m42 = m42;
      result.m43 = m43;
      result.m44 = m44;
    }

    /// <summary>
    /// Create a scale Matrix.
    /// </summary>
    public static void CreateScale(ref Vector3 scale, out Matrix4 result)
    {
      result.m11 = scale.x;
      result.m12 = 0.0;
      result.m13 = 0.0;
      result.m14 = 0.0;
      result.m21 = 0.0;
      result.m22 = scale.y;
      result.m23 = 0.0;
      result.m24 = 0.0;
      result.m31 = 0.0;
      result.m32 = 0.0;
      result.m33 = scale.z;
      result.m34 = 0.0;
      result.m41 = 0.0;
      result.m42 = 0.0;
      result.m43 = 0.0;
      result.m44 = 1.0;
    }

    public static Matrix4 CreateRotationX(double radians)
    {
      Matrix4 result = Identity;

      double val1 = Math.Cos(radians);
      double val2 = Math.Sin(radians);

      result.m22 = val1;
      result.m23 = val2;
      result.m32 = -val2;
      result.m33 = val1;

      return result;
    }

    public static Matrix4 CreateRotationY(double radians)
    {
      Matrix4 result = Identity;

      double val1 = Math.Cos(radians);
      double val2 = Math.Sin(radians);

      result.m11 = val1;
      result.m13 = -val2;
      result.m31 = val2;
      result.m33 = val1;

      return result;
    }

    public static Matrix4 CreateRotationZ(double radians)
    {
      Matrix4 result = Identity;

      double val1 = Math.Cos(radians);
      double val2 = Math.Sin(radians);

      result.m11 = val1;
      result.m12 = val2;
      result.m21 = -val2;
      result.m22 = val1;

      return result;
    }

    public static Matrix4 CreateTranslation(Vector3 position)
    {
      Matrix4 result = Identity;

      result.m41 = position.x;
      result.m42 = position.y;
      result.m43 = position.z;

      return result;
    }
  }
}
