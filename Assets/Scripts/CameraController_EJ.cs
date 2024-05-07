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
        // V Ű�� ������ ������ ����
        if (Input.GetKeyDown(KeyCode.V))
        {
            ToggleCamera();
        }

        // ������ ���콺 ��ư�� ���� �� ���� ����
        if (Input.GetMouseButtonDown(1))
        {
            StartAiming();
        }

        // ������ ���콺 ��ư�� ���� ���� ����
        if (Input.GetMouseButtonUp(1))
        {
            EndAiming();
        }
    }

    // ���� ���� �Լ�
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

    // ī�޶� ���� �Լ�
    void SetCamera(CinemachineVirtualCamera camera)
    {
        if (currentCamera != null)
        {
            currentCamera.gameObject.SetActive(false);
        }
        camera.gameObject.SetActive(true);
        currentCamera = camera;
    }

    // ���� ���� �Լ�
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

    // ���� ���� �Լ�
    void EndAiming()
    {
        // ������ ���콺 ��ư�� ���� �׻� ���� �������� ����
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
