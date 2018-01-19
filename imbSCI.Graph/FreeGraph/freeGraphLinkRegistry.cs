using System;
using System.Linq;
using System.Collections.Generic;
using imbSCI.Core.extensions.data;
using System.Text;
using System.Xml.Serialization;
using imbSCI.Core.reporting;

namespace imbNLP.PartOfSpeech.TFModels.semanticCloud.core
{

    public class freeGraphLinkRegistry
    {
        public freeGraphLinkRegistry()
        {

        }

        public void Clear()
        {
            linkedAtoBDictionary.Clear();
            linkedBtoADictionary.Clear();
            linkAtoBDictionary.Clear();
            linkBtoADictionary.Clear();
            linkDictionary.Clear();
        }

        public Boolean Any()
        {
            if (linkedAtoBDictionary.Any()) return true;
            if (linkedBtoADictionary.Any()) return true;
            return false;
        }

        /// <summary>
        /// Makes the link key - for quering the optimized collections
        /// </summary>
        /// <param name="nodeNameA">The node name a.</param>
        /// <param name="nodeNameB">The node name b.</param>
        /// <returns></returns>
        public static String GetLinkKey(String nodeNameA, String nodeNameB)
        {
            if (String.CompareOrdinal(nodeNameA, nodeNameB)<0)
            {
                return nodeNameB + "--" + nodeNameA;
            }

            return nodeNameA + "--" + nodeNameB;
        }

        /// <summary>
        /// Gets the link - order of nodeNameA and nodeNameB is irrelevant for the query
        /// </summary>
        /// <param name="nodeNameA">The node name a.</param>
        /// <param name="nodeNameB">The node name b.</param>
        /// <returns></returns>
        public freeGraphLinkBase GetLink(String nodeNameA, String nodeNameB)
        {
            freeGraphLinkBase output = null;

            String key = GetLinkKey(nodeNameA, nodeNameB);
            if (linkDictionary.ContainsKey(key))
            {
                return linkDictionary[key];
            }

            return output;
        }


        public List<freeGraphLinkBase> GetLinks(String nodeName, Boolean AtoB = true, Boolean BtoA = true)
        {
            List<freeGraphLinkBase> output = new List<freeGraphLinkBase>();

            if (BtoA)
            {
                if (linkBtoADictionary.ContainsKey(nodeName))
                {

                    output.AddRange(linkBtoADictionary[nodeName]);
                }
            }
            if (AtoB)
            {
                if (linkAtoBDictionary.ContainsKey(nodeName))
                {
                    output.AddRange(linkAtoBDictionary[nodeName]);
                }
            }
            
            return output;
        }

        public List<freeGraphNodeBase> GetLinkedNodesBase(String nodeName, Boolean BtoA = false, Int32 distanceCorrection = 0, Boolean cloneAndAdjustWeight=true)
        {
            List<freeGraphNodeBase> output = new List<freeGraphNodeBase>();
            Double weightFactor = 1;
            if (cloneAndAdjustWeight == false)
            {
                if (BtoA)
                {
                    if (linkedBtoADictionary.ContainsKey(nodeName))
                    {

                        return linkedBtoADictionary[nodeName];
                    }
                }
                else
                {
                    if (linkedAtoBDictionary.ContainsKey(nodeName))
                    {
                        return linkedAtoBDictionary[nodeName];
                    }
                }
            } else
            {
                if (BtoA)
                {
                    if (linkedBtoADictionary.ContainsKey(nodeName))
                    {

                        foreach(var link in linkBtoADictionary[nodeName])
                        {
                            freeGraphNodeBase nodeA = linkedBtoADictionary[nodeName].FirstOrDefault(x => x.name == link.nodeNameA);
                            if (nodeA != null)
                            {
                                var n = nodeA.GetQueryResultClone(distanceCorrection);
                                n.weight = n.weight * link.weight;
                                output.Add(n);
                            }
                        }

                        return output;
                    }
                }
                else
                {
                    if (linkedAtoBDictionary.ContainsKey(nodeName))
                    {

                        foreach (var link in linkAtoBDictionary[nodeName])
                        {
                            freeGraphNodeBase nodeB = linkedAtoBDictionary[nodeName].FirstOrDefault(x => x.name == link.nodeNameB);
                            if (nodeB != null)
                            {
                                var n = nodeB.GetQueryResultClone(distanceCorrection);
                                n.weight = n.weight * link.weight;
                                output.Add(n);
                            }
                        }

                        return output;
                    }
                }

            }
            return new List<freeGraphNodeBase>();
        }


