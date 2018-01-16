using System;
using System.Collections.Generic;
using AStar.Core.Entity;
using AStar.Core.Internal;

namespace AStar.Core
{
  // Алгоритм A* поиска кратчайшего пути на карте
  public static class AStarWorker
  {
    private static Cage[,] _field; // Внутреннее представление поля для алгоритма
    private static List<Point> _finalPath;
    private static PriorityQueue<Point> _open;
    private static PriorityQueue<Point> _close;
    private static Point _begin;
    private static Point _end;

    public static List<Point> Start(int[,] matrix, int rowsAmount, int columnsAmount, Point startPoint, Point finishPoint)
    {
      _finalPath = new List<Point>();
      if (matrix[finishPoint.X, finishPoint.Y] != 0)
      {
        return _finalPath;
      }

      _open = new PriorityQueue<Point>(new CompareRule<Point>(CompareCoord));
      _close = new PriorityQueue<Point>(new CompareRule<Point>(CompareCoord));
      _begin = startPoint;
      _end = finishPoint;

      _field = new Cage[rowsAmount, columnsAmount];
      for (int i = 0; i < rowsAmount; i++)
      {
        for (int j = 0; j < columnsAmount; j++)
        {
          _field[i, j] = new Cage { v = matrix[i, j] != 0 };
        }
      }

      _open.Add(startPoint);
      while (!_open.Empty())
      {
        var curr = _open.Pop();
        _close.Add(curr);

        Point adj;
        if (curr.X != 0)
        {
          adj = new Point { X = curr.X - 1, Y = curr.Y };
          if (ProcAdj(curr, adj))
          {
            break;
          }
        }
        if (curr.X != rowsAmount - 1)
        {
          adj = new Point { X = curr.X + 1, Y = curr.Y };
          if (ProcAdj(curr, adj))
          {
            break;
          }
        }
        if (curr.Y != 0)
        {
          adj = new Point { X = curr.X, Y = curr.Y - 1 };
          if (ProcAdj(curr, adj))
          {
            break;
          }
        }
        if (curr.Y != columnsAmount - 1)
        {
          adj = new Point { X = curr.X, Y = curr.Y + 1 };
          if (ProcAdj(curr, adj))
          {
            break;
          }
        }
      }

      _finalPath.Reverse();

      return _finalPath;
    }

    // Исследование смежной вершины adj вершине curr
    static bool ProcAdj(Point curr, Point adj)
    {
      if (!_field[adj.X, adj.Y].v && !_close.Find(adj))
      {
        if (!_open.Find(adj))
        {
          _field[adj.X, adj.Y].g = _field[curr.X, curr.Y].g + 10;
          _field[adj.X, adj.Y].h = GetH(adj);
          _field[adj.X, adj.Y].parent = curr;
          _open.Add(adj);

          if (adj.Equals(_end))
          {
            Point tmp = _end;
            _finalPath.Add(tmp);
            do
            {
              tmp = _field[tmp.X, tmp.Y].parent;
              _finalPath.Add(tmp);
            } while (tmp != _begin);

            return true;
          }
        }
        else
        {
          if (_field[curr.X, curr.Y].g + 10 < _field[adj.X, adj.Y].g)
          {
            _field[adj.X, adj.Y].g = _field[curr.X, curr.Y].g + 10;
            _field[adj.X, adj.Y].parent = curr;

            _open.Update(adj);
          }
        }
      }

      return false;
    }

    // Правило сравнения двух клеток
    static int CompareCoord(Point p1, Point p2)
    {
      if (_field[p1.X, p1.Y].f > _field[p2.X, p2.Y].f)
      {
        return -1;
      }

      if (_field[p1.X, p1.Y].f == _field[p2.X, p2.Y].f)
      {
        return 0;
      }

      return 1;
    }

    static int GetH(Point curr)
    {
      return (Math.Abs(curr.X - _end.X) + Math.Abs(curr.Y - _end.Y)) * 10;
    }
  }
}
