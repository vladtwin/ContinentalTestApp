using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using test;

namespace Assets.Script.Character
{
    public class CharactersSingleton
    {
        public static readonly CharactersSingleton Singleton=new CharactersSingleton();
        public List<CharacterPropertyesInfo> CharactersInfos = new List<CharacterPropertyesInfo>();
        private CharactersSingleton() { }
    }
}
