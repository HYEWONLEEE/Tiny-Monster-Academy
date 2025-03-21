using UnityEngine;
using System.IO;
//실제로 JSON으로 저장하는 클래스 
public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/playerData.json";
    
    //저장 함수
    public static void SaveGameData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("저장 완료 : " + savePath);
    }
    //로드 함수
    public static PlayerData LoadGameData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("로드 완료");
            return data;
        }

        else
        {
            Debug.LogWarning("세이브 파일이 없습니다. 새 데이터를 만듭니다.");
            return new PlayerData();
        }
    }
}
