using UnityEngine;


//게임 매니저 스크립트
public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; } //싱글톤 할당할 전역변수 프로퍼티
    

    private void Awake() //게임 매니저 오브젝트 할당
    {
        if (instance == null)
        {
            instance = this;
            
        }
         
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
