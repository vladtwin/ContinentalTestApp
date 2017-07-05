using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace test
{
    [DataContract]
    public class CharacterDTO
    {
        [DataMember]
        public int Cost { get; set; }
        [DataMember]
        public int Power { get; set; }
        [DataMember]
        public int ImagePosition { get; set; }
        [DataMember]
        public int UpdateTime { get; set; }
        [DataMember]
        public int StartUpdateTime { get; set; }
    }
}