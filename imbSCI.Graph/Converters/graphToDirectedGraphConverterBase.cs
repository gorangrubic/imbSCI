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

namespace imbSCI.Graph.Converters
{

    public abstract class graphToDirectedGraphConverterBase<T> : DirectedGraphConverterBase<T> where T : IGraphNode
    {
        public override string GetNodeID(T node)
        {
            if (node == null) return "null";
            return node.path;
        }



        public override DirectedGraph Convert(T source, int depthLimit = 500)
        {
            DirectedGraph output = new DirectedGraph();
            if (source == null) return output;
            output.Title = source.name;
            
            String description = "DirectedGraph built from " + source.GetType().Name + ":GraphNodeBase graph";




            var nodes = source.getAllChildren(null, false, false, 1, depthLimit).ConvertList<IObjectWithPathAndChildren, T>(); //.ConvertIList<IObjectWithPathAndChildren, T>();
            

            DirectedGraphStylingCase styleCase = GetStylingCase(nodes);

            Dictionary<String, Node> nodeDictionary = new Dictionary<string, Node>();

            foreach (var ch in nodes)
            {
                T child = (T)ch;
                var gn = output.Nodes.AddNode(GetNodeID(child), GetNodeLabel(child));
                var tid = GetTypeID(child);
                Double w = GetNodeWeight(child);
                gn.Category = styleCase.Categories.AddOrGetCategory(tid.ToString(), "", "").Id;
                gn.Background = styleCase.nodeStyler.GetHexColor(w, tid);
                gn.StrokeThinkness = styleCase.nodeStyler.GetBorderThickness(w, tid);
                gn.Stroke = styleCase.nodeStyler.GetHexColor(w, tid);
                SetNodeStyle(child, gn, styleCase);
            }

            foreach (var ch in nodes)
            {
                if (ch.parent != null)
                {
                    T parent = (T)ch.parent;
                    T child = (T)ch;
                    if ((parent != null) && (child != null))
                    {
                        var tmp = GetLink(parent, child);
                        var l_tid = GetTypeID(child);
                        Double l_w = GetLinkWeight(parent, child);
                        output.Links.Add(tmp);
                        tmp.Category = styleCase.Categories.AddOrGetCategory(l_tid.ToString(), "", "").Id;
                        tmp.StrokeThinkness = styleCase.linkStyler.GetBorderThickness(l_w, l_tid);
                        tmp.Stroke = styleCase.linkStyler.GetHexColor(l_w, l_tid);
                        SetLinkStyle(parent, child, tmp, styleCase);
                    }
                }

            }

            output.Layout = setup.GraphLayout; // DGML.enums.GraphLayoutEnum.Sugiyama;
            output.GraphDirection = setup.GraphDirection; // DGML.enums.GraphDirectionEnum.LeftToRight;
            
            return output;
        }

        public virtual void SetLinkStyle(T parent, T child, Link link, DirectedGraphStylingCase styleCase)
        {
            
        }

        public virtual void SetNodeStyle(T child, Node link, DirectedGraphStylingCase styleCase)
        {

        }


        public override DirectedGraphStylingCase GetStylingCase(IEnumerable<T> nodes)
        {
            DirectedGraphStylingCase output = new DirectedGraphStylingCase(setup);
            foreach (var ch in nodes)
            {
                Int32 tid = GetTypeID(ch);
                Double weight = GetNodeWeight(ch);

                output.nodeStyler.learn(tid, weight);


                if (ch.parent != null)
                {
                    T parent = (T)ch.parent;
                    T child = (T)ch;
                    if ((parent != null) && (child != null))
                    {

                        
                        var l_tid = GetTypeID(child);
                        Double l_w = GetLinkWeight(parent, child);
                        output.linkStyler.learn(l_tid, l_w);

                        var cl = output.Categories.AddOrGetCategory(GetTypeID(parent), GetCategoryID(parent), "");
                        output.Categories.AddUnique(cl);
                    }
                }
                
                var c = output.Categories.AddOrGetCategory(GetTypeID(ch), GetCategoryID(ch), "");
                output.Categories.AddUnique(c);

            }
            return output;

        }

       

        

       
    }

}