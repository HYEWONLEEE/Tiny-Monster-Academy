using UnityEngine;
//업그레이드 관련 매니저
//생산량 증가 로직 
public class UpgradeManager : MonoBehaviour
{
    private PlayerData playerData; //playerData 참조
    private double growthRate = 1.2d; //성장률
    private double baseProductivity = 10d; //기본 생산량
    private double costIncreaseRate = 1.5d; //레벨업 비용 증가율
    private double baseCost = 100d; //기본 비용 
    private double upgradeCost;

    private void Start()
    {
        playerData = DataManager.instance.playerData;
        
        UIManager.instance.UpdateProductUI(playerData.totalProductivity);
        Debug.Log("생산량 : " + playerData.totalProductivity);
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
