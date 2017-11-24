namespace imbSCI.Core.data
{
    using imbSCI.Core.attributes;
    using imbSCI.Core.collection;
    using imbSCI.Core.enums;
    using imbSCI.Core.extensions.enumworks;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.extensions.typeworks;
    using imbSCI.Core.math.aggregation;
    using imbSCI.Data;
    using imbSCI.Data.enums.fields;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Reflection;
    using System.Xml.Serialization;

    public class settingsMemberInfoEntry:INotifyPropertyChanged
    {

        public String relevantTypeName { get; set; } = "";
        public List<String> additionalInfo { get; set; } = new List<string>();

        public String info_link { get; set; } = "";

        public String info_helpTips { get; set; } = "";

        public String info_helpTitle { get; set; } = "";

        public String name { get; set; } = "";
        public event PropertyChangedEventHandler PropertyChanged;

        public List<String> CategoryByPriority { get; set; } = new List<string>();

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public settingsMemberInfoEntry(Object __primitive)
        {
            displayName = __primitive.toStringSafe().imbTitleCamelOperation(true);

            description = __primitive.GetType().Name;
        }

        /// <summary>
        /// Descriptor info model -- aceTypology
        /// </summary>
        /// <param name="mi">The mi.</param>
        public settingsMemberInfoEntry(MemberInfo mi, PropertyCollectionExtended pce=null)
        {

            process(mi, pce);
        }

        public DescriptionAttribute descAttribute;
        public DisplayNameAttribute displayNameAttribute;
        public CategoryAttribute catAttribute;

        public MemberInfo memberInfo;

        public Boolean IsXmlIgnore { get; set; }


        public void deploy(templateFieldDataTable dtc, Object dtc_val)
        {
            switch (dtc)
            {
                case templateFieldDataTable.categoryPriority:
                    break;
                case templateFieldDataTable.col_alignment:
                    break;
                case templateFieldDataTable.col_attributes:
                    break;
                case templateFieldDataTable.col_caption:
                    displayName = dtc_val.toStringSafe(displayName);
                    break;
                case templateFieldDataTable.col_color:
                    color = dtc_val.toStringSafe(color);
                    break;
                case templateFieldDataTable.col_desc:
                    description = dtc_val.toStringSafe(description);
                    break;
                case templateFieldDataTable.col_directAppend:
                    break;
                case templateFieldDataTable.col_even:
                    break;
                case templateFieldDataTable.col_expression:
                    expression = dtc_val.toStringSafe(expression);
                    break;
                case templateFieldDataTable.col_format:
                    format = dtc_val.toStringSafe(format);
                    
                    break;
                case templateFieldDataTable.col_group:
                    categoryName = dtc_val.toStringSafe(categoryName);
                    break;
                case templateFieldDataTable.col_hasLinks:
                    break;
                case templateFieldDataTable.col_hasTemplate:
                    break;
                case templateFieldDataTable.col_id:
                    break;
                case templateFieldDataTable.col_imbattributes:
                    break;
                case templateFieldDataTable.col_importance:
                    importance = (dataPointImportance) dtc_val;
                    break;
                case templateFieldDataTable.col_letter:
                    letter = dtc_val.toStringSafe(letter);
                    break;
                case templateFieldDataTable.col_name:
                    break;
                case templateFieldDataTable.col_nameClean:
                    break;
                case templateFieldDataTable.col_namePrefix:
                    break;
                case templateFieldDataTable.col_pe:
                    break;
                case templateFieldDataTable.col_priority:
                    priority = (Int32)dtc_val;
                    break;
                case templateFieldDataTable.col_propertyInfo:
                    break;
                case templateFieldDataTable.col_rel:
                    break;
                case templateFieldDataTable.col_spe:
                    break;
                case templateFieldDataTable.col_type:
                    break;
                case templateFieldDataTable.col_unit:
                    unit = dtc_val.toStringSafe(unit);
                    break;
                case templateFieldDataTable.col_width:
                    width = (Int32)dtc_val;
                    break;
                case templateFieldDataTable.columnEncodeMode:
                    break;
                case templateFieldDataTable.columns:
                    break;
                case templateFieldDataTable.columnWidth:
                    width = (Int32)dtc_val;
                    break;
                case templateFieldDataTable.columnWrapTag:
                    break;
                case templateFieldDataTable.count_format:
                    break;
                case templateFieldDataTable.data_accesslist:
                    break;
                case templateFieldDataTable.data_additional:
                    break;
                case templateFieldDataTable.data_aggregation_type:
                    break;
                case templateFieldDataTable.data_columncount:
                    break;
                case templateFieldDataTable.data_dbengine:
                    break;
                case templateFieldDataTable.data_dbhost:
                    break;
                case templateFieldDataTable.data_dbname:
                    break;
                case templateFieldDataTable.data_dbuser:
                    break;
                case templateFieldDataTable.data_origin_count:
                    break;
                case templateFieldDataTable.data_origin_type:
                    break;
                case templateFieldDataTable.data_query:
                    break;
                case templateFieldDataTable.data_rowcountselected:
                    break;
                case templateFieldDataTable.data_rowcounttotal:
                    break;
                case templateFieldDataTable.data_table:
                    break;
                case templateFieldDataTable.data_tabledesc:
                    break;
                case templateFieldDataTable.data_tablename:
                    break;
                case templateFieldDataTable.data_tablenamedb:
                    break;
                case templateFieldDataTable.data_tablescount:
                    break;
                case templateFieldDataTable.description:
                    break;
                case templateFieldDataTable.renderEmptySpace:
                    break;
                case templateFieldDataTable.row_data:
                    break;
                case templateFieldDataTable.row_even:
                    break;
                case templateFieldDataTable.row_id:
                    break;
                case templateFieldDataTable.shema_classname:
                    break;
                case templateFieldDataTable.shema_dbcount:
                    break;
                case templateFieldDataTable.shema_dictionary:
                    break;
                case templateFieldDataTable.shema_sourceinstance:
                    break;
                case templateFieldDataTable.shema_sourcename:
                    break;
                case templateFieldDataTable.table_extraDesc:
                    break;
                case templateFieldDataTable.table_metacolumns:
                    break;
                case templateFieldDataTable.table_metarows:
                    break;
                case templateFieldDataTable.title:
                    break;
            }
        }

        public void deployAttributes(Object[] propAttributes)
        {

            foreach (Object propAtt in propAttributes)
            {
                descAttribute = propAtt as DescriptionAttribute;
                if (descAttribute != null)
                {
                    description = descAttribute.Description;
                }

                displayNameAttribute = propAtt as DisplayNameAttribute;
                if (displayNameAttribute != null)
                {
                    displayName = displayNameAttribute.DisplayName;
                }


                catAttribute = propAtt as CategoryAttribute;
                if (catAttribute != null)
                {
                    categoryName = catAttribute.Category.ToUpper();


                    if (categoryName.Contains(","))
                    {
                        groups.AddRange(categoryName.getStringTokens());
                    }
                    else
                    {
                        groups.Add(categoryName);
                    }
                }


                if (propAtt is DisplayAttribute)
                {
                    DisplayAttribute displayAttribute_DisplayAttribute = (DisplayAttribute)propAtt;
                    description += displayAttribute_DisplayAttribute.Description.toStringSafe("");
                    displayName = displayAttribute_DisplayAttribute.Name.toStringSafe(displayName);
                    letter = displayAttribute_DisplayAttribute.ShortName.toStringSafe(letter);
                    // priority = (int)displayAttribute_DisplayAttribute.Order;
                    categoryName = displayAttribute_DisplayAttribute.GroupName.toStringSafe(categoryName);
                }

                if (propAtt is RangeAttribute)
                {
                    RangeAttribute rng = (RangeAttribute)propAtt;
                    range_defined = true;
                    range_min = Convert.ToDouble((object) rng.Minimum);
                    range_max = Convert.ToDouble((object) rng.Maximum);
                }

                if (propAtt is DisplayFormatAttribute)
                {
                    DisplayFormatAttribute dFormat = (DisplayFormatAttribute)propAtt;
                    escapeValueString = dFormat.HtmlEncode;

                    format = dFormat.DataFormatString;
                }

                if (propAtt is DisplayColumnAttribute)
                {
                    DisplayColumnAttribute dColumn = (DisplayColumnAttribute)propAtt;
                    displayName = dColumn.DisplayColumn;
                }


                if (propAtt is XmlIgnoreAttribute)
                {
                    IsXmlIgnore = true;
                }

                if (propAtt is imbAttribute)
                {
                    imbAttribute propAtt_imbAttribute = (imbAttribute)propAtt;
                    switch (propAtt_imbAttribute.nameEnum)
                    {
                        case imbAttributeName.DataTableExport:

                            templateFieldDataTable dtc = (templateFieldDataTable)propAtt_imbAttribute.objMsg;
                            Object dtc_val = propAtt_imbAttribute.objExtra;
                            deploy(dtc, dtc_val);
                            //propAtt_imbAttribute.objExtra

                            break;
                        case imbAttributeName.help:
                        case imbAttributeName.helpDescription:
                        case imbAttributeName.helpPurpose:
                        case imbAttributeName.menuHelp:
                            additionalInfo.Add(propAtt_imbAttribute.getMessage().toStringSafe(""));
                            break;
                        case imbAttributeName.helpTips:
                            info_helpTips = propAtt_imbAttribute.getMessage().toStringSafe("");
                            break;
                        case imbAttributeName.helpTitle:

                            info_helpTitle = propAtt_imbAttribute.getMessage().toStringSafe("");
                            break;
                        case imbAttributeName.basicColor:
                            color = propAtt_imbAttribute.getMessage().toStringSafe("");
                            break;
                        case imbAttributeName.reporting_categoryOrder:
                            CategoryByPriority.AddRange(imbSciStringExtensions.SplitSmart(propAtt_imbAttribute.getMessage().toStringSafe(""), ",", "", true));
                            break;
                        case imbAttributeName.reporting_aggregation:
                            aggregation[(dataPointAggregationAspect)propAtt_imbAttribute.objExtra] = (dataPointAggregationType)propAtt_imbAttribute.objMsg;
                            break;
                        case imbAttributeName.reporting_valueformat:
                            format = propAtt_imbAttribute.getMessage().toStringSafe("");
                            break;
                        case imbAttributeName.measure_setUnit:
                            unit = propAtt_imbAttribute.getMessage().toStringSafe("");
                            break;
                        case imbAttributeName.measure_important:
                            importance = propAtt_imbAttribute.getMessage().imbToEnumeration<dataPointImportance>();
                            break;
                        case imbAttributeName.measure_expression:
                            expression = propAtt_imbAttribute.getMessage().toStringSafe("");
                            break;
                        case imbAttributeName.measure_calcGroup:
                        case imbAttributeName.measure_displayGroup:
                        case imbAttributeName.menuGroupPath:
                            groups.Add(propAtt_imbAttribute.getMessage().toStringSafe(""));
                            if (categoryName.isNullOrEmpty()) categoryName = propAtt_imbAttribute.getMessage().toStringSafe("").ToUpper();
                            break;
                        case imbAttributeName.viewPriority:
                            priority = propAtt_imbAttribute.getMessage().imbToNumber<Int32>();
                            break;
                        case imbAttributeName.reporting_template:
                            template = propAtt_imbAttribute.getMessage().toStringSafe("");
                            break;
                        case imbAttributeName.reporting_escapeoff:
                            escapeValueString = propAtt_imbAttribute.getMessage().imbToBoolean();
                            break;
                        case imbAttributeName.collectionPrimaryKey:
                            isPrimaryKey = true;
                            break;

                        case imbAttributeName.measure_letter:
                        case imbAttributeName.menuCommandKey:
                            letter = propAtt_imbAttribute.getMessage().toStringSafe();
                            break;
                    }


                    if (!attributes.ContainsKey(propAtt_imbAttribute.nameEnum))
                    {
                        attributes.Add(propAtt_imbAttribute.nameEnum, propAtt_imbAttribute);
                    }
                    else
                    {

                    }
                }


            }


        }



        protected void process(MemberInfo mi, PropertyCollectionExtended pce = null)
        {
            pe = null;
            name = mi.Name;


            if (mi is MethodBase)
            {
                MethodBase mb = mi as MethodBase;
                relevantTypeName = mb.MemberType.ToString();

                //mb.MemberType
            }

            if (pce != null)
            {
                pe = pce.entries.Get(mi.Name);

            }

            description = "";
            displayName = "";
            memberInfo = mi;
            Object[] propAttributes = mi.GetCustomAttributes(false);
            deployAttributes(propAttributes);



            if (String.IsNullOrEmpty(description))
            {
                if (pe != null)
                {
                    description = pe[PropertyEntryColumn.entry_description].toStringSafe();
                }
                else
                {
                    description = mi.Name;
                }
            }

            if (String.IsNullOrEmpty(displayName))
            {
                if (pe != null)
                {
                    displayName = pe[PropertyEntryColumn.entry_name].toStringSafe();
                }
                else
                {
                    displayName = mi.Name;
                }
            }

            //imbAttributeCollection coll = imbAttributeTools.getImbAttributeDictionary(mi);
            //helpContent = coll.getHelpContent();


        }
        /// <summary>
        /// Help content for this member
        /// </summary>
        /// <value>
        /// The content of the help.
        /// </value>
        public imbHelpContent helpContent { get; set; } = new imbHelpContent();

        /// <summary>
        /// Gets or sets a value indicating whether this instance is primary key.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is primary key; otherwise, <c>false</c>.
        /// </value>
        public Boolean isPrimaryKey { get; set; } = false;

        /// <summary>
        /// Letter or code name for this member
        /// </summary>
        /// <value>
        /// The letter.
        /// </value>
        public String letter { get; set; } = "";

        /// <summary>
        /// Hexadecimal color code or name
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public String color { get; set; } = "";


        /// <summary>
        /// Gets or sets a value indicating whether the range is defined.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [range defined]; otherwise, <c>false</c>.
        /// </value>
        public Boolean range_defined { get; set; } = false;

        /// <summary>
        /// Gets or sets the range minimum.
        /// </summary>
        /// <value>
        /// The range minimum.
        /// </value>
        public Double range_min { get; set; } = 0;

        /// <summary>
        /// Gets or sets the range maximum.
        /// </summary>
        /// <value>
        /// The range maximum.
        /// </value>
        public Double range_max { get; set; } = 1;

        #region --- displayName ------- Naziv varijable za prikaz

        private String _displayName = "";
        /// <summary>
        /// Naziv varijable za prikaz
        /// </summary>
        public String displayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }
        #endregion


        #region --- categoryName ------- Naziv kategorije propertija

        private String _categoryName = "";
        /// <summary>
        /// Naziv kategorije propertija
        /// </summary>
        public String categoryName
        {
            get
            {

                return _categoryName;
            }
            set
            {
                _categoryName = value;
                OnPropertyChanged("categoryName");
            }
        }
        #endregion


        #region --- description ------- Opis
        private String _description = "";
        /// <summary>
        /// Opis
        /// </summary>
        public String description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("description");
            }
        }
        #endregion

        public dataPointAggregationDefinition aggregation { get; set; } = new dataPointAggregationDefinition();


        private imbAttributeCollection _attributes = new imbAttributeCollection();
        /// <summary>
        /// 
        /// </summary>
        public imbAttributeCollection attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }


        private PropertyEntry _pe;
        /// <summary>
        /// 
        /// </summary>
        public PropertyEntry pe
        {
            get { return _pe; }
            set { _pe = value; }
        }


        private String _template;
        /// <summary>
        ///property is a String template, this property contains wrapping template where {{{inner}}} is result of member value: template with placeholders {{{property_name}}} 
        /// </summary>
        public String template
        {
            get { return _template; }
            set { _template = value; }
        }

        private String _format = "";
        /// <summary>
        /// Value format to apply
        /// </summary>
        public String format
        {
            get { return _format; }
            set { _format = value; }
        }


        private String _expression = "";
        /// <summary>
        /// 
        /// </summary>
        public String expression
        {
            get { return _expression; }
            set { _expression = value; }
        }

        public String unit { get; set; } = "";


        /// <summary>
        /// Message when used asked for value of this property
        /// </summary>
        /// <value>
        /// The prompt.
        /// </value>
        public String prompt { get; set; } = "";


        public Boolean allowEdit { get; set; } = true;


        private dataPointImportance _importance = dataPointImportance.none;
        /// <summary>
        /// 
        /// </summary>
        public dataPointImportance importance
        {
            get { return _importance; }
            set { _importance = value; }
        }


        private Int32 _priority = 100;
        /// <summary>
        /// 
        /// </summary>
        public Int32 priority
        {
            get { return _priority; }
            set { _priority = value; }
        }


        public Int32 width { get; set; } = 20;

        private Boolean _escapeValueString = true;

        /// <summary>
        /// 
        /// </summary>
        public Boolean escapeValueString
        {
            get { return _escapeValueString; }
            set { _escapeValueString = value; }
        }



        private List<String> _groups = new List<String>();
        /// <summary>Groups this property is asociated with</summary>
        public List<String> groups
        {
            get
            {
                return _groups;
            }
            protected set
            {
                _groups = value;
                OnPropertyChanged("groups");
            }
        }

        internal PropertyCollection exportPropertyCollection( PropertyCollection extraData)
        {
            if (extraData == null) extraData = new PropertyCollection();

            
            extraData[imbAttributeName.reporting_valueformat] = format; //*
            extraData[imbAttributeName.measure_displayGroup] = categoryName; //groups.Join(","); //imb.getProperString(me.categoryName, imbAttributeName.measure_displayGroup, imbAttributeName.menuGroupPath); //*
            extraData[imbAttributeName.measure_important] = importance; // imb.getMessage(imbAttributeName.measure_important, false); //*
            if (memberInfo is PropertyInfo)
            {
                PropertyInfo pi = memberInfo as PropertyInfo;

                extraData[templateFieldDataTable.col_type] = pi.PropertyType;
                extraData[templateFieldDataTable.col_propertyInfo] = pi;
            }
            
            extraData[templateFieldDataTable.col_directAppend] = !escapeValueString; //imb.ContainsKey(imbAttributeName.reporting_escapeoff);
            extraData[templateFieldDataTable.col_attributes] = attributes;
            extraData[templateFieldDataTable.col_propertyInfo] = memberInfo;
            extraData[templateFieldDataTable.col_desc] = description; // imb.getStringLine(Environment.NewLine, imbAttributeName.menuHelp, imbAttributeName.help, imbAttributeName.helpDescription, imbAttributeName.helpPurpose).add(extraData[name_description].toStringSafe(), Environment.NewLine);
            extraData[templateFieldDataTable.col_format] = format; //*
            extraData[templateFieldDataTable.col_group] = categoryName;
            extraData[templateFieldDataTable.col_priority] = priority;
            extraData[templateFieldDataTable.col_pe] = pe;
            extraData[templateFieldDataTable.col_caption] = displayName;
            extraData[templateFieldDataTable.col_name] = memberInfo.Name;
            extraData[templateFieldDataTable.col_expression] = expression;
            extraData[templateFieldDataTable.col_imbattributes] = attributes;
            extraData[templateFieldDataTable.col_unit] = unit;

            // extraData[templateFieldDataTable.col_alignment] = attributes;
          //  extraData.AppendData(pe, existingDataMode.overwriteExisting, false);
            return extraData;
        }


        #region --- acceptableValues ------- prihvatljive vrednosti

        private List<Object> _acceptableValues = new List<object>();

        protected settingsMemberInfoEntry()
        {
            
        }

        /// <summary>
        /// prihvatljive vrednosti
        /// </summary>
        public List<Object> acceptableValues
        {
            get
            {
                return _acceptableValues;
            }
            set
            {
                _acceptableValues = value;
                OnPropertyChanged("acceptableValues");
            }
        }
        #endregion
    }
}