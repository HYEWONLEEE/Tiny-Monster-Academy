using UnityEngine;
using System.IO;
//������ JSON���� �����ϴ� Ŭ���� 
public static class SaveSystem
{
    private static string savePath = Application.persistentDataPath + "/playerData.json";
    
    //���� �Լ�
    public static void SaveGameData(PlayerData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("���� �Ϸ� : " + savePath);
    }
    //�ε� �Լ�
    public static PlayerData LoadGameData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("�ε� �Ϸ�");
            return data;
        }

        else
        {
            Debug.LogWarning("���̺� ������ �����ϴ�. �� �����͸� ����ϴ�.");
            return new PlayerData();
        }
    }
}
