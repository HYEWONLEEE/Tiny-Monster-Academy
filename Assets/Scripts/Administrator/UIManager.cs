using UnityEngine;
using TMPro;
//UI�� �����ϴ� �Ŵ��� 
public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    public TextMeshProUGUI goldText; //��� ǥ�� UI
    public TextMeshProUGUI rubyText; //��� ǥ�� UI
    public TextMeshProUGUI levelText; //����
    public TextMeshProUGUI nameText; //�̸�
    public TextMeshProUGUI productivityText; //���귮

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
        goldText.text = "��� : " + CurrencyUnit.ToCurrencyString(gold);
    }

    public void UpdateRubyUI(double ruby)
    {
        rubyText.text = "��� : " + CurrencyUnit.ToCurrencyString(ruby);
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
        productivityText.text = "���귮 : " + CurrencyUnit.ToCurrencyString(productivity);
    }
}
