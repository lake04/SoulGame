using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private float attackTime;
    [SerializeField]
    private float damage;
    private bool isAttack;
    private bool isAttacking;

    [SerializeField]
    private float combotTime = 0.2f;
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        player.animator.SetBool(PlayerAnimation.isMove, false);
        player.animator.SetTrigger(PlayerAnimation.attack);
        isAttacking = true;
        if (isAttacking)
        {
            float time =+Time.deltaTime;

            if(time <=combotTime)
            {
                if(Input.GetMouseButtonDown(0))
                {
                    Debug.Log("ÄÞº¸ °ø°Ý");
                    player.animator.SetTrigger(PlayerAnimation.attack2);
                }
            }
            else
            {
                isAttacking = false;
            }
        }
    }

    private void Combt()
    {

    }
}
