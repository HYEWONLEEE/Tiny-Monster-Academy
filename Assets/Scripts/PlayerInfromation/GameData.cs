using UnityEngine;
//데이터 관리 클래스. playerData와 facilityData를 관리함
[System.Serializable]
public class GameData
{
    public PlayerData playerData;   //플레이어 데이터
    public FacilityData[] facilities; //시설 데이터 배열

    //시설 종류와 해금, 업그레이드에 관한 처리 함
    //시설 해금, 업그레이드 시 플레이어 데이터의 생산량이 증가함
    
}
