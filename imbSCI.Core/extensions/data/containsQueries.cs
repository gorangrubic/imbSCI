﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Core.extensions.data
{
    public static class containsQueries
    {
        public static Boolean ContainsOnly(this IList flags, params Object[] tests)
        {

            foreach (Object f in flags)
            {
                if (!tests.Contains(f)) return false;
            }
            return true;
        }


        //public static Boolean ContainsAll(this IList flags, params Object[] tests)
        //{

        //    foreach (Object f in tests)
        //    {
        //        if (!flags.Contains(f)) return false;
        //    }
        //    return true;
        //}






        /// <summary>
        /// Logical sum of criterias. All must be true to pass.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="criteria">The criteria.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified criteria]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean Contains<T>(this IList<T> list, params T[] criteria)
        {
            foreach (T t in criteria)
            {
                if (!list.Contains(t))
                {
                    return false;
                }
            }
            return true;

        }


        /// <summary>
        /// Determines whether the <c>target</c> contains any of specified needles 
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="needles">The needles.</param>
        /// <returns>
        ///   <c>true</c> if the specified needles contains any; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean ContainsAny(this IList target, IEnumerable needles)
        {

            foreach (Object needle in needles)
            {
                if (target.Contains(needle))
                {
                    return true;
                }
            }
            return false;
        }


        public static Boolean ContainsAny(this IList target, IEnumerable needles, out Object match)
        {

            foreach (Object needle in needles)
            {

                if (target.Contains(needle))
                {
                    match = needle;
                    return true;
                }
            }
            match = null;
            return false;
        }

        public static Boolean ContainsAll(this IList target, params Object[] needles)
        {
            Boolean output = true;
            foreach (Object needle in needles)
            {

                if (!target.Contains(needle))
                {
                    return false;
                }
            }
            return true;
        }


        public static Boolean ContainsAll(this IList target, IEnumerable needles)
        {
            Boolean output = true;
            foreach (Object needle in needles)
            {


                if (!target.Contains(needle))
                {
                    return false;
                }
            }
            return true;
        }

        public static Boolean ContainsOneOrMore(this IList flags, params Object[] tests)
        {

            foreach (Object f in flags)
            {
                if (tests.Contains(f)) return true;
            }
            return false;
        }

    }
}