using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;
//�̸� �Է�â, �̸� ǥ�ÿ� ���� Ŭ���� 

public class NameInputUI : MonoBehaviour
{
    public GameObject nameInputWindow; //�̸� �Է� â
    public GameObject confirmWindow; //Ȯ�� ���� â
    public Button inputbutton; //�Է� �Ϸ� ��ư
    public Button confirmButton; //Ȯ�� ���� ��ư
    public Button cancelButton; //��� ��ư
    public TMP_InputField nameInput; //�Էµ� �̸�
    public TextMeshProUGUI confirmText; //Ȯ�� ����
    public TextMeshProUGUI nameDisplay; //ǥ�õ� �г���
    private PlayerData playerData;
    private string currentName;

  
    private void Start()
    {
        playerData = DataManager.instance.playerData;
        
        currentName = playerData.playerName; //�����Ϳ� ����� �̸� ��������
        Debug.Log("���� �̸� :" + currentName);
        if (string.IsNullOrEmpty(currentName)) //���� �̸��� ���̰ų� �����̸�
        {
            OpenNameInputWindow(); //�Է� â ǥ��
        }
        else
        {
            nameDisplay.text = currentName; //�ƴϸ� ���� �̸��� UI�� ǥ�� 
        }
        
    }
    public void ConfirmName()
    {
        string input = nameInput.text.Trim(); //�յ� ���� �߶��ֱ�
        if (IsValidName(input))
        {
            confirmText.text = $"\"{input}\" �� �̸��� �³���?";
            confirmWindow.SetActive(true);
        }
        //else
    }

    public void OpenNameInputWindow() //�̸� �Է� â Ȱ��ȭ
    {
        nameInputWindow.SetActive(true);
    }

    public void CancelConfrimWindow() //Ȯ�� â ��Ȱ��ȭ
    {
        confirmWindow.SetActive(false); 
    }

    private bool IsValidName(string input)//�г��� ��ȿ�� �˻� �Լ�
    {
        return Regex.IsMatch(input,"^[a-zA-Z0-9��-�R]{1,8}$");
    }

    public void ApplyName()
    {
        currentName = nameInput.text.Trim();
        playerData.playerName = currentName; //�̸� �ٲ� �� �������ֱ�
        DataManager.instance.SaveData(); //���嵵 ��
        nameDisplay.text = currentName; //�ٲ� �̸� UI�� ǥ�õ� ���ֱ�
        nameInputWindow.SetActive(false); 
        confirmWindow.SetActive(false); //â�� ��Ȱ��ȭ 
    }
}
