namespace imbSCI.Core.syntax.nc.line
{
    using imbSCI.Core.extensions.text;
    using imbSCI.Data;
    using System;
    using System.Linq;

    public static class ncLineExtensions
    {

        public static String writeLineCriteriaInline(this ncLineCriteria criteria)
        {
            String output = "";
            output = output.add("Criteria type[" + criteria.GetType().Name + "]");

            if (criteria.commandCriteria == ncLineCommandPredefined.custom)
            {
                output.add("cust.command[" + criteria.customCommand + "]");
            } else
            {
                output.add("command[" + criteria.commandCriteria.ToString() + "]");
            }

            if (criteria is ncLineRelativeCriteria)
            {
                ncLineRelativeCriteria rc = criteria as ncLineRelativeCriteria;

                output.addVal("relation type: ", rc.relativeType.ToString());

                output.addVal("relation offset: ", rc.relativePosition.ToString());
            }

            if (criteria is ncLineSelector)
            {
                ncLineSelector sc = criteria as ncLineSelector;
                

                output.addVal("included relative criterias: ", sc.Count().ToString());

                foreach (ncLineRelativeCriteria rc in sc)
                {
                    output.log(rc.writeLineCriteriaInline());
                }
            }
            return output;
        }
        
    }
}
