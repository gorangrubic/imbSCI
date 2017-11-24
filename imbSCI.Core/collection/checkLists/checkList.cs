namespace imbSCI.Core.collection.checkLists
{
    using System;
    using System.Collections.Generic;
    using imbSCI.Core.extensions.data;

    /// <summary>
	/// 2017: Key is value, Value tells if is is checked/selected
	/// </summary>
	public class checkList
	{

		private PropertyCollectionExtended _items = new PropertyCollectionExtended();
		/// <summary> </summary>
		public PropertyCollectionExtended items
		{
			get
			{
				return _items;
			}
			protected set
			{
				_items = value;
				//OnPropertyChanged("items");
			}
		}

		/// <summary>
		/// Gets the check value.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public checkListItemValue getCheckValue(Object key)
		{
			if (items.entries.ContainsKey(key))
			{
				if ((Boolean) items.entries[key].EntryValue)
				{
					return checkListItemValue.checkTrue;
				} else
				{
					return checkListItemValue.checkFalse;
				}
			} else
			{
				return checkListItemValue.none;
			}
			
		}

		/// <summary>
		/// Gets entries for checked items
		/// </summary>
		/// <param name="targetValue">if set to <c>true</c> [target value].</param>
		/// <returns></returns>
		public PropertyCollectionExtended getCheckedItems(Boolean targetValue = true)
		{
			PropertyCollectionExtended output = new PropertyCollectionExtended();
			foreach (KeyValuePair<object, PropertyEntry> pe in items.entries)
			{
				if (pe.Value.getProperBoolean(false, PropertyEntryColumn.entry_value) == targetValue)
				{
					output.Add(pe.Value);
				}
			}
			return output;
		}

		// /// <summary>
		// /// Gets sub lst
		// /// </summary>
		// /// <param name="checkedValue"></param>
		// /// <returns></returns>
		//public List<String> getCheckedStrings(Boolean checkedValue = true, String format="")
		//{
		//    List<String> output = new List<string>();

		//    PropertyCollectionExtended pce = getCheckedItems(checkedValue);

		//    foreach ( str in items)
		//    {
				
		//        if ()
		//        if (items.ContainsKey(str)) output.Add(str);
		//    }
		//    return output;
		//}

		/// <summary>
		/// Appends its data points into new or existing property collection
		/// </summary>
		/// <param name="data">Property collection to add data into</param>
		/// <returns>Updated or newly created property collection</returns>
		public PropertyCollectionExtended AppendDataFields(PropertyCollectionExtended data = null)
		{
			if (data == null) data = new PropertyCollectionExtended();

			data.AddRange(items, false, false, false);
			/*
			data.Add("grouptag", groupTag, "Database tag", "Tag string to mark sample item row in the database table");
			data.Add("groupweight", weight, "Weight factor", "Relative weight number used for automatic population-to-group assigment");
			data.Add("grouplimit", groupSizeLimit, "Size limit", "Optional limit for total count of population within this group");
			data.Add("groupcount", count, "Sample count", "Sample item entries count attached to this group");
			*/
			return data;
		}

	   



		public checkList()
		{

		}

		public checkList(Enum flags)
		{
			foreach (Enum en in Enum.GetValues(flags.GetType())) {
				String name = en.ToString();
				Boolean val = flags.HasFlag(en);
				items.addAsObjectKey(en, val);
			}
		}

	   

		public void setChecked(IEnumerable<String> input, Boolean setAllChecked = false)
		{
			foreach (String str in input)
			{
				if (items.ContainsKey(str))
				{
					items[str] = setAllChecked;
				}
			}
		}

		public void AddRange(IEnumerable<String> input, Boolean setAllChecked = false)
		{
			foreach (String str in input)
			{
				items.addAsObjectKey(str, setAllChecked);
			}

		}
	}
}