﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbEnumExtendBase.cs" company="imbVeles" >
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
namespace imbSCI.Core.extensions.enumworks
{
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Data;
    #region imbVeles using

    using System;

    #endregion

    /// <summary>
    /// Ekstenzije za rad sa enum tipovima
    /// </summary>
    public static class imbEnumExtendBase
    {


        /// <summary>
        /// Converts to number
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public static Int32 ToInt32(this Enum target)
        {

            return Convert.ToInt32(target); // as Int32;
        }

        /// <summary>
        /// Returns distance in <see cref="Int32"/> between <c>from</c> <see cref="Enum"/> and <c>to</c> value.
        /// </summary>
        /// <param name="from">Enum to start measuring distance from.</param>
        /// <param name="to">Enum value to measure distace to.</param>
        /// <returns>Int32 distance between options <c>from</c> and <c>to</c></returns>
        public static Int32 ToInt32From(this Enum from, Enum to)
        {


            return Convert.ToInt32(to) - Convert.ToInt32(from); // as Int32;
        }



        /// <summary>
        /// Vraca enum member path koji moze da se koristi za preuzimanje enumeracije i njenog tipa
        /// </summary>
        /// <param name="enumSource"></param>
        /// <param name="includeMemberName">Ako je false - onda ce prvo pretpostaviti da je enumSource ustvari Type</param>
        /// <returns></returns>
        public static String getEnumMemberPath(this Object enumSource, Boolean includeMemberName = true,
                                               String nestedInsert = "_", Boolean useFullName = false)
        {
            Type msgType = null;

            if (includeMemberName)
            {
                msgType = enumSource.GetType();
            }
            else
            {
                msgType = enumSource as Type;
                if (msgType == null)
                {
                    msgType = enumSource.GetType();
                }
            }
            String output = "";

            if (msgType.IsEnum)
            {
                if (useFullName)
                {
                    output = msgType.FullName.getCleanTypeFullName();
                }
                else
                {
                    if (msgType.IsNested)
                    {
                        output = msgType.DeclaringType.Name + nestedInsert + msgType.Name;
                    }
                    else
                    {
                        output = msgType.Name;
                    }
                }


                if (includeMemberName) output += "." + enumSource.ToString();
            }
            else
            {
                throw new ArgumentOutOfRangeException("enumSource", "it shouldn't arrive here - check what's up"); // new aceGeneralException("Nije ovo bre Enum member sto si prosledio!");
            }
            return output;
        }


        /// <summary>
        /// Generates default list in string format out of Type
        /// </summary>
        /// <param name="EnumType">Enumeration type</param>
        /// <returns></returns>
        public static String getEnumAsDefaultsList(this Type EnumType)
        {
            String output = "";
            string[] names = Enum.GetNames(EnumType);
            int a = 0;
            foreach (String item in names)
            {
                output = output + a.ToString() + "|" + names[a] + ";";
                a++;
            }
            return output;
        }

        public static Object getEnumByEnum(this Type EnumType, Object otherEnum)
        {
            String name = otherEnum.ToString();
            if (EnumType == null) return null;
            return Enum.Parse(EnumType, name);
        }

        /// <summary>
        /// Na osnovu zadatog tipa i imena vraća instancu enumeracijije. Ako ne može da pronađe po imenu onda vraća prvu
        /// </summary>
        /// <param name="EnumType">Tip koji je enumeracija</param>
        /// <param name="name">String ime enumeration člana</param>
        /// <returns>Enumeracija - instanca</returns>
        public static object getEnumByName(this Type EnumType, String name, Object valueOnFail = null)
        {
            Object output = new object();
            if (imbSciStringExtensions.isNullOrEmptyString(name)) return valueOnFail;
            try
            {
                output = Enum.Parse(EnumType, name);
            }
            catch
            {
                if (valueOnFail == null)
                {
                    Array arr = Enum.GetValues(EnumType);
                    output = arr.GetValue(0);
                }
                else
                {
                    output = valueOnFail;
                }
            }
            return output;
        }

       
    }
}