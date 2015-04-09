using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace L2L.API.Shared.Interfaces
{
    public interface IDataPart 
    {
        /// <summary>
        /// This method's return type is the 'Type' you can safely type cast this IDataPart to.
        /// </summary>
        /// <returns></returns>
        Type GetDataPartType();
        

        /*
        XElement SerializeToXML();
        void DeserializeFromXML(XElement xe);
        string SerializeToJson();
        void DeserializeFromJson(string jsonStr);
         
        
        /// <summary>
        /// call this method to get a list of all the parts that make up this IDataPart 
        /// </summary>
        /// <returns>list of IDataPart Types: not the objects, but their type</returns>
        List<string> GetComponentParts();
        
        /// <summary>
        /// call this method to get a list of all the parts that are filled this object
        /// </summary>
        /// <returns>list of IDataPart Types: not the objects, but their type</returns>
        List<Type> GetAvailableParts();

        /// <summary>
        /// Returns the actual data that are filled
        /// </summary>
        /// <returns>Dictinary of output part enum and its contentpart</returns>
        Dictionary<Type, IDataPart> GetParts(List<string> parts);
        */
    }
}
