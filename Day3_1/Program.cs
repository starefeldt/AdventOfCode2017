using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_1
{
	public enum NextDirection
	{
		Up,
		Down,
		Left,
		Right
	}

	struct NumIndex
	{
		public int rowIndex { get; set; }
		public int columnIndex { get; set; }
	}

	class Program
	{
		static NextDirection _nextDirection;
		static List<List<int>> _spiral;

		static void Main(string[] args)
		{
			int searchNum = 312051;
			CreateSpiral(searchNum);

			var entryPoint = new NumIndex();
			var searchPoint = new NumIndex();
			GetIndexes(searchNum, ref entryPoint, ref searchPoint);

			int rowSteps = entryPoint.rowIndex - searchPoint.rowIndex;
			if (rowSteps < 0)
				rowSteps = Math.Abs(rowSteps);	//turns negative to positive

			int columnSteps = entryPoint.columnIndex - searchPoint.columnIndex;
			if (columnSteps < 0)
				columnSteps = Math.Abs(columnSteps); 

			int sum = rowSteps + columnSteps;
			Console.WriteLine(sum);
			Console.ReadLine();
		}

		private static void GetIndexes(int searchNum, ref NumIndex entryPoint, ref NumIndex searchPoint)
		{
			for (int row = 0; row < _spiral.Count; row++)
			{
				for (int column = 0; column < _spiral[row].Count; column++)
				{
					int num = _spiral[row][column];

					if (num == 1)	//Entrypoint
					{
						entryPoint.rowIndex = row;
						entryPoint.columnIndex = column;
					}
					if (num == searchNum)
					{
						searchPoint.rowIndex = row;
						searchPoint.columnIndex = column;
					}
				}
			}
		}

		private static void CreateSpiral(int amount)
		{
			_spiral = new List<List<int>>();
			_spiral.Add(new List<int>() { 1, 2 });   //First 2 values
			_nextDirection = NextDirection.Up;

			int rowIndex = 0;
			int columnIndex = 1;

			for (int i = 3; i <= amount; i++)
			{
				List<int> row;

				switch (_nextDirection)
				{
					case NextDirection.Up:
						if (rowIndex == 0)
						{
							InsertRowAbove(columnIndex, i);
							_nextDirection = NextDirection.Left;
						}
						else
						{
							rowIndex--;
							row = _spiral[rowIndex];
							row.Add(i);
						}
						break;

					case NextDirection.Left:
						row = _spiral[rowIndex];

						if (columnIndex == 0)
						{
							InsertColumnsAtBeginning();
							row[columnIndex] = i;
							_nextDirection = NextDirection.Down;
						}
						else
						{
							row[columnIndex - 1] = i;
							columnIndex--;
						}
						break;

					case NextDirection.Down:
						if (rowIndex == _spiral.Count - 1)
						{
							InsertRowBelow();
							rowIndex++;
							_spiral[rowIndex][columnIndex] = i;
							_nextDirection = NextDirection.Right;
						}
						else
						{
							_spiral[rowIndex + 1][columnIndex] = i;
							rowIndex++;
						}
						break;

					case NextDirection.Right:
						row = _spiral[rowIndex];

						if (columnIndex + 1 == row.Count)
						{
							row.Add(i);
							columnIndex++;
							_nextDirection = NextDirection.Up;
						}
						else
						{
							row[columnIndex + 1] = i;
							columnIndex++;
						}
						break;
				}
			}
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

		private static void InsertRowAbove(int columnIndex, int num)
		{
			var row = new List<int>();
			for (int i = 0; i <= columnIndex; i++)
				row.Add(num);
			_spiral.Insert(0, row);
		}
	}
}
