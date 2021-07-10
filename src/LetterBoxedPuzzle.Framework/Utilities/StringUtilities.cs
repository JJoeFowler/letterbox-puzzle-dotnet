﻿// ===============================================================================================================================================
// <copyright file="StringUtilities.cs" company="Joe Fowler">
// Copyright (c) 2021 Joe Fowler.
// Licensed under the GNU Affero General Public License v3. See LICENSE file in the project root for full license information.
// </copyright>
// ===============================================================================================================================================

namespace LetterBoxedPuzzle.Framework.Utilities
{
    using System;
    using System.Linq;

    /// <summary>
    ///     Class for string utility methods.
    /// </summary>
    public static class StringUtilities
    {
        /// <summary>
        ///     Double quote and join the given text values with a comma and space, where given array [ text1, text2, ..., text<i>N</i>
        ///     of length <i>N</i> ] would yield "'text1', 'text2', ..., 'text<i>N</i>'", where <see langword="null " /> values are replaced
        ///     by the word "null".
        /// </summary>
        /// <param name="textValues">The text values.</param>
        /// <returns>The join of each text value double-quoted and separated by a comma and a space.</returns>
        /// <exception cref="ArgumentNullException">Thrown when given a null value for the text values.</exception>
        /// <exception cref="ArgumentException">Thrown when given a null value for any text value.</exception>
        public static string QuoteJoin(params string[] textValues) =>

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            textValues switch
                {
                    null => throw new ArgumentNullException(nameof(textValues)),

                    _ when textValues.Any(x => x == null) => throw new ArgumentException($"'{nameof(textValues)}' cannot have null values."),

                    _ => $"\"{string.Join("\", \"", textValues.Select(value => value ?? "null"))}\"",
                };

        /// <summary>
        ///     Single quote and join the given characters with a comma and space, where given array [ character1, character2, ..., character<i>N</i>
        ///     of length <i>N</i> ] would yield "'character1', 'character2', ..., 'character<i>N</i>'".
        /// </summary>
        /// <param name="characters">The text values.</param>
        /// <returns>The join of each character single-quoted and separated by a comma and a space.</returns>
        /// <exception cref="ArgumentNullException">Thrown when given a null value for the characters.</exception>
        /// <exception cref="ArgumentException">Thrown when given a null value for any text value.</exception>
        public static string QuoteJoin(params char[] characters) =>
            characters switch
                {
                    null => throw new ArgumentNullException(nameof(characters)),

                    _ => $"'{string.Join("', '", characters)}'",
                };
    }
}