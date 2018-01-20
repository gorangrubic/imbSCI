// --------------------------------------------------------------------------------------------------------------------
// <copyright file="folderNode.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbSCI.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using imbSCI.Core;
using imbSCI.Core.attributes;
using imbSCI.Core.collection;
using imbSCI.Core.data;
using imbSCI.Core.enums;
using imbSCI.Core.extensions.data;
using imbSCI.Core.extensions.io;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.typeworks;
using imbSCI.Core.interfaces;
using imbSCI.Core.reporting;
using imbSCI.Data;
using imbSCI.Data.data;
using imbSCI.Data.enums;
using imbSCI.Data.interfaces;

namespace imbSCI.Core.files.folders
{
    using imbSCI.Core.reporting.render;
    using imbSCI.Core.reporting.render.builders;
    using System.Collections;
    using System.Data;
    using System.IO;

    /// <summary>
    /// Subfolder in the <see cref="folderStructure"/>
    /// </summary>
    /// <seealso cref="imbBindable" />
    /// <seealso cref="imbACE.Core.files.folders.IFolderNode" />
    /// <seealso cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String, imbACE.Core.files.folders.folderNode}}" />
    public class folderNode:imbBindable, IFolderNode, IEnumerable<KeyValuePair<string, folderNode>>, IEnumerable<folderNode>
    {

        /// <summary>
        /// Refers to the current directory of application
        /// </summary>
        public folderNode(String _description="")
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(Directory.GetCurrentDirectory());
                folderNode par = info.Parent;

                parent = par;



                _name = info.Name;
                caption = _name.imbTitleCamelOperation(true);
                if (_description.isNullOrEmpty())
                {
                    description = "Application root directory";
                }
                else
                {
                    description = _description;
                }


