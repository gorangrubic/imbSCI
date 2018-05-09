using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging.Filters;
using imbSCI.Core.extensions.io;
using imbSCI.Core.files.folders;
using imbSCI.Core.files.unit;
using imbSCI.Core.math.functions;
using imbSCI.Core.math.functions.core;
using imbSCI.Core.reporting;

namespace imbSCI.Core.math.range.matrix
{


    /// <summary>
    /// Generator for <see cref="HeatMapModel"/> using X and Y function arrays to set value
    /// </summary>
    public class proceduralHeatMapGenerator
    {

        /// <summary>
        /// Generator for horizontal sine function waves
        /// </summary>
        /// <returns></returns>
        public static proceduralHeatMapGenerator PresetSineWave()
        {
            proceduralHeatMapGenerator output = new proceduralHeatMapGenerator();

            sineFunction fn = new sineFunction();

            output.xAxisFunction.Add(new sineFunction(), 1);
            output.yAxisFunction.Add(new pseudoFunction(0), 1);

            return output;
        }

        /// <summary>
        /// Generates sine function waves in both horizontal and vertical directions
        /// </summary>
        /// <param name="xVsYRatio">Weight of the horizontal sine function, complementary to the vertical sine function. </param>
        /// <returns></returns>
        public static proceduralHeatMapGenerator PresetDoubleSineWave(Double xVsYRatio = 0.8)
        {
            proceduralHeatMapGenerator output = new proceduralHeatMapGenerator();

            sineFunction fn = new sineFunction();

            output.xAxisFunction.Add(new sineFunction(), xVsYRatio);
            output.yAxisFunction.Add(new sineFunction(), 1 - xVsYRatio);

            return output;
        }


        /// <summary>
        /// Gets or sets the x axis function.
        /// </summary>
        /// <value>
        /// The x axis function.
        /// </value>
        public functionArray xAxisFunction { get; set; } = new functionArray();

        /// <summary>
        /// Gets or sets the y axis function.
        /// </summary>
        /// <value>
        /// The y axis function.
        /// </value>
        public functionArray yAxisFunction { get; set; } = new functionArray();

        /// <summary>
        /// Renders HeatMapModel of specified size
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public HeatMapModel MakeHeatMap(Int32 width, Int32 height, Int32 xPeriod = 20, Int32 yPeriod = 20)
        {
            xAxisFunction.outputRange = new imbNumberScale(numberRangePresetEnum.zeroToOne);
            yAxisFunction.outputRange = new imbNumberScale(numberRangePresetEnum.zeroToOne);

            HeatMapModel map = HeatMapModel.Create(width, height, "D3");

            map.AllocateSize(width, height);


            for (Int32 y = 0; y < height; y++)
            {
                Double yValue = yAxisFunction.GetOutput(y.GetRatio(yPeriod));
                for (Int32 x = 0; x < width; x++)
                {
                    map[x, y] = xAxisFunction.GetOutput(x.GetRatio(xPeriod)) + yValue;  //grayImage.GetIntesity(x, y, bs);
                }

            }

            return map;
        }

    }
}