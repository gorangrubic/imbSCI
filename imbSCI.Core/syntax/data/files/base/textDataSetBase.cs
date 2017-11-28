namespace imbSCI.Core.syntax.data.files.@base
{
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Polazna klasa za sve fajlove koji se sastoje od linija teksta
    /// </summary>
    public abstract class textDataSetBase:fileDataSetBase, IAceDataFile
    {

        public virtual String writeDescription()
        {

            String filename = "";
            String output = "";

            if (!String.IsNullOrEmpty(path)) filename = Path.GetFileName(path);


            if (String.IsNullOrEmpty(filename))
            {
                output = output.log("Invalid path - file not loaded");
            }
            else
            {
                FileInfo fi = new FileInfo(path);
                String filesize = fi.Length.writeFileSize();
                output = output.addVal("File: ", filename, " : ", "{0} [{1,-16}]");
                output = output.addVal("Filesize: ", filesize, " : ", "{0} [{1, -10}]");
                output = output.addVal("Created: ",
                                       fi.CreationTime.ToShortDateString() + " " + fi.CreationTime.ToShortTimeString(),
                                       " : ");
                output = output.addVal("Modified: ",
                                       fi.LastWriteTime.ToShortDateString() + " " + fi.LastWriteTime.ToShortTimeString(),
                                       " : ");
                output = output.newLine();
            }
            output = output.addVal("Source lines: ", lines.Count().ToString(), " : ");
            
            return output;
        }


        #region --- lines ------- sve ucitane linije

        private List<string> _lines = new List<string>();
        /// <summary>
        /// sve ucitane linije
        /// </summary>
        public List<string> lines
        {
            get
            {
                return _lines;
            }
            set
            {
                _lines = value;
                OnPropertyChanged("lines");
            }
        }
        #endregion

        /// <summary>
        /// Poziva beforeSave();
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public override bool save(string _path = "")
        {
            beforeSave();

            _checkPath(_path);

            String dir = Path.GetDirectoryName(_path);

            var di = fileOpsBase.getDirectory(dir, false);

            try
            {
                File.WriteAllLines(_path, lines);
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Ucitavanje fajla
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        public override bool load(string _path = "")
        {
            _path = _checkPath(_path);
            
            if (File.Exists(_path))
            {
                path = _path;
                lines.Clear();
                string[] lns = File.ReadAllLines(_path);
                foreach (string ln in lns)
                {
                    if (!String.IsNullOrEmpty(ln))
                    {
                        lines.Add(ln.Trim());
                    }
                }

                afterLoad();

                return lines.Count > 0;
            } else
            {
                return false;
            }
        }

       
       
    }
}
