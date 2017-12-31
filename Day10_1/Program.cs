using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_1
{
	class Program
	{
		static void Main(string[] args)
		{
			var nums = GetNumArray(256);
			var input = GetInput();
			var reordered = ReorderNumbers(nums, input);

			Console.WriteLine(reordered[0] * reordered[1]);
			Console.ReadLine();
		}

		private static List<int> ReorderNumbers(int[] nums, List<int> input)
		{
			var reordered = new List<int>(nums);
			int currentIndex = 0;
			int startIndex;
			int skipsize = 0;
			var subList = new Stack<int>();
			var insertIndexes = new List<int>();

			foreach (var num in input)
			{
				startIndex = currentIndex;
				insertIndexes.Clear();

				for (int i = 0; i < num; i++)
				{
					subList.Push(reordered[currentIndex]);
					insertIndexes.Add(currentIndex);

					if (currentIndex + 1 == nums.Length)    //have to wrap around
						currentIndex = 0;
					else
						currentIndex++;
				}

				for (int i = 0; i < num; i++)
				{
					var temp = subList.Pop();
					var index = insertIndexes[i];
					reordered.Insert(index, temp);
					reordered.RemoveAt(index + 1);
				}

				int nextIndex = startIndex + num + skipsize;
				currentIndex = GetCurrentIndex(reordered.Count, nextIndex);
				skipsize++;
			}

			return reordered;
		}

		private static int GetCurrentIndex(int reorderedCount, int nextIndex)
		{
			while (nextIndex >= reorderedCount)
				nextIndex = Math.Abs(reorderedCount - nextIndex);
			return nextIndex;
		}

		private static List<int> GetInput()
		{
			var arr = "63,144,180,149,1,255,167,84,125,65,188,0,2,254,229,24".Split(',');
			return arr.Select(x => int.Parse(x)).ToList();
		}

		private static int[] GetNumArray(int size)
		{
			var array = new int[size];
			for (int i = 0; i < size; i++)
				array[i] = i;
			return array;
		}
	}
}
