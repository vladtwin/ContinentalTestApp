using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Assets.Script.Character;
using Assets.Script.HelpClass;
using test;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class PlayerSingleton
    {
        private static PlayerSingleton singletin;
        public static PlayerSingleton Singleton
        {
            get { return singletin ?? (singletin = new PlayerSingleton()); }
        }

        private PlayerSingleton()
        {
            LoadPlayer();
        }

        public int GetCharacterLevel(int id)
        {
            int level = 0;
            UpdateTDO tDto = player.Updates.FirstOrDefault(p => p.id == id);
            if (tDto != null)
                level = tDto.Level;
            return level;
        }

        public CharacterDTO GetNowCharacterTDO(int id)
        {
            int level = GetCharacterLevel(id);
            return getCharacterPropertyesInfo(id).Characters[level];
        }

        public CharacterPropertyesInfo getCharacterPropertyesInfo(int id)
        {
            return CharactersSingleton.Singleton.CharactersInfos.FirstOrDefault(p => p.id == id);
        }
        public int GetMoneyCountToUpdate(int id)
        {
            int level = GetCharacterLevel(id);
            CharacterPropertyesInfo cinfo = getCharacterPropertyesInfo(id);
            if (cinfo.Characters.Count > level)
                return cinfo.Characters[level].Cost;
            return -1;
        }

        public void SetImageToCharacter(RawImage img, int id)
        {
            int level = GetCharacterLevel(id);
            CharacterPropertyesInfo cinfo = getCharacterPropertyesInfo(id);
            img.texture = Resources.Load("Characters/" + cinfo.ImageName, typeof(Texture)) as Texture;
            if (img.texture == null)
                img.texture = Resources.Load("Characters/character" + cinfo.id, typeof(Texture)) as Texture;
            if (cinfo.Characters.Count > 0)
            {
                float size = 1f / cinfo.Characters.Count;
                if (cinfo.Characters.Count > level)
                {
                    int position = cinfo.Characters[level].ImagePosition;
                    if (position < 0)
                        position = cinfo.id;
                    float x1 = size*(cinfo.Characters[level].ImagePosition);
                    img.uvRect=new Rect(new Vector2(x1,0), new Vector2(size,1));
                }
            }
        }

        public void SavePlayer()
        {
            try
            {
                if (player != null)
                {
                    byte[] data = DataContractSerializerHelp.Serialize(player);
                    if (data != null && data.Length > 0)
                    {
                        File.WriteAllBytes(Application.persistentDataPath + "/PlayerData.xml", data);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
        }

        private void LoadPlayer()
        {
            try
            {

                /*  object ObjectXmlPlayerData = Resources.Load("PlayerData.xml");
                  if (ObjectXmlPlayerData != null && ObjectXmlPlayerData is string)
                  {
                      byte[] data = Encoding.UTF8.GetBytes(ObjectXmlPlayerData.ToString());
                      player = DataContractSerializerHelp.Deserialize(data, typeof(Player)) as Player;
                  }*/
                byte[] data = File.ReadAllBytes(Application.persistentDataPath + "/PlayerData.xml");
                if (data != null && data.Length > 0)
                    player = DataContractSerializerHelp.Deserialize(data, typeof(Player)) as Player;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
            }
            finally
            {
                if (player == null)
                    player = new Player() { Money = 1000, Updates = new List<UpdateTDO>() };
            }
        }

        private Player player;
        public Player Player { get { return player; } }

        public UpdateTDO GetUpdate(int id)
        {
            return player.Updates.FirstOrDefault(p => p.id == id);;
        }

        public bool NowIsUpdate(int id)
        {
            UpdateTDO update = GetUpdate(id);
            if (update != null)
            {
                DateTime dt = new DateTime(update.StartUpdate.Ticks);
                return (dt.AddSeconds(update.UpdateTime) > DateTime.Now);
            }
            return false;
        }
    }
}
