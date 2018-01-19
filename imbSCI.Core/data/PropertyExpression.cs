// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyExpression.cs" company="imbVeles" >
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
namespace imbSCI.Core.data
{
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Data.collection.nested;
    using System;
    using System.Linq;
    using System.Reflection;
    using imbSCI.Data.collection.graph;

    public class PropertyExpression:graphNode
    {
        public const String PATH_SPLITER = PropertyExpressionTools.EXPRESSION_PATH_DELIMITER;

        private String _unresolvedPart = "";
        /// <summary>
        /// Part of the expression path that left unresolved
        /// </summary>
        /// <value>
        /// The undesolved part.
        /// </value>
        public String undesolvedPart
        {
            get
            {
                if (parent == null)
                {
                    return _unresolvedPart;
                } else
                {
                    PropertyExpression pe = parent as PropertyExpression;
                    return pe.undesolvedPart;
                }
            }
            set
            {
                if (parent == null)
                {
                    _unresolvedPart = value;
                } else
                {
                    PropertyExpression pe = parent as PropertyExpression;
                    pe.undesolvedPart = value;
                }
            }
        }

        /// <summary>
        /// Parent expression node
        /// </summary>
        /// <value>
        /// The parent expression.
        /// </value>
        public PropertyExpression parentExpression
        {
            get
            {
                return parent as PropertyExpression;
            }
        }


        private PropertyExpressionStateEnum _state = PropertyExpressionStateEnum.none;
        /// <summary>
        /// State of this expression node, indicating if it was solved or not
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public PropertyExpressionStateEnum state
        {
            get
            {
                if (parentExpression == null) return _state;
                return parentExpression.state;
            }
            set
            {
                if (parentExpression == null)
                {
                    _state = value;
                } else
                {
                    parentExpression.state = value;
                }

            }
        }

        private Type _hostType ;
        /// <summary>Type of the host instance at this expression node</summary>
        public Type hostType
        {
            get
            {
                return _hostType;
            }
            protected set
            {
                _hostType = value;
                
            }
        }


        private Object _host ;
        /// <summary>Host instance at this expression node </summary>
        public Object host
        {
            get
            {
                return _host;
            }
            protected set
            {
                _host = value;
                
            }
        }


        private PropertyInfo _property ;
        /// <summary>Property information about this expression node</summary>
        public PropertyInfo property
        {
            get
            {
                return _property;
            }
            protected set
            {
                _property = value;
                
            }
        }



        /// <summary>
        /// Opposite to root -- the last child
        /// </summary>
        /// <value>
        /// The leaf.
        /// </value>
        public PropertyExpression Leaf
        {
            get
            {
                if (children.Count > 0)
                {
                    PropertyExpression pe = getFirst() as PropertyExpression;

                    
                    return pe.Leaf;
                } else
                {
                    return this;
                }
            }
        }

        /// <summary>
        /// Gets the value at this expression node
        /// </summary>
        /// <returns></returns>
        public Object getValue()
        {
            if (host == null) return null;
            if (property == null) return null;

            
           return property.GetValue(host, null);
        }

        /// <summary>
        /// Sets the value at this expression node
        /// </summary>
        /// <param name="val">The value.</param>
        public void setValue(Object val)
        {
            if (host == null) return;
            if (property == null) return;
            if (!property.CanWrite) return;

            Object vl = val.imbConvertValueSafe(property.PropertyType);

            property.SetValue(host, vl, null);
             
        }

        

        public PropertyExpression Add(String __pathPart)
        {
            Object subhost = getValue();

            

            var output = new PropertyExpression(subhost, __pathPart, this);
            
            return output;

        }
        public PropertyExpression(Object __host, String __pathPart, PropertyExpression __parent=null)
        {
            host = __host;
            if (host != null) hostType = host.GetType();
            if (hostType != null) property = hostType.GetProperty(__pathPart);
            if (property != null) name = property.Name;
            if (property != null)
            {
                if (__parent != null)
                {
                    parent = __parent;
                    if (!__parent.children.Contains(this.name))
                    {
                        __parent.children.Add(this.name, this);
                    }
                }
            }

        }
    }

}