using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;
//이름 입력창, 이름 표시에 관한 클래스 

public class NameInputUI : MonoBehaviour
{
    public GameObject nameInputWindow; //이름 입력 창
    public GameObject confirmWindow; //확인 질문 창
    public Button inputbutton; //입력 완료 버튼
    public Button confirmButton; //확인 질문 버튼
    public Button cancelButton; //취소 버튼
    public TMP_InputField nameInput; //입력된 이름
    public TextMeshProUGUI confirmText; //확인 질문
    public TextMeshProUGUI nameDisplay; //표시될 닉네임
    private PlayerData playerData;
    private string currentName;

  
    private void Start()
    {
        playerData = DataManager.instance.playerData;
        
        currentName = playerData.playerName; //데이터에 저장된 이름 가져오기
        Debug.Log("현재 이름 :" + currentName);
        if (string.IsNullOrEmpty(currentName)) //현재 이름이 널이거나 공백이면
        {
            OpenNameInputWindow(); //입력 창 표시
        }
        else
        {
            nameDisplay.text = currentName; //아니면 현재 이름을 UI에 표시 
        }
        
    }
    public void ConfirmName()
    {
        string input = nameInput.text.Trim(); //앞뒤 공백 잘라주기
        if (IsValidName(input))
        {
            confirmText.text = $"\"{input}\" 이 이름이 맞나요?";
            confirmWindow.SetActive(true);
        }
        //else
    }

    public void OpenNameInputWindow() //이름 입력 창 활성화
    {
        nameInputWindow.SetActive(true);
    }

    public void CancelConfrimWindow() //확인 창 비활성화
    {
        confirmWindow.SetActive(false); 
    }

    private bool IsValidName(string input)//닉네임 유효성 검사 함수
    {
        return Regex.IsMatch(input,"^[a-zA-Z0-9가-힣]{1,8}$");
    }

    public void ApplyName()
    {
        currentName = nameInput.text.Trim();
        playerData.playerName = currentName; //이름 바꾼 것 적용해주기
        DataManager.instance.SaveData(); //저장도 해
        nameDisplay.text = currentName; //바꾼 이름 UI에 표시도 해주기
        nameInputWindow.SetActive(false); 
        confirmWindow.SetActive(false); //창들 비활성화 
    }
}
