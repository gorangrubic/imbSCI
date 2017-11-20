namespace imbSCI.Core.data
{
    using imbSCI.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Tools for property selection expression resolution
    /// </summary>
    public static class PropertyExpressionTools
    {

        public static PropertyExpression GetExpressionResolved(this Object host, String path)
        {
            PropertyExpression output = null;

            List<String> pathPart = imbSciStringExtensions.SplitSmart(path, ".");
            String root = "";
            if (pathPart.Any())
            {
                root = pathPart.First();
                output = new PropertyExpression(host, root);
            }
            pathPart.Remove(pathPart.First());

            Object head = host;
            if (output.property == null)
            {
                output.state = PropertyExpressionStateEnum.nothingResolved;
                output.undesolvedPart = path;
                return output;
            }
            String currentPart = root;
            foreach (String pp in pathPart)
            {
                currentPart = pp;
                var tmp = output.Add(pp);
                if (tmp.host == null)
                {
                    output.state = PropertyExpressionStateEnum.resolvedSome;
                    break;
                }
                else
                {
                    output = tmp;
                }

            }

            if (currentPart != pathPart.Last())
            {
                String unp = "";
                Int32 i = pathPart.IndexOf(currentPart);
                for (int j = i; j < pathPart.Count; j++)
                {
                    unp = imbSciStringExtensions.add(unp, pathPart[j], ".");
                }
                output.undesolvedPart = unp;
            }
            else
            {
                if (output.property != null)
                {
                    output.state = PropertyExpressionStateEnum.resolvedAll;
                }
                
            }
            return output;
        }
    }

}