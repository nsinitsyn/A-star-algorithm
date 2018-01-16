# A* search algorithm
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE.md)

A* search algorithm implementation for maps.  
Algorithm details: https://ru.wikipedia.org/wiki/A*

## Usage

Just call static method `AStarWorker.Start(field, rowsAmount, columnsAmount, startPoint, finishPoint)` where:
`field` - two-dimensional array of 0 and 1 where 0 - cage is passable, 1 - cage isn't passable
`rowsAmount` - amount of rows of field array
`columnsAmount` - amount of columns of field array
`startPoint` - starting point of search 
`finishPoint` - search endpoint 

```csharp
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
```
