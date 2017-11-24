﻿namespace imbSCI.Data.collection.math
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Data.collection.nested;
    using imbSCI.Data.primitives;


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TXAxis">The type of the x axis.</typeparam>
    /// <typeparam name="TYAxis">The type of the y axis.</typeparam>
    /// <typeparam name="TRelation">The type of the relation.</typeparam>
    
    public class aceRelationMatrix<TXAxis, TYAxis, TRelation>:coordinateXY
    {

        public aceRelationMatrix(IEnumerable<TXAxis> __axisX, IEnumerable<TYAxis> __axisY, aceRelationValue<TXAxis, TYAxis, TRelation> __init)
        {
            deploy(__axisX, __axisY, __init);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="aceRelationMatrix{TXAxis, TYAxis, TRelation}"/> class.
        /// </summary>
        /// <param name="__axisX">The axis x.</param>
        /// <param name="__axisY">The axis y.</param>
        /// <param name="__init">The initialize.</param>
        public aceRelationMatrix(IEnumerable<TXAxis> __axisX, IEnumerable<TYAxis> __axisY, TRelation __init)
        {
            deploy(__axisX, __axisY, __init);
        }

        /// <summary>
        /// Indexes the x of.
        /// </summary>
        /// <param name="itemX">The item x.</param>
        /// <returns></returns>
        public Int32 IndexXOf(TXAxis itemX) => axisX.IndexOf(itemX);

        /// <summary>
        /// Indexes the y of.
        /// </summary>
        /// <param name="itemY">The item y.</param>
        /// <returns></returns>
        public Int32 IndexYOf(TYAxis itemY) => axisY.IndexOf(itemY);


        
        

        /// <summary>
        /// Maps to x.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public Dictionary<TXAxis, TRelation> MapToX(List<TRelation> values)
        {
            Dictionary<TXAxis, TRelation> output = new Dictionary<TXAxis, TRelation>();

            for (int i = 0; i < x; i++)
            {
                output.Add(axisX[i], values[i]);
            }
            return output;
        }

        /// <summary>
        /// Maps to y.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public Dictionary<TYAxis, TRelation> MapToY(List<TRelation> values)
        {
            Dictionary<TYAxis, TRelation> output = new Dictionary<TYAxis, TRelation>();

            for (int i = 0; i < y; i++)
            {
                output.Add(axisY[i], values[i]);
            }
            return output;
        }

        /// <summary>
        /// Gets the matrix.
        /// </summary>
        /// <returns></returns>
        public ArrayList GetMatrix()
        {
            ArrayList incomingLinks = new ArrayList(x);
            for (int i = 0; i < x; i++)
            {
                var column = new List<TRelation>();
                for (int j = 0; j < y; j++)
                {
                    TRelation val = values[i, j];
                    column.Add(val);
                    
                }
                incomingLinks.Add(column);

            }
            return incomingLinks;
        }


        /// <summary>
        /// Gets the triple.
        /// </summary>
        /// <param name="xi">The xi.</param>
        /// <param name="yi">The yi.</param>
        /// <returns></returns>
        public aceRelationMatrixTriple<TXAxis, TYAxis, TRelation> GetTriple(Int32 xi, Int32 yi)
        {
            return new aceRelationMatrixTriple<TXAxis, TYAxis, TRelation>(axisX[xi], axisY[yi], values[xi, yi]);
        }

        /// <summary>
        /// Gets the <see cref="aceRelationMatrixTriple{TXAxis, TYAxis, TRelation}"/> with the specified xi.
        /// </summary>
        /// <value>
        /// The <see cref="aceRelationMatrixTriple{TXAxis, TYAxis, TRelation}"/>.
        /// </value>
        /// <param name="xi">The xi.</param>
        /// <param name="yi">The yi.</param>
        /// <returns></returns>
        public TRelation this[Int32 xi, Int32 yi]
        {
            get
            {
                return values[xi, yi];
            } 
            set
            {
                values[xi, yi] = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="TRelation"/> with the specified xi.
        /// </summary>
        /// <value>
        /// The <see cref="TRelation"/>.
        /// </value>
        /// <param name="xi">The xi.</param>
        /// <param name="yi">The yi.</param>
        /// <returns></returns>
        public TRelation this[TXAxis xi, TYAxis yi]
        {
            get
            {
                return values[IndexXOf(xi), IndexYOf(yi)];
            }
            set
            {
                values[IndexXOf(xi), IndexYOf(yi)] = value;
            }
        }


        

        protected void deploy(IEnumerable<TXAxis> __axisX, IEnumerable<TYAxis> __axisY, aceRelationValue<TXAxis, TYAxis, TRelation> __init)
        {
            axisY.Clear();
            axisX.Clear();
            values = new aceDictionary2D<int, int, TRelation>();

            y = 0;
            foreach (TYAxis aY in __axisY)
            {
                axisY.Add(aY);
                y++;
            }

            x = 0;
            foreach (TXAxis aX in __axisX)
            {
                axisX.Add(aX);
                x++;

            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    TXAxis aX = axisX[i];
                    TYAxis aY = axisY[j];
                    values[i, j] = __init(aX, aY);
                }
            }
        }


        /// <summary>
        /// Deploys the specified axis x.
        /// </summary>
        /// <param name="__axisX">The axis x.</param>
        /// <param name="__axisY">The axis y.</param>
        /// <param name="__init">The initialize.</param>
        protected void deploy(IEnumerable<TXAxis> __axisX, IEnumerable<TYAxis> __axisY, TRelation __init)
        {
            axisY.Clear();
            axisX.Clear();
            values = new aceDictionary2D<int, int, TRelation>();

            y = 0;
            foreach (TYAxis aY in __axisY)
            {
                axisY.Add(aY);
                y++;
            }

            x = 0;
            foreach (TXAxis aX in __axisX)
            {
                axisX.Add(aX);
                x++;

            }

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    values[i, j] = __init;
                }
            }
        }


        public List<TXAxis> GetXAxis()
        {
            return axisX.ToList();
        }

        public List<TYAxis> GetYAxis()
        {
            return axisY.ToList();
        }

        private aceDictionary2D<Int32, Int32, TRelation> _values = new aceDictionary2D<Int32, Int32, TRelation>();
        /// <summary> </summary>
        protected aceDictionary2D<Int32, Int32, TRelation> values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
                //OnPropertyChanged("values");
            }
        }


        private List<TXAxis> _axisX = new List<TXAxis>();
        /// <summary> </summary>
        protected List<TXAxis> axisX
        {
            get
            {
                return _axisX;
            }
            set
            {
                _axisX = value;
                //OnPropertyChanged("axisX");
            }
        }


        private List<TYAxis> _axisY = new List<TYAxis>();
        /// <summary> </summary>
        protected List<TYAxis> axisY
        {
            get
            {
                return _axisY;
            }
            set
            {
                _axisY = value;
                //OnPropertyChanged("axisY");
            }
        }


    }
}