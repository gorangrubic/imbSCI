// --------------------------------------------------------------------------------------------------------------------
// <copyright file="links_charplibs.cs" company="imbVeles" >
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
// Project: imbSCI.Reporting
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Reporting.links.presets
{
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
    using imbSCI.Core.reporting.render;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    using imbSCI.Reporting.delivery;
    using imbSCI.Reporting.interfaces;
    using imbSCI.Reporting.resources;
    using imbSCI.Reporting.script;

    public class links_charplibs : reportLinkCollection
    {
        public links_charplibs()
        {
            title = "C# Libraries";
            description = "Links with help, examples and other info on relevant C#/.NET libraries";

            // EXAMPLE ENTRIEs - to be changed
            AddGroup("Bootstrap", "Links on the Bootstrap framework");

            AddLink("Home", "Home of Bootstrap framework", "http://getbootstrap.com/");
            AddLink("Componenets", "Components within Bootstrap", "http://getbootstrap.com/components/");




            AddGroup("Showdown", "Showdown is Markdown to HTML converter written in Javascript used by Bootmark library");

            AddLink("Showdown home", "Github home page for showdown", "https://github.com/showdownjs/showdown");
            AddLink("Showdown demo", "Demo page with online editor to test output", "http://showdownjs.github.io/demo/");
            AddLink("Showdown Wiki", "Wiki of the Showdown project", "https://github.com/showdownjs/showdown/wiki");



            AddGroup("Bootmark", "Useful links on the Bootmark library");

            AddLink("Bootmark", "Home of Bootmark library", "https://obedm503.github.io/article/2016-09-23-bootmark.html");
            AddLink("Bootmark documents", "Bootmark official documentation", "https://obedm503.github.io/bootmark/docs/");
            AddLink("Bootmark demo", "Demo of Bootmark javascript library", "https://obedm503.github.io/bootmark/");
            AddLink("Bootmark examples", "Page with examples of bootmark explanation", "https://obedm503.github.io/bootmark/docs/examples.html");

        }
    }

}