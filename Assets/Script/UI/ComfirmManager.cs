using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets;
using Assets.Script.HelpClass;
using test;
using UnityEngine;
using UnityEngine.UI;

public class ComfirmManager : MonoBehaviour
{
    public Text MoneyCount;
    public RawImage ImgCharacter;
    public Button BtnOk;
    public Button BtnCansel;
    private CharacterPropertyesInfo _character;
    public Text TimeText;

    public GameObject child;
    public void Start()
    {
         child.SetActive(false);
        BtnOk.onClick.AddListener(delegate
        {
            CharacterDTO characterDto = PlayerSingleton.Singleton.GetNowCharacterTDO(_character.id);
            if (characterDto.Cost > 0 && PlayerSingleton.Singleton.Player.Money >= characterDto.Cost)
                PlayerSingleton.Singleton.Player.Money -= characterDto.Cost;
            UpdateTDO update = PlayerSingleton.Singleton.Player.Updates.FirstOrDefault(p => p.id == _character.id);
            if (update == null)
            {
                update=new UpdateTDO() {id=_character.id};
                PlayerSingleton.Singleton.Player.Updates.Add(update);
            }
            update.Level++;
            update.StartUpdate=DateTime.Now;
            update.UpdateTime = characterDto.UpdateTime;
            PlayerSingleton.Singleton.SavePlayer();
             child.SetActive(false);
        });
        BtnCansel.onClick.AddListener(delegate
        {
            child.SetActive(false);
        });
    }

    public CharacterPropertyesInfo _propertyesInfo
    {
        set
        {
            _character = value;
            Init();
        }
    }

    public void Init()
    {
        child.SetActive(true);
        TimeText.text =
            TimeSpan.FromSeconds(PlayerSingleton.Singleton.GetNowCharacterTDO(_character.id).UpdateTime).GetTimeString();
        MoneyCount.text = PlayerSingleton.Singleton.GetMoneyCountToUpdate(_character.id).ToString();
        PlayerSingleton.Singleton.SetImageToCharacter(ImgCharacter, _character.id);

    }



}
