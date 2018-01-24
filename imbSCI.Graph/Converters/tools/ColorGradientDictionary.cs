using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Text;
using Accord;
using imbSCI.Core.reporting.colors;
using AForge.Imaging;
using System.Xml.Serialization;
using imbSCI.Core.math;

namespace imbSCI.Graph.Converters.tools
{

    public class ColorGradientDictionary: Dictionary<String, Double>
    {
        public List<String> GetColors()
        {
            return Keys.ToList();
        }

        public List<String> GetColors(Double rStart, Double rEnd)
        {
            List<String> output = new List<string>();
            foreach (var pair in this)
            {
                
                if (pair.Value >= rStart && pair.Value < rEnd)
                {
                    output.Add(pair.Key);
                }
            }
            return output;
        }

        public String GetColor(Double r)
        {
            String first = "";
            foreach (var pair in this)
            {
                if (first == "") first = pair.Key;
                if (pair.Value > r)
                {
                    return pair.Key;
                }
            }
            return first;
        }

    }

}