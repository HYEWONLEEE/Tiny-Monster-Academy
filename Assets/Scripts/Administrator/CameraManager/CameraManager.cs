using UnityEngine;
//ī�޶� ����, ����, ��ġ � ���� ��ũ��Ʈ
public class CameraManager : MonoBehaviour
{
    public float moveSpeed = 0.25f; //ī�޶� �̵� �ӵ�
    public float zoomSpeed = 0.1f; //ī�޶� �� �ӵ�
    public Transform cameraTransform;
    
    public Vector2 prePos, newPos;
    public Vector3 movePos;

    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        
    }
    void Update()
    {
        MoveCam();
        ZoomCam();
    }

    private void MoveCam() //�Ǳ� �Ǵµ� ���� �̻��� ...
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0); //��ġ
            if (touch.phase == TouchPhase.Began) //��ġ ���� ����
            {
                prePos = touch.position - touch.deltaPosition; //��ġ ���۽����� ��ǥ
            }
            else if (touch.phase == TouchPhase.Moved) //�̵��� ��
            {
                newPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - newPos) * moveSpeed * Time.deltaTime;
                cameraTransform.Translate(movePos);
                prePos = touch.position - touch.deltaPosition;
            }

            

        }
    }

    private void ZoomCam() //�� ���� �ɱ�, �ӵ� ����
    {
        if (Input.touchCount == 2)
        {

            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            //���� �������� ��ġ ������ 
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

            //���� �����ӿ��� ��ġ ��ġ ������ �Ÿ�
            //magnitude : ������ ũ�⸦ ��ȯ
            float prevDistance = (touch1PrevPos - touch2PrevPos).magnitude;
            //���� �����ӿ����� ��ġ ��ġ ������ �Ÿ�
            float currentDistance = (touch1.position - touch2.position).magnitude;

            //float zoomSize = (touch1.deltaPosition - touch2.deltaPosition).magnitude * zoomSpeed;

            //�� �����Ӹ����� �Ÿ��� ����
            float deltaMagnitudeDiff = prevDistance - currentDistance; //�����������ǰŸ� - �����������ǰŸ�
            //�������=������������ �� ����= Ȯ��
            if (Camera.main.orthographic)
            {
                Camera.main.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            }
         
        }
    }
}
