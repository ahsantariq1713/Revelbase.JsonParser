using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Revelbase.JsonParser.Core
{
    /// <summary>
    /// This class parse the json data, stored in a file, to Choice object array 
    /// </summary>
    public class JParser
    {
        /// <summary>
        /// The path of the file containing json object array of Choice data-type
        /// </summary>
        private readonly string filePath;

        /// <summary>
        /// Private constructors used by the static method New only
        /// </summary>
        /// <param name="filePath">The path of the file containing json object array of Choice data-type</param>
        private JParser(string filePath)
        {

            this.filePath = filePath;
        }

        /// <summary>
        /// Create new JsonParser Object.
        /// </summary>
        /// <param name="filePath">The path of the file containing json object array of Choice data-type</param>
        /// <exception cref="FileNotFoundException">When file do not exist</exception>
        /// <returns>JsonParser Object</returns>
        public static JParser New(string filePath)
        {
            var parser = new JParser(filePath);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found on the given path '{filePath}'");
            }
            
            return parser;
        }

        /// <summary>
        /// Returns a collection of Choice objects
        /// </summary>
        /// <exception cref="FormatException">When file data format is invalid. 
        /// File must contains a json object array of Choice data-type</exception>
        /// <returns>An iterateable collection of Choice</returns>
        public IEnumerable<Choice> GetChoices()
        {
            var data = File.ReadAllText(filePath);

            IEnumerable<Choice> choices = null;
            try
            {
                
               choices =  JsonConvert.DeserializeObject<IEnumerable<Choice>>(data);
            }
            catch (Exception)
            {
                throw new FormatException("File data format is invalid and choice objects cannot be read.");
            }
            
            return choices;
        }

    }
}
