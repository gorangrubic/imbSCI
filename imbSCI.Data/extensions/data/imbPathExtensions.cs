// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbPathExtensions.cs" company="imbVeles" >
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
namespace imbSCI.Data.extensions.data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using imbSCI.Data.enums;
    using imbSCI.Data.interfaces;
    //using imbSCI.Reporting.reporting.format;

    /// <summary>
    /// Universal Tree-structure access extensions and Path tools
    /// </summary>
    /// \ingroup_disabled ace_ext_path
    public static class imbPathExtensions
    {


        /// <summary>
        /// Adds path prefix for root member
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static String addPrefixForRoot(this String path)
        {
            return PATHSPLITER + path;
        }


        /// <summary>
        /// Gets the ordinal path part. If it is not ordinal path path> returns -1
        /// </summary>
        /// <param name="ordinalPart">The ordinal part.</param>
        /// <returns>Number from ordinal path sequence, or -1 if it is not ordinal path</returns>
        public static Int32 getOrdinalPathPart(String ordinalPart)
        {
            if (ordinalPart.StartsWith("[") && ordinalPart.EndsWith("]"))
            {
                ordinalPart = ordinalPart.Trim("[]".ToArray());
            }
            else
            {
                return -1;
            }
            return Convert.ToInt32(ordinalPart);
        }




        //public static IObjectWithPathAndChildSelector getMemberByPath(this IObjectWithPathAndChildSelector shead, )

        /// <summary>
        /// Get member by resolving relative or absolute <c>path</c> over <c>shead</c> starting object.
        /// </summary>
        /// <remarks>
        /// Path supports: absolute (starts with <c>PATHSPLITER</c>, go to parent <c>..</c>, ordinal selectors <c>[1]</c> and sequential child <c>name</c> selection
        /// </remarks>
        /// <param name="shead">Start head - object to start from</param>
        /// <param name="path">The path: accepts go to parent syntax.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">getChild() STACK OVERFLOW [".o(c).a("] metaContentBase")</exception>
        public static IObjectWithChildSelector getChildByPath(this IObjectWithChildSelector shead, string path)
        {


            if (path.StartsWith(PATHSPLITER))
            {
                if (shead is IObjectWithRoot)
                {
                    IObjectWithRoot sroot = shead as IObjectWithRoot;
                    shead = sroot.root as IObjectWithChildSelector;
                }
                path = imbSciStringExtensions.removeStartsWith(path, PATHSPLITER);
            }


            List<string> prts = path.SplitSmart(PATHSPLITER); //.getPathParts();
            IObjectWithChildSelector head = shead;

            Int32 c = 0;
            foreach (String pt in prts)
            {


                IObjectWithChildSelector nhead;
                Int32 ord = getOrdinalPathPart(pt);

                if (ord > -1)
                {
                    if (ord >= head.Count())
                    {
                        ord = head.Count() - 1;
                    }

                    nhead = head[ord] as IObjectWithChildSelector;
                }
                else if (pt.StartsWith(PATHGO_PARENT))
                {
                    IObjectWithParent phead = head as IObjectWithParent;
                    if (phead != null)
                    {
                        nhead = phead.parent as IObjectWithPathAndChildSelector;
                    }
                    else
                    {
                        throw new ArgumentException("Go to parent path syntax found but head is not IObjectWithParent!!"); //  [".o(c).a("] metaContentBase"));
                    }
                }
                else
                {
                    nhead = head[pt] as IObjectWithChildSelector;
                }

                if (nhead == head)
                {
                    // logSystem.log("tmp");
                    //break;
                }
                else
                {
                    head = nhead;
                }
                c++;
                if (c > 100)
                {
                    throw new ArgumentException("getChild() would lead to STACK OVERFLOW - the limit was breached"); // aceGeneralException("getChild() STACK OVERFLOW [".o(c).a("] metaContentBase"));
                }
            }

            return head;
        }

        internal static String PATHGO_ROOT = "\\";
        internal static String PATHGO_PARENT = "..";
        internal static String PATHSPLITER = "\\";

        internal static String XPATHGO_ROOT = "\\";
        internal static String XPATHGO_PARENT = "..";
        internal static String XPATHSPLITER = "\\";

        internal static Int32 PATHSEARCH_MAX_LIMIT = 10000;


        public static IObjectWithPath detectParentChildLoopReference(this List<IObjectWithPath> suspects)
        {
            IObjectWithPath output = null;

            List<string> uidList = new List<string>();

            foreach (IObjectWithPath item in suspects)
            {
                String uid = "";

                if (item is IObjectWithUID)
                {
                    IObjectWithUID item_IObjectWithUID = (IObjectWithUID)item;
                    uid = item_IObjectWithUID.UID;
                }

                /// ovde prosiriti podrsku za jos neke objekte - za sada samo IObjectWithUID podrzava

                if (uidList.Contains(uid))
                {
                    // objekat sa istim uidom vec postoji znaci da je on uzrok problema

                    return item;

                } else
                {
                    uidList.Add(uid);
                }
                
            }

            // ako je do ovde stigao znaci da nije nasao uzrok loopa


            return output;
        }


        /// <summary>
        /// Gets all parents. Prevents loop inherence.
        /// </summary>
        /// <param name="source">The object to start from. Excluded from result</param>
        /// <param name="parentDepthLimit">The parent depth limit.</param>
        /// <returns>
        /// List of all parents until root object or until looped node. Order of objects in the result is from <c>source</c> to <c>root</c>
        /// </returns>
        /// <exception cref="Exception"></exception>
        /// <seealso cref="IObjectWithPath" />
        /// <seealso cref="IObjectWithRoot" />
        public static List<IObjectWithPath> getParentsViaExtension(this IObjectWithPath source, Int32 parentDepthLimit=2000)
        {
            List<IObjectWithPath> output = new List<IObjectWithPath>();
            IObjectWithPath head = source;
            IObjectWithPath last_head = source;
            Int32 c = 0;
            do
            {
                c++;
                if (c>parentDepthLimit)
                {
                    IObjectWithPath looper = output.detectParentChildLoopReference();

                    if (looper == null)
                    {
                        
                        //throw new aceGeneralException("Parent search reached limit [" + parentDepthLimit + "] for [" + source.name + "]");
                    } else
                    {
                        String msg = "Parent search reached limit[" + parentDepthLimit + "] for [" + source.name + "]";
                        msg = msg + "Looper found: " + looper.name;

                        throw new ArgumentOutOfRangeException(nameof(source), msg);
                    }

                    
                    break;
                }
                head = head.parent as IObjectWithPath;
                if (head == last_head)
                {
                    // object is parent to it self
                    head = null;
                }
                if (head != null)
                {
                    if (output.Contains(head))
                    {
                        head = null;
                    }
                    else
                    {
                        output.Add(head);
                    }
                }
                last_head = head;


            } while (head !=null);
            return output;

        }

        /// <summary>
        /// Gets the path string - including <c>source</c> at end of the path
        /// </summary>
        /// <param name="source">Object to get XPath for</param>
        /// <param name="useXPathFormat">if set to <c>true</c> if will return XPath format with / instead of backslash, otherwise it will use \\ as path separator member.</param>
        /// <returns>
        /// XPath string with the root backslash
        /// </returns>
        public static String getPathViaExtension(this IObjectWithPath source, Boolean useXPathFormat)
        {
            List<IObjectWithPath> parents = source.getParentsViaExtension();
            String output = PATHGO_ROOT;
            if (useXPathFormat) output = XPATHGO_ROOT;

            parents.Reverse();
            parents.Add(source);

            Int32 l = parents.Count();
            for (int i = 0; i < l; i++)
            {
                if (output.isNullOrEmpty())
                {
                    output = output + parents[i].name;
                } else
                {
                    if (useXPathFormat)
                    {
                        output = output + XPATHSPLITER + parents[i].name;
                    } else
                    {
                        output = output + PATHSPLITER + parents[i].name;
                    }
                    
                }
            }
            
            return output;
        }



        /// <summary>
        /// Gets a member from parent-chain: a) Nth parent according to limit. b) parent on <c>targetPath</c>, c) parent of <c>target</c> type or simply d) root if no more parents.
        /// </summary>
        /// <param name="source">The source - objects to start search from</param>
        /// <param name="target">The target Type - what type will triger return of current head</param>
        /// <param name="limit">The limit of depth. For -1: unlimited, For 1: it will return source.parent, For 0: it will return source, for 50: it will return  50th parent in parent-chain.</param>
        /// <param name="targetPath">Once head reach this path it will trigger return of head. Disabled if empty or null.</param>
        /// <returns>Parent in parent chain or root</returns>
        /// \ingroup_disabled ace_ext_path
        public static IObjectWithParent getParentOrRoot(this IObjectWithParent source, String targetPath = "", Type target = null, Int32 limit = 100)
        {
            IObjectWithParent head = source;

            Int32 c = 0;
            Boolean p_testOn = (!imbSciStringExtensions.isNullOrEmptyString(targetPath) || (source is IObjectWithPath));
            Boolean t_testOn = (target != null);
            if (limit == -1) limit = PATHSEARCH_MAX_LIMIT;

            do
            {
                IObjectWithParent nhead = head.parent as IObjectWithParent;

                if (nhead == null) return head;


                if (nhead == head)
                {
                    throw new ArgumentException("IObjectWithParent.parent is the object it self! getParentOrRoot [" + c + "]");
                    // logSystem.log("tmp");
                    break;
                }
                else
                {

                    head = nhead;
                }

                if (t_testOn)
                {
                    if (head.GetType() == target)
                    {
                        return head;
                    }
                }

                if (p_testOn)
                {
                    IObjectWithPath p_head = head as IObjectWithPath;
                    if (p_head != null)
                    {
                        if (p_head.path == targetPath)
                        {
                            return head;
                        }
                    }

                }

                c++;
                if ((c > limit) || (c > PATHSEARCH_MAX_LIMIT))
                {
                    return head;
                    //
                }
            } while (head.parent != null);

            return head;
        }

        /// <summary>
        /// Relative path to memeber in parent chain
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns>Propert relative path</returns>
        public static String getPathToParent(this IObjectWithParent source, IObjectWithParent target, String prefix = "", Int32 limit = 100)
        {

            String output = "";
            IObjectWithParent head = source;

            Int32 c = 0;

            if (limit == -1) limit = PATHSEARCH_MAX_LIMIT;

            do
            {
                output = PATHGO_PARENT.add(output, PATHSPLITER);

                head = head.parent as IObjectWithParent;

                c++;
                if ((c > limit) || (c > PATHSEARCH_MAX_LIMIT))
                {
                    break;
                }

            } while ((head != null) && (head != target));



            return output;

        }


        public const String DefaultXPathSplitter = "/";

        /// <summary>
        /// Returns common part of the path - the root that both paths are sharing
        /// </summary>
        /// <param name="xPathA"></param>
        /// <param name="xPathB"></param>
        /// \ingroup_disabled ace_ext_xpath_highlight
        /// <returns></returns>
        public static String getCommonRoot(this String xPathA, String xPathB, Boolean includeAbsolute = false, String splitter = "")
        {
            String output = "";
            if (splitter.isNullOrEmpty()) splitter = DefaultXPathSplitter;
            if (String.IsNullOrEmpty(xPathB)) return "";
            if (String.IsNullOrEmpty(xPathB)) return "";

            if (includeAbsolute) output = splitter;
            String[] tmpA = xPathA.Split(splitter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            String[] tmpB = xPathB.Split(splitter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            Int32 a = tmpA.Length;
            if (a > tmpB.Length)
            {
                a = tmpB.Length;
            }

            Int32 i = 0;

            for (i = 0; i < a; i++)
            {
                output += tmpA[i] + splitter;
            }

            return output.TrimEnd(splitter.ToCharArray());
        }

        /// <summary>
        /// Removes common root from <c>xPathA</c> and returns result
        /// </summary>
        /// <param name="xPathA">The x path a.</param>
        /// <param name="xPathB">The x path b.</param>
        /// <param name="includeAbsolute">if set to <c>true</c> [include absolute].</param>
        /// <returns></returns>
        /// \ingroup_disabled ace_ext_xpath_highlight
        public static String removeCommonRoot(this String xPathA, String xPathB, Boolean includeAbsolute = false, String splitter = "")
        {
            String output = "";
            if (splitter.isNullOrEmpty()) splitter = DefaultXPathSplitter;
            //if (includeAbsolute) output = "/";

            String root = getCommonRoot(xPathA, xPathB, includeAbsolute);

            if (!String.IsNullOrEmpty(root))
            {
                xPathA = xPathA.TrimStart(splitter.ToCharArray());
                root = root.TrimStart(splitter.ToCharArray());

                if (xPathA.StartsWith(root))
                {
                    output += xPathA.Replace(root, "");
                }
                else
                {
                    output += xPathA;
                }
            }
            else
            {
                output = xPathA;
            }

            if (includeAbsolute) output = splitter + output;

            return output;
        }

        /// <summary>
        /// Gets the path from object - just casting trick
        /// </summary>
        /// <param name="head">The head.</param>
        /// <returns></returns>
        public static String getPathFromObject(this IObjectWithPath head)
        {
            IObjectWithPath p_head = head as IObjectWithPath;
            if (p_head != null)
            {
                return p_head.path;
            }
            if (head is IObjectWithName)
            {
                IObjectWithName n_head = head as IObjectWithName;
                return PATHGO_PARENT + n_head.name;
            }
            return PATHSPLITER;
        }

        /// <summary>
        /// Discovers relative path to <c>target</c> member of the structure
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>String that leads to target</returns>
        public static string getPathTo(this IObjectWithPathAndChildSelector source, IObjectWithPathAndChildSelector target)
        {
            String t_path = target.path;
            String s_path = source.path;
            String c_path = t_path.getCommonRoot(s_path, false);
            String c_to_t = imbSciStringExtensions.removeStartsWith(t_path, c_path);


            IObjectWithPathAndChildSelector root = source.getParentOrRoot() as IObjectWithPathAndChildSelector;

            IObjectWithPathAndChildSelector common = root.getChildByPath(c_path) as IObjectWithPathAndChildSelector; // root.getChild(c_to_t);

            String s_to_c = source.getPathToParent(common);


            String output = s_to_c.add(c_to_t, PATHSPLITER);
            return output;
        }


        

        public static List<T> getTyped<T>(this IEnumerable<IObjectWithName> source) where T:IObjectWithName
        {
            List<T> output = new List<T>();
            foreach (IObjectWithName on in source) output.Add((T)@on);
            return output;
        }


        /// <summary>
        /// Null safe way to get meta element level
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static reportElementLevel getElementLevel(this IObjectWithReportLevel source)
        {
            if (source == null)
            {
                return reportElementLevel.none;
            }

            return source.elementLevel;
            /*

            if (source.GetType().get("IMetaDocument") != null)
            {
                return reportElementLevel.document;
            }

            if (source.GetType().GetInterface("IMetaDocumentSet") != null)
            {
                return reportElementLevel.documentSet;
            }


            if (source.GetType().GetInterface("IMetaServicePage") != null)
            {
                return reportElementLevel.servicepage;
            }

            if (source.GetType().GetInterface("IMetaPage") != null)
            {
                return reportElementLevel.page;
            }

            if (source.GetType().GetInterface("IMetaBlock") != null)
            {
                return reportElementLevel.block;
            }

            String sourceName = source.ToString();

            if (sourceName == "delivery")
            {
                return reportElementLevel.delivery;
            }
            else
            {

            }
            */
            return reportElementLevel.none;
        }

        public static Boolean isElementLevel(this IObjectWithReportLevel obj, reportElementLevel element)
        {
            reportElementLevel el = getElementLevel(obj);
            return (el == element);
        }

        /// <summary>
        /// Gets the parent of target element level or root if reached
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="level">The level.</param>
        /// <param name="getLastParent">if set to <c>true</c> [get last parent].</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        public static IObjectWithParent getParentOfLevel(this IObjectWithParent source, reportElementLevel level, Boolean getLastParent=false, Boolean nullForNotFound=true, Int32 limit = 100)
        {
            IObjectWithParent output = source;
            IObjectWithReportLevel head = output as IObjectWithReportLevel;
            Int32 c = 0;

            if (limit == -1) limit = PATHSEARCH_MAX_LIMIT;

            do
            {

                head = head.parent as IObjectWithReportLevel;

                if (getLastParent)
                {
                    if (head.elementLevel == level)
                    {
                        IObjectWithReportLevel parent = head.parent as IObjectWithReportLevel;
                        if (parent != null)
                        {
                            if (!(parent.elementLevel == level))
                            {
                                return head;
                            }
                        } else
                        {
                            return head;
                        }
                    } else
                    {
                        
                    }
                    
                } else
                {
                    if (getElementLevel(head) == level)
                    {
                        return head;
                    }
                }
                

                c++;
                if ((c > limit) || (c > PATHSEARCH_MAX_LIMIT))
                {
                    break;
                }

            } while ((head != null));

            if (head == null)
            {
                if (nullForNotFound)
                {

                } else
                {

                }
            }
            return head;
        }
    }
}
