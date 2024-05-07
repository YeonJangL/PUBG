using UnityEngine;
using Cinemachine;

public class CameraController_EJ : MonoBehaviour
{
    public CinemachineVirtualCamera firstPersonCamera;
    public CinemachineVirtualCamera thirdPersonCamera;

    public CinemachineVirtualCamera aiming1Camera;
    public CinemachineVirtualCamera aiming3Camera;

    private CinemachineVirtualCamera currentCamera;

    private bool isFirstPersonActive;

    void Start()
    {
        firstPersonCamera.gameObject.SetActive(false);
        thirdPersonCamera.gameObject.SetActive(true);
        currentCamera = thirdPersonCamera;
        isFirstPersonActive = false;
    }

    void Update()
    {
        // V 키를 누르면 시점을 변경
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleCamera();
        }

        // 오른쪽 마우스 버튼을 누를 때 견착 시작
        if (Input.GetMouseButtonDown(1))
        {
            StartAiming();
        }

        // 오른쪽 마우스 버튼을 떼면 견착 종료
        if (Input.GetMouseButtonUp(1))
        {
            EndAiming();
        }
    }

    // 시점 변경 함수
    void ToggleCamera()
    {
        if (isFirstPersonActive)
        {
            SetCamera(thirdPersonCamera);
        }
        else
        {
            SetCamera(firstPersonCamera);
        }
        isFirstPersonActive = !isFirstPersonActive;
    }

    // 카메라 설정 함수
    void SetCamera(CinemachineVirtualCamera camera)
    {
        if (currentCamera != null)
        {
            currentCamera.gameObject.SetActive(false);
        }
        camera.gameObject.SetActive(true);
        currentCamera = camera;
    }

    // 견착 시작 함수
    void StartAiming()
    {
        if (isFirstPersonActive)
        {
            SetCamera(aiming1Camera);
        }
        else
        {
            SetCamera(aiming3Camera);
        }
    }

    // 견착 종료 함수
    void EndAiming()
    {
        // 오른쪽 마우스 버튼을 떼면 항상 현재 시점으로 복귀
        if (isFirstPersonActive)
        {
            SetCamera(firstPersonCamera);
        }
        else
        {
            SetCamera(thirdPersonCamera);
        }
    }
}
