using UnityEngine;


//���� �Ŵ��� ��ũ��Ʈ
public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; } //�̱��� �Ҵ��� �������� ������Ƽ
    

    private void Awake() //���� �Ŵ��� ������Ʈ �Ҵ�
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
