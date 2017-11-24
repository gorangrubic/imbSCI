namespace imbSCI.Data.enums.tableReporting
{
    using System;

    /// <summary>
    /// DataTable request rescription
    /// </summary>
    [Flags]
    public enum dataTableDeliveryEnum
    {
        none=0,

        vertical=1,

        horizontal =2,
        /// <summary>
        /// The calculated: instruct provider to perform calculations before making table
        /// </summary>
        calculated = 4,
        /// <summary>
        /// The comparative: tells the provider to include more 
        /// </summary>
        comparative = 8,
        singleRow=16,
        navigation=32,
        described=64,
        collection = 128,

        dataTableVertical = vertical | singleRow | described, 
        dataTableHorizontal = horizontal | collection,
        singleRowCalculatedSummary = singleRow | calculated | described | horizontal,
        verticalCalculatedSummary = singleRow | calculated | described | vertical,
        comparativeSummary = collection | comparative | vertical | calculated


    }
}
