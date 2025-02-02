﻿
namespace Lab1_program
{
    internal class MyObject
    {
        public float[,] verticesList = {    // Вершины фигуры
            // Передняя часть буквы
            {0,0,0,1},      // 0
            {1,0,0,1},      // 1
            {1,2,0,1},      // 2
            {2,0,0,1},      // 3
            {3,0,0,1},      // 4
            {1.5f,3,0,1},   // 5
            {3,6,0,1},      // 6
            {2,6,0,1},      // 7
            {1,4,0,1},      // 8
            {1,6,0,1},      // 9
            {0,6,0,1},      // 10
            // Задняя часть буквы
            {0,0,1,1},      // 11
            {1,0,1,1},      // 12
            {1,2,1,1},      // 13
            {2,0,1,1},      // 14
            {3,0,1,1},      // 15
            {1.5f,3,1,1},   // 16
            {3,6,1,1},      // 17
            {2,6,1,1},      // 18
            {1,4,1,1},      // 19
            {1,6,1,1},      // 20
            {0,6,1,1},      // 21
        };
        
        public List<int[]> edgesList = [];  // Массив с рёбрами

        public MyObject()
        {
            // Создание рёбер
            for (int i = 0; i < 10; i++)
            {
                edgesList.Add([i, i + 1]);
                edgesList.Add([i, i + 11]);
                edgesList.Add([i + 11, i + 12]);
            }
            edgesList.Add([0, 10]);
            edgesList.Add([11, 21]);
            edgesList.Add([10, 21]);
        }
    }
}
