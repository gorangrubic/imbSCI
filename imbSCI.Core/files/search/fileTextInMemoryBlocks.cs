// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileTextInMemoryBlocks.cs" company="imbVeles" >
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
using System;
using System.Collections.Generic;
using System.Linq;
using imbSCI.Core;
using imbSCI.Core.attributes;
using imbSCI.Core.collection;
using imbSCI.Core.data;
using imbSCI.Core.enums;
using imbSCI.Core.extensions.data;
using imbSCI.Core.extensions.io;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.typeworks;
using imbSCI.Core.interfaces;
using imbSCI.Core.reporting;
using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.Core.files.search
{
    using System.Collections;
    using System.IO;

    public class fileTextInMemoryBlocks:IEnumerable<fileTextInMemoryBlockUnit>
    {


       

        private Int32 _blockSize;
        /// <summary>
        /// 
        /// </summary>
        public Int32 blockSize
        {
            get { return _blockSize; }
            protected set { _blockSize = value; }
        }

        public fileTextInMemoryBlocks()
        {

        }

        public fileTextInMemoryBlocks(String filepath, Int32 __blockSize=-1)
        {
            loadFile(filepath, __blockSize);
        }

        /// <summary>
        /// Loads the file.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="blockSize">Size of the block.</param>
        public void loadFile(String filepath, Int32 __blockSize=-1)
        {
            Int32 bl = 0;
            Int32 bi = 0;
            Int32 ln = 0;
            items.Clear();
            if (__blockSize < 0) __blockSize = fileOpsBase.standardBlockSize;
            blockSize = __blockSize;
            using (var st = File.OpenText(filepath))
            {
                while (!st.EndOfStream)
                {
                    if (items.Count() <= bi)
                    {
                        items.Add(new fileTextInMemoryBlockUnit(ln));
                    }
                    items[bi].Add(st.ReadLine());
                    if (items.Count >= blockSize)
                    {
                        bi++;
                    }
                    ln++;
                }
            }
        }

        public void saveFile(String filepath, Boolean filterEmptyLines=true)
        {

            using (var st = File.AppendText(filepath))
            {
                foreach (fileTextInMemoryBlockUnit bu in items)
                {
                    foreach (String str in bu)
                    {
                        if (!str.isNullOrEmpty())
                        {
                            st.WriteLine(str);
                        }
                    }
                }
                st.Dispose();
            }
        }


        public String this[Int32 ln]
        {
            get
            {
                Int32 i = ln % blockSize;
                Int32 bi = ln / blockSize;
                return items[bi][i];
            }
            set
            {
                Int32 i = ln % blockSize;
                Int32 bi = ln / blockSize;
                items[bi][i] = value;
            }
        }


        public IEnumerator<fileTextInMemoryBlockUnit> GetEnumerator()
        {
            return ((IEnumerable<fileTextInMemoryBlockUnit>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<fileTextInMemoryBlockUnit>)items).GetEnumerator();
        }

        private List<fileTextInMemoryBlockUnit> _items = new List<fileTextInMemoryBlockUnit>();
        /// <summary> </summary>
        protected List<fileTextInMemoryBlockUnit> items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                //OnPropertyChanged("items");
            }
        }

        
    }

}