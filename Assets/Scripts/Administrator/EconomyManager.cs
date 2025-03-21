using UnityEngine;
using System.IO;
using System.Collections.Generic;
//재화의 총 생산량, 생산량의 증가, 감소.
//재화의 획득, 소비량 처리 
public class EconomyManager : MonoBehaviour
{
    public static EconomyManager instance { get; private set; } //인스턴스 선언
    
    private PlayerData playerData; //플레이어 데이터
    private FacilityData facilityData; //시설 데이터

    private float timer = 0f;
    private const float productionInterval = 1f; //생산 인터벌(1초)

    private void Awake() //인스턴스에 싱글톤 할당
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        Initialize();
    }
    public void Initialize() //데이터 초기화 및 저장되어있는 데이터 불러오기
    {
        playerData = DataManager.instance.playerData;
        //dataManager에서 로드해 온 playerData와 연결하기.
        //EconomyManager의 playerData = DataManager의 playerData를 참조 중. 즉 같은 메모리를 가리킴
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > productionInterval)
        {
            AutoProduce();
            //초마다 생산
            timer = 0f; //시간 초기화
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ProduceOnTap(); //터치마다 생산
        }
    }

    //탭당 생산
    private void ProduceOnTap()
    {
        playerData.gold += playerData.totalProductivity; //총 생산량 만큼 골드 획득
        UIManager.instance.UpdateGoldUI(playerData.gold);
        
    }

    //초당 자동 생산
    private void AutoProduce()
    {
        playerData.gold += playerData.totalProductivity;
        UIManager.instance.UpdateGoldUI(playerData.gold);

    }
}

