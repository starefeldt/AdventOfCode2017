﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_2
{
	class Program
	{
		static void Main(string[] args)
		{
			var table = GetInputTable();
			int sum = 0;

			foreach (var row in table)
			{
				for (int a = 0; a < row.Count; a++)
				{
					for (int b = a + 1; b < row.Count; b++)
					{
						double result = row[a] / (double)row[b];

						if (result % 1 == 0)	// check if value has divided evenly
						{
							sum += (int)result;
							break;
						}
					}
				}
			}
				

			Console.WriteLine(sum);
			Console.ReadLine();
		}

		private static List<List<int>> GetInputTable()
		{
			var table = new List<List<int>>();

			table.Add(CreateTableRow("1236    741 557 1029    144 101 1968    2159    1399    80  1139    1167    1695    82  90  2236"));
			table.Add(CreateTableRow("2134    106 107 1025    584 619 191 496 80  352 351 2267    1983    1973    97  1244"));
			table.Add(CreateTableRow("3227    179 691 3177    172 1636    3781    2020    3339    2337    189 3516    1500    176 159 3279"));
			table.Add(CreateTableRow("201 688 364 180 586 659 623 577 188 265 403 670 195 720 115 37"));
			table.Add(CreateTableRow("1892    1664    2737    2676    849 2514    923 171 311 218 255 2787    1271    188 1278    2834"));
			table.Add(CreateTableRow("150 3276    204 603 3130    587 3363    3306    2890    127 176 174 383 3309    213 1620"));
			table.Add(CreateTableRow("5903    3686    200 230 6040    4675    6266    179 5375    1069    283 82  6210    6626    6398    1954"));
			table.Add(CreateTableRow("942 2324    1901    213 125 2518    655 189 2499    160 2841    2646    198 173 1841    200"));
			table.Add(CreateTableRow("232 45  272 280 44  248 50  266 296 297 236 254 58  212 276 48"));
			table.Add(CreateTableRow("563 768 124 267 153 622 199 591 204 125 93  656 198 164 797 506"));
			table.Add(CreateTableRow("243 4746    1785    204 568 4228    2701    4303    188 4148    4831    1557    4692    166 4210    3656"));
			table.Add(CreateTableRow("72  514 1572    172 1197    750 1392    1647    1587    183 1484    213 1614    718 177 622"));
			table.Add(CreateTableRow("1117    97  2758    2484    941 1854    1074    264 2494    83  1434    96  2067    2825    2160    92"));
			table.Add(CreateTableRow("2610    1290    204 2265    1374    2581    185 852 207 175 3308    1500    2898    1120    1892    3074"));
			table.Add(CreateTableRow("2322    1434    301 2156    98  2194    587 1416    1521    94  1985    424 91  119 1869    1073"));
			table.Add(CreateTableRow("66  87  176 107 2791    109 21  92  3016    2239    1708    3175    3210    2842    446 484"));

			return table;
		}

		private static List<int> CreateTableRow(string input)
		{
			return input.Split(' ')
						.Where(x => !String.IsNullOrEmpty(x))
						.Select(n => int.Parse(n))
						.OrderByDescending(x => x)
						.ToList();
		}
	}
}