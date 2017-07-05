using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Assets.Script.HelpClass
{
   public static class DataContractSerializerHelp
    {
        public static byte[] Serialize(object data, List<Type> known = null )
        {
            if (data == null)
            {
                return null;
            }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializerDC = new DataContractSerializer(data.GetType(),known);
                serializerDC.WriteObject(memoryStream, data);
                return memoryStream.ToArray();
            }
        }

        public static object Deserialize(this byte[] byteArray, Type type) 
        {
            if (byteArray == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream(byteArray))
            {
                DataContractSerializer serializerDC = new DataContractSerializer(type);
                return serializerDC.ReadObject(memoryStream);
            }
        }
    }
}
