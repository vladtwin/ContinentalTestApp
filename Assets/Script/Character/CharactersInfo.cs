using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace test
{
    [DataContract]
    ///CharacterPropertyesInfo
    public class CharacterPropertyesInfo
    {
        [DataMember]
        public List<CharacterDTO> Characters { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ImageName { get; set; }

        public float ImageScale
        {
            get { return (Characters.Count > 0) ? 1/Characters.Count : 0; }
        }
         [DataMember]
        public int id { get; set; }
    }
}