using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Assets;
using test;
using UnityEngine;
using UnityEngine.UI;

public class UIComfirm : MonoBehaviour
{

    public Text MoneyCount;
    public RawImage ImgCharacter;
    private CharacterPropertyesInfo _character;

    public CharacterPropertyesInfo Character
    {
        set
        {
            _character = value;
            MoneyCount.text = PlayerSingleton.Singleton.GetMoneyCountToUpdate(value.id).ToString();
            PlayerSingleton.Singleton.SetImageToCharacter(ImgCharacter, value.id);
        }

    

    }
}