                par.Add(this);
            } catch (Exception ex)
            {
                throw new imbFileException("folderNode construction failed", ex, this, null, null);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="folderNode"/> class.
        /// </summary>
        /// <param name="__name">The name.</param>
        /// <param name="__caption">The caption.</param>
        /// <param name="__description">The description.</param>
        public folderNode(string __name, string __caption, string __description)
        {
            _name = __name;
            caption = __caption;
            description = __description;
        }

        /// <summary>
        /// Adds the specified name enum.
        /// </summary>
        /// <param name="nameEnum">The name enum.</param>
        /// <param name="__caption">The caption.</param>
        /// <param name="__description">The description.</param>
        /// <returns></returns>
        public folderNode Add(Enum nameEnum, string __caption, string __description)
        {
            return Add(nameEnum.toString(), __caption, __description);
        }

        public folderNode Add(folderNode node)
        {

            node.parent = this;
            if (items.ContainsKey(node.name))
            {
                items[node.name] = node;
            } else
            {
                items.Add(node.name, node);
            }
            
            return node;
            
        }

        public string forTreeview
        {
            get
            {
                return name;
            }
        }

        public folderNode Add(folderStructure subStructure)
        {
            folderNode node = new folderNode(subStructure.name, subStructure.caption, subStructure.description);
            return Add(node);
            

        }

        public static implicit operator DirectoryInfo(folderNode node)
        {
            return new DirectoryInfo(node.path);
        }

        public static implicit operator folderNode(DirectoryInfo di)
        {
            folderStructure node = new folderStructure(di.FullName, di.Name.imbTitleCamelOperation(true), "Folder node generated from DirectoryInfo object: " + di.FullName);

            return node;
        }

        public const string CAPTION_FOR_TUNNELFOLDER = "--";


        private object addFolderLock = new object();


        /// <summary>
        /// Adds new node or nodes to correspond to specified path or name. <c>pathOrName</c> can be path like: path1\\path2\\path3
        /// </summary>
        /// <param name="pathOrName">Name of the path or.</param>
        /// <param name="__caption">The caption - display name of the folder</param>
        /// <param name="__description">The description - description about the folder</param>
        /// <returns></returns>
        public folderNode Add(string pathOrName, string __caption, string __description)
        {
            List<string> pathParts = imbSciStringExtensions.SplitSmart(pathOrName, "\\");
            folderNode head = this;
            if (pathParts.Count() > 1)
            {
                foreach (string part in pathParts)
                {
                    head = head.Add(part, CAPTION_FOR_TUNNELFOLDER, CAPTION_FOR_TUNNELFOLDER);
                }
                return head;
            } else
            {
                lock (addFolderLock)
                {
                    if (!items.ContainsKey(pathOrName))
                    {
                        folderNode node = new folderNode(pathOrName, __caption, __description);
                        node.parent = this;
                        items.Add(pathOrName, node);
                        return node;
                    }
                    else
                    {
                        folderNode node = items[pathOrName];
                        if (node.caption.isNullOrEmpty() || node.caption == CAPTION_FOR_TUNNELFOLDER) node.caption = __caption;
                        if (node.description.isNullOrEmpty() || node.description == CAPTION_FOR_TUNNELFOLDER) node.description = __description;
                        return node;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, folderNode> items { get; set; } = new Dictionary<string, folderNode>();

        public bool Contains(string key) => items.ContainsKey(key);

        /// <summary>
        /// description/comment - objasnjenje
        /// </summary>
        private string _description = "";
        /// <summary>
        /// description/comment - objasnjenje
        /// </summary>
        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }


        /// <summary>
        /// Display title
        /// </summary>
        public string caption { get; set; }


        /// <summary>
        /// file system ime direktorijuma
        /// </summary>
        private  string _name = "";
        /// <summary>
        /// file system ime direktorijuma
        /// </summary>
        public virtual string name
        {
            get
            {
                return _name;
            }
            set { }
        }


        public virtual string path
        {
            get
            {
                if (name.isNullOrEmpty())
                {
                    throw new InvalidOperationException("Name not set for folderNode - Can't create path when name not set");
                }

                if (parent != null)
                {
                    return parent.path + "\\" + name;
                } else
                {
                    return name;
                }
            }
        }

        public const string NOTFOUND_RETURN = "--FILE NOT FOUND--";

        /// <summary>
        /// Finds the file - and returns relative path
        /// </summary>
        /// <param name="partOrPattern">The part or pattern.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public string findFile(out bool found, string partOrPattern, SearchOption options = SearchOption.TopDirectoryOnly, bool returnRelative=false)
        {
            DirectoryInfo di = Directory.CreateDirectory(path);
            var files = di.GetFiles(partOrPattern, options);
            if (files.Any())
            {
                found = true;
                if (returnRelative)
                {
                    return imbSciStringExtensions.removeStartsWith(files.First().FullName, path).TrimStart('\\');
                } else
                {
                    return files.First().FullName;
                }
            }
            found = false;
            return "";
        }

        /// <summary>
        /// Finds the file - and returns relative path. If not found returns emptry string
        /// </summary>
        /// <param name="partOrPattern">The part or pattern.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public string findFile(string partOrPattern, SearchOption options = SearchOption.TopDirectoryOnly, bool returnRelative = false)
        {
            bool found = true;
            string output = findFile(out found, partOrPattern, options, returnRelative);
            if (found) return output;
            return "";
        }

        /// <summary>
        /// Finds the files - returns relative paths
        /// </summary>
        /// <param name="partOrPattern">The part or pattern.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public List<string> findFiles(string partOrPattern = "*.*", SearchOption options = SearchOption.TopDirectoryOnly, bool returnRelative = false)
        {
            DirectoryInfo di = Directory.CreateDirectory(path);
            var __files = di.GetFiles(partOrPattern, options);
            List<string> output = new List<string>();

            foreach (FileInfo fi in __files)
            {
                if (returnRelative)
                {
                    output.Add(imbSciStringExtensions.removeStartsWith(fi.FullName, path).TrimStart('\\'));
                }
                else
                {
                    output.Add(fi.FullName);
                }
                
            }

            return output;
        }

        /// <summary>
        /// Finds the directories - returns relative paths
        /// </summary>
        /// <param name="partOrPattern">The part or pattern.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public List<string> findDirectories(string partOrPattern = "*", SearchOption options = SearchOption.TopDirectoryOnly, bool returnRelative = false)
        {
            DirectoryInfo di = Directory.CreateDirectory(path);
            var files = di.GetDirectories(partOrPattern, options);
            List<string> output = new List<string>();
            foreach (DirectoryInfo fi in files)
            {
                if (returnRelative)
                {
                    output.Add(imbSciStringExtensions.removeStartsWith(fi.FullName, path).TrimStart('\\'));
                }
                else
                {
                    output.Add(files.First().FullName);
                }

                
            }

            return output;
        }


        /// <summary>
        /// Creates the directory, child node and finds unique name if required
        /// </summary>
        /// <param name="nameOrPath">The proposal.</param>
        /// <param name="desc">The desc.</param>
        /// <param name="findUniqueName">if set to <c>true</c> [find unique name].</param>
        /// <returns></returns>
        public folderNode createDirectory(string nameOrPath, string desc="", bool findUniqueName=true)
        {
            string new_name = nameOrPath;

            if (findUniqueName) new_name = findUniqueDirectoryName(nameOrPath);

            folderNode new_node = Add(new_name, nameOrPath, desc);

            DirectoryInfo di = Directory.CreateDirectory(new_node.path);
            return new_node;
        }

        //public FileInfo findUniqueFileName(String proposal)
        //{
        //    String p = pathFor(proposal);
        //    return p.getWritableFile(enums.getWritableFileMode.autoRenameThis);
        //}


        public string findUniqueDirectoryName(string proposal)
        {
            string pt = imbSciStringExtensions.add(path, proposal, "\\");
            int c = 0;
            string output = proposal;
            while (Directory.Exists(pt)) {
                c++;
                if (c > 1000) break;
                output = proposal + c.ToString("D5");
                pt = imbSciStringExtensions.add(path, output, "\\");
            }
            //DirectoryInfo di = Directory.CreateDirectory(path);
            //String[] dirs = Directory.GetDirectories(path);
            //proposal = proposal.makeUniqueName(dirs.Contains);
            return output;
        }



        /// <summary>
        /// Returns path with filename specified. Optionally, sets <c>fileDescription</c> for directory readme generator
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="fileDescription">The file description - if not specified, it will try to improvize :)</param>
        /// <returns></returns>
        public string pathFor(string filename, getWritableFileMode mode=getWritableFileMode.none, String fileDescription="")
        {
            filename = filename.getCleanFilepath("");
            //filename = filename.getCleanFileName(false);
            if (Path.IsPathRooted(filename)) {
                filename = Path.GetFileName(filename);
            } else if (filename.StartsWith(path))
            {
                filename = imbSciStringExtensions.removeStartsWith(filename, path);
            }



            string output = imbSciStringExtensions.add(path, filename, Path.DirectorySeparatorChar);
            output = output.Replace("\\\\", Path.DirectorySeparatorChar.ToString());
            output = output.Replace("\\\\", Path.DirectorySeparatorChar.ToString());

            if (mode != getWritableFileMode.none)
            {
                output = output.getWritableFile(mode).FullName;
            }

            lock (addFileDescriptionLock)
            {
                if (!AdditionalFileEntries.ContainsKey(filename))
                {
                    AdditionalFileEntries.Add(filename, this.GetFileDescription(filename, fileDescription));
                }
                else
                {
                    AdditionalFileEntries[filename].description = fileDescription;
                }
            }

            
            
            return output;
        }


        private Object addFileDescriptionLock = new Object();




        public void deleteFiles(string selectionPattern="*.*", bool subFolders=true)
        {
            fileOpsBase.deleteFiles(path, selectionPattern, subFolders);
        }


        /// <summary>
        /// 
        /// </summary>
        public virtual IFolderNode parent { get; protected set; }


        public int level
        {
            get
            {
                if (parent == null)
                {
                    return 1;
                } else
                {
                    return parent.level + 1;
                }
            }
        }

        public IFolderNode root
        {
            get
            {
                if (parent == null)
                {
                    return this;
                } else
                {
                    return parent.root;
                }
            }
        }

       
       

        IFolderNode IFolderNode.root
        {
            get
            {
                return root;
            }
        }


        string IObjectWithTreeView.forTreeview
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object IObjectWithRoot.root
        {
            get
            {
                return root;
            }
        }

        object IObjectWithParent.parent
        {
            get
            {
                return parent;
            }
        }

        public folderNode this[Enum key]
        {
            get
            {
                if (!items.ContainsKey(key.ToString()))
                {
                    Directory.CreateDirectory(imbSciStringExtensions.add(path, key.ToString(), "\\"));
                    Add(key, key.ToString().imbTitleCamelOperation(true), "");
                    
                }
                return ((IDictionary<string, folderNode>)items)[key.toString()];
            }

            //set
            //{
            //    ((IDictionary<string, folderNode>)items)[key.toString()] = value;
            //}
        }


        public folderNode this[string key]
        {
            get
            {
                if (!items.ContainsKey(key))
                {
                    Directory.CreateDirectory(imbSciStringExtensions.add(path, key.ToString(), "\\"));
                        return Add(key, key.imbTitleCamelOperation(true), "");
                }
                return ((IDictionary<string, folderNode>)items)[key];
            }

            //set
            //{
            //    ((IDictionary<string, folderNode>)items)[key] = value;
            //}
        }

        /// <summary>
        /// Generates the folder readme.
        /// </summary>
        /// <param name="notation">The notation.</param>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public string generateFolderReadme(aceAuthorNotation notation, ITextRender builder=null)
        {
            if (builder == null) builder = new builderForMarkdown();
            String prefix = "";

            

            String mypath = path;
            if (parent != null)
            {
                mypath = mypath.removeStartsWith(parent.path);
                prefix = parent.path;
            }

            builder.AppendHeading("Directory information", 2);
            


            builder.AppendHeading(caption, 3);
            builder.AppendLine(" > " + mypath);
            builder.AppendLine(" > " + description);
            

            builder.AppendHorizontalLine();

            foreach (String st in AdditionalDescriptionLines)
            {
                builder.AppendLine(st);
            }

            if (AdditionalDescriptionLines.Any())
            {
                builder.AppendHorizontalLine();
            }

            if (AdditionalFileEntries.Any())
            {
                builder.AppendHeading("Files in this directory:", 2);
                String format = "D" + AdditionalFileEntries.Count().ToString().Length.ToString();
                Int32 flc = 1;

                List<String> sortedKeys = AdditionalFileEntries.Keys.ToList();
                sortedKeys.Sort(String.CompareOrdinal);

                foreach (String key in sortedKeys)
                {
                    builder.AppendLine(flc.ToString(format) + " : " + AdditionalFileEntries[key].description);
                    flc++;
                }
            }


            //builder.AppendHeading("Folder treeview", 2);

            //builder.Append(this.tree)    

            builder.AppendHorizontalLine();

            builder.AppendHeading("Subdirectories of: " + prefix,2);
                
            var folderNodes = this.getAllChildrenInType<folderNode>();
            foreach (var fold in folderNodes)
                {
                    //    builder.nextTabLevel();
                    builder.AppendHeading(String.Format("{0,-30} : {1,-100}", fold.caption, fold.path.removeStartsWith(prefix)), 3);
                
                if (!fold.description.isNullOrEmpty()) builder.AppendLine(" > " + fold.description);
                    //builder.AppendLine();
                    //  builder.prevTabLevel();
                }

          //  AdditionalFileEntries.Sort(String.CompareOrdinal);

         

            if (notation != null)
            {
                
                
                builder.AppendHorizontalLine();

                if (!notation.author.isNullOrEmpty()) builder.AppendPair("Author", notation.author, true, ": ");
                if (!notation.copyright.isNullOrEmpty()) builder.AppendPair("Copyright", notation.copyright, true, ": ");
                if (!notation.license.isNullOrEmpty()) builder.AppendPair("License", notation.license, true, ": ");
                if (!notation.software.isNullOrEmpty()) builder.AppendPair("Software", notation.software, true, ": ");
                if (!notation.organization.isNullOrEmpty()) builder.AppendPair("Organization", notation.organization, true, ": ");
                if (!notation.comment.isNullOrEmpty()) builder.AppendPair("Comment", notation.comment, true, ": ");


                

            }

            builder.AppendLine();
            builder.AppendHorizontalLine();

            builder.AppendLine(imbSciStringExtensions.add(imbSciStringExtensions.add("File generated: ", DateTime.Now.ToLongDateString(), " "), DateTime.Now.ToLongTimeString()));
            


            return builder.ContentToString(true);
        }

        private Object GenerateReadmeLock = new Object();


        /// <summary>
        /// These are additional description lines that will be inserted in readme file generated by <see cref="generateFolderReadme(aceAuthorNotation, ITextRender)"/>
        /// </summary>
        /// <value>
        /// The additional description lines.
        /// </value>
        public List<String> AdditionalDescriptionLines { get; protected set; } = new List<string>();


        /// <summary>
        /// Gets or sets the additional file entries.
        /// </summary>
        /// <value>
        /// The additional file entries.
        /// </value>
        public Dictionary<String, folderNodeFileDescriptor> AdditionalFileEntries { get; protected set; } = new Dictionary<String, folderNodeFileDescriptor>();


        /// <summary>
        /// Generates the readme files for complete folder tree
        /// </summary>
        /// <param name="notation">The notation.</param>
        public void generateReadmeFiles(aceAuthorNotation notation, String readmeFileName = "directory_readme.txt")
        {
            lock (GenerateReadmeLock)
            {

                String readme_filename = readmeFileName;
                String mpath = this.pathFor(readme_filename); //imbSciStringExtensions.add(path, readme_filename, "\\");
                generateFolderReadme(notation).saveStringToFile(mpath);
                var folderNodes = this.getAllChildrenInType<folderNode>();
                foreach (folderNode ni in folderNodes)
                {

                    String path = ni.pathFor(readme_filename);


                    FileInfo fi = path.getWritableFile(getWritableFileMode.overwrite);

                    String content = ni.generateFolderReadme(notation);
                    content.saveStringToFile(fi.FullName, getWritableFileMode.overwrite);
                    saveBase.saveToFile(fi.FullName, content);

                }
            }

        }



        public IEnumerator<KeyValuePair<string, folderNode>> GetEnumerator()
        {
            return ((IDictionary<string, folderNode>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IDictionary<string, folderNode>)items).GetEnumerator();
        }

        IEnumerator<folderNode> IEnumerable<folderNode>.GetEnumerator()
        {
            return items.Values.GetEnumerator();
        }

        public void Remove(string key)
        {
            items.Remove(key);
        }

        IEnumerator<IObjectWithPathAndChildren> IEnumerable<IObjectWithPathAndChildren>.GetEnumerator()
        {
            return items.Values.GetEnumerator();
        }

        void IObjectWithPathAndChildren.Remove(string key) => Remove(key);
        
    }

}