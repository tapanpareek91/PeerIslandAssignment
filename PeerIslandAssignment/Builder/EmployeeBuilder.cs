using System.Collections.Generic;

namespace PeerIslandAssignment.Builder
{
    /// <summary>he Base Builder class. This class will be used for creating the parts of the generic result object.</summary>
    /// <typeparam name="T">The Generic result class.</typeparam>
    public abstract class Builder<T>
    {
        /// <summary>Read the XML.</summary>
        /// <param name="rootAttribute">The root attribute from XML.</param>
        /// <returns>
        ///   The List of elements from XML.
        /// </returns>
        public abstract IList<T> Read(string rootAttribute);

        /// <summary>Writes the specified data into XML.</summary>
        /// <param name="data">The data.</param>
        /// <param name="rootAttribute">The root attribute.</param>
        /// <returns>
        ///   True if success else false.
        /// </returns>
        public abstract bool Write(T data, string rootAttribute);

        /// <summary>Deletes the specified element from XML using node name and node value.</summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="NodeValue">The node value.</param>
        /// <returns>
        ///  True if success else false.
        /// </returns>
        public abstract bool Delete(string nodeName, string NodeValue);
    }
}
