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
  /// Quaternion.
  /// </summary>
  public struct Quaternion
  {
    public double x;

    public double y;

    public double z;

    public double w;

    public static Quaternion identity = new Quaternion(0, 0, 0, 1);

    public Quaternion(double x, double y, double z, double w)
    {
      this.x = x;
      this.y = y;
      this.z = z;
      this.w = w;
    }


    public Quaternion(Vector3 vector, double scalar)
    {
      this.x = vector.x;
      this.y = vector.y;
      this.z = vector.z;
      this.w = scalar;
    }

    public static Quaternion Multiply(Quaternion q1, Quaternion q2)
    {
      Quaternion quaternion;
      
      quaternion.x = ((q1.x * q2.w) + (q2.x * q1.w)) + (q1.y * q2.z) - (q1.z * q2.y);
      quaternion.y = ((q1.y * q2.w) + (q2.y * q1.w)) + (q1.z * q2.x) - (q1.x * q2.z);
      quaternion.z = ((q1.z * q2.w) + (q2.z * q1.w)) + (q1.x * q2.y) - (q1.y * q2.x);
      quaternion.w = (q1.w * q2.w) - ((q1.x * q2.x) + (q1.y * q2.y)) + (q1.z * q2.z);

      return quaternion;
    }

    public static Quaternion Conjugate(Quaternion q)
    {
      Quaternion quaternion;

      quaternion.x = -q.x;
      quaternion.y = -q.y;
      quaternion.z = -q.z;
      quaternion.w = q.w;

      return quaternion;
    }

    public static Quaternion Inverse(Quaternion q)
    {
      Quaternion quaternion;

      double num = 1.0 / ((((q.x * q.x) + (q.y * q.y)) + (q.z * q.z)) + (q.w * q.w));
      quaternion.x = -q.x * num;
      quaternion.y = -q.y * num;
      quaternion.z = -q.z * num;
      quaternion.w = q.w * num;

      return quaternion;
    }

    public static Quaternion FromAxisAngle(Vector3 axis, double angle)
    {
      Quaternion quaternion;

      double halfAngle = angle * 0.5;
      double sin = Math.Sin(halfAngle);

      quaternion.x = axis.x * sin;
      quaternion.y = axis.y * sin;
      quaternion.z = axis.z * sin;
      quaternion.w = Math.Cos(halfAngle);

      return quaternion;
    }

    public static Quaternion FromYawPitchRoll(double yaw, double pitch, double roll)
    {
      Quaternion quaternion;

      double halfRoll = roll * 0.5;
      double halfPitch = pitch * 0.5;
      double halfYaw = yaw * 0.5;

      double sinRoll = Math.Sin(halfRoll);
      double cosRoll = Math.Cos(halfRoll);
      double sinPitch = Math.Sin(halfPitch);
      double cosPitch = Math.Cos(halfPitch);
      double sinYaw = Math.Sin(halfYaw);
      double cosYaw = Math.Cos(halfYaw);

      quaternion.x = ((cosYaw * sinPitch) * cosRoll) + ((sinYaw * cosPitch) * sinRoll);
      quaternion.y = ((sinYaw * cosPitch) * cosRoll) - ((cosYaw * sinPitch) * sinRoll);
      quaternion.z = ((cosYaw * cosPitch) * sinRoll) - ((sinYaw * sinPitch) * cosRoll);
      quaternion.w = ((cosYaw * cosPitch) * cosRoll) + ((sinYaw * sinPitch) * sinRoll);

      return quaternion;
    }

    public static Quaternion Lerp(Quaternion q1, Quaternion q2, float t)
    {
      double oneMinusT = 1 - t;

      Quaternion quaternion = new Quaternion();
      if ((((q1.x * q2.x) + (q1.y * q2.y)) + (q1.z * q2.z)) + (q1.w * q2.w) >= 0)
      {
        quaternion.x = (oneMinusT * q1.x) + (t * q2.x);
        quaternion.y = (oneMinusT * q1.y) + (t * q2.y);
        quaternion.z = (oneMinusT * q1.z) + (t * q2.z);
        quaternion.w = (oneMinusT * q1.w) + (t * q2.w);
      }
      else
      {
        quaternion.x = (oneMinusT * q1.x) - (t * q2.x);
        quaternion.y = (oneMinusT * q1.y) - (t * q2.y);
        quaternion.z = (oneMinusT * q1.z) - (t * q2.z);
        quaternion.w = (oneMinusT * q1.w) - (t * q2.w);
      }
      
      double invLength = 1 / quaternion.Length();
      quaternion.x *= invLength;
      quaternion.y *= invLength;
      quaternion.z *= invLength;
      quaternion.z *= invLength;

      return quaternion;
    }

    public static Quaternion Slerp(Quaternion q1, Quaternion q2, float t)
    {
      double k;
      double m;
      Quaternion quaternion;

      double diff = (((q1.x * q2.x) + (q1.y * q2.y)) + (q1.z * q2.z)) + (q1.w * q2.w);
      bool flag = false;
      if (diff < 0)
      {
        flag = true;
        diff = -diff;
      }
      else if (diff > 0.999999)
      {
        m = 1 - t;
        k = flag ? -t : t;
      }
      else
      {
        double cosDiff = Math.Acos(diff);
        double invCosDiff = 1 / Math.Sin(cosDiff);
        
        m = Math.Sin((1 - t) * cosDiff) * invCosDiff;
        k = flag ? -Math.Sin(t * cosDiff) * invCosDiff : Math.Sin(t * cosDiff) * invCosDiff;
      }

      quaternion.x = (m * q1.x) + (k * q2.x);
      quaternion.y = (m * q1.y) + (k * q2.y);
      quaternion.z = (m * q1.z) + (k * q2.z);
      quaternion.w = (m * q1.w) + (k * q2.w);

      return quaternion;
    }

    public double Length()
    {
      return Math.Sqrt((((x * x) + (y * y)) + (z * z)) + (w * w));
    }

    public double LengthSquared()
    {
      return (((x * x) + (y * y)) + (z * z)) + (w * w);
    }
  }
}
