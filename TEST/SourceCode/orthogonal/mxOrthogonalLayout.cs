/// <summary>
 * Copyright (c) 2008-2009, JGraph Ltd
 */
package com.mxgraph.layout.orthogonal;

using com.mxgraph.layout.mxGraphLayout;
using com.mxgraph.layout.orthogonal.model.mxOrthogonalModel;
using com.mxgraph.view.mxGraph;

/// <summary>
 *
 */
/// <summary>
*
*/
public class mxOrthogonalLayout : mxGraphLayout
{

  /// <summary>
   * 
   */
  protected mxOrthogonalModel orthModel;

  /// <summary>
   * Whether or not to route the edges along grid lines only, if the grid
   * is enabled. Default is false
   */
  protected boolean routeToGrid = false;
  
  /// <summary>
   * 
   */
  public mxOrthogonalLayout(mxGraph graph)
  {
     super(graph);
     orthModel = new mxOrthogonalModel(graph);
  }

  /// <summary>
   * 
   */
  public void execute(Object parent)
  {
     // Create the rectangulation
     
  }

}

