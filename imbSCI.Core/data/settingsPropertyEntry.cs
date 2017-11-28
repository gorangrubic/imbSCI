// --------------------------------------------------------------------------------------------------------------------
// <copyright file="settingsPropertyEntry.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
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
namespace imbSCI.Core.data
{
    using imbSCI.Core.collection;
    using System;
    using System.Reflection;

    /// <summary>
    /// Jedan settings property sa svojim podacima prikaza
    /// </summary>
    public class settingsPropertyEntry : settingsMemberInfoEntry
    {
        #region --- index ------- indeks na kome se nalazi

        private Int32 _index = -1;
        /// <summary>
        /// indeks na kome se nalazi - ako je -1 onda nije kolekcija
        /// </summary>
        public Int32 index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                OnPropertyChanged("index");
            }
        }
        #endregion


        #region --- type ------- referenca prema tipu
        private Type _type;
        /// <summary>
        /// referenca prema tipu
        /// </summary>
        public Type type
        {
            get
            {

                return _type;
            }
            set
            {
                _type = value;
                relevantTypeName = _type.Name;
                OnPropertyChanged("type");
            }
        }
        #endregion
        
        

        public settingsPropertyEntry(Int32 __index, PropertyCollectionExtended pce = null)
        {
          //  var gt = __type.GetGenericArguments();
            index = __index;
        }

        public settingsPropertyEntry(ParameterInfo __par)
        {
            priority = __par.Position;
            name = __par.Name;
            type = __par.ParameterType;

            deployAttributes(__par.GetCustomAttributes(true));

        }

        /// <summary>
        /// Deklarise jedan property entry i podesava njegove parametre prikaza
        /// </summary>
        /// <param name="__pi"></param>
        public settingsPropertyEntry(MemberInfo __pi, PropertyCollectionExtended pce=null)
        {
            pi = __pi as PropertyInfo;
            type = pi.PropertyType;

            process(__pi, pce);

            if (type.IsEnum)//pi.PropertyType.IsEnum)
            {
                Array vl = Enum.GetValues(pi.PropertyType);
                foreach (Object v in vl)
                {
                    acceptableValues.Add(v);
                }
                
            } else if (type == typeof(bool))
            {
                acceptableValues.Add(true);
                acceptableValues.Add(false);
            }
        }

        #region --- pi ------- referenca prema PropertyInfo objektu

        private PropertyInfo _pi;
        /// <summary>
        /// referenca prema PropertyInfo objektu
        /// </summary>
        public PropertyInfo pi
        {
            get
            {
                return _pi;
            }
            set
            {
                _pi = value;
                OnPropertyChanged("pi");
            }
        }
        #endregion



       
        


       
    }
}
