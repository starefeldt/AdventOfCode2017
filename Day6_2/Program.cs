﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_2
{
	struct HighestData
	{
		public int MaxItems { get; set; }
		public int StartIndex { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			List<int[]> blocks = GetBlocksFromInput();
			var sequences = new List<string>();
			Tuple<int, bool> result;

			while (true)
			{
				var data = GetHighestData(blocks);
				Redistribute(blocks, data);
				result = SequenceExists(blocks, sequences);

				if (result.Item2)
					break;
			}
			Console.WriteLine(result.Item1);
			Console.ReadLine();
		}

		private static HighestData GetHighestData(List<int[]> blocks)
		{
			var data = new HighestData();

			for (int i = 0; i < blocks.Count; i++)
			{
				var block = blocks[i];
				if (block.Length > data.MaxItems)
				{
					data.MaxItems = block.Length;
					data.StartIndex = i;
				}
			}
			return data;
		}

		private static void Redistribute(List<int[]> blocks, HighestData data)
		{
			int distribute = (int)Math.Ceiling(data.MaxItems / (double)(blocks.Count));
			int counter = blocks[data.StartIndex].Length;
			int index = data.StartIndex;
			blocks[data.StartIndex] = new int[0];

			while (counter != 0)
			{
				index++;
				if (index == blocks.Count)   //after last item in list, wrap around
					index = 0;

				if (counter < distribute)
				{
					blocks[index] = new int[counter];
					counter = 0;
				}
				else
				{
					int size = blocks[index].Length;
					blocks[index] = new int[size + distribute];
					counter -= distribute;
				}
			}
		}

		private static Tuple<int, bool> SequenceExists(List<int[]> blocks, List<string> sequences)
		{
			var sb = new StringBuilder();
			foreach (var block in blocks)
				sb.Append(block.Length.ToString());

			if (sequences.Contains(sb.ToString()))
			{
				var indexOfFirst = sequences.IndexOf(sb.ToString());
				var difference = sequences.Count - indexOfFirst;
				return new Tuple<int, bool>(difference, true);
			}
				
			else
				sequences.Add(sb.ToString());
			return new Tuple<int, bool>(-1, false);
		}

		private static List<int[]> GetBlocksFromInput()
		{
			var blocks = new List<int[]>();
			//string input = "0 2 7 0";
			string input = "0   5   10  0   11  14  13  4   11  8   8   7   1   4   12  11";
			var blockSizes = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
								.Select(x => int.Parse(x));

			foreach (var size in blockSizes)
				blocks.Add(new int[size]);
			return blocks;
		}
	}
}
