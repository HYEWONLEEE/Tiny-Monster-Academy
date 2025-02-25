using UnityEngine;
//카메라 조작, 설정, 터치 등에 관한 스크립트
public class CameraManager : MonoBehaviour
{
    public float moveSpeed = 0.25f; //카메라 이동 속도
    public float zoomSpeed = 0.1f; //카메라 줌 속도
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

    private void MoveCam() //되긴 되는데 뭔가 이상함 ...
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0); //터치
            if (touch.phase == TouchPhase.Began) //터치 시작 시점
            {
                prePos = touch.position - touch.deltaPosition; //터치 시작시점의 좌표
            }
            else if (touch.phase == TouchPhase.Moved) //이동할 때
            {
                newPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - newPos) * moveSpeed * Time.deltaTime;
                cameraTransform.Translate(movePos);
                prePos = touch.position - touch.deltaPosition;
            }

            

        }
    }

    private void ZoomCam() //줌 제한 걸기, 속도 조절
    {
        if (Input.touchCount == 2)
        {

            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            //이전 프레임의 터치 포지션 
            Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
            Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;

            //이전 프레임에서 터치 위치 사이의 거리
            //magnitude : 벡터의 크기를 반환
            float prevDistance = (touch1PrevPos - touch2PrevPos).magnitude;
            //현재 프레임에서의 터치 위치 사이의 거리
            float currentDistance = (touch1.position - touch2.position).magnitude;

            //float zoomSize = (touch1.deltaPosition - touch2.deltaPosition).magnitude * zoomSpeed;

            //각 프레임마다의 거리의 차이
            float deltaMagnitudeDiff = prevDistance - currentDistance; //이전프레임의거리 - 현재프레임의거리
            //음수라면=이전프레임이 더 작음= 확대
            if (Camera.main.orthographic)
            {
                Camera.main.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            }
         
        }
    }
}
