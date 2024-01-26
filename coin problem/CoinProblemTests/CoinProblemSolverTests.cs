namespace CoinProblem
{
	[TestClass]
	public class CoinProblemSolverTests
	{
		public struct TestData
		{
			public static int[] CoinValues => [ 1, 2, 3 ];
			public static long[] ExpectedResults => [ 0L, 1L, 2L, 3L, 4L, 5L, 7L, 8L, 10L, 12L ];
			public static long[] Totals => [ 0L, 1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L ];
		}


		public CoinProblemSolver? solver;


		[TestInitialize]
		public void Setup()
		{
			solver = new();
		}


		[TestMethod]
		[DynamicData( nameof( Data_Success_Solve ), DynamicDataSourceType.Method )]
		public void Test_Success_Solve( long[] totals, int[] coinValues, long[] expected )
		{
			var actual = new List<long>();
			foreach ( var total in totals )
			{
				actual.Add( solver!.Solve( total, coinValues ) );
			}

			Console.WriteLine( "expected" );
			foreach ( var value in expected )
			{
				Console.Write( $"\t{ value }," );
			}
			Console.WriteLine();

			Console.WriteLine( "actual" );
			foreach ( var value in actual )
			{
				Console.Write( $"\t{ value }," );
			}
			Console.WriteLine();

			CollectionAssert.AreEqual( expected, actual );
		}

		private static IEnumerable< object[] > Data_Success_Solve()
		{
			yield return new object[] { TestData.Totals, TestData.CoinValues, TestData.ExpectedResults };
		}
	}
}

/*
<1 = 0

1 = 1
1_

2 = 2
2
1_

3 = 3
3			-> 3(0)
21_
1_

4 = 4
31			-> 3(1)
22 21_
1_

5 = 5
32 31_		-> 3(2)
221 21_
1_

6 = 7
33 321 31_		-> 3(3)
222 221_ 21_
1_

7 = 8
331 322 321_ 31_		-> 3(4)
2221_ 221_ 21_
1_

8 = 10
332 331_ 3221_ 321_ 31_		-> 3(5)
2222 2221_ 221_ 21_
1_

9 = 12
333 3321_ 331_ 3222 3221_ 321_ 31_		-> 3(6)
22221_ 2221_ 221_ 21_
1_
*/
