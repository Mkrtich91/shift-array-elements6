namespace ShiftArrayElements
{
    public static class EnumShifter
    {
        /// <summary>
        /// Shifts elements in a <see cref="source"/> array using directions from <see cref="directions"/> array, one element shift per each direction array element.
        /// </summary>
        /// <param name="source">A source array.</param>
        /// <param name="directions">An array with directions.</param>
        /// <exception cref="ArgumentNullException">source array is null.</exception>
        /// <exception cref="ArgumentNullException">directions array is null.</exception>
        /// <exception cref="InvalidOperationException">direction array contains an element that is not <see cref="Direction.Left"/> or <see cref="Direction.Right"/>.</exception>
        public static void Shift(int[] source, Direction[] directions)
        {
            if (source == null)
            {
            throw new ArgumentNullException(nameof(source));
            }

            if (directions == null)
            {
                throw new ArgumentNullException(nameof(directions));
            }

            for (int i = 0; i < directions.Length; i++)
            {
                Direction currentDirection = directions[i];

                switch (currentDirection)
                {
                    case Direction.Left:
                        ShiftLeft(source);
                        break;

                    case Direction.Right:
                        ShiftRight(source);
                        break;

                    default:
                        throw new InvalidOperationException($"Incorrect {currentDirection} enum value.");
                }
            }
        }

        private static void ShiftLeft(int[] source)
        {
            int temp = source[0];

            for (int i = 0; i < source.Length - 1; i++)
            {
                source[i] = source[i + 1];
            }

            source[^1] = temp;
        }

        private static void ShiftRight(int[] source)
        {
            int temp = source[^1];

            for (int i = source.Length - 1; i > 0; i--)
            {
                source[i] = source[i - 1];
            }

            source[0] = temp;
        }
    }
}
