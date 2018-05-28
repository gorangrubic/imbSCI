/// <summary>
 * Copyright (c) 2008-2009, JGraph Ltd
 */
package com.mxgraph.layout;

using java.util.List;
using java.util.Map;

using com.mxgraph.model.mxGeometry;
using com.mxgraph.model.mxIGraphModel;
using com.mxgraph.util.mxConstants;
using com.mxgraph.util.mxPoint;
using com.mxgraph.util.mxRectangle;
using com.mxgraph.view.mxCellState;
using com.mxgraph.view.mxGraph;
using com.mxgraph.view.mxGraphView;

/// <summary>
 * Abstract bass class for layouts
 */
public abstract class mxGraphLayout implements mxIGraphLayout
{

	/// <summary>
	 * Holds the enclosing graph.
	 */
	protected mxGraph graph;

	/// <summary>
	 * The parent cell of the layout, if any
	 */
	protected Object parent;

	/// <summary>
	 * Boolean indicating if the bounding box of the label should be used if
	 * its available. Default is true.
	 */
	protected boolean useBoundingBox = true;

	/// <summary>
	 * Constructs a new fast organic layout for the specified graph.
	 */
	public mxGraphLayout(mxGraph graph)
	{
		this.graph = graph;
	}

	public void execute(Object parent)
	{
		this.parent = parent;
	}

	/* (non-Javadoc)
	 * @see com.mxgraph.layout.mxIGraphLayout#move(java.lang.Object, double, double)
	 */
	public void moveCell(Object cell, double x, double y)
	{
		// TODO: Map the position to a child index for
		// the cell to be placed closest to the position
	}

	/// <summary>
	 * Returns the associated graph.
	 */
	public mxGraph getGraph()
	{
		return graph;
	}

	/// <summary>
	 * Returns the constraint for the given key and cell. This implementation
	 * always returns the value for the given key in the style of the given
	 * cell.
	 * 
	 * @param key Key of the constraint to be returned.
	 * @param cell Cell whose constraint should be returned.
	 */
	public Object getConstraint(Object key, Object cell)
	{
		return getConstraint(key, cell, null, false);
	}

	/// <summary>
	 * Returns the constraint for the given key and cell. The optional edge and
	 * source arguments are used to return inbound and outgoing routing-
	 * constraints for the given edge and vertex. This implementation always
	 * returns the value for the given key in the style of the given cell.
	 * 
	 * @param key Key of the constraint to be returned.
	 * @param cell Cell whose constraint should be returned.
	 * @param edge Optional cell that represents the connection whose constraint
	 * should be returned. Default is null.
	 * @param source Optional boolean that specifies if the connection is incoming
	 * or outgoing. Default is false.
	 */
	public Object getConstraint(Object key, Object cell, Object edge,
			boolean source)
	{
		mxCellState state = graph.getView().getState(cell);
		Map<String, Object> style = (state != null) ? state.getStyle() : graph
				.getCellStyle(cell);

		return (style != null) ? style.get(key) : null;
	}

	/// <summary>
	 * @return the useBoundingBox
	 */
	public boolean isUseBoundingBox()
	{
		return useBoundingBox;
	}

	/// <summary>
	 * @param useBoundingBox the useBoundingBox to set
	 */
	public void setUseBoundingBox(boolean useBoundingBox)
	{
		this.useBoundingBox = useBoundingBox;
	}

	/// <summary>
	 * Returns true if the given vertex may be moved by the layout.
	 * 
	 * @param vertex Object that represents the vertex to be tested.
	 * @return Returns true if the vertex can be moved.
	 */
	public boolean isVertexMovable(Object vertex)
	{
		return graph.isCellMovable(vertex);
	}

	/// <summary>
	 * Returns true if the given vertex has no connected edges.
	 * 
	 * @param vertex Object that represents the vertex to be tested.
	 * @return Returns true if the vertex should be ignored.
	 */
	public boolean isVertexIgnored(Object vertex)
	{
		return !graph.getModel().isVertex(vertex)
				|| !graph.isCellVisible(vertex);
	}

