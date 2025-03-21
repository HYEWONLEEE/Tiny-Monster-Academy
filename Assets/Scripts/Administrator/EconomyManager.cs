using UnityEngine;
using System.IO;
using System.Collections.Generic;
//��ȭ�� �� ���귮, ���귮�� ����, ����.
//��ȭ�� ȹ��, �Һ� ó�� 
public class EconomyManager : MonoBehaviour
{
    public static EconomyManager instance { get; private set; } //�ν��Ͻ� ����
    
    private PlayerData playerData; //�÷��̾� ������
    private FacilityData facilityData; //�ü� ������

    private float timer = 0f;
    private const float productionInterval = 1f; //���� ���͹�(1��)

    private void Awake() //�ν��Ͻ��� �̱��� �Ҵ�
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        Initialize();
    }
    public void Initialize() //������ �ʱ�ȭ �� ����Ǿ��ִ� ������ �ҷ�����
    {
        playerData = DataManager.instance.playerData;
        //dataManager���� �ε��� �� playerData�� �����ϱ�.
        //EconomyManager�� playerData = DataManager�� playerData�� ���� ��. �� ���� �޸𸮸� ����Ŵ
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > productionInterval)
        {
            AutoProduce();
            //�ʸ��� ����
            timer = 0f; //�ð� �ʱ�ȭ
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ProduceOnTap(); //��ġ���� ����
        }
    }

    //�Ǵ� ����
    private void ProduceOnTap()
    {
        playerData.gold += playerData.totalProductivity; //�� ���귮 ��ŭ ��� ȹ��
        UIManager.instance.UpdateGoldUI(playerData.gold);
        
    }

    //�ʴ� �ڵ� ����
    private void AutoProduce()
    {
        playerData.gold += playerData.totalProductivity;
        UIManager.instance.UpdateGoldUI(playerData.gold);

    }
}

