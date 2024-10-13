namespace Lab1_program
{
    internal class ObjectTransformation
    {
        // Умножение матриц
        private float[,] multiplyMatrix(float[,] matrixA, float[,] matrixB)
        {
            float[,] result = new float[matrixA.GetLength(0), matrixB.GetLength(1)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    for (int k = 0; k < matrixB.GetLength(0); k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            return result;
        }

        // Проецирование объекта на экран с помощью кабинетной проекции
        public float[,] proectionObjectOnScreen(float[,] matrix, float proectionTick = 0)
        {
            double alpha = 45;
            return multiplyMatrix(
                matrix, 
                new float[,]
                {
                    { 1, 0, 0, 0},
                    { 0, -1, 0, 0},
                    { -(float)(Math.Cos(alpha))/2 * (1-proectionTick), (float)(Math.Sin(alpha))/2 * (1-proectionTick), 1, -1f/600f * proectionTick},
                    { 0, 0, 1, 1}
                }
            );
        }

        // Мастшабирование объекта
        public float[,] dilatationObject(float[,] matrix, float size)
        {
            return multiplyMatrix(
                matrix, 
                new float[,] {
                    { size, 0, 0, 0},
                    { 0, size, 0, 0 },
                    { 0, 0, size, 0 },
                    { 0, 0, 0, 1 }
                }
            );
        }

        // Переместить объект
        public float[,] moveObject(float[,] matrix, float x = 0, float y = 0, float z = 0)
        {
            return multiplyMatrix(
                matrix,
                new float[,] {
                    { 1, 0, 0, 0},
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { x, y, z, 1 }
                }
            );
        }

        // Повернуть объект по оси X
        public float[,] rotateObjectByAxisX(float[,] matrix, float angle)
        {
            float radians = angle * (MathF.PI / 180);
            return multiplyMatrix(
                matrix,
                new float[,] {
                    { 1, 0, 0, 0},
                    { 0, (float)(Math.Cos(radians)), (float)(Math.Sin(radians)), 0 },
                    { 0, -(float)(Math.Sin(radians)), (float)(Math.Cos(radians)), 0 },
                    { 0, 0, 0, 1 }
                }
            );
        }

        // Повернуть объект по оси Y
        public float[,] rotateObjectByAxisY(float[,] matrix, float angle)
        {
            float radians = angle * (MathF.PI / 180);
            return multiplyMatrix(
                matrix,
                new float[,] {
                    { (float)(Math.Cos(radians)), 0, -(float)(Math.Sin(radians)), 0},
                    { 0, 1, 0, 0 },
                    { (float)(Math.Sin(radians)), 0, (float)(Math.Cos(radians)), 0 },
                    { 0, 0, 0, 1 }
                }
            );
        }

        // Повернуть объект по оси Z
        public float[,] rotateObjectByAxisZ(float[,] matrix, float angle)
        {
            float radians = angle * (MathF.PI / 180);
            return multiplyMatrix(
                matrix,
                new float[,] {
                    { (float)(Math.Cos(radians)), (float)(Math.Sin(radians)), 0, 0},
                    { -(float)(Math.Sin(radians)), (float)(Math.Cos(radians)), 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                }
            );
        }
    }
}
