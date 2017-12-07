using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_2
{
	public enum NextDirection
	{
		Up,
		Down,
		Left,
		Right
	}

	class Program
	{
		static NextDirection _nextDirection;
		static List<List<int>> _spiral;

		static void Main(string[] args)
		{
			var input = 312051;
			var result = GetFirstHighestNum(input);

			Console.WriteLine(result);
			Console.ReadLine();
		}


		private static int GetFirstHighestNum(int input)
		{
			_spiral = new List<List<int>>();
			_spiral.Add(new List<int>() { 1, 1 });   //First 2 values
			_nextDirection = NextDirection.Up;

			int rowIndex = 0;
			int columnIndex = 1;

			for (int i = 3; i <= 100; i++)
			{
				List<int> row;
				int result = 0;

				switch (_nextDirection)
				{
					case NextDirection.Up:
						if (rowIndex == 0)
						{
							InsertRowAbove(rowIndex, columnIndex);
							_nextDirection = NextDirection.Left;
						}
						else if (rowIndex - 1 == 0)
						{
							rowIndex--;
							row = _spiral[rowIndex];
							result = _spiral[rowIndex][columnIndex - 1] + _spiral[rowIndex + 1][columnIndex - 1] + _spiral[rowIndex + 1][columnIndex];
							row.Add(result);
						}
						else
						{
							rowIndex--;
							row = _spiral[rowIndex];
							result = _spiral[rowIndex - 1][columnIndex - 1] + _spiral[rowIndex][columnIndex - 1] + _spiral[rowIndex + 1][columnIndex - 1] + _spiral[rowIndex + 1][columnIndex];
							row.Add(result);
						}
						break;

					case NextDirection.Left:
						row = _spiral[rowIndex];

						if (columnIndex == 0)
						{
							InsertColumnsAtBeginning();
							result = _spiral[rowIndex][columnIndex + 1] + _spiral[rowIndex + 1][columnIndex + 1];
							row[columnIndex] = result;
							_nextDirection = NextDirection.Down;
						}
						else if (columnIndex - 1 == 0)
						{
							result = _spiral[rowIndex][columnIndex] + _spiral[rowIndex + 1][columnIndex] + _spiral[rowIndex + 1][columnIndex - 1];
							row[columnIndex - 1] = result;
							columnIndex--;
						}
						else
						{
							result = _spiral[rowIndex][columnIndex] + _spiral[rowIndex + 1][columnIndex - 2] + _spiral[rowIndex + 1][columnIndex - 1] + _spiral[rowIndex + 1][columnIndex];
							row[columnIndex - 1] = result;
							columnIndex--;
						}
						break;

					case NextDirection.Down:
						if (rowIndex == _spiral.Count - 1)
						{
							InsertRowBelow();
							rowIndex++;
							result = _spiral[rowIndex - 1][columnIndex] + _spiral[rowIndex - 1][columnIndex + 1];
							_spiral[rowIndex][columnIndex] = result;
							_nextDirection = NextDirection.Right;
						}
						else if (rowIndex + 1 == _spiral.Count - 1)
						{
							result = _spiral[rowIndex][columnIndex] + _spiral[rowIndex][columnIndex + 1] + _spiral[rowIndex + 1][columnIndex + 1];
							_spiral[rowIndex + 1][columnIndex] = result;
							rowIndex++;
						}
						else
						{
							result = _spiral[rowIndex][columnIndex] + _spiral[rowIndex][columnIndex + 1] + _spiral[rowIndex + 1][columnIndex + 1] + _spiral[rowIndex + 2][columnIndex + 1];
							_spiral[rowIndex + 1][columnIndex] = result;
							rowIndex++;
						}
						break;

					case NextDirection.Right:
						row = _spiral[rowIndex];

						if (columnIndex + 1 == row.Count)
						{
							result = _spiral[rowIndex - 1][columnIndex] + _spiral[rowIndex][columnIndex];
							row.Add(result);
							columnIndex++;
							_nextDirection = NextDirection.Up;
						}
						else if (columnIndex + 2 == row.Count)
						{
							result = _spiral[rowIndex][columnIndex] + _spiral[rowIndex - 1][columnIndex] + _spiral[rowIndex - 1][columnIndex + 1];
							row[columnIndex + 1] = result;
							columnIndex++;
						}
						else
						{
							result = _spiral[rowIndex][columnIndex] + _spiral[rowIndex - 1][columnIndex] + _spiral[rowIndex - 1][columnIndex + 1] + _spiral[rowIndex - 1][columnIndex + 2];
							row[columnIndex + 1] = result;
							columnIndex++;
						}
						break;
				}

				if (result > input) return result;
			}
			return 0;
		}

		private static void InsertRowAbove(int rowIndex, int columnIndex)
		{
			var row = new List<int>();
			for (int i = 0; i <= columnIndex; i++)  //will insert same value first, eg dummy values for some squares
			{
				var result = _spiral[rowIndex][columnIndex] + _spiral[rowIndex][columnIndex - 1];
				row.Add(result);
			}
			_spiral.Insert(0, row);
		}

		private static void InsertRowBelow()
		{
			var row = new List<int>();
			for (int i = 0; i < _spiral[0].Count; i++)
				row.Add(-1);    //Default value -1.
			_spiral.Add(row);
		}

		private static void InsertColumnsAtBeginning()
		{
			foreach (var row in _spiral)
				row.Insert(0, -1);  //Default value -1
		}

	}
}
