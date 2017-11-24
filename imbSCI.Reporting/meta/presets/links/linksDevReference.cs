namespace imbSCI.Reporting.meta.presets.links
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Reporting.meta.blocks;
    using imbSCI.Reporting.meta.collection;
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
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    /// <summary>
    /// List of reference manuals
    /// </summary>
    public class linksDevReference:metaLinkCollection
    {

        #region --- topic ------- what development domain is this 

        /// <summary>
        /// what development domain is this
        /// </summary>
        public linksDevReferenceDomain topic { get; set; } = linksDevReferenceDomain.standard;

        #endregion


        public linksDevReference(linksDevReferenceDomain topic)
        {

            loadTopic(topic);
        }

        internal void loadTopic(linksDevReferenceDomain topic)
        {
            type = metaLinkCollectionType.externalWeb;
            rootRelativePath = "\\imbVelesFrameworkDocs";
            switch (topic)
            {
                case linksDevReferenceDomain.standard:
                    AddLink("MSDN:APIs", "Microsoft Developer Network - APIs index page", @"https://msdn.microsoft.com/library");
                    AddLink(".NET library", "Microsoft .NET framework 4.0", @"https://msdn.microsoft.com/en-us/library/w0x726c2(v=vs.100).aspx");
                    AddLink("C# language", "C# language reference", @"https://msdn.microsoft.com/en-us/library/618ayhy6.aspx");
                    AddLink("HtmlAgilityPack", "HTML processing library", @"htmlagility.chm");
                    break;
                case linksDevReferenceDomain.web:
                    AddLink("JS Grid", "JS Grid table plug in", @"http://js-grid.com/demos/");
                    break;
                case linksDevReferenceDomain.reporting:
                    AddLink("PDFSharp", "Library for: text abstract, printing, RTF, png/jpg, meta files EMF, HTML... supports CMYK", @"http://www.pdfsharp.net/");
                    AddLink("Doddle", "Library for: OpenXML, PDF, HTML, CSV.", @"https://doddlereport.codeplex.com/");
                    AddLink("GRAV Markdown", "Learning resource for Markdown syntax", @"https://learn.getgrav.org/content/markdown");
                    AddLink("W3C CSS", "W3schools CSS reference", @"http://www.w3schools.com/tags/tag_head.asp");
                    AddLink("W3C HTML", "W3schools HTML reference", @"http://www.w3schools.com/html/default.asp");
                    AddLink("W3C JS", "W3schools JavaScript reference", @"http://www.w3schools.com/js/default.asp");
                    AddLink("W3C JQUERY", "W3schools JavaScript reference", @"http://www.w3schools.com/js/default.asp");
                    break;
                case linksDevReferenceDomain.semantic:
                    AddLink("RDF Sharp .NET", "Library for RDF and Ontologies", @"https://rdfsharp.codeplex.com/");
                    AddLink("dotNetRDF", "RDF, SPARQL and the Semantic Web", @"https://bitbucket.org/dotnetrdf/dotnetrdf/wiki/UserGuide/Working%20with%20Triple%20Stores");
                    break;
                case linksDevReferenceDomain.nlp:
                    break;
                case linksDevReferenceDomain.xml:
                    break;
                
            }
        }
    }
}