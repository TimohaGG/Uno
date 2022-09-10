using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Uno_V2.Core
{
    internal class Serialaizator
    {
        IFormatter formatter;
        Stream stream;

        public Serialaizator() {
            formatter = new BinaryFormatter();
        }

        public void Serialize(string filename, object ToSerialize)
        {
            stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, ToSerialize);
            stream.Close();
        }

        public object Deserialize(ISerializable ob)
        {
            
            stream = new FileStream(ob.name, FileMode.Open, FileAccess.Read);
            ob = (ISerializable)formatter.Deserialize(stream);
            stream.Close();
            return ob;
        }
    }
}
