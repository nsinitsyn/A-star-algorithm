using System.Collections.Generic;

namespace AStar.Core.Internal
{
  // Делегат описывает правила сравнения. Возвращает -1 - меньше; 0 - равно; 1 - больше
  internal delegate int CompareRule<T>(T elem1, T elem2);

  // Очередь с приоритетами на основе двоичной кучи
  internal class PriorityQueue<T>
  {
    private CompareRule<T> _compare;
    private List<T> _maxHeap;

    public PriorityQueue(CompareRule<T> compareRule)
    {
      _maxHeap = new List<T>();
      _compare = compareRule;
    }

    public void Add(T elem)
    {
      // Вставка в конец списка
      _maxHeap.Add(elem);

      // Поднятие элемента
      int i = _maxHeap.Count - 1;
      int parent = (i - 1) / 2;

      T tmp;
      while (i > 0 && _compare(_maxHeap[parent], _maxHeap[i]) < 0)
      {
        tmp = _maxHeap[i];
        _maxHeap[i] = _maxHeap[parent];
        _maxHeap[parent] = tmp;

        i = parent;
        parent = (i - 1) / 2;
      }
    }

    public T Top()
    {
      return _maxHeap[0];
    }

    public T Pop()
    {
      T elemRet = _maxHeap[0];

      _maxHeap[0] = _maxHeap[_maxHeap.Count - 1];
      _maxHeap.RemoveAt(_maxHeap.Count - 1);

      Heapify(0);

      return elemRet;
    }

    public bool Empty()
    {
      return _maxHeap.Count == 0;
    }

    public bool Find(T elem)
    {
      bool d = _maxHeap.Contains(elem);

      var result = _maxHeap.Contains(elem);
      return result;
    }

    public void Update(T elem)
    {
      int i = _maxHeap.IndexOf(elem);
      if (i != -1)
      {
        Heapify(i);

        T tmp;
        while (i > 0 && _compare(_maxHeap[(i - 1) / 2], _maxHeap[i]) < 0)
        {
          tmp = _maxHeap[i];
          _maxHeap[i] = _maxHeap[(i - 1) / 2];
          _maxHeap[(i - 1) / 2] = tmp;

          i = (i - 1) / 2;
        }
      }
    }

    // Восстановление свойства кучи
    private void Heapify(int i)
    {
      int left = 2 * i + 1;
      int right = 2 * i + 2;

      int largest = i;
      if (left < _maxHeap.Count && _compare(_maxHeap[left], _maxHeap[i]) > 0)
      {
        largest = left;
      }

      if (right < _maxHeap.Count && _compare(_maxHeap[right], _maxHeap[largest]) > 0)
      {
        largest = right;
      }

      T tmp;
      if (largest != i)
      {
        tmp = _maxHeap[i];
        _maxHeap[i] = _maxHeap[largest];
        _maxHeap[largest] = tmp;

        Heapify(largest);
      }
    }
  }
}
