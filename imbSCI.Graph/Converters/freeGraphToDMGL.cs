using imbNLP.PartOfSpeech.TFModels.semanticCloud.core;
using imbSCI.Data.collection.special;
using imbSCI.Core.extensions.text;
using imbSCI.Core.extensions.data;

using imbSCI.Graph.DGML;
using imbSCI.Graph.DGML.collections;
using imbSCI.Graph.DGML.core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using imbSCI.Core.reporting.colors;
using imbSCI.Graph.Converters.tools;

namespace imbSCI.Graph.Converters
{

    public abstract class ToDGMLConverterBase
    {
        public GraphStylerSettings setup { get; set; }

        public CategoryCollection Categories { get; set; } = new CategoryCollection();

        public NodeWeightStylerCategories nodeStyler { get; set; }

        public NodeWeightStylerCategories linkStyler { get; set; }
    }

    /// <summary>
    /// Free graph to DMGL converter
    /// </summary>
    public class freeGraphToDMGL:ToDGMLConverterBase
    {

        public freeGraphToDMGL(GraphStylerSettings settings = null)
        {
            setup = settings;
            if (setup == null) setup = new GraphStylerSettings();
        }
        


        public DirectedGraph ConvertToDMGL(freeGraph input)
        {
            DirectedGraph output = new DirectedGraph();
            output.Title = input.name;

           // input.InverseWeights(false, true);

            nodeStyler = new NodeWeightStylerCategories(setup);
            linkStyler = new NodeWeightStylerCategories(setup);

            foreach (freeGraphNodeBase node in input.nodes)
            {
                try
                {
                    if (node != null)
                    {
                        var c = Categories.AddOrGetCategory(node.type.ToString(), "", "");
                        output.Categories.AddUnique(c);
                        nodeStyler.learn(node.type, node.weight);
                    }
                } catch (Exception ex)
                {
                    output.ConversionErrors.Add("Node learning-conversion: " + ex.Message + Environment.NewLine + ex.StackTrace);
                }

            }

            foreach (var link in input.links)
            {
                try
                {
                    if (link != null)
                    {
                        var c = Categories.AddOrGetCategory(link.type.ToString(), "", "");
                        output.Categories.AddUnique(c);
                        linkStyler.learn(link.type, link.weight);
                    }
                }
                catch (Exception ex)
                {
                    output.ConversionErrors.Add("link learning-conversion: " + ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }

            

            foreach (freeGraphNodeBase node in input.nodes)
            {
                try
                {
                    if (node != null)
                    {
                        var nd = output.Nodes.AddNode(node.name);
                        nd.Category = output.Categories[node.type].Id;
                        nd.Background = nodeStyler.GetHexColor(node.weight, node.type);
                        nd.StrokeThinkness = nodeStyler.GetBorderThickness(node.weight, node.type);
                        nd.Label = nd.Label + " (" + node.weight.ToString(setup.NodeWeightFormat) + ")";
                        if (setup.doAddNodeTypeToLabel)
                        {
                            nd.Label = nd.Label + " [" + node.type + "]";
                        }
                    }
                }
                catch (Exception ex)
                {
                    output.ConversionErrors.Add("Node conversion: " + ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }

            foreach (var link in input.links)
            {
                try
                {
                    if (link != null)
                    {

                        var nodeA = input.GetNode(link.nodeNameA);
                        var nodeB = input.GetNode(link.nodeNameB);

                        var lnk = new Link(link.nodeNameA, link.nodeNameB);

                        if (setup.doLinkDirectionFromLowerTypeToHigher)
                        {
                            if (nodeB.type < nodeA.type)
                            {
                                lnk = new Link(link.nodeNameB, link.nodeNameA);
                            }
                        }


                        if (setup.doMakeLinkLabel) lnk.Label = link.weight.ToString(setup.LinkWeightFormat);
                        lnk.Category = output.Categories[link.type].Id;
                        lnk.Stroke = linkStyler.GetHexColor(link.weight, link.type);
                        lnk.StrokeThinkness = linkStyler.GetBorderThickness(link.weight, link.type);
                        output.Links.Add(lnk);
                    }
                } catch (Exception ex)
                {
                    output.ConversionErrors.Add("Link conversion: " + ex.Message + Environment.NewLine + ex.StackTrace);  
                }
            }

            output.Layout = DGML.enums.GraphLayoutEnum.ForceDirected;
            output.GraphDirection = DGML.enums.GraphDirectionEnum.Sugiyama;


            return output;


        }

    }
}
