namespace CoinProblem
{
	[TestClass]
	public class CoinProblemSolverTests
	{
		public struct TestData
		{
			public static int[] CoinValues => [ 1, 2, 3 ];
			public static long[] ExpectedResults => [ 0L, 1L, 2L, 3L, 4L, 5L, 7L, 8L, 10L, 12L, 14L, 16L, 19L, 21L, 24L, 27L, 30L, 33L, 37L, 40L, 44L, 48L, 52L, 56L, 61L, 65L, 70L, 75L, 80L, 85L, 91L ];
			public static long[] Totals => [ 0L, 1L, 2L, 3L, 4L, 5L, 6L, 7L, 8L, 9L, 10L, 11L, 12L, 13L, 14L, 15L, 16L, 17L, 18L, 19L, 20L, 21L, 22L, 23L, 24L, 25L, 26L, 27L, 28L, 29L, 30L ];
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
<1 -> 0
1 -> 1
2 -> 2, 11
3 -> 3, 21, 111
>3 -> C( n - 3 ) + floor( n / 2 ) + 1

<1 = 0
1  = 1
2  = 2
3  = 3
4  = 4  =>  C(1)  + ⌊2⌋    + 1 =>  1 + 2 + 1
5  = 5  =>  C(2)  + ⌊2.5⌋  + 1 =>  2 + 2 + 1
6  = 7  =>  C(3)  + ⌊3⌋    + 1 =>  3 + 3 + 1
7  = 8  =>  C(4)  + ⌊3.5⌋  + 1 =>  4 + 3 + 1
8  = 10 =>  C(5)  + ⌊4⌋    + 1 =>  5 + 4 + 1
9  = 12 =>  C(6)  + ⌊4.5⌋  + 1 =>  7 + 4 + 1
10 = 14 =>  C(7)  + ⌊5⌋    + 1 =>  8 + 5 + 1
11 = 16 =>  C(8)  + ⌊5.5⌋  + 1 =>  10 + 5 + 1
12 = 19 =>  C(9)  + ⌊6⌋    + 1 =>  12 + 6 + 1
13 = 21 =>  C(10) + ⌊6.5⌋  + 1 =>  14 + 6 + 1
14 = 24 =>  C(11) + ⌊7⌋    + 1 =>  16 + 7 + 1
15 = 27 =>  C(12) + ⌊7.5⌋  + 1 =>  19 + 7 + 1
16 = 30 =>  C(13) + ⌊8⌋    + 1 =>  21 + 8 + 1
17 = 33 =>  C(14) + ⌊8.5⌋  + 1 =>  24 + 8 + 1
18 = 37 =>  C(15) + ⌊9⌋    + 1 =>  27 + 9 + 1
19 = 40 =>  C(16) + ⌊9.5⌋  + 1 =>  30 + 9 + 1
20 = 44 =>  C(17) + ⌊10⌋   + 1 =>  33 + 10 + 1
21 = 48 =>  C(18) + ⌊10.5⌋ + 1 =>  37 + 10 + 1
22 = 52 =>  C(19) + ⌊11⌋   + 1 =>  40 + 11 + 1
23 = 56 =>  C(20) + ⌊11.5⌋ + 1 =>  44 + 11 + 1
24 = 61 =>  C(21) + ⌊12⌋   + 1 =>  48 + 12 + 1
25 = 65 =>  C(22) + ⌊12.5⌋ + 1 =>  52 + 12 + 1
26 = 70 =>  C(23) + ⌊13⌋   + 1 =>  56 + 13 + 1
27 = 75 =>  C(24) + ⌊13.5⌋ + 1 =>  61 + 13 + 1
28 = 80 =>  C(25) + ⌊14⌋   + 1 =>  65 + 14 + 1
29 = 85 =>  C(26) + ⌊14.5⌋ + 1 =>  70 + 14 + 1
30 = 91 =>  C(27) + ⌊15⌋   + 1 =>  75 + 15 + 1
*/
