using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;
//ÀÌ¸§ ÀÔ·ÂÃ¢, ÀÌ¸§ Ç¥½Ã¿¡ °üÇÑ Å¬·¡½º 

public class NameInputUI : MonoBehaviour
{
    public GameObject nameInputWindow; //ÀÌ¸§ ÀÔ·Â Ã¢
    public GameObject confirmWindow; //È®ÀÎ Áú¹® Ã¢
    public Button inputbutton; //ÀÔ·Â ¿Ï·á ¹öÆ°
    public Button confirmButton; //È®ÀÎ Áú¹® ¹öÆ°
    public Button cancelButton; //Ãë¼Ò ¹öÆ°
    public TMP_InputField nameInput; //ÀÔ·ÂµÈ ÀÌ¸§
    public TextMeshProUGUI confirmText; //È®ÀÎ Áú¹®
    public TextMeshProUGUI nameDisplay; //Ç¥½ÃµÉ ´Ğ³×ÀÓ
    private PlayerData playerData;
    private string currentName;

  
    private void Start()
    {
        playerData = DataManager.instance.playerData;
        
        currentName = playerData.playerName; //µ¥ÀÌÅÍ¿¡ ÀúÀåµÈ ÀÌ¸§ °¡Á®¿À±â
        Debug.Log("ÇöÀç ÀÌ¸§ :" + currentName);
        if (string.IsNullOrEmpty(currentName)) //ÇöÀç ÀÌ¸§ÀÌ ³ÎÀÌ°Å³ª °ø¹éÀÌ¸é
        {
            OpenNameInputWindow(); //ÀÔ·Â Ã¢ Ç¥½Ã
        }
        else
        {
            nameDisplay.text = currentName; //¾Æ´Ï¸é ÇöÀç ÀÌ¸§À» UI¿¡ Ç¥½Ã 
        }
        
    }
    public void ConfirmName()
    {
        string input = nameInput.text.Trim(); //¾ÕµÚ °ø¹é Àß¶óÁÖ±â
        if (IsValidName(input))
        {
            confirmText.text = $"\"{input}\" ÀÌ ÀÌ¸§ÀÌ ¸Â³ª¿ä?";
            confirmWindow.SetActive(true);
        }
        //else
    }

    public void OpenNameInputWindow() //ÀÌ¸§ ÀÔ·Â Ã¢ È°¼ºÈ­
    {
        nameInputWindow.SetActive(true);
    }

    public void CancelConfrimWindow() //È®ÀÎ Ã¢ ºñÈ°¼ºÈ­
    {
        confirmWindow.SetActive(false); 
    }

    private bool IsValidName(string input)//´Ğ³×ÀÓ À¯È¿¼º °Ë»ç ÇÔ¼ö
    {
        return Regex.IsMatch(input,"^[a-zA-Z0-9°¡-ÆR]{1,8}$");
    }

    public void ApplyName()
    {
        currentName = nameInput.text.Trim();
        playerData.playerName = currentName; //ÀÌ¸§ ¹Ù²Û °Í Àû¿ëÇØÁÖ±â
        DataManager.instance.SaveData(); //ÀúÀåµµ ÇØ
        nameDisplay.text = currentName; //¹Ù²Û ÀÌ¸§ UI¿¡ Ç¥½Ãµµ ÇØÁÖ±â
        nameInputWindow.SetActive(false); 
        confirmWindow.SetActive(false); //Ã¢µé ºñÈ°¼ºÈ­ 
    }
}
