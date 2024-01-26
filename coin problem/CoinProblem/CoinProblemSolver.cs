namespace CoinProblem
{
	public class CoinProblemSolver
	{
		private Dictionary< long, long > SubtotalSolutions = new();
		private int[] CoinValues { get; set; } = Array.Empty<int>();


		public long Solve( long total, int[] coinValues )
		{
			if ( total < 1 )
			{
				return 0;
			}

			CoinValues = SortCoinValues( coinValues );
			return SolveSubtotal( total, coinValues.Length );
		}


		private long SolveSubtotal( long subtotal, int coinPoolSize )
		{
			bool isValidSolution = subtotal == 0;
			if ( isValidSolution )
			{
				return 1;
			}

			bool isInvalidSolution = subtotal < 0;
			if ( isInvalidSolution )
			{
				return 0;
			}

			bool isCoinPoolEmpty = coinPoolSize < 1;
			if ( isCoinPoolEmpty )
			{
				return 0;
			}

			return SolveSubtotal( subtotal, coinPoolSize - 1 ) + SolveSubtotal( subtotal - CoinValues[ coinPoolSize - 1 ], coinPoolSize );
		}

		private static int[] SortCoinValues( int[] coinValues )
		{
			var result = coinValues.ToList();
			result.Sort( ( a, b ) => b.CompareTo( a ) );
			return result.ToArray();
		}
	}
}
