using AStar.Core;
using AStar.Core.Entity;
using NUnit.Framework;
using System.Collections.Generic;

namespace AStar.Tests
{
  [TestFixture]
  public class Tests
  {
    [Test]
    public void SmallField_ResultListFound()
    {
      // Arrange
      const int rowsAmount = 3;
      const int columnsAmount = 3;

      var startPoint = new Point { X = 0, Y = 2 };
      var finishPoint = new Point { X = 2, Y = 2 };

      int[,] field =
      {
        /*  X↓   Y→  0  1  2 */
        /*  0 */   { 0, 0, 0 },
        /*  1 */   { 0, 0, 1 },
        /*  2 */   { 0, 0, 0 }
      };

      var pathExpected = new List<Point>
      {
        new Point { X = 0, Y = 2 },
        new Point { X = 0, Y = 1 },
        new Point { X = 1, Y = 1 },
        new Point { X = 2, Y = 1 },
        new Point { X = 2, Y = 2 }
      };

      // Act
      var path = AStarWorker.Start(field, rowsAmount, columnsAmount, startPoint, finishPoint);

      // Assert
      CollectionAssert.AreEqual(pathExpected, path);
    }

    [Test]
    public void MediumField_ResultListFound()
    {
      // Arrange
      const int rowsAmount = 6;
      const int columnsAmount = 5;

      var startPoint = new Point { X = 0, Y = 0 };
      var finishPoint = new Point { X = 4, Y = 4 };

      int[,] field =
      {
        /*  X↓   Y→  0  1  2  3  4 */
        /*  0 */   { 0, 1, 0, 0, 0 },
        /*  1 */   { 0, 1, 0, 1, 0 },
        /*  2 */   { 0, 1, 0, 1, 0 },
        /*  3 */   { 0, 1, 0, 1, 0 },
        /*  4 */   { 0, 0, 0, 1, 0 },
        /*  5 */   { 0, 0, 0, 0, 0 }
      };

      var pathExpected = new List<Point>
      {
        new Point { X = 0, Y = 0 },
        new Point { X = 1, Y = 0 },
        new Point { X = 2, Y = 0 },
        new Point { X = 3, Y = 0 },
        new Point { X = 4, Y = 0 },
        new Point { X = 4, Y = 1 },
        new Point { X = 4, Y = 2 },
        new Point { X = 5, Y = 2 },
        new Point { X = 5, Y = 3 },
        new Point { X = 5, Y = 4 },
        new Point { X = 4, Y = 4 }
      };

      // Act
      var path = AStarWorker.Start(field, rowsAmount, columnsAmount, startPoint, finishPoint);

      // Assert
      CollectionAssert.AreEqual(pathExpected, path);
    }

    [Test]
    public void LargeField_ResultListFound()
    {
      // Arrange
      const int rowsAmount = 12;
      const int columnsAmount = 12;

      var startPoint = new Point { X = 2, Y = 0 };
      var finishPoint = new Point { X = 1, Y = 11 };

      int[,] field =
      {
       /*  X↓   Y→  0  1  2  3  4  5  6  7  8  9  10 11 */
       /*  0 */   { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
       /*  1 */   { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
       /*  2 */   { 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1, 1 },
       /*  3 */   { 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
       /*  4 */   { 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
       /*  5 */   { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 },
       /*  6 */   { 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0 },
       /*  7 */   { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0 },
       /*  8 */   { 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0 },
       /*  9 */   { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
       /* 10 */   { 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0 },
       /* 11 */   { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
      };

      var pathExpected = new List<Point>
      {
        new Point { X = 2, Y = 0 },
        new Point { X = 2, Y = 1 },
        new Point { X = 2, Y = 2 },
        new Point { X = 2, Y = 3 },
        new Point { X = 3, Y = 3 },
        new Point { X = 4, Y = 3 },
        new Point { X = 5, Y = 3 },
        new Point { X = 6, Y = 3 },
        new Point { X = 7, Y = 3 },
        new Point { X = 7, Y = 4 },
        new Point { X = 7, Y = 5 },
        new Point { X = 6, Y = 5 },
        new Point { X = 5, Y = 5 },
        new Point { X = 5, Y = 6 },
        new Point { X = 5, Y = 7 },
        new Point { X = 6, Y = 7 },
        new Point { X = 7, Y = 7 },
        new Point { X = 8, Y = 7 },
        new Point { X = 9, Y = 7 },
        new Point { X = 9, Y = 6 },
        new Point { X = 9, Y = 5 },
        new Point { X = 9, Y = 4 },
        new Point { X = 9, Y = 3 },
        new Point { X = 10, Y = 3 },
        new Point { X = 11, Y = 3 },
        new Point { X = 11, Y = 4 },
        new Point { X = 11, Y = 5 },
        new Point { X = 11, Y = 6 },
        new Point { X = 11, Y = 7 },
        new Point { X = 11, Y = 8 },
        new Point { X = 11, Y = 9 },
        new Point { X = 10, Y = 9 },
        new Point { X = 9, Y = 9 },
        new Point { X = 8, Y = 9 },
        new Point { X = 7, Y = 9 },
        new Point { X = 6, Y = 9 },
        new Point { X = 5, Y = 9 },
        new Point { X = 4, Y = 9 },
        new Point { X = 3, Y = 9 },
        new Point { X = 3, Y = 8 },
        new Point { X = 3, Y = 7 },
        new Point { X = 2, Y = 7 },
        new Point { X = 1, Y = 7 },
        new Point { X = 1, Y = 8 },
        new Point { X = 1, Y = 9 },
        new Point { X = 1, Y = 10 },
        new Point { X = 1, Y = 11 }
      };

      // Act
      var path = AStarWorker.Start(field, rowsAmount, columnsAmount, startPoint, finishPoint);

      // Assert
      CollectionAssert.AreEqual(pathExpected, path);
    }

    [Test]
    public void NoPath_ResultListIsEmpty()
    {
      // Arrange
      const int rowsAmount = 4;
      const int columnsAmount = 4;

      var startPoint = new Point { X = 0, Y = 0 };
      var finishPoint = new Point { X = 3, Y = 3 };

      int[,] field =
      {
        /*  X↓   Y→  0  1  2  3 */
        /*  0 */   { 0, 0, 0, 0 },
        /*  1 */   { 0, 0, 1, 1 },
        /*  2 */   { 1, 0, 1, 0 },
        /*  3 */   { 1, 1, 0, 0 }
      };

      var pathExpected = new List<Point> { };

      // Act
      var path = AStarWorker.Start(field, rowsAmount, columnsAmount, startPoint, finishPoint);

      // Assert
      CollectionAssert.AreEqual(pathExpected, path);
    }

    [Test]
    public void StartAndFinishPointsIsOne_ResultListIsEmpty()
    {
      // Arrange
      const int rowsAmount = 4;
      const int columnsAmount = 4;

      var startPoint = new Point { X = 0, Y = 0 };
      var finishPoint = new Point { X = 3, Y = 3 };

      int[,] field =
      {
        /*  X↓   Y→  0  1  2  3 */
        /*  0 */   { 1, 1, 0, 0 },
        /*  1 */   { 0, 0, 0, 1 },
        /*  2 */   { 1, 0, 0, 1 },
        /*  3 */   { 1, 1, 0, 1 }
      };

      var pathExpected = new List<Point> { };

      // Act
      var path = AStarWorker.Start(field, rowsAmount, columnsAmount, startPoint, finishPoint);

      // Assert
      CollectionAssert.AreEqual(pathExpected, path);
    }
  }
}
