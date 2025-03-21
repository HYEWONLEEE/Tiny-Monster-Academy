using UnityEngine;

public class Testing : MonoBehaviour
{
    public void Start()
    {
        ResetPlayerData();
    }
    public void ResetPlayerData()
    {
        DataManager.instance.playerData.gold = 0d;
        DataManager.instance.playerData.ruby = 0d;
        DataManager.instance.playerData.level = 1;
        DataManager.instance.playerData.playerName = "";
        DataManager.instance.playerData.totalProductivity = 10d;

        DataManager.instance.SaveData(); // 초기값 저장
        
    }
}
