namespace imbSCI.DataComplex.linknode
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text.RegularExpressions;
    using imbSCI.Core;
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.data;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.interfaces;
    using imbSCI.Core.reporting;
    using imbSCI.Data;
    using imbSCI.Data.data;
    using imbSCI.Data.interfaces;

    public static class linknodeTools
    {
        // ([\w\d-\.=]*)[/#\&\$\?\:]*
        // regex za razbijanje na nodove

        public static Regex regexForPathElements = new Regex(@"([\w\d-\.=]+)[/#\&\$\?\:]*", RegexOptions.Compiled);

        public static PropertyCollectionExtended buildParentScoreCollection(this linknodeElement node)
        {
            PropertyCollectionExtended pce = new PropertyCollectionExtended();
            linknodeElement head = node;

            do
            {
                if (head == null) break;
                pce.Add(head.name, head.score, head.name, head.path + " [" + head.level.ToString() + "]");
                if (head.parent != null)
                {
                    head = head.parent;
                }


            } while (head.parent != null);

            return pce;
        }

        public static DataTable buildParentScoreTable(this linknodeElement node)
        {
            PropertyCollectionExtended pce = node.buildParentScoreCollection();

            DataTable dataTable = pce.buildDataTable("Score table");

            return dataTable;
        }

        public const char PATH_SPLITTER = '/';
      

        /// <summary>
        /// Processes the <c>path</c>, builds nodes if missing and adds scores to existing elements. Supplied meta object is attached to the last node
        /// </summary>
        /// <param name="root">The root.</param>
        /// <param name="path">The path.</param>
        /// <param name="meta">The meta.</param>
        /// <returns></returns>
        public static linknodeElement buildNode(this linknodeElement root, string path, object meta, int score=1)
        {
            linknodeElement head = root;
            var ms = regexForPathElements.Matches(path);
            string repath = "";
            int level = 0;
            foreach (Match m in ms)
            {
                if ((m.Value.Length == 0) || (m.Value == PATH_SPLITTER.ToString())) continue;

                level++;
                string pathPart = m.Value.Trim(PATH_SPLITTER);
                repath = repath.add(pathPart, PATH_SPLITTER);

                if (head.items.ContainsKey(pathPart))
                {
                    head = head.items[pathPart];
                    head.score++;
                } else
                {
                    linknodeElement tmp = new linknodeElement();
                    tmp.setnode(repath, pathPart, head, root, level);
                    tmp.score = score;
                    head.items.Add(pathPart, tmp);
                    head = tmp;
                }
            }

            head.setmeta(meta);
            return head;
        }
    }
}