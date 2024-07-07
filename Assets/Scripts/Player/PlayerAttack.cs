using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSond;
    private Animator anim;
    private playerMovement playerMove;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake(){
        anim= GetComponent<Animator>();
        playerMove= GetComponent<playerMovement>();
    }

    private void Update(){
        if(Input.GetMouseButton(1) && cooldownTimer > attackCooldown && playerMove.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    public void Attack(){
        SoundManager.instance.PlaySound(fireballSond);
        anim.SetTrigger("attack");
        cooldownTimer =0; 

       fireballs[FindFireball()].transform.position= firePoint.position;
       fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball(){
        for( int i=0; i< fireballs.Length; i++){
            if( !fireballs[i].activeInHierarchy)
                  return i;
        }
        return 0;
    }
}