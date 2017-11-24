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