        public Boolean ContainsLink(String nodeNameA, String nodeNameB, Boolean includeBtoALinks = false)
        {
            Boolean output = false;

            if (includeBtoALinks)
            {
                String key = GetLinkKey(nodeNameA, nodeNameB);
                return linkDictionary.ContainsKey(key);
            }

            if (linkedAtoBDictionary.ContainsKey(nodeNameA))
            {
                output = linkedAtoBDictionary[nodeNameA].Any(x => x.name == nodeNameB);
            }
            if (!output && includeBtoALinks)
            {
                if (linkedBtoADictionary.ContainsKey(nodeNameA))
                {
                    output = linkedBtoADictionary[nodeNameA].Any(x => x.name == nodeNameB);
                }
            }
            return output;
        }

        public Boolean UnregisterLink(String nodeName, ILogBuilder logger=null)
        {
            try
            {
                linkedAtoBDictionary.Remove(nodeName);
                linkedBtoADictionary.Remove(nodeName);
                List<freeGraphLinkBase> links = new List<freeGraphLinkBase>();
                if (linkAtoBDictionary.ContainsKey(nodeName))
                {
                    links.AddRange(linkAtoBDictionary[nodeName]);

                }
                if (linkBtoADictionary.ContainsKey(nodeName))
                {
                    links.AddRange(linkBtoADictionary[nodeName]);
                }
                Int32 lc = 0;
                foreach (freeGraphLinkBase l in links)
                {
                    if (linkDictionary.Remove(GetLinkKey(l.nodeNameA, l.nodeNameB)))
                    {
                        lc++;
                    }
                }

                linkAtoBDictionary.Remove(nodeName);
                linkBtoADictionary.Remove(nodeName);


                return lc > 0;
            } catch (Exception ex)
            {
                if (logger != null) logger.log("Node link unregister call failed> " + ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Registers the link, returns true if this link is redundant
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="nodeDictionary">The node dictionary.</param>
        /// <returns></returns>
        public Boolean RegisterLink(freeGraphLinkBase link, Dictionary<String, freeGraphNodeBase> nodeDictionary)
        {
            if (!linkedAtoBDictionary.ContainsKey(link.nodeNameA))
            {
                linkedAtoBDictionary.Add(link.nodeNameA, new List<freeGraphNodeBase>());
                linkAtoBDictionary.Add(link.nodeNameA, new List<freeGraphLinkBase>());
            }
            if (!linkedBtoADictionary.ContainsKey(link.nodeNameB))
            {
                linkedBtoADictionary.Add(link.nodeNameB, new List<freeGraphNodeBase>());
                linkBtoADictionary.Add(link.nodeNameB, new List<freeGraphLinkBase>());
            }
            Boolean isRedundant = false;
            if (linkedAtoBDictionary[link.nodeNameA].Contains(nodeDictionary[link.nodeNameB]))
            {
                isRedundant = true;
            }
            if (linkedBtoADictionary[link.nodeNameB].Contains(nodeDictionary[link.nodeNameA]))
            {
                isRedundant = true;
            }
            if (isRedundant)
            {
                
            }
            else
            {
                linkedAtoBDictionary[link.nodeNameA].Add(nodeDictionary[link.nodeNameB]);
                linkedBtoADictionary[link.nodeNameB].Add(nodeDictionary[link.nodeNameA]);
                linkAtoBDictionary[link.nodeNameA].Add(link);
                linkBtoADictionary[link.nodeNameB].Add(link);
                linkDictionary.Add(GetLinkKey(link.nodeNameA, link.nodeNameB),link);
            }
            return isRedundant;
        }

        protected Dictionary<String, List<freeGraphNodeBase>> linkedAtoBDictionary { get; set; } = new Dictionary<string, List<freeGraphNodeBase>>();
        protected Dictionary<String, List<freeGraphNodeBase>> linkedBtoADictionary { get; set; } = new Dictionary<string, List<freeGraphNodeBase>>();
        protected Dictionary<String, List<freeGraphLinkBase>> linkAtoBDictionary { get; set; } = new Dictionary<string, List<freeGraphLinkBase>>();
        protected Dictionary<String, List<freeGraphLinkBase>> linkBtoADictionary { get; set; } = new Dictionary<string, List<freeGraphLinkBase>>();
        protected Dictionary<String, freeGraphLinkBase> linkDictionary { get; set; } = new Dictionary<String, freeGraphLinkBase>();
    }

}