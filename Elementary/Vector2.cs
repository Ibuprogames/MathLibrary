﻿///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
  /// Two-dimensional vector.
  /// </summary>
  public struct Vector2
  {
    /// <summary>
    /// Components.
    /// </summary>
    public double x, y;

    /// <summary>
    /// Constructor.
    /// </summary>
    public Vector2(double x, double y)
    {
      this.x = x;
      this.y = y;
    }

    /// <summary>
    /// Opposite operator.
    /// </summary>
    public static Vector2 operator -(Vector2 v)
    {
      v.y = -v.x;
      v.y = -v.y;

      return v;
    }

    /// <summary>
    /// Addition operator.
    /// </summary>
    public static Vector2 operator +(Vector2 v1, Vector2 v2)
    {
      v1.x += v2.x;
      v1.y += v2.y;

      return v1;
    }

    /// <summary>
    /// Subtraction operator.
    /// </summary>
    public static Vector2 operator -(Vector2 v1, Vector2 v2)
    {
      v1.x -= v2.x;
      v1.y -= v2.y;

      return v1;
    }

    /// <summary>
    /// Scalar multiplier operator.
    /// </summary>
    public static Vector2 operator *(Vector2 v, double scalar)
    {
      v.x *= scalar;
      v.y *= scalar;

      return v;
    }

    /// <summary>
    /// Scalar multiplier operator.
    /// </summary>
    public static Vector2 operator *(double scalar, Vector2 v)
    {
      v.x *= scalar;
      v.y *= scalar;

      return v;
    }

    /// <summary>
    /// Scalar divider operator.
    /// </summary>
    public static Vector2 operator /(Vector2 v, double scalar)
    {
      double factor = 1.0 / scalar;

      v.x *= factor;
      v.y *= factor;

      return v;
    }

    /// <summary>
    /// Returns the length of the vector.
    /// </summary>
    public double Length()
    {
      return Math.Sqrt((x * x) + (y * y));
    }

    /// <summary>
    /// Returns the squared length of the vector.
    /// </summary>
    public double LengthSquared()
    {
      return (x * x) + (y * y);
    }

    /// <summary>
    /// Normalizes the vector.
    /// </summary>
    public void Normalize()
    {
      double value = 1.0 / Math.Sqrt((x * x) + (y * y));

      x *= value;
      y *= value;
    }

    /// <summary>
    /// Dot product.
    /// </summary>
    public static double Dot(Vector2 v1, Vector2 v2)
    {
      return (v1.x * v2.x) + (v1.y * v2.y);
    }
  }
}
