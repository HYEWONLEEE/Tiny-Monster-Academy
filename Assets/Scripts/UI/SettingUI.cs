using UnityEngine;
using UnityEngine.UI;
//���� �޴��鿡���� ó��

public class SettingUI : MonoBehaviour
{
    public GameObject nameInputUI;
    public GameObject confirmPanel;
    public GameObject settingPanel;
    


    public void OnClickSetting()
    {
        settingPanel.SetActive(true);
    }
    public void OnClickRename()
    {
        nameInputUI.SetActive(true);
    }
    public void OnClickReset()
    {
        confirmPanel.SetActive(true);
    }

    public void ConfirmReset()
    {
        ResetPlayerData();
        confirmPanel.SetActive(false);
    }
    public void CloseConfirmPanel()
    {
        confirmPanel.SetActive(false);
    }
    public void ResetPlayerData()
    {
        DataManager.instance.playerData.gold = 0d;
        DataManager.instance.playerData.ruby = 0d;
        DataManager.instance.playerData.level = 1;
        DataManager.instance.playerData.playerName = "";
        DataManager.instance.playerData.totalProductivity = 10d;

        DataManager.instance.SaveData(); // �ʱⰪ ����

    }
}
