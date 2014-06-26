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
        public int Width { get; private set; }
        public int Height { get; private set; }

        public LinearArray(int width, int height)
        {
            Width = width;
            Height = height;
            ArraySource = new T[width * height];
        }

        /// <summary>
        /// Converts Two-dimensional array to one-dimensional. First index assotiated with x, second with y
        /// </summary>
        /// <param name="arraySource"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static LinearArray<T> FromTwoDimensional(T[,] arraySource, int width, int height)
        {
            var result = new LinearArray<T>(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    result.SetItem(arraySource[x, y], x, y);
                }
            }

            return result;
        }

        public T GetItem(int x, int y)
        {
            CheckBorders(x, y);

            return ArraySource[x + y * Height];
        }

        public void SetItem(T item, int x, int y)
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
                    result[i, j] = GetItem(i, j);
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