using UnityEngine;
using TMPro;
//UI를 관리하는 매니저 
public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    public TextMeshProUGUI goldText; //골드 표시 UI
    public TextMeshProUGUI rubyText; //루비 표시 UI
    public TextMeshProUGUI levelText; //레벨
    public TextMeshProUGUI nameText; //이름
    public TextMeshProUGUI productivityText; //생산량

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void UpdateGoldUI(double gold)
    {
        goldText.text = "골드 : " + CurrencyUnit.ToCurrencyString(gold);
    }

    public void UpdateRubyUI(double ruby)
    {
        rubyText.text = "루비 : " + CurrencyUnit.ToCurrencyString(ruby);
    }

    public void UpdateLevelUI(int level)
    {
        levelText.text = "LV : " + level.ToString();
    }

    public void UpdateNameUI(string name)
    {
        nameText.text = name;
    }

    public void UpdateProductUI(double productivity)
    {
        productivityText.text = "생산량 : " + CurrencyUnit.ToCurrencyString(productivity);
    }
}