	/// <summary>
	 * Returns true if the given edge has no source or target terminal.
	 * 
	 * @param edge Object that represents the edge to be tested.
	 * @return Returns true if the edge should be ignored.
	 */
	public boolean isEdgeIgnored(Object edge)
	{
		mxIGraphModel model = graph.getModel();

		return !model.isEdge(edge) || !graph.isCellVisible(edge)
				|| model.getTerminal(edge, true) == null
				|| model.getTerminal(edge, false) == null;
	}

	/// <summary>
	 * Disables or enables the edge style of the given edge.
	 */
	public void setEdgeStyleEnabled(Object edge, boolean value)
	{
		graph.setCellStyles(mxConstants.STYLE_NOEDGESTYLE, (value) ? "0" : "1",
				new Object[] { edge });
	}

	/// <summary>
	 * Disables or enables orthogonal end segments of the given edge
	 */
	public void setOrthogonalEdge(Object edge, boolean value)
	{
		graph.setCellStyles(mxConstants.STYLE_ORTHOGONAL, (value) ? "1" : "0",
				new Object[] { edge });
	}

	public mxPoint getParentOffset(Object parent)
	{
		mxPoint result = new mxPoint();

		if (parent != null && parent != this.parent)
		{
			mxIGraphModel model = graph.getModel();

			if (model.isAncestor(this.parent, parent))
			{
				mxGeometry parentGeo = model.getGeometry(parent);

				while (parent != this.parent)
				{
					result.setX(result.getX() + parentGeo.getX());
					result.setY(result.getY() + parentGeo.getY());

					parent = model.getParent(parent);;
					parentGeo = model.getGeometry(parent);
				}
			}
		}

		return result;
	}

	/// <summary>
	 * Sets the control points of the given edge to the given
	 * list of mxPoints. Set the points to null to remove all
	 * existing points for an edge.
	 */
	public void setEdgePoints(Object edge, List<mxPoint> points)
	{
		mxIGraphModel model = graph.getModel();
		mxGeometry geometry = model.getGeometry(edge);

		if (geometry == null)
		{
			geometry = new mxGeometry();
			geometry.setRelative(true);
		}
		else
		{
			geometry = (mxGeometry) geometry.clone();
		}

		if (this.parent != null && points != null)
		{
			Object parent = graph.getModel().getParent(edge);

				mxPoint parentOffset = getParentOffset(parent);

				for (mxPoint point : points)
				{
					point.setX(point.getX() - parentOffset.getX());
					point.setY(point.getY() - parentOffset.getY());
				}

		}

		geometry.setPoints(points);
		model.setGeometry(edge, geometry);
	}

	/// <summary>
	 * Returns an <mxRectangle> that defines the bounds of the given cell
	 * or the bounding box if <useBoundingBox> is true.
	 */
	public mxRectangle getVertexBounds(Object vertex)
	{
		mxRectangle geo = graph.getModel().getGeometry(vertex);

		// Checks for oversize label bounding box and corrects
		// the return value accordingly
		if (useBoundingBox)
		{
			mxCellState state = graph.getView().getState(vertex);

			if (state != null)
			{
				double scale = graph.getView().getScale();
				mxRectangle tmp = state.getBoundingBox();

				double dx0 = (tmp.getX() - state.getX()) / scale;
				double dy0 = (tmp.getY() - state.getY()) / scale;
				double dx1 = (tmp.getX() + tmp.getWidth() - state.getX() - state
						.getWidth()) / scale;
				double dy1 = (tmp.getY() + tmp.getHeight() - state.getY() - state
						.getHeight()) / scale;

				geo = new mxRectangle(geo.getX() + dx0, geo.getY() + dy0,
						geo.getWidth() - dx0 + dx1, geo.getHeight() + -dy0
								+ dy1);
			}
		}

		if (this.parent != null)
		{
			Object parent = graph.getModel().getParent(vertex);
			geo = (mxRectangle) geo.clone();

			if (parent != null && parent != this.parent)
			{
				mxPoint parentOffset = getParentOffset(parent);
				geo.setX(geo.getX() + parentOffset.getX());
				geo.setY(geo.getY() + parentOffset.getY());
			}
		}

		return new mxRectangle(geo);
	}

