using CMAIBOVSII_Lab1;

//var MatrixForCholeskyMetod = new double[][] {
//        [4, 12, -16],
//        [12, 37, -43],
//        [-16, -43, 98]};

//var CMatrix = SomeMatrix.CholeskyMethod(MatrixForCholeskyMetod);
//foreach (var item in CMatrix)
//{
//    foreach (var mat in item)
//    {
//        Console.Write(mat + "\t");
//    }
//    Console.WriteLine();
//}

//var MatrixForGJMetod = new double[][] {
//        [8.301, 2.625, 4.1, 1.903],
//        [3.926, 8.458, 7.787, 2.46],
//        [3.773, 7.211, 8.041, 2.28],
//        [2.211, 3.657, 1.697, 6.993]};

//var MatrixForDefaultMethod = new Matrix4x4(8.301f, 2.625f, 4.1f, 1.903f,
//                                  3.926f, 8.458f, 7.787f, 2.46f,
//                                  3.773f, 7.211f, 8.041f, 2.28f,
//                                  2.211f, 3.657f, 1.697f, 6.993f);

//var GJMatrix = SomeMatrix.GaussJordanJMethod(MatrixForGJMetod);
//Matrix4x4.Invert(MatrixForDefaultMethod, out Matrix4x4 InvertedMatrixForDefaultMethod);

//Console.WriteLine("Рукописный метод:\t\tВстроенный метод:");
//for (int i = 0; i < 4;i++)
//{
//    for (int j = 0; j < 4;j++)
//    {
//        Console.WriteLine(GJMatrix[i][j] + "\t\t" + InvertedMatrixForDefaultMethod[i,j]);
//    }
//}

var MatrixForCholeskyMetod = new double[][] {
        [4, 12, -16],
        [12, 37, -43],
        [-16, -43, 98]};

var b = new double[MatrixForCholeskyMetod.Length];
for (int j = 0; j < MatrixForCholeskyMetod[0].Length; j++)
{
    for (int i = 0; i < MatrixForCholeskyMetod.Length; i++)
    {
        b[i] += MatrixForCholeskyMetod[i][j];
    }
}

var L = SomeMatrix.CholeskyMethod(MatrixForCholeskyMetod);
var y = SomeMatrix.ForwardSubstitution(L, b); //решение системы Ly = b
var x = SomeMatrix.BackwardSubstitution(SomeMatrix.Transpose(L), y); // решение системы L^T x = y

Console.WriteLine("Решение системы:");
foreach (var value in x)
{
    Console.WriteLine(value);
}



