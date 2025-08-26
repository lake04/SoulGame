using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [Header("# speed")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float oringSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private Transform cameraTransform; // ī�޶� Transform ����


    [SerializeField] private float runSpeed = 10f;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        Move();
        Run();
    }

    private void Run()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else{
            moveSpeed = oringSpeed;
        }
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // �Է� ����
        Vector3 inputDir = new Vector3(x, 0, z).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            // ī�޶� ���� ���� ��ȯ
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f; // �������θ�
            camRight.y = 0f;

            Vector3 moveDir = (camForward * z + camRight * x).normalized;

            // �̵�
            transform.position += moveDir * moveSpeed * Time.deltaTime;

            // �ε巯�� ȸ��
            Quaternion targetRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            player.animator.SetBool(PlayerAnimation.isMove, true);
        }
        else
        {
            player.animator.SetBool(PlayerAnimation.isMove, false);
        }
    }
}
