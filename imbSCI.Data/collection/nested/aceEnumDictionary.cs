namespace imbSCI.Data.collection.nested
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Recnik koji automatski popuni stavke svim TEnum enumeracijama - a value mu je new TObject();
    /// </summary>
    public class aceEnumDictionary<TEnum, TObject> : Dictionary<TEnum, TObject> where TObject:class
    {
        public aceEnumDictionary()
        {
            deploy();
        }

       // protected enums.imbTypeGroup typeGroup = enums.imbTypeGroup.unknown;
        protected Type t;

        protected void deploy()
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentOutOfRangeException("TEnum must bi ENUM");
                return;
            }
            
            
            var itts = Enum.GetValues(typeof(TEnum));
            t = typeof(TObject);

            //  typeGroup = t.getTypeGroup();

            

            foreach (TEnum md in itts)
            {
                if (t.IsClass)
                {
                    Object vl = null;

                    Boolean hasConstructor = t.GetConstructors().Any(x => !x.GetParameters().Any());

                    if (hasConstructor)
                    {
                       
                        vl = t.GetConstructor(new Type[] { }).Invoke(new Object[] { });
                        Add(md, (TObject)vl);
                    } else
                    {
                        Add(md, default(TObject));
                    }
                    
                } else if (t == typeof(String))
                {
                    String vl = "";
                    Add(md, vl as TObject);
                }
                else
                {

                    Add(md, default(TObject));
                }
            }
        }
    }
}