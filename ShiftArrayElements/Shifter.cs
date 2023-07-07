namespace ShiftArrayElements
{
    public static class Shifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using <see cref="iterations"/> array for getting directions and iterations (see README.md for detailed instructions).
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="iterations">An array with iterations.</param>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">iterations array is null.</exception>
        public static void Shift(int[] source, int[] iterations)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (iterations == null)
            {
                throw new ArgumentNullException(nameof(iterations));
            }

            for (int i = 0; i < iterations.Length; i++)
            {
                int currentIteration = iterations[i];

                if (i % 2 == 0) // Even index or zero index indicates left shift iterations
                {
                    for (int j = 0; j < currentIteration; j++)
                    {
                        ShiftLeft(source);
                    }
                }
                else // Odd index indicates right shift iterations
                {
                    for (int j = 0; j < currentIteration; j++)
                    {
                        ShiftRight(source);
                    }
                }
            }

            static void ShiftLeft(int[] source)
            {
                int firstElement = source[0];
                Array.Copy(source, 1, source, 0, source.Length - 1);
                source[^1] = firstElement;
            }

            static void ShiftRight(int[] source)
            {
                int lastElement = source[^1];
                Array.Copy(source, 0, source, 1, source.Length - 1);
                source[0] = lastElement;
            }
        }
    }
}
