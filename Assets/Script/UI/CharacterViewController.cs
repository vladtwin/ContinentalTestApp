using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using Assets.Script.HelpClass;
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
    public Text TimeText;

    public RawImage Image;
    public Image BarImage;

    private GameObject ConfirmUI;
    private UpdateTDO update;
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
    int level;
    private void Init()
    {
        characterDto = PlayerSingleton.Singleton.GetNowCharacterTDO(_propertyesInfo.id);
        level = PlayerSingleton.Singleton.GetCharacterLevel(_propertyesInfo.id);
        LevelText.text = level.ToString();
        NameText.text = _propertyesInfo.Name;
        PowerText.text = characterDto.Power.ToString();
        TimeText.text = TimeSpan.FromSeconds(characterDto.UpdateTime).GetTimeString();
        if (_propertyesInfo.Characters.Count > 0 && !PlayerSingleton.Singleton.NowIsUpdate(_propertyesInfo.id))
        {
            BarText.text = String.Format("{0} / {1}", level, _propertyesInfo.Characters.Count - 1);
            if (_propertyesInfo.Characters.Count > 0)
                BarImage.fillAmount = level / _propertyesInfo.Characters.Count;
        }
        else
        {
            update = PlayerSingleton.Singleton.GetUpdate(_propertyesInfo.id);
        }
        CosText.text = characterDto.Cost.ToString();
        PlayerSingleton.Singleton.SetImageToCharacter(Image, _propertyesInfo.id);

        GetComponent<Button>().onClick.AddListener(delegate
        {
            if (PlayerSingleton.Singleton.NowIsUpdate(_propertyesInfo.id))
                return;
            if (level + 1 >= _propertyesInfo.Characters.Count)
                return;
            if (ConfirmUI == null)
                ConfirmUI = GameObject.Find("ConfirmUI");
            ConfirmUI.SetActive(true);
            ConfirmUI.GetComponent<ComfirmManager>()._propertyesInfo = _propertyesInfo;
        });

    }
    [SerializeField]
    double procentage;

    [SerializeField] double time;
    private bool canUpdate = false;
    float timeUpdate = 0;
    [SerializeField]
    float CharacterUpdateTime;
    DateTime endTimeTask;
    public void Update()
    {
        timeUpdate += Time.fixedDeltaTime;
        if (timeUpdate < 1)
            return;
        timeUpdate = 0;
        if (_propertyesInfo != null)
        {
            if (!PlayerSingleton.Singleton.NowIsUpdate(_propertyesInfo.id))
            {
                if (canUpdate)
                {
                    Init();
                }
                canUpdate = false;
                return;
            }
            update = PlayerSingleton.Singleton.GetUpdate(_propertyesInfo.id);

            if (update != null)
            {
                if (!canUpdate)
                {
                    endTimeTask = new DateTime(update.StartUpdate.Ticks).AddSeconds(update.UpdateTime);
                    CharacterUpdateTime = update.UpdateTime;
                }
                canUpdate = true;
                time = (endTimeTask - DateTime.Now).TotalSeconds;
                procentage =1- ((CharacterUpdateTime /100)* (100d/CharacterUpdateTime*time)) /CharacterUpdateTime ;
                BarImage.fillAmount = (float)procentage;


                BarText.text = TimeSpan.FromSeconds(time).GetTimeString();
            }
            else
            {
                if (canUpdate)
                {
                    Init();
                }
                canUpdate = false;
            }
        }
    }

}
