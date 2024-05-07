using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float smoothRotation = 5f;

    [SerializeField]
    private Rigidbody rb;
    private float moveX;
    private float moveY;
    private float rotationY;
    private Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        // 이동 입력 수집
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        // 마우스 X 축에 따른 플레이어 회전
        rotationY += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        rotationY %= 360f; // 회전 각도를 0과 360도 사이로 유지

        // 보간을 사용하여 부드러운 회전 적용
        Quaternion targetRotation = Quaternion.Euler(0f, rotationY, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothRotation * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // 플레이어 이동 방향 계산
        moveDirection = (transform.forward * moveY + transform.right * moveX).normalized;

        // 부드러운 이동을 위해 보간을 사용하여 이동
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }
}