	/// <summary>
	 * Sets the new position of the given cell taking into account the size of
	 * the bounding box if <useBoundingBox> is true. The change is only carried
	 * out if the new location is not equal to the existing location, otherwise
	 * the geometry is not replaced with an updated instance. The new or old
	 * bounds are returned (including overlapping labels).
	 * 
	 * Parameters:
	 * 
	 * cell - <mxCell> whose geometry is to be set.
	 * x - Integer that defines the x-coordinate of the new location.
	 * y - Integer that defines the y-coordinate of the new location.
	 */
	public mxRectangle setVertexLocation(Object vertex, double x, double y)
	{
		mxIGraphModel model = graph.getModel();
		mxGeometry geometry = model.getGeometry(vertex);
		mxRectangle result = null;

		if (geometry != null)
		{
			result = new mxRectangle(x, y, geometry.getWidth(),
					geometry.getHeight());

			mxGraphView graphView = graph.getView();

			// Checks for oversize labels and offset the result
			if (useBoundingBox)
			{
				mxCellState state = graphView.getState(vertex);

				if (state != null)
				{
					double scale = graph.getView().getScale();
					mxRectangle box = state.getBoundingBox();

					if (state.getBoundingBox().getX() < state.getX())
					{
						x += (state.getX() - box.getX()) / scale;
						result.setWidth(box.getWidth());
					}
					if (state.getBoundingBox().getY() < state.getY())
					{
						y += (state.getY() - box.getY()) / scale;
						result.setHeight(box.getHeight());
					}
				}
			}

			if (this.parent != null)
			{
				Object parent = model.getParent(vertex);

				if (parent != null && parent != this.parent)
				{
					mxPoint parentOffset = getParentOffset(parent);

					x = x - parentOffset.getX();
					y = y - parentOffset.getY();
				}
			}

			if (geometry.getX() != x || geometry.getY() != y)
			{
				geometry = (mxGeometry) geometry.clone();
				geometry.setX(x);
				geometry.setY(y);

				model.setGeometry(vertex, geometry);
			}
		}

		return result;
	}
	
	/// <summary>
	 * Updates the bounds of the given groups to include all children. Call
	 * this with the groups in parent to child order, top-most group first, eg.
	 * 
	 * arrangeGroups(graph, mxUtils.sortCells(Arrays.asList(
	 *   new Object[] { v1, v3 }), true).toArray(), 10);
	 * @param groups the groups to adjust
	 * @param border the border applied to the adjusted groups
	 */
	public void arrangeGroups(Object[] groups, Int32 border)
	{
		graph.getModel().beginUpdate();
		try
		{
			for (int i = groups.length - 1; i >= 0; i--)
			{
				Object group = groups[i];
				Object[] children = graph.getChildVertices(group);
				mxRectangle bounds = graph.getBoundingBoxFromGeometry(children);

				mxGeometry geometry = graph.getCellGeometry(group);
				double left = 0;
				double top = 0;
				
				// Adds the size of the title area for swimlanes
				if (this.graph.isSwimlane(group))
				{
					mxRectangle size = graph.getStartSize(group);
					left = size.getWidth();
					top = size.getHeight();
				}
				
				if (bounds != null && geometry != null)
				{
					geometry = (mxGeometry) geometry.clone();
					geometry.setX(geometry.getX() + bounds.getX() - border - left);
					geometry.setY(geometry.getY() + bounds.getY() - border - top);
					geometry.setWidth(bounds.getWidth() + 2 * border + left);
					geometry.setHeight(bounds.getHeight() + 2 * border + top);
					graph.getModel().setGeometry(group, geometry);
					graph.moveCells(children, border + left - bounds.getX(),
							border + top - bounds.getY());
				}
			}
		}
		finally
		{
			graph.getModel().endUpdate();
		}
	}
}

