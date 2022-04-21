namespace ClassLibrary1;

public class Class1
{
    private static readonly int MinSz = 4;
    private static readonly int MaxSz = 20;
    private static int _boardSize = MinSz;

    private static void Main(String[] args)
    {
        Console.WriteLine("Sedgewick: ");
        int n = int.Parse(args[0]);
        Enumerate(n);
    }

    private static Boolean IsConsistent(int[] q, int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (q[i] == q[n]) return false; // same column
            if ((q[i] - q[n]) == (n - i)) return false; // same major diagonal
            if ((q[n] - q[i]) == (n - i)) return false; // same minor diagonal
        }

        return true;
    }

    private static void PrintQueens(int[] q)
    {
        int n = q.Length;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (q[i] == j) Console.Write("Q ");
                else Console.Write("* ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static void Enumerate(int n)
    {
        if (n >= MinSz && n <= MaxSz)
        {
            int[] a = new int[n];
            Enumerate(a, 0);
        }
        else
        {
            Console.WriteLine("parameters given not within board size limit. min: " + MinSz + ",  max: " + MaxSz +
                              ", given: " + n);
        }
    }

    private static void Enumerate(int[] q, int k)
    {
        var n = q.Length;
        if (k == n) PrintQueens(q);
        else
        {
            for (int i = 0; i < n; i++)
            {
                q[k] = i;
                if (IsConsistent(q, k)) Enumerate(q, k + 1);
            }
        }
    }
}