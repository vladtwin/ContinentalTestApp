using System;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using Assets;
using Assets.Script.Character;
using Assets.Script.HelpClass;
using test;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public GameObject BtnAdd100;
    public GameObject BtnAdd1000;
    public GameObject BtnExit;

    public Text MoneyTextBox;

    public GameObject CharacterPrefab;
    public GameObject MainContent;

    public UIMainMenu MainMenu;

    void Start()
    {
        MainMenu = new UIMainMenu(BtnAdd100, BtnAdd1000, BtnExit);
        MainMenu.Init();

        PlayerSingleton.Singleton.Player.PropertyChanged += Player_PropertyChanged;
        PlayerSingleton.Singleton.Player.Money = PlayerSingleton.Singleton.Player.Money;
        try
        {
            object[] characters = Resources.LoadAll("Characters", typeof(TextAsset));
            if (characters != null)
            {
                foreach (object val in characters)
                {
                    try
                    {
                        CharacterPropertyesInfo character = DataContractSerializerHelp.Deserialize(Encoding.UTF8.GetBytes(((TextAsset)val).text), typeof(CharacterPropertyesInfo)) as CharacterPropertyesInfo;
                        CharactersSingleton.Singleton.CharactersInfos.Add(character);
                        GameObject characterObject = GameObject.Instantiate(CharacterPrefab,MainContent.transform,false);
                        characterObject.GetComponent<CharacterViewController>().PropertyesInfo = character;
                    }
                    catch (Exception ex)
                    {
                        Debug.LogError(ex.Message);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }

    }

    private void Player_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        PlayerSingleton.Singleton.SavePlayer();
        if (e.PropertyName == "Money")
        {
            if (MoneyTextBox != null)
                MoneyTextBox.text = ((Player)sender).Money.ToString();
        }
    }
}
