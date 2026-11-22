namespace Inter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> X = [-2, 0, 1, 3];
            List<double> Y = [-1, -1, 2, 14];
            double xToFind = 2.0;
            double result = NewtonInterpolate(X, Y, xToFind);
            Console.WriteLine($"Результат интерполяции: {result}");

            // вместо массивов я использовал list. И копировал списки с помощью new List<double>(Y) где Y это список, который нужно скопировать
        }

        static List<double> CalculationCoeffs(List<double> X, List<double> Y)
        {
            List<double> divDiff = new List<double>(Y);
            List<double> a = new List<double>();

            int n = X.Count;

            a.Add(Y[0]);

            Console.WriteLine($"Коэффициент а0: {a[0]}");

            for (int k = 1; k <= n - 1; k++)
            {
                for (int i = 0; i < n - k; i++)
                {
                    divDiff[i] = (divDiff[i + 1] - divDiff[i]) / (X[i + k] - X[i]);
                }

                a.Add(divDiff[0]);
                Console.WriteLine($"Коэффициент а{k}: {a[k]}");
                divDiff.RemoveAt(divDiff.Count - 1);
            }

            return a;
        }

        static double NewtonInterpolate(List<double> X, List<double> Y, double xToFind)
        {
            double result = 0;
            List<double> a = CalculationCoeffs(X, Y);
            int n = X.Count;
            double multiplier = 1;

            for (int i = 0; i < n; i++)
            {
                result += a[i] * multiplier;
                multiplier *= (xToFind - X[i]);
            }

            return result;
        }
    }
}
