using System;
using System.Collections.Generic;

namespace MatrixManipulations
{
    /// <summary>
    /// Matrix manipulation.
    /// </summary>
    public static class MatrixExtension
    {
        /// <summary>
        /// Method fills the matrix with natural numbers, starting from 1 in the top-left corner,
        /// increasing in an inward, clockwise spiral order.
        /// </summary>
        /// <param name="size">Matrix order.</param>
        /// <returns>Filled matrix.</returns>
        /// <exception cref="ArgumentException">Throw ArgumentException, if matrix order less or equal zero.</exception>
        /// <example> size = 3
        ///     1 2 3
        ///     8 9 4
        ///     7 6 5.
        /// </example>
        /// <example> size = 4
        ///     1  2  3  4
        ///     12 13 14 5
        ///     11 16 15 6
        ///     10 9  8  7.
        /// </example>
        #pragma warning disable CA1814 // By condition, a multidimensional array is required
        public static int[,] GetMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Size of matrix '{size}' cannot be less or equal zero.");
            }

            if (size > Math.Sqrt(int.MaxValue))
            {
                throw new ArgumentException("Size is too big");
            }

            int[,] result = new int[size, size];

            int offset = 0;
            int itemCounter = 1;
            int currentSide = size;

            while (offset < (size / 2.0))
            {
                // top
                for (int i = 0; i < currentSide; i++)
                {
                    result[offset, offset + i] = itemCounter;
                    itemCounter++;
                }

                // right
                for (int i = 0; i < currentSide - 2; i++)
                {
                    result[1 + offset + i, size - 1 - offset] = itemCounter;
                    itemCounter++;
                }

                // bottom
                if ((size / 2) - offset > 0)
                {
                    for (int i = 0; i < currentSide; i++)
                    {
                        result[size - 1 - offset, size - 1 - i - offset] = itemCounter;
                        itemCounter++;
                    }
                }

                // left
                for (int i = 0; i < currentSide - 2; i++)
                {
                    result[size - 2 - offset - i, offset] = itemCounter;
                    itemCounter++;
                }

                offset++;
                currentSide -= 2;
            }

            return result;
        }
    }
}