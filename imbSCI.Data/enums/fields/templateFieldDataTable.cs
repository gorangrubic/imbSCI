namespace imbSCI.Data.enums.fields
{


    /// <summary>
    /// Fields for DataTable Reports
    /// </summary>
    public enum templateFieldDataTable
    {
        /// <summary>
        /// The data tablename - table name for display
        /// </summary>
        data_tablename,

        /// <summary>
        /// The data tabledesc - description footnote text about the table
        /// </summary>
        data_tabledesc,

        /// <summary>
        /// The data tablenamedb - table name in db shemata
        /// </summary>
        data_tablenamedb,

        /// <summary>
        /// The data dbname - name of database
        /// </summary>
        data_dbname,

        /// <summary>
        /// The data dbhost - host domain
        /// </summary>
        data_dbhost,

        /// <summary>
        /// The data dbuser - in case of database access
        /// </summary>
        data_dbuser,

        /// <summary>
        /// Total number of rows in DataTable
        /// </summary>
        data_rowcounttotal,

        /// <summary>
        /// Number of rows returned on query
        /// </summary>
        data_rowcountselected,

        /// <summary>
        /// The data columncount - DataColumn count
        /// </summary>
        data_columncount,

        /// <summary>
        /// The data dbengine - what is the engine behind the data
        /// </summary>
        data_dbengine,

        /// <summary>
        /// The number of tables in the report
        /// </summary>
        data_tablescount,

        /// <summary>
        /// The data dbcount - number of databases
        /// </summary>
        shema_dbcount,

        /// <summary>
        /// The data query: SQL or other query
        /// </summary>
        data_query,


        /// <summary>
        /// The data origin type: objectTable, singleObject, multiTables,
        /// </summary>
        data_origin_type,

        /// <summary>
        /// The data origin count: how many sources are aggregated here
        /// </summary>
        data_origin_count,


        /// <summary>
        /// The data aggregation type: what type of aggregation created this table
        /// </summary>
        data_aggregation_type,


        shema_sourceinstance,
        /// <summary>
        /// The shema sourcename - instance name for collection or table name for DataTable
        /// </summary>
        shema_sourcename,
        /// <summary>
        /// if shema derived from class - here it will contain Type.Name
        /// </summary>
        shema_classname,


        /// <summary>
        /// The col identifier
        /// </summary>
        col_id,

        /// <summary>
        /// The col name - data base name
        /// </summary>
        col_name,


        /// <summary>
        /// The col caption to display
        /// </summary>
        col_caption,

        /// <summary>
        /// The col Type for column data
        /// </summary>
        col_type,
        /// <summary>
        /// The col description
        /// </summary>
        col_desc,

        /// <summary>
        /// The col relationship
        /// </summary>
        col_rel,

        /// <summary>
        /// The DataColumn is even, not odd
        /// </summary>
        col_even,

        /// <summary>
        /// Imb attribute collection
        /// </summary>
        col_imbattributes,
        /// <summary>
        /// All property attributes
        /// </summary>
        col_attributes,
        /// <summary>
        /// The col name prefix (pre _)
        /// </summary>
        col_namePrefix,

        /// <summary>
        /// The col name clean (posle _)
        /// </summary>
        col_nameClean,

        col_group,

        

        /// <summary>
        /// The col direct append
        /// </summary>
        col_directAppend,

        col_propertyInfo,

        /// <summary>
        /// The row identifier - ID in DataTable.rows
        /// </summary>
        row_id,

        /// <summary>
        /// The row even - the row is even
        /// </summary>
        row_even,

        /// <summary>
        /// The row data collection
        /// </summary>
        row_data,

        table_metarows,

        table_metacolumns,
        
        categoryPriority,

        /// <summary>
        /// The data accesslist - imbDbAccess list
        /// </summary>
        data_accesslist,
        data_table,
        data_additional,
        count_format,
        columns,
        shema_dictionary,
        col_width,
        col_color,
        col_format,
        col_priority,
        col_pe,
        col_spe,
        col_expression,
        col_letter,
        col_unit,
        col_alignment,
        col_importance,
        col_hasLinks,
        col_hasTemplate,
        table_extraDesc,
        columnWidth,
        columnWrapTag,
        columnEncodeMode,
        renderEmptySpace,
        description,
        title,
    }

}