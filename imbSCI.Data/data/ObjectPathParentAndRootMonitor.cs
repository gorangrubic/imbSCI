namespace imbSCI.Data.data
{
    using System;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Monitors changes in scope - results are in State object
    /// </summary>
    /// <seealso cref="imbBindable" />
    public class ObjectPathParentAndRootMonitor: imbBindable
    {
        private ObjectScopeChangeReport state = new ObjectScopeChangeReport();

        private Object lastRoot;
        private Object lastParent;
        private String lastPath;
        private Int32 lastChildrenCount;
        private IObjectWithPathAndChildSelector lastTarget;

        protected ObjectScopeChangeReport State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        /// <summary>
        /// Sets target and automatically Update - sets all switches if options used
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="setSwitches">if set to <c>true</c> it will set state switches to <c>switchValueToSet</c> value</param>
        /// <param name="switchValueToSet">Value to set to switches, if <c>setSwitches</c> is <c>true</c></param>
        public ObjectPathParentAndRootMonitor(IObjectWithPathAndChildSelector target, Boolean setSwitches=false, Boolean switchValueToSet=true)
        {

            update(target);

            if (setSwitches)
            {
                state.IsChildrenCountChanged = switchValueToSet;
                state.IsParentChanged = switchValueToSet;
                state.IsPathChanged = switchValueToSet;
                state.IsRootChanged = switchValueToSet;
                state.IsTargetChanged = switchValueToSet;
                state.IsChanged = switchValueToSet;
            }
        }

        /// <summary>
        /// Returns state of changes and reset internal change switches if <c>acceptChange</c> is TRUE
        /// </summary>
        /// <param name="acceptChanges">if set to <c>true</c> [accept changes].</param>
        /// <returns>Changes report</returns>
        public ObjectScopeChangeReport getState(Boolean acceptChanges=true)
        {
            ObjectScopeChangeReport output = State;
            if (acceptChanges)
            {
                State = new ObjectScopeChangeReport();
                return output;
            } else
            {
                return State;
            }
        }

        /// <summary>
        /// Checks for changes and records it into internal change switches
        /// </summary>
        /// <param name="target">Monitored object</param>
        public void update(IObjectWithPathAndChildSelector target)
        {
            if (State == null) State = new ObjectScopeChangeReport();

            if (lastTarget != target)
            {
                State.IsTargetChanged = true;
                lastTarget = target;
            }

            if (target == null) return;


            if (lastPath != target.path)
            {
                State.IsPathChanged = true;
                lastPath = target.path;
            }

            if (lastParent != target.parent)
            {
                State.IsParentChanged = true;
                lastParent = target.parent;
            }

            if (lastRoot != target.root)
            {
                State.IsRootChanged = true;
                lastRoot = target.root;
            }

            if (lastChildrenCount != target.Count())
            {
                State.IsChildrenCountChanged = true;
                lastChildrenCount = target.Count();
            }

        }

    }

}