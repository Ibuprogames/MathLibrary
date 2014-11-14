///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Math Library.
// Ibuprogames. MIT License.
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
    /// Constructor.
    /// </summary>
    public Vector2(double value)
    {
      this.x = this.y = value;
    }

    public static void Test()
    {
      Vector2 v1, v2;
    }
  }
}
