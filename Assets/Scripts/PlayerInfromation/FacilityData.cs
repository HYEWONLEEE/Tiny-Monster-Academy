using UnityEngine;
//해금한 시설에 관한 데이터

[System.Serializable]
public class FacilityData
{
    public string facilityName; //시설 이름
    public bool isUnlocked; //해금 여부
    public int facilityLevel; //시설 레벨
    public double facilityProductivity; //시설 자체 생산량
}
