using System;

namespace AStar.Core.Entity
{
  // Для A*. Описывает координаты клетки
  public class Point
  {
    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(Object obj)
    {
      Point p = obj as Point;
      return X == p.X && Y == p.Y;
    }
  }
}
