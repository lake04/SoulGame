using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [Header("# speed")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float oringSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private Transform cameraTransform; // 카메라 Transform 연결


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

        // 입력 방향
        Vector3 inputDir = new Vector3(x, 0, z).normalized;

        if (inputDir.magnitude >= 0.1f)
        {
            // 카메라 기준 방향 변환
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0f; // 수평으로만
            camRight.y = 0f;

            Vector3 moveDir = (camForward * z + camRight * x).normalized;

            // 이동
            transform.position += moveDir * moveSpeed * Time.deltaTime;

            // 부드러운 회전
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
