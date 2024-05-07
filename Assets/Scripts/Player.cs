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
        // �̵� �Է� ����
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        // ���콺 X �࿡ ���� �÷��̾� ȸ��
        rotationY += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        rotationY %= 360f; // ȸ�� ������ 0�� 360�� ���̷� ����

        // ������ ����Ͽ� �ε巯�� ȸ�� ����
        Quaternion targetRotation = Quaternion.Euler(0f, rotationY, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothRotation * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // �÷��̾� �̵� ���� ���
        moveDirection = (transform.forward * moveY + transform.right * moveX).normalized;

        // �ε巯�� �̵��� ���� ������ ����Ͽ� �̵�
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }
}
