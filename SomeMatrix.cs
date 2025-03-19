namespace CMAIBOVSII_Lab1;
internal class SomeMatrix
{
    public static double[][] GaussJordanJMethod(double[][] OriginalMatrix)
    {
        var n = OriginalMatrix.GetLength(0);
        var ReversedMatrix = new double[n][];
        for (var i = 0; i < n; i++)
        {
            ReversedMatrix[i] = new double[n];
            ReversedMatrix[i][i] = 1;
        }

        //буффер = ог + реверс(единичная) матрицы
        var BufferMatrix = new double[n][];
        for (var i = 0; i < n; i++)
        {
            BufferMatrix[i] = new double[n * 2];
            for (var j = 0; j < n; j++)
            {
                BufferMatrix[i][j] = OriginalMatrix[i][j];
                BufferMatrix[i][j + n] = ReversedMatrix[i][j];
            }
        }

        //прямой ход - нулим низ
        for (var k = 0; k < n; k++) //строка
        {
            for (var i = 0; i < 2 * n; i++) //столбец
            {
                BufferMatrix[k][i] = BufferMatrix[k][i] / OriginalMatrix[k][k]; //делаем единицу из первого члена
            }
            for (var i = k + 1; i < n; i++) //некст строка после k
            {
                var Koef = BufferMatrix[i][k] / BufferMatrix[k][k];
                for (var j = 0; j < 2 * n; j++) //некст столбец в этой строке
                {
                    BufferMatrix[i][j] = BufferMatrix[i][j] - BufferMatrix[k][j] * Koef; //нулим
                }
            }
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    OriginalMatrix[i][j] = BufferMatrix[i][j];
                }
            }
        }

        //обратный ход - нулим верх
        for (var k = n - 1; k > -1; k--) //строка
        {
            for (var i = 2 * n - 1; i > -1; i--) //столбец
            {
                BufferMatrix[k][i] = BufferMatrix[k][i] / OriginalMatrix[k][k];
            }
            for (var i = k - 1; i > -1; i--) //некст строка после k
            {
                var K = BufferMatrix[i][k] / BufferMatrix[k][k];
                for (var j = 2 * n - 1; j > -1; j--) //некст столбец в этой строке
                {
                    BufferMatrix[i][j] = BufferMatrix[i][j] - BufferMatrix[k][j] * K;
                }
            }
        }
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                ReversedMatrix[i][j] = BufferMatrix[i][j + n];
            }
        }
        return ReversedMatrix;
    }


    /// <returns>левая нижняя треугольная матрица</returns>
    //public static double[][] CholeskyMethod(double[][] A)
    //{
    //    var Lmatrix = new double[A.Length][];
    //    for (int i = 0; i < A.Length; i++)
    //    {
    //        Lmatrix[i] = new double[i + 1];

    //        double temp;
    //        //считаем слева от диагонали
    //        for (int j = 0; j < i; j++)
    //        {
    //            temp = 0;
    //            for (int k = 0; k < j; k++)
    //            {
    //                temp += Lmatrix[i][k] * Lmatrix[j][k];
    //            }
    //            Lmatrix[i][j] = (A[i][j] - temp) / Lmatrix[j][j];
    //        }

    //        //считаем диагональ
    //        temp = A[i][i];
    //        for (int k = 0; k < i; k++)
    //        {
    //            temp -= Lmatrix[i][k] * Lmatrix[i][k];
    //        }
    //        Lmatrix[i][i] = Math.Sqrt(temp);
    //    }
    //    return Lmatrix;
    //}

    /// <returns>левая нижняя треугольная матрица</returns>
    public static double[][] CholeskyMethod(double[][] A)
    {
        int n = A.Length;
        var L = new double[n][];

        for (int i = 0; i < n; i++)
        {
            L[i] = new double[n];
            for (int j = 0; j <= i; j++)
            {
                double sum = 0;
                for (int k = 0; k < j; k++)
                {
                    sum += L[i][k] * L[j][k];
                }

                if (i == j)
                {
                    L[i][j] = Math.Sqrt(A[i][i] - sum);
                }
                else
                {
                    L[i][j] = (A[i][j] - sum) / L[j][j];
                }
            }
        }
        return L;
    }

    public static double[] ForwardSubstitution(double[][] L, double[] b)
    {
        int n = L.Length;
        double[] y = new double[n];

        for (int i = 0; i < n; i++)
        {
            double sum = 0;
            for (int j = 0; j < i; j++)
            {
                sum += L[i][j] * y[j];
            }
            y[i] = (b[i] - sum) / L[i][i];
        }
        //Array.Reverse(y);
        return y;
    }

    public static double[] BackwardSubstitution(double[][] U, double[] y)
    {
        int n = U.Length;
        double[] x = new double[n];

        for (int i = n - 1; i >= 0; i--)
        {
            double sum = 0;
            for (int j = i + 1; j < n; j++)
            {
                sum += U[i][j] * x[j];
            }
            x[i] = (y[i] - sum) / U[i][i];
        }

        return x;
    }

    public static double[][] Transpose(double[][] matrix)
    {
        if (matrix == null || matrix.Length == 0)
        {
            return [];
        }

        int rows = matrix.Length;
        int cols = matrix[0].Length;

        double[][] transposedMatrix = new double[cols][];
        for (int i = 0; i < cols; i++)
        {
            transposedMatrix[i] = new double[rows];
        }
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposedMatrix[j][i] = matrix[i][j];
            }
        }
        return transposedMatrix;
    }
}

