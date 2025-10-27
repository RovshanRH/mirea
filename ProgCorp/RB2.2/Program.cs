using System;

class MatrixCalculator
{
    static double[,] matrix1;
    static double[,] matrix2;
    static int rows1, cols1, rows2, cols2;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== КАЛЬКУЛЯТОР МАТРИЦ ===");
            Console.WriteLine("1. Создать и заполнить матрицы");
            Console.WriteLine("2. Сложение матриц");
            Console.WriteLine("3. Умножение матриц");
            Console.WriteLine("4. Найти детерминант матрицы");
            Console.WriteLine("5. Найти обратную матрицу");
            Console.WriteLine("6. Транспонировать матрицу");
            Console.WriteLine("7. Решить систему уравнений");
            Console.WriteLine("0. Выход");
            Console.Write("\nВыберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAndFillMatrices();
                    break;
                case "2":
                    AddMatrices();
                    break;
                case "3":
                    MultiplyMatrices();
                    break;
                case "4":
                    FindDeterminant();
                    break;
                case "5":
                    FindInverseMatrix();
                    break;
                case "6":
                    TransposeMatrix();
                    break;
                case "7":
                    SolveSystemOfEquations();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static void CreateAndFillMatrices()
    {
        Console.WriteLine("\n=== СОЗДАНИЕ МАТРИЦ ===");
        
        Console.Write("Введите количество строк первой матрицы (n): ");
        rows1 = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов первой матрицы (m): ");
        cols1 = int.Parse(Console.ReadLine());

        Console.Write("Введите количество строк второй матрицы (n): ");
        rows2 = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов второй матрицы (m): ");
        cols2 = int.Parse(Console.ReadLine());

        matrix1 = new double[rows1, cols1];
        matrix2 = new double[rows2, cols2];

        Console.WriteLine("\n1. Заполнить вручную");
        Console.WriteLine("2. Заполнить случайными числами");
        Console.Write("Выберите способ заполнения: ");
        string fillChoice = Console.ReadLine();

        if (fillChoice == "1")
        {
            FillMatrixManually(matrix1, rows1, cols1, "первую");
            FillMatrixManually(matrix2, rows2, cols2, "вторую");
        }
        else if (fillChoice == "2")
        {
            Console.Write("Введите минимальное значение (a): ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите максимальное значение (b): ");
            int b = int.Parse(Console.ReadLine());

            FillMatrixRandom(matrix1, rows1, cols1, a, b);
            FillMatrixRandom(matrix2, rows2, cols2, a, b);
        }

        Console.WriteLine("\nПервая матрица:");
        PrintMatrix(matrix1, rows1, cols1);
        Console.WriteLine("\nВторая матрица:");
        PrintMatrix(matrix2, rows2, cols2);
    }

    static void FillMatrixManually(double[,] matrix, int rows, int cols, string matrixName)
    {
        Console.WriteLine($"\nЗаполнение {matrixName} матрицы:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Элемент [{i},{j}]: ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }

    static void FillMatrixRandom(double[,] matrix, int rows, int cols, int min, int max)
    {
        Random rnd = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rnd.Next(min, max + 1);
            }
        }
    }

    static void PrintMatrix(double[,] matrix, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j],8:F2} ");
            }
            Console.WriteLine();
        }
    }

    static void AddMatrices()
    {
        Console.WriteLine("\n=== СЛОЖЕНИЕ МАТРИЦ ===");

        if (matrix1 == null || matrix2 == null)
        {
            Console.WriteLine("Сначала создайте матрицы!");
            return;
        }

        if (rows1 != rows2 || cols1 != cols2)
        {
            Console.WriteLine("ОШИБКА: Невозможно сложить матрицы!");
            Console.WriteLine($"Размерности не совпадают: ({rows1}x{cols1}) и ({rows2}x{cols2})");
            return;
        }

        double[,] result = new double[rows1, cols1];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols1; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        Console.WriteLine("\nРезультат сложения:");
        PrintMatrix(result, rows1, cols1);
    }

    static void MultiplyMatrices()
    {
        Console.WriteLine("\n=== УМНОЖЕНИЕ МАТРИЦ ===");

        if (matrix1 == null || matrix2 == null)
        {
            Console.WriteLine("Сначала создайте матрицы!");
            return;
        }

        if (cols1 != rows2)
        {
            Console.WriteLine("ОШИБКА: Невозможно умножить матрицы!");
            Console.WriteLine($"Количество столбцов первой матрицы ({cols1}) не равно количеству строк второй матрицы ({rows2})");
            return;
        }

        double[,] result = new double[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        Console.WriteLine("\nРезультат умножения:");
        PrintMatrix(result, rows1, cols2);
    }

    static void FindDeterminant()
    {
        Console.WriteLine("\n=== НАХОЖДЕНИЕ ДЕТЕРМИНАНТА ===");

        if (matrix1 == null)
        {
            Console.WriteLine("Сначала создайте матрицы!");
            return;
        }

        Console.Write("Выберите матрицу (1 или 2): ");
        string choice = Console.ReadLine();

        double[,] matrix;
        int rows, cols;

        if (choice == "1")
        {
            matrix = matrix1;
            rows = rows1;
            cols = cols1;
        }
        else
        {
            matrix = matrix2;
            rows = rows2;
            cols = cols2;
        }

        if (rows != cols)
        {
            Console.WriteLine($"ОШИБКА: Невозможно найти детерминант!");
            Console.WriteLine($"Матрица не квадратная: {rows}x{cols}");
            return;
        }

        double det = CalculateDeterminant(matrix, rows);
        Console.WriteLine($"\nДетерминант матрицы: {det:F2}");
    }

    static double CalculateDeterminant(double[,] matrix, int n)
    {
        if (n == 1)
            return matrix[0, 0];

        if (n == 2)
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        double det = 0;

        for (int j = 0; j < n; j++)
        {
            double[,] minor = GetMinor(matrix, 0, j, n);
            det += (j % 2 == 0 ? 1 : -1) * matrix[0, j] * CalculateDeterminant(minor, n - 1);
        }

        return det;
    }

    static double[,] GetMinor(double[,] matrix, int row, int col, int n)
    {
        double[,] minor = new double[n - 1, n - 1];
        int minorRow = 0;

        for (int i = 0; i < n; i++)
        {
            if (i == row) continue;
            int minorCol = 0;

            for (int j = 0; j < n; j++)
            {
                if (j == col) continue;
                minor[minorRow, minorCol] = matrix[i, j];
                minorCol++;
            }
            minorRow++;
        }

        return minor;
    }

    static void FindInverseMatrix()
    {
        Console.WriteLine("\n=== НАХОЖДЕНИЕ ОБРАТНОЙ МАТРИЦЫ ===");

        if (matrix1 == null)
        {
            Console.WriteLine("Сначала создайте матрицы!");
            return;
        }

        Console.Write("Выберите матрицу (1 или 2): ");
        string choice = Console.ReadLine();

        double[,] matrix;
        int rows, cols;

        if (choice == "1")
        {
            matrix = matrix1;
            rows = rows1;
            cols = cols1;
        }
        else
        {
            matrix = matrix2;
            rows = rows2;
            cols = cols2;
        }

        if (rows != cols)
        {
            Console.WriteLine($"ОШИБКА: Матрица не квадратная: {rows}x{cols}");
            return;
        }

        double det = CalculateDeterminant(matrix, rows);

        if (Math.Abs(det) < 0.0001)
        {
            Console.WriteLine("ОШИБКА: Детерминант равен нулю!");
            Console.WriteLine("Обратная матрица не существует.");
            return;
        }

        double[,] inverse = CalculateInverse(matrix, rows, det);
        Console.WriteLine("\nОбратная матрица:");
        PrintMatrix(inverse, rows, rows);
    }

    static double[,] CalculateInverse(double[,] matrix, int n, double det)
    {
        double[,] inverse = new double[n, n];
        double[,] cofactors = new double[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                double[,] minor = GetMinor(matrix, i, j, n);
                cofactors[i, j] = ((i + j) % 2 == 0 ? 1 : -1) * CalculateDeterminant(minor, n - 1);
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                inverse[i, j] = cofactors[j, i] / det;
            }
        }

        return inverse;
    }

    static void TransposeMatrix()
    {
        Console.WriteLine("\n=== ТРАНСПОНИРОВАНИЕ МАТРИЦЫ ===");

        if (matrix1 == null)
        {
            Console.WriteLine("Сначала создайте матрицы!");
            return;
        }

        Console.Write("Выберите матрицу (1 или 2): ");
        string choice = Console.ReadLine();

        double[,] matrix;
        int rows, cols;

        if (choice == "1")
        {
            matrix = matrix1;
            rows = rows1;
            cols = cols1;
        }
        else
        {
            matrix = matrix2;
            rows = rows2;
            cols = cols2;
        }

        double[,] transposed = new double[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                transposed[j, i] = matrix[i, j];
            }
        }

        Console.WriteLine("\nТранспонированная матрица:");
        PrintMatrix(transposed, cols, rows);
    }

    static void SolveSystemOfEquations()
    {
        Console.WriteLine("\n=== РЕШЕНИЕ СИСТЕМЫ УРАВНЕНИЙ (МЕТОД КРАМЕРА) ===");

        if (matrix1 == null)
        {
            Console.WriteLine("Сначала создайте матрицы!");
            return;
        }

        Console.WriteLine("Система вида: Ax = B");
        Console.WriteLine("Матрица A - коэффициенты, вектор B - свободные члены");

        Console.Write("Введите размерность системы (n): ");
        int n = int.Parse(Console.ReadLine());

        double[,] A = new double[n, n];
        double[] B = new double[n];

        Console.WriteLine("\nВведите матрицу коэффициентов A:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"A[{i},{j}]: ");
                A[i, j] = double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("\nВведите вектор свободных членов B:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"B[{i}]: ");
            B[i] = double.Parse(Console.ReadLine());
        }

        double detA = CalculateDeterminant(A, n);

        if (Math.Abs(detA) < 0.0001)
        {
            Console.WriteLine("\nОШИБКА: Детерминант матрицы A равен нулю!");
            Console.WriteLine("Система не имеет решения или имеет бесконечно много решений.");
            return;
        }

        double[] solution = new double[n];

        for (int i = 0; i < n; i++)
        {
            double[,] Ai = new double[n, n];
            
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col == i)
                        Ai[row, col] = B[row];
                    else
                        Ai[row, col] = A[row, col];
                }
            }

            double detAi = CalculateDeterminant(Ai, n);
            solution[i] = detAi / detA;
        }

        Console.WriteLine("\nРешение системы уравнений:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"x{i + 1} = {solution[i]:F4}");
        }
    }
}