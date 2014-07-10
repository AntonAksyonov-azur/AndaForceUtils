using System;

namespace AndaForceUtils.Variables.Extension
{
    public static class IsValueBetween
    {
        /// <summary>
        /// Проверяет попадание класса, реализующего интерефейс IComparable, в диапазон значений
        /// Обе границы будут включены
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="min">Нижняя граница для сравнения</param>
        /// <param name="max">Верхняя граница для сравнения</param>
        /// <returns>
        /// true, если значение value находится между min и max
        /// false, если значнеие value находится вне диапазона
        /// </returns>
        public static bool BetweenII<T>(this T value, T min, T max) where T : IComparable
        {
            //(min.CompareTo(value) <= 0) && (value.CompareTo(max) <= 0);
            return (value.CompareTo(min) >= 0) && (value.CompareTo(max) <= 0);
        }

        /// <summary>
        /// Проверяет попадание класса, реализующего интерефейс IComparable, в диапазон значений
        /// Обе границы будут исключены
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="min">Нижняя граница для сравнения</param>
        /// <param name="max">Верхняя граница для сравнения</param>
        /// <returns>
        /// true, если значение value находится между min и max
        /// false, если значнеие value находится вне диапазона
        /// </returns>
        public static bool BetweenEE<T>(this T value, T min, T max) where T : IComparable
        {
            return (value.CompareTo(min) > 0) && (value.CompareTo(max) < 0);
        }

        /// <summary>
        /// Проверяет попадание класса, реализующего интерефейс IComparable, в диапазон значений
        /// Нижняя граница будет включена, тогда как верхняя исключена из диапазона
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="min">Нижняя граница для сравнения</param>
        /// <param name="max">Верхняя граница для сравнения</param>
        /// <returns>
        /// true, если значение value находится между min и max
        /// false, если значнеие value находится вне диапазона
        /// </returns>
        public static bool BetweenIE<T>(this T value, T min, T max) where T : IComparable
        {
            return (value.CompareTo(min) >= 0) && (value.CompareTo(max) < 0);
        }

        /// <summary>
        /// Проверяет попадание класса, реализующего интерефейс IComparable, в диапазон значений
        /// Нижняя граница будет исключена, тогда как верхняя включена в диапазон
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="min">Нижняя граница для сравнения</param>
        /// <param name="max">Верхняя граница для сравнения</param>
        /// <returns>
        /// true, если значение value находится между min и max
        /// false, если значнеие value находится вне диапазона
        /// </returns>
        public static bool BetweenEI<T>(this T value, T min, T max) where T : IComparable
        {
            return (value.CompareTo(min) > 0 && value.CompareTo(max) <= 0);
        }
    }
}