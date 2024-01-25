namespace CoinProblem
{
	public class CoinProblemSolver
	{
		private Dictionary< long, long > SubtotalSolutions = new();
		private int[] CoinValues { get; set; } = Array.Empty<int>();


		public long Solve( long total, int[] coinValues )
		{
			CoinValues = coinValues;
			return SolveSubtotal( total );
		}


		private long SolveSubtotal( long subtotal )
		{
			if ( subtotal < 1 )
			{
				return 0;
			}

			long solutionCount = 0;
			if ( SubtotalSolutions.TryGetValue( subtotal, out solutionCount ) )
			{
				return solutionCount;
			}

			foreach ( var coinValue in CoinValues )
			{
				solutionCount += SolveSubtotal( subtotal - coinValue );
			}
			SubtotalSolutions.Add( subtotal, solutionCount );
			return solutionCount;
		}
	}
}