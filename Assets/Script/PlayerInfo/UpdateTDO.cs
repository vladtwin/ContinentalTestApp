using System;
using System.Runtime.Serialization;

[DataContract]
public class UpdateTDO
{
    [DataMember]
    public int Level { get; set; }
    [DataMember]
    public DateTime StartUpdate { get; set; }
    [DataMember]
    public int UpdateTime { get; set; }

    [DataMember]
    public int id { get; set; }
}
