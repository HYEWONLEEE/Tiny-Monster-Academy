using UnityEngine;
using System.Collections.Generic;
//JSON���� ������ �÷��̾� �����͸� Ŭ������ ����

[System.Serializable]
public class PlayerData
{
    public string playerName = ""; //�÷��̾� �̸�
    public double gold = 0d; //��� ������
    public double ruby = 0d; //��� ������
    public double totalProductivity = 10d; //�� ���귮
    public int level = 1; //�÷��̾� ����(���շ���)

    public List<FacilityData> unlockedFacilities = new List<FacilityData>();
}
