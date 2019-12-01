﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstructorIQ.Core.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/>
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts an IEnumerable of values to a delimited string.
        /// </summary>
        /// <typeparam name="T">
        /// The type of objects to delimit.
        /// </typeparam>
        /// <param name="values">
        /// The IEnumerable string values to convert.
        /// </param>
        /// <returns>
        /// A delimited string of the values.
        /// </returns>
        public static string ToDelimitedString<T>(this IEnumerable<T> values)
        {
            return ToDelimitedString<T>(values, ",");
        }

        /// <summary>
        /// Converts an IEnumerable of values to a delimited string.
        /// </summary>
        /// <typeparam name="T">
        /// The type of objects to delimit.
        /// </typeparam>
        /// <param name="values">
        /// The IEnumerable string values to convert.
        /// </param>
        /// <param name="delimiter">
        /// The delimiter.
        /// </param>
        /// <returns>
        /// A delimited string of the values.
        /// </returns>
        public static string ToDelimitedString<T>(this IEnumerable<T> values, string delimiter)
        {
            var sb = new StringBuilder();
            foreach (var i in values)
            {
                if (sb.Length > 0)
                    sb.Append(delimiter ?? ",");
                sb.Append(i.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts an IEnumerable of values to a delimited string.
        /// </summary>
        /// <param name="values">The IEnumerable string values to convert.</param>
        /// <returns>A delimited string of the values.</returns>
        public static string ToDelimitedString(this IEnumerable<string> values)
        {
            return ToDelimitedString(values, ",");
        }

        /// <summary>
        /// Converts an IEnumerable of values to a delimited string.
        /// </summary>
        /// <param name="values">The IEnumerable string values to convert.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns>A delimited string of the values.</returns>
        public static string ToDelimitedString(this IEnumerable<string> values, string delimiter)
        {
            return ToDelimitedString(values, delimiter, null);
        }

        /// <summary>
        /// Converts an IEnumerable of values to a delimited string.
        /// </summary>
        /// <param name="values">The IEnumerable string values to convert.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="escapeDelimiter">A delegate used to escape the delimiter contained in the value.</param>
        /// <returns>A delimited string of the values.</returns>
        public static string ToDelimitedString(this IEnumerable<string> values, string delimiter, Func<string, string> escapeDelimiter)
        {
            var sb = new StringBuilder();
            foreach (var value in values)
            {
                if (sb.Length > 0)
                    sb.Append(delimiter);

                var v = escapeDelimiter != null
                    ? escapeDelimiter(value ?? string.Empty)
                    : value ?? string.Empty;

                sb.Append(v);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts an IEnumerable to an index value.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="items">The items to index.</param>
        /// <returns></returns>
        public static IEnumerable<IndexedValue<TValue>> ToIndexedList<TValue>(this IEnumerable<TValue> items)
        {
            int index = 0;
            return items.Select(item => new IndexedValue<TValue>(index++, item));
        }

        /// <summary>
        /// Converts an IEnumerable to a selection list.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="items">The items to use.</param>
        /// <returns></returns>
        public static IEnumerable<SelectionValue<TValue>> ToSelectionList<TValue>(this IEnumerable<TValue> items)
        {
            int index = 0;
            return items.Select(item => new SelectionValue<TValue>(index++, item));
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            int skip = Math.Max(pageSize * (pageNumber - 1), 0);
            return query.Skip(skip).Take(pageSize);
        }

    }

    public class IndexedValue<T>
    {
        public IndexedValue(int index, T value)
        {
            Index = index;
            Value = value;
        }

        public int Index { get; }

        public T Value { get; }
    }

    public class SelectionValue<T>
    {
        public SelectionValue(int index, T value)
        {
            Index = index;
            Value = value;
        }

        public int Index { get; }

        public T Value { get; }

        public bool Selected { get; set; }
    }

}
