using AStar.Core.Entity;

namespace AStar.Core.Internal
{
  // Для A*. Описывает клетку
  internal class Cage
  {
    public Cage()
    {
      parent = new Point { X = -1, Y = -1 };
    }

    public bool v; // false - проходима, true - нет
    public int g; // стоимость пути от начальной вершины
    public int h; // эвристическая оценки расстояния от рассматриваемой вершины к конечной
    public int f { get { return g + h; } } // эвристическая функция
    public Point parent;
  }
}
