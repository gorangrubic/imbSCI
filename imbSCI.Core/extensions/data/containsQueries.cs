﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="containsQueries.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace imbSCI.Core.extensions.data
{
    public enum containsQueryTypeEnum
    {
        ContainsOnly,
        ContainsAny,
        ContainsAll,
        

    }


    public static class containsQueries
    {
        public static Boolean ContainsByEnum(this IList flags, Object[] needles, containsQueryTypeEnum type)
        {
            switch (type)
            {
                case containsQueryTypeEnum.ContainsAll:
                    return flags.ContainsAll(needles);
                    break;
                default:
                case containsQueryTypeEnum.ContainsAny:
                    return flags.ContainsAny(needles);
                    break;

                case containsQueryTypeEnum.ContainsOnly:
                    return flags.ContainsOnly(needles);
                    break;
                
            }
        }


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
