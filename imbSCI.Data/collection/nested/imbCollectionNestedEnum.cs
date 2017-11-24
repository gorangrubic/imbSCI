namespace imbSCI.Data.collection.nested
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Two dimensional collection where categories (X or the first axis) and options (Y or the second axis) are <see cref="Enum"/> types.  
    /// </summary>
    /// <remarks>
    /// <para>The collection automatically creates "room" for all members defined at the generic <see cref="Enum">s</para>
    /// <paga>While based on the <see cref="Dictionary{TKey, TValue}"/>, this collection is thread-safe because complete 2D structure is built in advance</para>
    /// </remarks>
    /// <typeparam name="TC">Enum type that enumerates categories i.e. the first axis</typeparam>
    /// <typeparam name="TI">Enum type that enumerates particular options</typeparam>
    /// <typeparam name="TIV">The class of value to be stored in this collection</typeparam>
    public class imbCollectionNestedEnum<TC, TI, TIV> : Dictionary<TC, Dictionary<TI, TIV>>
    {
        public imbCollectionNestedEnum()
        {
            TIV defaultValue = default(TIV); // this.GetDefaultValue<TIV>();
            deploy(defaultValue);
        }

        /// <summary>
        /// Konstruktor koji postavlja podrazumevanu vrednost na svako polje
        /// </summary>
        /// <param name="defaultValue"></param>
        public imbCollectionNestedEnum(TIV defaultValue)
        {
            deploy(defaultValue);
        }

        /// <summary>
        /// Defines the specified value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="category">The category.</param>
        /// <param name="forItem">For item.</param>
        public void define(TIV val, TC category, params TI[] forItem)
        {
            foreach (TI ti in forItem)
            {
                this[category][ti] = val;
            }
        }

        /// <summary>
        /// Sets fields of all categories  <c>val</c>
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="forItem">For item.</param>
        public void define(TIV val, params TI[] forItem)
        {
            foreach (TC ct in categories)
            {
                foreach (TI ti in forItem)
                {
                    this[ct][ti] = val;
                }
            }
        }

        protected void deploy(TIV defaultValue)
        {
            if (typeof (TI) == typeof (System.Enum))
            {
                return;
            }

            IList cats = Enum.GetValues(typeof (TC)) as IList;
            foreach (TC c in cats) categories.Add(c);
            


            if (!typeof (TI).IsEnum)
            {
                foreach (TC md in cats)
                {
                    Add(md, new Dictionary<TI, TIV>());
                }
                return;
            }

            IList itts = Enum.GetValues(typeof (TI)) as IList;
            foreach (TI it in cats) itemKeys.Add(it);
           

            foreach (TC md in cats)
            {
                Add(md, new Dictionary<TI, TIV>());
                foreach (TI qw in itts)
                {
                    this[md].Add(qw, defaultValue);
                }
            }
        }

        #region --- categories ------- allCateogriesValues

        private List<TC> _categories = new List<TC>();

        /// <summary>
        /// allCateogriesValues
        /// </summary>
        protected List<TC> categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        #endregion

        #region --- itemKeys ------- za sve iteme

        private List<TI> _itemKeys = new List<TI>();

        /// <summary>
        /// za sve iteme
        /// </summary>
        protected List<TI> itemKeys
        {
            get { return _itemKeys; }
            set { _itemKeys = value; }
        }

        #endregion
    }
}