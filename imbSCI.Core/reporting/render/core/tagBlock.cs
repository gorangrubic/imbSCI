namespace imbSCI.Core.reporting.render.core
{
    using imbSCI.Core.extensions.text;
    using imbSCI.Data;
    using imbSCI.Data.interfaces;
    using System;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="imbSCI.Data.interfaces.IObjectWithNameAndDescription" />
    public class tagBlock : IObjectWithNameAndDescription
    {


        private Object _meta;
        /// <summary>
        /// Custom object related to the block
        /// </summary>
        public Object meta
        {
            get { return _meta; }
            set { _meta = value; }
        }



        private Int32 _count = 0;

        /// <summary>
        /// 
        /// </summary>
        public Int32 count
        {
            get { return _count; }
            set { _count = value; }
        }

        public Int32 depth
        {
           get
            {
                if (parent == null)
                {
                    return 0;
                }
                else
                {
                    return parent.depth + 1;
                }
            }
        }

        public String getTitle(Boolean includeParent)
        {
            String output = getTitlePrefix(includeParent);

            return output.add(name, " ");
        }

        public String getTitlePrefix(Boolean includeParent=true)
        {

            String output = "";

            output = count.toNumberedListPrefix(depth, 3);
            if (includeParent)
            {
                if (parent != null)
                {
                    output = parent.getTitlePrefix().add(output, ".");
                }
            }

            return output;
        }

        public tagBlock(String __tag, String __name, String __description, tagBlock __parent)
        {
            tag = __tag;
            name = __name;
            description = __description;
            parent = __parent;
        }

        private tagBlock _parent;
        /// <summary>
        /// 
        /// </summary>
        public tagBlock parent
        {
            get { return _parent; }
            protected set { _parent = value; }
        }


        private String _tag;
        /// <summary>
        /// 
        /// </summary>
        public String tag
        {
            get { return _tag; }
            protected set { _tag = value; }
        }

        private String _name;
        /// <summary>
        /// 
        /// </summary>
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }


        private String _description;
        /// <summary>
        /// 
        /// </summary>
        public String description
        {
            get { return _description; }
            set { _description = value; }
        }


    }
}
