// --------------------------------------------------------------------------------------------------------------------
// <copyright file="externalTool.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
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
// Project: imbSCI.Data
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Data.enums
{
    /// <summary>
    /// External tool to run. Call extension to open tool and specified file from <c>filepath</c>
    /// </summary>
    public enum externalTool
    {
        none,
        /// <summary>
        /// Mozzila FireFox
        /// </summary>
        firefox,

        /// <summary>
        /// Google Chrome
        /// </summary>
        chrome,

        /// <summary>
        /// Internet Explorer
        /// </summary>
        explorer,

        /// <summary>
        /// Notepad ++
        /// </summary>
        notepadpp,

        /// <summary>
        /// Adobe Dreamweaver
        /// </summary>
        dreamweaver,

        /// <summary>
        /// WAMP server
        /// </summary>
        wamp,

        /// <summary>
        /// phpMyAdmin 
        /// </summary>
        phpMyAdmin,

        /// <summary>
        /// Windows Explorer da otvori folder gde se nalazi trenutni projekat
        /// </summary>
        projectFolder,

        /// <summary>
        /// Windows Explorer da otvori folder gde je instalirana aplikacija
        /// </summary>
        runtimeFolder,

        /// <summary>
        /// Windows Explorer da otvori WAMP www
        /// </summary>
        wampWWW,

        /// <summary>
        /// WAMP localhost via Firefox
        /// </summary>
        wampLocalhost,

        /// <summary>
        /// Windows Explorer
        /// </summary>
        folderExplorer,

        /// <summary>
        /// Adobe photoshop
        /// </summary>
        photoshop,

        /// <summary>
        /// Gde se nalazi dot.exe
        /// </summary>
        graphVizDot,

        /// <summary>
        /// Poziva kao command line
        /// </summary>
        fusekiServer,

        /// <summary>
        /// Poziva kao JAR preko Java
        /// </summary>
        fusekiServerJava,


        /// <summary>
        /// Prikaz fuseki local hosta
        /// </summary>
        fusekiLocalhost,

        /// <summary>
        /// Alatka za slobodno izvrsavanje
        /// </summary>
        freeRunner,

        /// <summary>
        /// Forces the application to guess tool by extension
        /// </summary>
        autodetect,
    }


}