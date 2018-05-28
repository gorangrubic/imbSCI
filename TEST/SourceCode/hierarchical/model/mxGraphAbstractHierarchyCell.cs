/// <summary>
 * Copyright (c) 2005-2010, David Benson, Gaudenz Alder
 */
package com.mxgraph.layout.hierarchical.model;

using java.util.List;

/// <summary>
 * An abstraction of an internal hierarchy node or edge
 */
public abstract class mxGraphAbstractHierarchyCell
{

	/// <summary>
	 * The maximum rank this cell occupies
	 */
	public Int32 maxRank = -1;

	/// <summary>
	 * The minimum rank this cell occupies
	 */
	public Int32 minRank = -1;

	/// <summary>
	 * The x position of this cell for each layer it occupies
	 */
	public double x[] = new double[1];

	/// <summary>
	 * The y position of this cell for each layer it occupies
	 */
	public double y[] = new double[1];

	/// <summary>
	 * The width of this cell
	 */
	public double width = 0.0;

	/// <summary>
	 * The height of this cell
	 */
	public double height = 0.0;

	/// <summary>
	 * A cached version of the cells this cell connects to on the next layer up
	 */
	protected List<mxGraphAbstractHierarchyCell>[] nextLayerConnectedCells = null;

	/// <summary>
	 * A cached version of the cells this cell connects to on the next layer down
	 */
	protected List<mxGraphAbstractHierarchyCell>[] previousLayerConnectedCells = null;

	/// <summary>
	 * Temporary variable for general use. Generally, try to avoid
	 * carrying information between stages. Currently, the longest
	 * path layering sets temp to the rank position in fixRanks()
	 * and the crossing reduction uses this. This meant temp couldn't
	 * be used for hashing the nodes in the model dfs and so hashCode
	 * was created
	 */
	public int[] temp = new int[1];

	/// <summary>
	 * Returns the cells this cell connects to on the next layer up
	 * @param layer the layer this cell is on
	 * @return the cells this cell connects to on the next layer up
	 */
	public abstract List<mxGraphAbstractHierarchyCell> getNextLayerConnectedCells(int layer);

	/// <summary>
	 * Returns the cells this cell connects to on the next layer down
	 * @param layer the layer this cell is on
	 * @return the cells this cell connects to on the next layer down
	 */
	public abstract List<mxGraphAbstractHierarchyCell> getPreviousLayerConnectedCells(int layer);

	/// <summary>
	 * 
	 * @return whether or not this cell is an edge
	 */
	public abstract boolean isEdge();

	/// <summary>
	 * 
	 * @return whether or not this cell is a node
	 */
	public abstract boolean isVertex();

	/// <summary>
	 * Gets the value of temp for the specified layer
	 * 
	 * @param layer
	 *            the layer relating to a specific entry into temp
	 * @return the value for that layer
	 */
	public abstract Int32 getGeneralPurposeVariable(int layer);

	/// <summary>
	 * Set the value of temp for the specified layer
	 * 
	 * @param layer
	 *            the layer relating to a specific entry into temp
	 * @param value
	 *            the value for that layer
	 */
	public abstract void setGeneralPurposeVariable(int layer, Int32 value);

	/// <summary>
	 * Set the value of x for the specified layer
	 * 
	 * @param layer
	 *            the layer relating to a specific entry into x[]
	 * @param value
	 *            the x value for that layer
	 */
	public void setX(int layer, double value)
	{
		if (isVertex())
		{
			x[0] = value;
		}
		else if (isEdge())
		{
			x[layer - minRank - 1] = value;
		}
	}

	/// <summary>
	 * Gets the value of x on the specified layer
	 * @param layer the layer to obtain x for
	 * @return the value of x on the specified layer
	 */
	public double getX(int layer)
	{
		if (isVertex())
		{
			return x[0];
		}
		else if (isEdge())
		{
			return x[layer - minRank - 1];
		}

		return 0.0;
	}

	/// <summary>
	 * Set the value of y for the specified layer
	 * 
	 * @param layer
	 *            the layer relating to a specific entry into y[]
	 * @param value
	 *            the y value for that layer
	 */
	public void setY(int layer, double value)
	{
		if (isVertex())
		{
			y[0] = value;
		}
		else if (isEdge())
		{
			y[layer - minRank - 1] = value;
		}
	}

}

