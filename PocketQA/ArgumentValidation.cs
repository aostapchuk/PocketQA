using System;
using System.Collections.Generic;

namespace PocketQA
{
    /// <summary>
    /// Helps with validating the arguments to methods by providing methods that when called will throw an 
    /// <see cref="ArgumentException"/> or a class derived from it if a value does not match certain expectations.
    /// </summary>
    public static class ArgumentValidation
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if a collection is <c>null</c> and 
        /// <see cref="ArgumentException"/> if it is empty.
        /// </summary>
        /// <param name="toValidate"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentNullException"><paramref name="toValidate"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="toValidate"/> is empty.</exception>
        public static void ThrowIfNullOrEmpty<TContained>(IList<TContained> toValidate, string argumentName)
        {
            ThrowIfNull(toValidate, argumentName);

            if (toValidate.Count == 0)
            {
                var message = $"{argumentName} cannot be empty.";

                throw new ArgumentException(message, argumentName);
            }
        }

        /// <summary>
        /// Throws an ArgumentNullException if the object to validate is <c>null</c>.
        /// </summary>
        /// <param name="toValidate"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentNullException"><paramref name="toValidate"/> is <c>null</c>.</exception>
        public static void ThrowIfNull<T>(T toValidate, string argumentName)
            where T : class
        {
            if (toValidate == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the object to validate is <c>null</c> and 
        /// <see cref="ArgumentException"/> if it is an empty or whitespace string.
        /// </summary>
        /// <param name="toValidate"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentNullException"><paramref name="toValidate"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="toValidate"/> is an empty or whitespace string.</exception>
        public static void ThrowIfNullOrWhiteSpace(string toValidate, string argumentName)
        {
            ThrowIfNull(toValidate, argumentName);

            if (toValidate.Trim() == string.Empty)
            {
                throw new ArgumentException($"The value of {argumentName} cannot be empty.", argumentName);
            }
        }

        public static void ThrowIfNullOrEmpty(byte[] toValidate, string argumentName)
        {
            ThrowIfNull(toValidate, argumentName);

            if (toValidate.Length == 0)
            {
                throw new ArgumentException($"The value of {argumentName} cannot be empty.", argumentName);
            }
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value is not defined within the specified enum
        /// </summary>
        /// <param name="toValidate"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentException"><paramref name="toValidate"/> is not defined within the specified enum.</exception>
        public static void ThrowIfEnumIsNotDefined<T>(T toValidate, string argumentName)
        {
            if (!Enum.IsDefined(typeof(T), toValidate))
            {
                throw new ArgumentException($"The value '{toValidate}' is not expected for Enum of type '{typeof(T).Name}'", argumentName);
            }
        }

        public static void ThrowIfNegative(int toValidate, string argumentName)
        {
            if (toValidate < 0)
            {
                throw new ArgumentOutOfRangeException($"The value of {argumentName} cannot be negative.", argumentName);
            }
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the value is null or has default value
        /// </summary>
        public static void ThrowIfDefault<T>(T value, string argumentName)
        {
            if (value == null || value.Equals(default(T)))
            {
                throw new ArgumentOutOfRangeException($"The value of {argumentName} should be initialized.", argumentName);
            }
        }
    }
}
