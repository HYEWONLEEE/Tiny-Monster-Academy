using UnityEngine;
using System.Collections;
//�����͸� �����ϴ� �Ŵ���, �̱������� ����
public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; }
    public PlayerData playerData;
    private float saveInterval = 5f; //���� ����
    private float timer = 0f;
    private bool isSaving = false; //���� �� ����
    private bool isDataChanging = false; //������ ���� �� ����

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
        playerData = LoadData(); //playerData�� ������ �ε� 
   
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > saveInterval && !isSaving)
        {   
            if (isDataChanging)
            {
                //���� �̷��
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

        PlayerData copy = new PlayerData //���纻 ����
        {
            playerName = playerData.playerName,
            gold = playerData.gold,
            ruby = playerData.ruby,
            totalProductivity = playerData.totalProductivity,
            level = playerData.level,
            unlockedFacilities = playerData.unlockedFacilities

        };

        SaveSystem.SaveGameData(copy);
        
        Debug.Log("���� �Ϸ�");

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

    void OnApplicationQuit() //���� ���� �� ��� ���� 
    {
        SaveData();
        Debug.Log("���� ���� - ��� ����");
    }

    void OnApplicationPause(bool pause) //��׶��� ��ȯ �� ��� ����
    {
        if (pause)
        {
            SaveData();
            Debug.Log("��׶��� ��ȯ - ��� ����");
        }
    }

    public void SetDataChanging(bool isChanging)
    {
        isDataChanging = isChanging;
    }
}
