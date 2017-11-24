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

namespace imbSCI.DataComplex.diagram.builders
{
    using System.Collections;
    using imbSCI.DataComplex.diagram.core;
    using imbSCI.DataComplex.diagram.enums;

    /// <summary>
    /// Universal diagram builder for parent->children hierarchical objects
    /// </summary>
    /// <seealso cref="diagramBuilderBase" />
    public class diagramBuilderUniversalTree : diagramBuilderBase
    {


        /// <summary>
        /// Builds the diagram model from an object with children
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public override diagramModel buildModel(diagramModel output, IObjectWithPathAndChildSelector source)
        {

            if (source == null)
            {
                throw new ArgumentNullException("can-t build model :: source is null" +  "Diagram = source is null");
            }
            if (output == null)
            {
                output = new diagramModel("","",diagramDirectionEnum.LR);
                if (source is IObjectWithNameAndDescription)
                {
                    IObjectWithNameAndDescription source_IObjectWithNameAndDescription = (IObjectWithNameAndDescription)source;
                    output.name = source_IObjectWithNameAndDescription.name;
                    output.description = source_IObjectWithNameAndDescription.description;
                }

            }
            
            diagramNode parent = buildNode(output, source);
            //parent.relatedObject = source;

            List<diagramNode> childNodes = new List<diagramNode>();

            childNodes = buildChildren(output, parent, source, diagramNodeShapeEnum.normal, diagramLinkTypeEnum.normal, true);
            int c = 1;
            while (childNodes.Any())
            {
                c++;
                if (c > childDepthLimit)
                {
                    break;
                }
                List<diagramNode> newChildNodes = new List<diagramNode>();
                foreach (diagramNode childNode in childNodes)
                {
                    if (childNode.relatedObject is IEnumerable)
                    {
                        newChildNodes.AddRange(buildChildren(output, childNode, childNode.relatedObject as IEnumerable, diagramNodeShapeEnum.normal, diagramLinkTypeEnum.normal, true));
                    }
                }

                childNodes = newChildNodes;
            }

            
            return output;
        }


        /// <summary>
        /// Builds the children and returns newly built nodes
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="source">The source.</param>
        /// <param name="defShapeType">Type of the definition shape.</param>
        /// <param name="defLinkType">Type of the definition link.</param>
        /// <param name="doDegradeImportance">if set to <c>true</c> [do degrade importance].</param>
        /// <returns></returns>
        public List<diagramNode> buildChildren(diagramModel model, diagramNode parent, IEnumerable source, diagramNodeShapeEnum defShapeType = diagramNodeShapeEnum.normal, diagramLinkTypeEnum defLinkType = diagramLinkTypeEnum.normal, bool doDegradeImportance=true)
        {
            List<diagramNode> childNodes = new List<diagramNode>();

            if (source == null) return childNodes;

            foreach (IObjectWithPathAndChildSelector child in source)
            {
                diagramNode node = buildNode(model, child);
                node.shapeType = getShapeTypeEnum(child, defShapeType);
                //node.relatedObject = child;
                childNodes.Add(node);
                if (doDegradeImportance)
                {
                    node.importance = parent.importance - 1;
                }
                node.color = getColor(node);
            }

            foreach (diagramNode child in childNodes)
            {
                diagramLink link = model.AddLink(parent, child, diagramLinkTypeEnum.normal);
                link.type = getLinkTypeEnum(child, defLinkType);
                link.description = getLinkDescription(link, "");
                
            }
            return childNodes;
        }

        //public virtual 

        /// <summary>
        /// Builds a node.
        /// </summary>
        /// <param name="model">The diagram model.</param>
        /// <param name="source">The source object to build from</param>
        /// <returns></returns>
        public override diagramNode buildNode(diagramModel model, IObjectWithPathAndChildSelector source)
        {
            string name = getNodeName(source, "NaN");
            string description = getNodeDescription(source, name);
            diagramNode node = model.AddNode(description, diagramNodeShapeEnum.normal, name);

            node.relatedObject = source;

            return node;
        }


        public virtual string getNodeName(IObjectWithPathAndChildSelector source, string defName = "")
        {
            if (source is IObjectWithNameAndDescription)
            {
                IObjectWithNameAndDescription child_IObjectWithNameAndDescription = (IObjectWithNameAndDescription)source;
                return child_IObjectWithNameAndDescription.name;
                
            }
            return defName;
        }

        public virtual string getNodeDescription(IObjectWithPathAndChildSelector source, string defDescription = "")
        {
            if (source is IObjectWithNameAndDescription)
            {
                IObjectWithNameAndDescription child_IObjectWithNameAndDescription = (IObjectWithNameAndDescription)source;
                return child_IObjectWithNameAndDescription.description; 
            }
            return defDescription;
        }


        public virtual string getLinkDescription(diagramLink child, string defDescription = "")
        {
            return defDescription;
        }

        public virtual int getColor(diagramNode child, int defColor = 1)
        {
            return defColor;
        }

        public virtual diagramLinkTypeEnum getLinkTypeEnum(diagramNode child, diagramLinkTypeEnum defType = diagramLinkTypeEnum.normal)
        {
            return defType;
        }

        public virtual diagramNodeShapeEnum getShapeTypeEnum(IObjectWithPathAndChildSelector child, diagramNodeShapeEnum defType = diagramNodeShapeEnum.normal)
        {
            return defType;
        }
    }

}