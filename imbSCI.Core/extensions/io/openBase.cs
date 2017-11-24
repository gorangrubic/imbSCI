namespace imbSCI.Core.extensions.io
{
    using imbSCI.Core.reporting;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Basic file open extensions
    /// </summary>
    public static class openBase
    {

        /// <summary>
        /// The logger instance to report on warnings
        /// </summary>
        public static ILogBuilder logger = null;

        /// <summary>
        /// Varijanta openFile metoda, samo vraca vec sklopljen string
        /// </summary>
        /// <param name="_path">Putanja na kojoj se nalazi fajl za ucitavanje</param>
        /// <param name="insertNlTags">Da li da na kraju svake linije doda NewLine tag</param>
        /// <returns>Sklopljen string</returns>
        public static String openFileToString(String _path, Boolean insertNlTags, Boolean askIfNotExist = false)
        {
            String output = "";


            List<String> source = openFile(_path);
            output = String.Join(Environment.NewLine, source); // ListToString(source, insertNlTags);

            return output;
        }

        /// <summary>
        /// Učitava fajl i vraća niz binarnih vrednosti
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public static Byte[] openBinary(String _path)
        {
            Byte[] output = null;
            if (File.Exists(_path))
            {
                //FileStream st = File.OpenRead(_path);


                output = File.ReadAllBytes(_path);
            }
            return output;
        }


        /// <summary>
        /// Opens the file -- without exception if file not found. Sets out params: fileFound if exists and fileEmpty if zero lines loaded
        /// </summary>
        /// <param name="_path">The path.</param>
        /// <param name="fileFound">if set to <c>true</c> [file found].</param>
        /// <param name="fileEmpty">if set to <c>true</c> [file empty].</param>
        /// <returns></returns>
        public static List<string> openFile(String _path, out Boolean fileFound, out Boolean fileEmpty)
        {
            List<String> output = new List<string>();
            if (File.Exists(_path))
            {
                output = __openFile(_path, false);
                fileFound = true;
                fileEmpty = (output.Count== 0);
            } else
            {
                fileFound = false;
                fileEmpty = true;
            }
            return output;
        }

        /// <summary>
        /// Opens the file into List of lines
        /// </summary>
        /// <param name="_path">The path.</param>
        /// <returns></returns>
        public static List<string> openFile(String _path)
        {
            return __openFile(_path, false);
        }

        /// <summary>
        /// Opens the file into List of lines, where empty lines are filtered out
        /// </summary>
        /// <param name="_path">The path.</param>
        /// <returns></returns>
        public static List<string> openFileFilterLines(String _path)
        {
            return __openFile(_path, true);
        }

        /// <summary>
        /// Ucitava tekstualni fajl i vraca string u listi
        /// </summary>
        /// <param name="_path">Putanja na kojoj se fajl nalazi, nece otvoriti dijalog - ako je prazna putanja otvorice dijalog za TXT i * fajlove</param>
        /// <returns>Listu linija koda</returns>
        private static List<string> __openFile(String _path, Boolean skipEmptyLines)
        {
            List<string> output = new List<string>();
            String line = "";
            StreamReader tmpStream;
            int eLine = 0;
            try
            {


                tmpStream = new StreamReader(_path);

                while ((line = tmpStream.ReadLine()) != null)
                {
                    if (skipEmptyLines && String.IsNullOrWhiteSpace(line))
                    {
                        eLine++;
                    }
                    else
                    {
                        output.Add(line);
                    }
                }

                tmpStream.Close();
                tmpStream.Dispose();
            } catch (Exception ex)
            {
                if (logger != null) logger.log("__openFile(\"" + _path + "\") Exception: " +  ex.Message); 
                else
                {
                    throw;
                }
            }
           
            fileOpsBase.lastFilePath = _path;
           
            return output;
        }
    }
}