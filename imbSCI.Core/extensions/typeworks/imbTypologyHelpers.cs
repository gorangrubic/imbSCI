namespace imbSCI.Core.extensions.typeworks
{
    using imbSCI.Core.extensions.data;
    using imbSCI.Data;
    #region imbVeles using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    #endregion

    /// <summary>
    /// 2013: pomoćne alatke za rad sa tipovima
    /// </summary>
    public static class imbTypologyHelpers
    {
        /// <summary>
        /// Gets the name of the type from.
        /// </summary>
        /// <param name="typename">The typename.</param>
        /// <param name="defaultResult">The default result.</param>
        /// <returns></returns>
        /// \ingroup_disabled ace_ext_type_highlight
        public static Type getTypeFromName(this String typename, Type defaultResult=null)
        {
            if (typename == "type") return typeof(String);

            if (!typename.Contains("."))
            {
                
                typename = typename.ensureStartsWith("System.");

            }

            Type output = Type.GetType(typename, false, true);

            if (output == null)
            {
                output = defaultResult;
            }

            return output;
        }

        /// <summary>
        /// Gets the clean full name the type.
        /// </summary>
        /// <param name="typeFullName">Full name of the type.</param>
        /// <returns></returns>
        public static String getCleanTypeFullName(this String typeFullName)
        {
            String output = typeFullName;
            output = output.Replace("+", ".");
            output = output.Replace("`1", "<>");
            output = output.Replace("`2", "<>");
            output = output.Replace("`3", "<>");
            return output;
        }

        /// <summary>
        /// Gets the type path filter.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static String getTypePathFilter(this Type type)
        {
            if (type == null) return "";
            String output = type.Name;
            if (type.ContainsGenericParameters)
            {
                Type[] tg;
                tg = type.GetGenericArguments();
                foreach (var t in tg)
                {
                    output += "&" + t.Name;
                }
            }
            return output;
        }

        //internal static Boolean entityCollectionPropertyCheck(imbPropertyInfo iPI)
        //{
        //    if (iPI.type.Name.EndsWith("Collection"))
        //    {
        //        if (iPI.propertyTypeInfo.interfaces.Contains(typeof (IRelationEnabledCollection)))
        //        {
        //            if (iPI.propertyInfoSource.GetAccessors().Any())
        //            {
        //                if (!iPI.propertyInfoSource.Name.StartsWith("_"))
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}
        
        


        /// <summary>
        /// Describes the types.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static String describeTypes(this IEnumerable<Type> types, String separator = "; ")
        {
            StringBuilder sb = new StringBuilder();
            foreach (var t in types)
            {
                sb.Append(t.Name + separator);
            }
            return sb.ToString();
        }

       



        /// <summary>
        /// Vraća sve Tipove koji su mu parenti
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static IEnumerable<Type> GetBaseTypes(this Type type)
        {
            IEnumerable<Type> output = new Type[] {};
            if (type == null) return output;
            output = Enumerable.Repeat(type.BaseType, 1).Concat(type.BaseType.GetBaseTypes());
            return output.Where(x => (x != null));
        }

        /// <summary>
        /// Vraca listu sa svim nasledjenim tipovima - po redosledu nasledjivanja: classBase.classInherited
        /// </summary>
        /// <param name="type">Tip za koji se vracaju nasledjeni tipovi</param>
        /// <param name="includeSelf">da li da na kraju liste ubaci i sebe</param>
        /// <param name="uniqueTypes">da li da budu samo unikatni tipovi</param>
        /// <param name="untilClass">Do koje klase da ide duboko u nasledjivanju? ako je null onda sve</param>
        /// <returns>Listu nasledjivanja</returns>
        /// \ingroup_disabled ace_ext_type_highlight
        public static List<Type> GetBaseTypeList(this Type type, Boolean includeSelf = false,
                                                 Boolean uniqueTypes = false, Type untilClass = null)
        {
            String signature = type.AssemblyQualifiedName + includeSelf.ToString() + uniqueTypes.ToString();
            if (untilClass != null) signature += untilClass.Name;
            
            List<Type> baseTypes = new List<Type>();
            Type[] tmp;
            if (uniqueTypes)
            {
                baseTypes.AddRangeImb(type.GetBaseTypes());
            }
            else
            {
                baseTypes.AddRange(type.GetBaseTypes());
            }
            baseTypes.Reverse();
            if (includeSelf) baseTypes.Add(type);
            if (untilClass != null)
            {
                Int32 ind = baseTypes.IndexOf(untilClass) + 1;
                if (ind > 0)
                {
                    baseTypes = baseTypes.GetRange(ind, baseTypes.Count - ind);
                }
            }
           // imbTypologyInternal.baseTypeListRegistry.Add(signature, baseTypes);
            return baseTypes;
        }



        /// <summary>
        /// Vraca tipiziranu podrazumevanu vrednost
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="host"></param>
        /// <returns></returns>
        public static T GetDefaultValue<T>(this Object host)
        {
            return (T) typeof (T).GetDefaultValue();
        }

        /// <summary>
        /// Returns default value for type. It may be new instance if <c>t</c> is class type.
        /// </summary>
        /// <param name="t">The Type to get value for.</param>
        /// <returns>Proper default value</returns>
        /// \ingroup_disabled ace_ext_type_highlight
        public static object GetDefaultValue(this Type t)
        {
            Type iTI = t;

            if (iTI == null) iTI = typeof(String);
            if (iTI.isBoolean())
            {
                return false;
            }
            
            if (iTI.isText())
            {
                return "";
            }
            else if (iTI.IsPrimitive)
            {
                return 0;
            }
            else if (iTI.IsEnum)
            {
                foreach (object en in Enum.GetValues(t))
                {
                    return en;
                }
                
            }
            else if (iTI.IsClass)
            {
                return iTI.getInstance();
            }
            else
            {
                return null;
            }
            return null;

       
        }




        /// <summary>
        /// Determines whether Type has parameterless constructor
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if [has parameterless constructor] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean hasParameterlessConstructor(this Type type)
        {
            Boolean output = false;
            ConstructorInfo[] cis = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            foreach (ConstructorInfo ci in cis)
            {
                ParameterInfo[] pari = ci.GetParameters();

                if (pari.Count() == 0)
                {
                    output = true;
                    break;
                }
            }
            return output;
        }


        /// <summary>
        /// Determines whether is Type a simple (String, number, enum...) one that can be serialized ToString() way easy.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if [is imb serializable simple] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean isImbSerializableSimple(this Type type)
        {
            

            Boolean output = false; // isImbSerializableQuick(type);

            if (type.IsNested)
            {
                if (!type.IsNestedPublic) return false;
            }
            else
            {
                if (type.IsNotPublic) return false;
            }


            if (type.ContainsGenericParameters)
            {
                return false;
            }

            if (type.IsPrimitive) return true;
            if (type.IsValueType) return true;
            if (type == typeof (String)) return true;

            output = type.hasParameterlessConstructor();

            return output;
        }



    }
}