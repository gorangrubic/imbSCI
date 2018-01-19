// --------------------------------------------------------------------------------------------------------------------
// <copyright file="settingsEntriesForObject.cs" company="imbVeles" >
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
// Project: imbSCI.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbSCI.Core.data
{
    using imbSCI.Core.collection;
    using imbSCI.Core.extensions.data;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.math;
    using imbSCI.Data.collection.nested;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Model za prikaz podešavanja jednog objekata
    /// </summary>
    public class settingsEntriesForObject:INotifyPropertyChanged
    {

        private String _id;
        /// <summary>
        /// 
        /// </summary>
        public String id
        {
            get { return _id; }
            protected set { _id = value; }
        }


        /// <summary>
        /// Name of this type/class - if not specified then uses normal type name 
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public String DisplayName { get; set; } = "";

        public String Description { get; set; } = "";

        public String Category { get; set; } = "";

        public List<String> additionalInfo { get; set; } = new List<string>();

        public String info_link { get; set; } = "";

        public String info_helpTips { get; set; } = "";

        public String info_helpTitle { get; set; } = "";

        private static aceConcurrentDictionary<settingsEntriesForObject> _registry;
        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        internal static aceConcurrentDictionary<settingsEntriesForObject> registry
        {
            get
            {
                if (_registry == null)
                {
                    _registry = new aceConcurrentDictionary<settingsEntriesForObject>();
                }
                return _registry;
            }
        }


        /// <summary>
        /// Generise meta model za prosledjeni tip
        /// </summary>
        /// <param name="target"></param>
        public settingsEntriesForObject(Type type, Boolean includeCollectionItems)
        {
            id = type.FullName + includeCollectionItems.ToString();

            if (registry.ContainsKey(id))
            {
                this.pis = registry[id].pis;
                this.spes = registry[id].spes;
                targetType = type;
            }
            else
            {
                processType(type, includeCollectionItems, null);
                registry.Add(id, this);
            }
            
        }

        /// <summary>
        /// Generise meta model za prosledjeni objekat
        /// </summary>
        /// <param name="target"></param>
        public settingsEntriesForObject(Object target, Boolean includeCollectionItems=false, Boolean useCached=true)
        {
            if (target == null) throw new ArgumentNullException("target"); //new aceGeneralException("Target is null", null, this, "settingsEntriesForObject-> target null");
            id = target.GetType().FullName + includeCollectionItems.ToString();
            if (registry.ContainsKey(id) && useCached)
            {
                this.pis = registry[id].pis;
                this.spes = registry[id].spes;
                this.pce = registry[id].pce;
                targetType = target.GetType();
            }
            else
            {
                processObject(target, false);

                if (useCached) registry.Add(id, this);
            }
        }

        ///// <summary>
        ///// Generise meta model za prosledjeni objekat
        ///// </summary>
        ///// <param name="target"></param>
        //public settingsEntriesForObject(Object target, Boolean includeCollectionItems)
        //{
        //    if (target == null) throw new aceGeneralException("Target is null", null, this, "settingsEntriesForObject-> target null");
        //    processObject(target, includeCollectionItems);
            
        //    registry.Add(id, this);
        //}

        #region --- targetType ------- 
        private Type _targetType;
        /// <summary>
        /// Ciljani tip
        /// </summary>
        public Type targetType
        {
            get
            {
                return _targetType;
            }
            set
            {
                _targetType = value;
                OnPropertyChanged("targetType");
            }
        }
        #endregion


        private PropertyCollectionExtended _pce ;
        /// <summary> </summary>
        public PropertyCollectionExtended pce
        {
            get
            {
                return _pce;
            }
            protected set
            {
                _pce = value;
                OnPropertyChanged("pce");
            }
        }

        private Int32 SortProperty(PropertyInfo a, PropertyInfo b)
        {
            if (a == null) return -1;
            if (b == null) return 1;
            if (a == b) return 0;

            //a.DeclaringType.ty
            
            if (a.DeclaringType == targetType)
            {
                return -1;
            }
            return 1;
        }

        public List<String> CategoryByPriority { get; set; } = new List<string>();


        /// <summary>
        /// Hashed type signature
        /// </summary>
        /// <returns></returns>
        public String GetSignature()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(targetType.Name).Append((string)spes.Keys.ToList().toCsvInLine()); //.toCsvInLine());
            return md5.GetMd5Hash(sb.ToString());
        }

        /// <summary>
        /// Processes the type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="includeCollectionItems">if set to <c>true</c> [include collection items].</param>
        /// <param name="target">The target.</param>
        protected void processType(Type type, Boolean includeCollectionItems, Object target = null, Int32 call=0)
        {
            targetType = type;


            settingsMemberInfoEntry sMIE = new settingsMemberInfoEntry(type);
            DisplayName = sMIE.displayName.or(type.Name.imbTitleCamelOperation(true, false));
            Category = sMIE.categoryName;
            Description = sMIE.description;

            additionalInfo.AddRange(sMIE.additionalInfo);
            info_helpTips = sMIE.info_helpTips;
            info_helpTitle = sMIE.info_helpTitle;

            info_link = sMIE.info_link;

            CategoryByPriority = sMIE.CategoryByPriority;
            


            var pTypes = type.GetBaseTypeList(false, true, null, call++);

            pTypes.Add(type);

            List<PropertyInfo> props = new List<PropertyInfo>();
            foreach (var t in pTypes)
            {
                var pr = t.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);
                props.AddRange(pr);
            }

          

           

            

            //if (target != null) pce = target.buildPCE(true);
            List<PropertyInfo> propList = new List<PropertyInfo>();


            foreach (PropertyInfo pro in props)
            {
                if (pro.CanWrite)
                {
                    if (pro.PropertyType.IsEnum)
                    {
                        propList.Add(pro);
                    }
                    else if (pro.PropertyType.IsPrimitive)
                    {
                        propList.Add(pro);
                    }
                    else if (pro.PropertyType == typeof(String))
                    {
                        propList.Add(pro);
                    }
                    else
                    {
                        if (pro.DeclaringType == targetType)
                        {
                            
                            if (pro.Name != "Item")
                            {
                                propList.Add(pro);
                            }
                            else
                            {

                            }
                        }

                    }
                }
            }
            
          //  propList.Sort(SortProperty);

            foreach (PropertyInfo pro in propList)
            {
                if (!pis.ContainsKey(pro.Name))
                {
                    pis.Add(pro.Name, pro);

                    settingsPropertyEntryWithContext spe = new settingsPropertyEntryWithContext(pro, target, pce);
                    spes.Add(pro.Name, spe);
                }
            }

            if (includeCollectionItems)
            {
                if (target is IList)
                {
                    IList l = target as IList;

                    foreach (var i in l)
                    {
                        settingsPropertyEntryWithContext spe = new settingsPropertyEntryWithContext(i, l, pce);
                        spes.Add(spe.displayName, spe);
                    }
                }
            }
            CategoryByPriority = sMIE.CategoryByPriority;

            // SORTING BY CATEGORY
            if (sMIE.CategoryByPriority.Count > 0)
            {
                //aceDictionarySet<String, settingsPropertyEntry> pi_set = new aceDictionarySet<string, settingsPropertyEntry>();
                Int32 pri = 0;
                foreach (String cat in CategoryByPriority)
                {
                    var propInCat = spes.Values.Where(x => x.categoryName.ToLower() == cat.ToLower()); 
                    foreach (var pic in propInCat)
                    {
                        pic.priority = pri;
                        pic.index = pri;
                        pri++;
                    }
                }
            }

        }

        /// <summary>
        /// Ucitava objekat u sebe i postavlja sve definicije
        /// </summary>
        /// <param name="target"></param>
        protected void processObject(Object target,Boolean includeCollectionItems)
        {
            targetType = target.GetType();
            processType(targetType, includeCollectionItems, target);

            //PropertyInfo[] props = targetType.GetProperties();

            //List<PropertyInfo> propList = new List<PropertyInfo>();
            //foreach (PropertyInfo pro in props)
            //{
            //    if (pro.CanWrite)
            //    {
            //        if (pro.PropertyType.IsEnum)
            //        {
            //            propList.Add(pro);
            //        }
            //        else if (pro.PropertyType.IsPrimitive)
            //        {
            //            propList.Add(pro);
            //        }
            //        else if (pro.PropertyType == typeof(String))
            //        {
            //            propList.Add(pro);
            //        }
            //        else
            //        {
            //            if (pro.DeclaringType == targetType)
            //            {
            //                if (pro.Name != "Item")
            //                {
            //                    propList.Add(pro);
            //                }
            //                else
            //                {

            //                }
            //            }

            //        }
            //    }

            //}

            //foreach (PropertyInfo pro in propList)
            //{
            //    pis.Add(pro.Name, pro);
            //    settingsPropertyEntryWithContext spe = new settingsPropertyEntryWithContext(pro, target);

            //    spes.Add(pro.Name, spe);
            //}

            //if (includeCollectionItems)
            //{
            //    if (target is IList)
            //    {
            //        IList l = target as IList;

            //        foreach (var i in l)
            //        {
            //            settingsPropertyEntryWithContext spe = new settingsPropertyEntryWithContext(i, l);
            //            spes.Add(spe.displayName, spe);
            //        }
            //    }
            //}

        }

        /// <summary>
        /// Primenjuje kontekstualne vrednosti na objekat - ako je objekat null onda ga generise ponovo
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public Object valueToObject(Object target)
        {
            if (target == null)
            {
                target = targetType.getInstance();
            }
            foreach (var spe in spes)
            {
                if (spe.Value.index > -1)
                {
                    IList l = target as IList;
                    if (spe.Value.index >= l.Count)
                    {
                        l.Add(spe.Value.value);
                    } else
                    {
                        l[spe.Value.index] = spe.Value.value;
                    }
                }
                else
                {
                    target.imbSetPropertySafe(spe.Value.pi, spe.Value.value);
                }
            }
            return target;
        }

        public Dictionary<String, PropertyInfo> pis = new Dictionary<string, PropertyInfo>();

        #region --- spes ------- settings entries with context

        private Dictionary<String, settingsPropertyEntryWithContext> _spes =
            new Dictionary<string, settingsPropertyEntryWithContext>();

        //protected settingsEntriesForObject()
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// settings entries with context
        /// </summary>
        public Dictionary<String, settingsPropertyEntryWithContext> spes
        {
            get
            {
                return _spes;
            }
            set
            {
                _spes = value;
                OnPropertyChanged("spes");
            }
        }
        #endregion
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}