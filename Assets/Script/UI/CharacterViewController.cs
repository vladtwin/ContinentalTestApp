using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using test;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterViewController : MonoBehaviour
{
    public Text LevelText;
    public Text NameText;
    public Text PowerText;
    public Text CosText;
    public Text BarText;

    public RawImage Image;
    public Image BarImage;

    private CharacterPropertyesInfo _propertyesInfo;

    public CharacterPropertyesInfo PropertyesInfo
    {
        get { return _propertyesInfo; }
        set
        {
            _propertyesInfo = value;
            Init();
        }
    }

    CharacterDTO characterDto;

    private void Init()
    {
        characterDto = PlayerSingleton.Singleton.GetNowCharacterTDO(_propertyesInfo.id);
        int level = PlayerSingleton.Singleton.GetCharacterLevel(_propertyesInfo.id);
        LevelText.text = level.ToString();
        NameText.text = _propertyesInfo.Name;

        if (_propertyesInfo.Characters.Count > 0 && !PlayerSingleton.Singleton.NowIsUpdate(_propertyesInfo.id))
        {
            BarText.text = String.Format("{0} / {1}", level, _propertyesInfo.Characters.Count);
        }
        CosText.text = characterDto.Cost.ToString();
        PlayerSingleton.Singleton.SetImageToCharacter(Image,_propertyesInfo.id);

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
