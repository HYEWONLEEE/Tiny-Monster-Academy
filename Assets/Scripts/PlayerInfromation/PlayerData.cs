using UnityEngine;
using System.Collections.Generic;
//JSON으로 저장할 플레이어 데이터를 클래스로 정의

[System.Serializable]
public class PlayerData
{
    public string playerName = ""; //플레이어 이름
    public double gold = 0d; //골드 보유량
    public double ruby = 0d; //루비 보유량
    public double totalProductivity = 10d; //총 생산량
    public int level = 1; //플레이어 레벨(통합레벨)

    public List<FacilityData> unlockedFacilities = new List<FacilityData>();
}
