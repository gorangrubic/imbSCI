namespace imbSCI.DataComplex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;

    /*
    public class weightTableWrappedTerm<TTerm>:IWeightTableTerm
    {
        /// <summary>
        /// Determines whether the specified <c>other</c> <see cref="weightTableGenericTerm"/> is match with this one (meaning their frequencies are summed)
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c> if the specified other is match; otherwise, <c>false</c>.
        /// </returns>
        public Boolean isMatch(weightTableWrappedTerm<TTerm> other)
        {
            return name.ToLower() == other.name.ToLower();
        }


        bool IWeightTableTerm.isMatch(IWeightTableTerm other) => isMatch((IWeightTableTerm)other);


        private Double _weight = 1;
        /// <summary>
        /// The weight associated with the term
        /// </summary>
        public Double weight
        {
            get { return _weight; }
            set { _weight = value; }
        }


        private String _name;
        /// <summary>
        /// The original content of the wrapped <see cref="String"/> word
        /// </summary>
        public String name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
    */

    


    /// <summary>
    /// Generic - simple <see cref="String"/> wrapper for the <see cref="IWeightTableDocument"/> and <see cref="IWeightTable"/> applications
    /// </summary>
    /// <seealso cref="IWeightTableTerm" />
    public class weightTableGenericTerm:IWeightTableTerm
    {

        /// <summary>
        /// Performs an implicit conversion from <see cref="weightTableGenericTerm"/> to <see cref="String"/>.
        /// </summary>
        /// <param name="gt">The gt.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator string(weightTableGenericTerm gt)
        {
            return gt.name;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="String"/> to <see cref="weightTableGenericTerm"/>.
        /// </summary>
        /// <param name="st">The st.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator weightTableGenericTerm(string st)
        {
            return new weightTableGenericTerm(st);
        }

        /// <summary>
        /// Determines whether the specified <c>other</c> <see cref="weightTableGenericTerm"/> is match with this one (meaning their frequencies are summed)
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>
        ///   <c>true</c> if the specified other is match; otherwise, <c>false</c>.
        /// </returns>
        public bool isMatch(weightTableGenericTerm other)
        {
            return name.Equals(other.name, StringComparison.InvariantCultureIgnoreCase);
        }

        bool IWeightTableTerm.isMatch(IWeightTableTerm other) => isMatch((weightTableGenericTerm)other);

        public List<string> GetAllForms(bool includingNominalForm = true)
        {
            if (includingNominalForm)
            {
                return new List<string>() { nominalForm };
            } else
            {
                return new List<string>();
            }
        }

        public void Define(string __name, string __nominalForm)
        {
            name = __name;
          //  _nominalForm = __nominalForm;
        }

        public void SetOtherForms(IEnumerable<string> instances)
        {
            // <---------------- generic form doesn-t support instances
        }


        /// <summary>
        /// Constructor for Xml Serialization, do not use
        /// </summary>
        public weightTableGenericTerm() { }


        /// <summary>
        /// Proper constructor for the generic term
        /// </summary>
        /// <param name="__name">The name.</param>
        public weightTableGenericTerm(string __name, double __weight=1)
        {
            name = __name;
            weight = __weight;
        }


        /// <summary>
        /// The weight associated with the term
        /// </summary>
        public double weight { get; set; } = 1;


        /// <summary>
        /// The original content of the wrapped <see cref="String"/> word
        /// </summary>
        public string name { get; set; }

        public int AFreqPoints { get; set; } = 1;

        public string nominalForm
        {
            get
            {
                return name;
            }
        }

        public int Count
        {
            get
            {
                return 1;
            }
        }
    }

}