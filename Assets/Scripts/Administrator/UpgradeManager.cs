using UnityEngine;
//���׷��̵� ���� �Ŵ���
//���귮 ���� ���� 
public class UpgradeManager : MonoBehaviour
{
    private PlayerData playerData; //playerData ����
    private double growthRate = 1.2d; //�����
    private double baseProductivity = 10d; //�⺻ ���귮
    private double costIncreaseRate = 1.5d; //������ ��� ������
    private double baseCost = 100d; //�⺻ ��� 
    private double upgradeCost;

    private void Start()
    {
        playerData = DataManager.instance.playerData;
        
        UIManager.instance.UpdateProductUI(playerData.totalProductivity);
        Debug.Log("���귮 : " + playerData.totalProductivity);
    }
    public void Upgrade()
    {
        if (playerData != null)
        {
            playerData.level += 1;
            playerData.totalProductivity = GetNewProductivity();
            upgradeCost = GetNewCost();

            UIManager.instance.UpdateProductUI(playerData.totalProductivity);
        }
    }
    public double GetNewProductivity()
    {
        return baseProductivity * Mathf.Pow((float)growthRate, playerData.level);
    }

    public double GetNewCost()
    {
        return baseCost * Mathf.Pow((float)costIncreaseRate, playerData.level);
    }
}
