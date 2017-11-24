namespace imbSCI.Data.data
{
    using System;
    using imbSCI.Data.interfaces;

    /// <summary>
    /// Helper class to monitor path change 
    /// </summary>
    /// <seealso cref="imbBindable" />
    public class ObjectPathChangeMonitor:imbBindable
    {

        private String lastPath = "";
        private String newPath = "";

        /// <summary>
        /// New instance with initial target
        /// </summary>
        /// <param name="target">The target.</param>
        public ObjectPathChangeMonitor(IObjectWithPath target)
        {
            update(target);
        }

        public virtual Boolean update(IObjectWithPath target)
        {
            _target = target;
            if (_target == null)
            {
                newPath = "";
            }
            newPath = _target.path;
            return getPathChange(false);
        }


        protected IObjectWithPath _target;

        /// <summary>
        /// TEels if scope path was changed than last call with <c>markAsUnchanged</c> set TRUE
        /// </summary>
        /// <param name="markAsUnchanged">if set to <c>true</c> if will change state to unchange</param>
        /// <returns>TRUE if scope-s path is different than last call with <c>markAsUnchanged</c> set TRUE</returns>
        public Boolean getPathChange(Boolean markAsUnchanged = true)
        {
            if (lastPath != newPath)
            {
                if (markAsUnchanged) lastPath = newPath;
                return true;
            }
            return false;
        }
    }

}