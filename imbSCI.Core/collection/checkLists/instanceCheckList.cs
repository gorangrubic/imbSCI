// --------------------------------------------------------------------------------------------------------------------
// <copyright file="instanceCheckList.cs" company="imbVeles" >
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
// Author: Goran Grubi?
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Core.collection.checkLists
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Instance based check list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{T, System.Boolean}}" />
    public class instanceCheckList<T>:IEnumerable<KeyValuePair<T, bool>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="instanceCheckList{T}"/> class.
        /// </summary>
        /// <param name="allowedValues">The allowed values.</param>
        public instanceCheckList(IEnumerable<T> allowedValues)
        {
            AddAllowValues(allowedValues);
        }


        /// <summary>
        /// Gets the percentage score: ratio between: score and count
        /// </summary>
        /// <returns></returns>
        public Double GetPercentageScore()
        {
            if (items.Count == 0) return 0.0F;
            Double output = Convert.ToDouble(GetScore());

            return output / items.Count;
        }



        /// <summary>
        /// Gets the score: number of <c>true</c> values
        /// </summary>
        /// <returns></returns>
        public Int32 GetScore()
        {
            Int32 output = 0;
            foreach (T vl in items.Keys)
            {
                if (items[vl]) output++;
            }
            return output;
        }

        /// <summary>
        /// Sets the value to <c>checkState</c> for specified key
        /// </summary>
        /// <param name="vl">The vl.</param>
        /// <param name="checkState">if set to <c>true</c> [check state].</param>
        /// <param name="logic">The logic.</param>
        /// <param name="expandAllow">if set to <c>true</c> [expand allow].</param>
        /// <returns></returns>
        public Boolean Set(T vl, Boolean checkState, checkListLogic logic = checkListLogic.OR, Boolean expandAllow=false)
        {
            if (!items.ContainsKey(vl))
            {
                if (expandAllow) items.Add(vl, checkState);
            } else
            {
                switch (logic)
                {
                    case checkListLogic.AND:
                        items[vl] = items[vl] && checkState;
                        break;
                    case checkListLogic.NOR:
                        items[vl] = !(items[vl] || checkState);
                        break;
                    case checkListLogic.NOT:
                        items[vl] = items[vl] && !checkState;
                        break;
                    case checkListLogic.OR:
                        items[vl] = items[vl] && checkState;
                        break;
                }
            }
            return items[vl];
        }

        /// <summary>
        /// Sets the values specified according to <c>check state</c>
        /// </summary>
        /// <param name="testValues">The test values.</param>
        /// <param name="checkState">if set to <c>true</c> [check state].</param>
        /// <param name="logic">The logic.</param>
        public void Set(IEnumerable<T> testValues, Boolean checkState, checkListLogic logic = checkListLogic.AND)
        {
            foreach (T vl in testValues)
            {
                if (items.ContainsKey(vl))
                {
                    Set(vl, checkState, logic);
                  
                }
            }
        }


        /// <summary>
        /// Returns instances that have TRUE value in the list
        /// </summary>
        /// <param name="testValues">The test values.</param>
        /// <param name="logic">The logic.</param>
        /// <returns></returns>
        public List<T> Check(IEnumerable<T> testValues)
        {
            List<T> output = new List<T>();

            foreach (T vl in testValues)
            {
                if (items.ContainsKey(vl))
                {
                    if (items[vl]) output.Add(vl);

                }
            }
            return output;
        }

        /// <summary>
        /// Adds the allow values.
        /// </summary>
        /// <param name="allowedValues">The allowed values.</param>
        /// <returns></returns>
        public Int32 AddAllowValues(IEnumerable<T> allowedValues)
        {
            Int32 c = 0;

            foreach(T av in allowedValues)
            {
                if (!items.ContainsKey(av))
                {
                    c++;
                    items.Add(av, false);
                }
            }
            return c;
        }

        public IEnumerator<KeyValuePair<T, bool>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<T, bool>>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<T, bool>>)items).GetEnumerator();
        }

        private Dictionary<T, Boolean> _items = new Dictionary<T, Boolean>();
        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<T, Boolean> items
        {
            get
            {
                //if (_items == null)_items = new Dictionary<T, Boolean>();
                return _items;
            }
            set { _items = value; }
        }

    }

}