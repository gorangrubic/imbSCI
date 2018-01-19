// --------------------------------------------------------------------------------------------------------------------
// <copyright file="aceColorEntry.cs" company="imbVeles" >
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
namespace imbSCI.Core.reporting.colors
{
    #region imbVeles using

    using System;
    using mColor = System.Windows.Media.Color;
    using gColor = System.Drawing.Color;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;
    using imbSCI.Data;
    using imbSCI.Core.extensions.text;

    #endregion

    /// <summary>
    /// GUI framework - data model to save color definition
    /// </summary>
    /// <seealso cref="aceCommonTypes.primitives.imbBindable" />
    /// <seealso cref="aceCommonTypes.interfaces.IHasDescribeMethod" />
    public class aceColorEntry : imbBindable, IHasDescribeMethod
    {
        #region --- baseColorHex ------- Bindable property

        private String _baseColorHex;

        /// <summary>
        /// Bindable property
        /// </summary>
        public String baseColorHex
        {
            get { return _baseColorHex; }
            set
            {
                _baseColorHex = value;
                OnPropertyChanged("baseColorHex");
            }
        }

        #endregion

        #region --- valueDelta ------- Bindable property

        private float _valueDelta;

        /// <summary>
        /// Bindable property
        /// </summary>
        public float valueDelta
        {
            get { return _valueDelta; }
            set
            {
                _valueDelta = value;
                OnPropertyChanged("valueDelta");
            }
        }

        #endregion

        #region --- saturationDelta ------- Bindable property

        private float _saturationDelta;

        /// <summary>
        /// Bindable property
        /// </summary>
        public float saturationDelta
        {
            get { return _saturationDelta; }
            set
            {
                _saturationDelta = value;
                OnPropertyChanged("saturationDelta");
            }
        }

        #endregion

        #region --- hueDelta ------- Bindable property

        private Int32 _hueDelta;

        /// <summary>
        /// Bindable property
        /// </summary>
        public Int32 hueDelta
        {
            get { return _hueDelta; }
            set
            {
                _hueDelta = value;
                OnPropertyChanged("hueDelta");
            }
        }

        #endregion

        #region ----------- Boolean [ isForeColor ] -------  [Da li da]

        private Boolean _isForeColor = false;

        public Boolean isForeColor
        {
            get { return _isForeColor; }
            set
            {
                _isForeColor = value;
                OnPropertyChanged("isForeColor");
            }
        }

        #endregion

        public aceColorEntry()
        {
        }

        public aceColorEntry(String __baseColorHex, float __valueDelta = 0, float __saturationDelta = 0,
                          Int32 __hueDelta = 0,
                          Boolean __isForeColor = false, Object __color = null)
        {
            baseColorHex = __baseColorHex;
            valueDelta = __valueDelta;
            saturationDelta = __saturationDelta;
            hueDelta = __hueDelta;
            isForeColor = __isForeColor;
            if (__color != null)
            {
                color = (mColor) __color;
            }
            _path = aceColorConverts.makePath(baseColorHex, valueDelta, saturationDelta, hueDelta, isForeColor);
        }

        #region --- path ------- putanja - unique ID

        private String _path;

        /// <summary>
        /// putanja - unique ID
        /// </summary>
        public String path
        {
            get
            {
                if (String.IsNullOrEmpty(_path))
                {
                    _path = aceColorConverts.makePath(baseColorHex, valueDelta, saturationDelta, hueDelta,
                                                         isForeColor);
                }
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged("path");
            }
        }

        #endregion

        #region --- color ------- Wrappovan color objekat

        private mColor _color;

        /// <summary>
        /// Wrappovan color objekat
        /// </summary>
        public mColor color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("color");
            }
        }

        #endregion

        #region Implementation of IHasDescribeMethod

        public string describe(int tabInsert)
        {
            return describe((string) "\t".Repeat(tabInsert));
        }

        public string statusLine
        {
            get { return imbSciStringExtensions.add(label, String.Format(" delta: h:{0} s:{1} v:{2}", hueDelta, saturationDelta, valueDelta)); }
        }

        public string label
        {
            get { return baseColorHex + " (" + color.ToString() + ")"; }
        }

        public string describe(string __prefix = null)
        {
            return imbSciStringExtensions.add(__prefix, statusLine) +  " isForeColor: " + isForeColor.ToString();
            //throw new NotImplementedException();
        }

        #endregion
    }
}