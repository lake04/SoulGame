using UnityEngine;

public class PlayerMoveMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Rigidbody rb;
    private Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if(x != 0f || z != 0f)
        {
            animator.SetBool("isMove",true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
            transform.position += new Vector3(x, 0, z) * moveSpeed * Time.deltaTime;
    }
}
