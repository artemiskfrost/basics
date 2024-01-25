namespace CoinProblem
{
	[TestClass]
	public class CoinProblemSolverTests
	{
		public struct TestData
		{
			public static int[] CoinValues => new[] { 1, 2, 3 };
			public static long[] Totals => new[] { 0L, 1L, 2L, 3L, 4L, 5L, 6L };
			public static long[] ExpectedResults => new[] { 0L, 1L, 2L, 4L, 7L, 15L, 28L };
		}


		public CoinProblemSolver solver;


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
				actual.Add( solver.Solve( total, coinValues ) );
			}
			Console.WriteLine( "actual" );
			foreach ( var value in actual )
			{
				Console.WriteLine( $"\t{ value }" );
			}
			Console.WriteLine( "expected" );
			foreach ( var value in expected )
			{
				Console.WriteLine( $"\t{ value }" );
			}
			CollectionAssert.AreEqual( expected, actual );
		}

		private static IEnumerable< object[] > Data_Success_Solve()
		{
			yield return new object[] { TestData.Totals, TestData.CoinValues, TestData.ExpectedResults };
		}
	}
}
