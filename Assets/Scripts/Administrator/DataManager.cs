using UnityEngine;
using System.Collections;
//데이터를 저장하는 매니저, 싱글톤으로 구현
public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; }
    public PlayerData playerData;
    private float saveInterval = 5f; //저장 간격
    private float timer = 0f;
    private bool isSaving = false; //저장 중 여부
    private bool isDataChanging = false; //데이터 변경 중 여부

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        playerData = LoadData(); //playerData에 데이터 로드 
   
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > saveInterval && !isSaving)
        {   
            if (isDataChanging)
            {
                //저장 미루기
            }

            else
            {
                StartCoroutine(SaveDataCoroutine());
                timer = 0f;
            }

        }

    }

    IEnumerator SaveDataCoroutine() 
    {
        isSaving = true;

        PlayerData copy = new PlayerData //복사본 생성
        {
            playerName = playerData.playerName,
            gold = playerData.gold,
            ruby = playerData.ruby,
            totalProductivity = playerData.totalProductivity,
            level = playerData.level,
            unlockedFacilities = playerData.unlockedFacilities

        };

        SaveSystem.SaveGameData(copy);
        
        Debug.Log("저장 완료");

        yield return null;
        isSaving = false;
    }

    public void SaveData()
    {
        StartCoroutine(SaveDataCoroutine());
    }

    public PlayerData LoadData()
    {
        return SaveSystem.LoadGameData();
    }

    void OnApplicationQuit() //게임 종료 시 즉시 저장 
    {
        SaveData();
        Debug.Log("게임 종료 - 즉시 저장");
    }

    void OnApplicationPause(bool pause) //백그라운드 전환 시 즉시 저장
    {
        if (pause)
        {
            SaveData();
            Debug.Log("백그라운드 전환 - 즉시 저장");
        }
    }

    public void SetDataChanging(bool isChanging)
    {
        isDataChanging = isChanging;
    }
}
