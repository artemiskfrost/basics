namespace CoinProblem
{
	[TestClass]
	public class CoinProblemSolverTests
	{
		public struct TestData
		{
			public int[] CoinValues => new[] { 1, 2, 3 };
			public long[] Totals => new[] { 0, 1, 2, 3, 4, 5, 6 };
			public long[] ExpectedResults => new[] { 0, 1, 2, 4, 7, 15, 28 };
		}


		public CoinProblemSolver solver;


		[TestInitialize]
		public void Setup()
		{
			solver = new();
		}


		[TestMethod]
		[DataRow( TestData.Totals, TestData.CoinValues, TestData.ExpectedResults )]
		public void Test_Success_Solve( long[] totals, int[] coinValues, long[] expected )
		{
			var actual = new List<long>();
			foreach ( var total in totals )
			{
				actual.Add( solver.Solve( total, coinValues ) );
			}
			CollectionAssert.AreEqual( expected, actual );
		}
	}
}
