using System;

namespace AndaForceExtensions.com.andaforce.arazect.collections.generic
{
    /// <summary>
    /// Two-dimensional array presented as one-dimensional. Good for serialization, which doesnt accept two-dimensional arrays
    /// </summary>
    /// <typeparam name="T">Data type for array</typeparam>
    public class LinearArray<T>
    {
        public T[] ArraySource { get; private set; }
        public int Width;
        public int Height;

        public LinearArray(int width, int height)
        {
            Width = width;
            Height = height;
            ArraySource = new T[width * height];
        }

        public static LinearArray<T> FromTwoDimensional(T[,] arraySource, int width, int height)
        {
            var result = new LinearArray<T>(width, height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result.Set(arraySource[i, j], j, i);
                }
            }

            return result;
        }

        public T Get(int x, int y)
        {
            CheckBorders(x, y);

            return ArraySource[x + y * Height];
        }

        public void Set(T item, int x, int y)
        {
            CheckBorders(x, y);

            ArraySource[x + y * Height] = item;
        }

        public T[,] ToTwoDimensional()
        {
            var result = new T[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result[i, j] = Get(i, j);
                }
            }

            return result;
        }


        private void CheckBorders(int x, int y)
        {
            if (x > Width || x < 0)
            {
                throw new Exception("X-coordinate is out of bounds");
            }

            if (y > Height || y < 0)
            {
                throw new Exception("Y-coordinate is out of bound");
            }
        }
    }
}