using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Data.collection.special;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.data;
using imbSCI.Graph.DGML;
using imbSCI.Graph.DGML.collections;
using imbSCI.Graph.DGML.core;
using System.Drawing;
using System.Text;
using imbSCI.Core.reporting.colors;
using imbSCI.Graph.Converters.tools;
using imbSCI.Data.collection.graph;
using imbSCI.Data;
using imbSCI.Core.math;
using imbSCI.Graph.FreeGraph;
using imbSCI.Data.interfaces;
using System.Web.UI.WebControls;
using Accord;
using imbSCI.Core.data;
using System.Collections;
using imbSCI.Core.extensions.typeworks;
using imbSCI.Core.style.color;
using imbSCI.Core.files.folders;
using imbSCI.Core.reporting.colors;

namespace imbSCI.Graph.Converters
{

    /// <summary>
    /// 
    /// </summary>
    public static class StaticConverters
    {

        public const String CAT_FOLDERNODE = "folderNode";
        public const String CAT_FOLDERNODEDESC = "folderNodeDesc";
        public const String CAT_FILE = "folderNodeFile";
        public const String CAT_FILEDESC = "folderNodeFileDesc";

        /// <summary>
        /// Gets the directed graph from <see cref="folderNode"/>
        /// </summary>
        /// <param name="folder">The folder.</param>
        /// <param name="doFolderDescription">if set to <c>true</c> [do folder description].</param>
        /// <param name="doFileEntries">if set to <c>true</c> [do file entries].</param>
        /// <param name="doFileDescriptions">if set to <c>true</c> [do file descriptions].</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        public static DirectedGraph GetDirectedGraph(this folderNode folder, Boolean doFolderDescription, Boolean doFileEntries, Boolean doFileDescriptions, Int32 limit=100)
        {
            DirectedGraph output = new DirectedGraph();
            output.Title = folder.name;
           

            output.Categories.AddOrGetCategory(CAT_FOLDERNODE, "Folder", "").Background = Color.Orange.toHexColor();
            output.Categories.AddOrGetCategory(CAT_FOLDERNODEDESC, "Folder Description", "").Background = Color.LightGray.toHexColor();
            output.Categories.AddOrGetCategory(CAT_FILE, "File", "").Background = Color.LightSteelBlue.toHexColor(); 
            output.Categories.AddOrGetCategory(CAT_FILEDESC, "File Description", "").Background = Color.LightGray.toHexColor();

            List<folderNode> nextSet = new List<folderNode>();
            nextSet.Add(folder);
            Int32 i = 0;

            while (nextSet.Any())
            {
                i++;
                List<folderNode> newNextSet = new List<folderNode>();

                foreach (folderNode parent in nextSet)
                {
                    var parentNode = output.Nodes.AddNode(parent.path, parent.name);
                    parentNode.Category = CAT_FOLDERNODE;

                    if (parent.parent != null)
                    {
                        folderNode parentFolder = parent.parent as folderNode;
                        Link l = new Link(parentFolder.path, parentNode.Id, true);
                        l.Stroke = Color.OrangeRed.toHexColor();
                        output.Links.Add(l);
                    }

                    foreach (var pair in parent)
                    {
                        newNextSet.AddUnique(pair.Value);
                    }

                    if (doFolderDescription)
                    {
                        if (!parent.description.isNullOrEmpty())
                        {
                            Node descNode = output.Nodes.AddNode(parent.path + "_DESC", parent.description);
                            descNode.Category = CAT_FOLDERNODEDESC;
                            output.Links.AddLink(parentNode, descNode, "About").StrokeDashArray = "2,5,2,5";
                        }
                    }

                    if (doFileEntries)
                    {
                        foreach (var f in parent.AdditionalFileEntries)
                        {

                            Node fileNode = output.Nodes.AddNode(parent.path + f.Key, f.Value.description);
                            fileNode.Category = CAT_FILE;
                            var fileLink = output.Links.AddLink(parentNode, fileNode, f.Value.filename);
                            fileLink.StrokeDashArray = "2,2,5,2";
                            fileLink.Stroke = Color.LightGray.toHexColor();

                            //if (doFileDescriptions)
                            //{
                            //    Node fileInfoNode = output.Nodes.AddNode(parent.path + f.Key + "_DESC", );
                            //    fileInfoNode.Category = CAT_FILEDESC;
                            //    var fileInfoLink = output.Links.AddLink(fileNode, fileInfoNode, "");
                            //    fileLink.StrokeDashArray = "2,2,5,2";
                            //    fileLink.Stroke = Color.LightGray.toHexColor();
                            //}
                        }
                    }
                }

                if (i > limit) break;
                nextSet = newNextSet;
            }


            return output;

        }

    }



}