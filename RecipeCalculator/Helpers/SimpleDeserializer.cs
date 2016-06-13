using System;
using System.Xml;
using System.Xml.Serialization;

namespace RecipeCalculator
{
    public static class SimpleDeserializer
    {
        public static T Deserialize<T>(string path)
        {
            T tee = default(T);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            
            using (XmlReader reader = XmlReader.Create(path))
            {
                if (serializer.CanDeserialize(reader))
                {
                    tee = (T)serializer.Deserialize(reader);
                }
            }

            if(tee == null)
            {
                throw new ArgumentException($"{path} is not in the proper format");
            }

            return tee;
        }
    }
}
