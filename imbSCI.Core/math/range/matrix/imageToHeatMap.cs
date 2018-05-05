using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging.Filters;
using imbSCI.Core.extensions.io;
using imbSCI.Core.files.folders;
using imbSCI.Core.files.unit;
using imbSCI.Core.reporting;

namespace imbSCI.Core.math.range.matrix
{
    /// <summary>
    /// Static methods for <see cref="HeatMapModel"/> creation from images
    /// </summary>
    public static class imageToHeatMap
    {

        /// <summary>
        /// Gets average intesity of sample patch located at x/y
        /// </summary>
        /// <param name="grayImage">The gray image.</param>
        /// <param name="x">horizobtal index of the field</param>
        /// <param name="y">vertical index of the field</param>
        /// <param name="bs">Sample patch size (side of the sampling square, in pixels)</param>
        /// <returns>Mean brightness value for the patch at x,y</returns>
        public static Double GetIntesity(this Bitmap grayImage, Int32 x, Int32 y, Int32 bs)
        {
            List<Double> vl = new List<double>();

            Int32 startX = x * bs;
            Int32 startY = y * bs;

            for (int i = 0; i < bs; i++)
            {
                for (int j = 0; j < bs; j++)
                {
                    Double px = grayImage.GetPixel(i+startX, j+startY).GetBrightness();


                    vl.Add(px);
                }
            }

            return vl.Average();
        }


        /// <summary>
        /// Creates a heat map model from image file. Supported formats: JPEG, PNG, TIFF etc. See: <see cref="Image.FromFile(string, bool)"/>
        /// </summary>
        /// <param name="imageFile">Path of the image file.</param>
        /// <param name="widthOfMap">The width of map - number of horizontal fields, vertical are computed in respect to image dimensional proportion </param>
        /// <param name="loger">The loger.</param>
        /// <returns>Heat map model, fields have mean brightness value</returns>
        public static HeatMapModel CreateFromImage(String imageFile, Int32 widthOfMap = 1000, ILogBuilder loger=null) {

            
            Bitmap grayImage = null;

            var imgFile = imageFile.getWritableFile(Data.enums.getWritableFileMode.existing, loger);
            if (!imgFile.Exists)
            {
                loger.log("Loading image file failed (" + imageFile + ") for heatmap model mapping");
            }
            else
            {
                try
                {
                    Bitmap sbmp = new Bitmap(Image.FromFile(imgFile.FullName));
                    grayImage = sbmp;
                  //  grayImage = Grayscale.CommonAlgorithms.Y.Apply(sbmp);
                }
                catch (Exception ex)
                {
                    loger.log("Error in loading file (" + imageFile + "): " + ex.Message);
                }

            }
            
            Int32 heightOfMap = Convert.ToInt32(grayImage.Size.Height.GetRatio(grayImage.Size.Width) * widthOfMap);
            HeatMapModel map = HeatMapModel.Create(widthOfMap, heightOfMap, "D3");

            map.AllocateSize(widthOfMap, heightOfMap);

            Int32 bs = Convert.ToInt32(grayImage.Size.Width / widthOfMap);



            for (Int32 y = 0; y < heightOfMap; y++)
            {
                for (Int32 x = 0; x < widthOfMap; x++)
                {
                    map[x, y] = grayImage.GetIntesity(x, y, bs);
                }

            }

            

            return map;

        }
    }
}
