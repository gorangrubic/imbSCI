namespace imbSCI.Data.collection.nested
{
    #region imbVeles using

    using System;
    using System.Collections;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    /// The <see cref="imbCollectionNestedEnum{TC, TI, TIV}"/> applied for String values. It is thread-safe.
    /// </summary>
    /// <typeparam name="TC">Enum type defining the first or X axis (aka: categories)</typeparam>
    /// <typeparam name="TI">Enum type defining the second or Y axis (aka: options)</typeparam>
    /// <remarks>
    /// <para>To access the value use indexers, i.e.: collection[X][Y] = "something"</para>
    /// <para>This application of the <see cref="imbCollectionNestedEnum{TC, TI, TIV}"/> allows you to set initial string value for each cell in the 2D matrix</para>
    /// </remarks>
    public class imbCollectionNestedEnumToString<TC, TI> : imbCollectionNestedEnum<TC, TI, string>
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="defaultToString">Da li da upiše ime enuma kao podrazumevanu vrednost polja ili da ostane prazan string</param>
        public imbCollectionNestedEnumToString(Boolean defaultToString = false)
        {
            deploy(defaultToString);
        }

        private void deploy(Boolean defaultToString = false)
        {
            try
            {
                IList itts = Enum.GetValues(typeof (TI)) as IList;
                foreach (TI ti in itts) itemKeys.Add(ti);
                
                IList cats = Enum.GetValues(typeof (TC)) as IList;
                foreach (TC tc in cats) categories.Add(tc);
                

                foreach (TC md in cats)
                {
                    if (!ContainsKey(md))
                    {
                        Add(md, new Dictionary<TI, String>());
                    }
                    else
                    {
                    }
                    foreach (TI qw in itts)
                    {
                        if (!this[md].ContainsKey(qw))
                        {
                            if (defaultToString)
                            {
                                this[md].Add(qw, qw.ToString());
                            }
                            else
                            {
                                this[md].Add(qw, "");
                            }
                        }
                        else
                        {
                            if (defaultToString)
                            {
                                this[md][qw] = qw.ToString();
                            }
                            else
                            {
                                this[md][qw] = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}