using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header ("Attack Prameter")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header ("Attack Prameter")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

    [Header ("Collider Prameter")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    [Header("Fireball Sound")]
    [SerializeField] private AudioClip fireballSound;
   
   
    private float cooldownTimer= Mathf.Infinity;
    private Animator anim;
    private EnemyPatrol enemyPatrol;
     private Health playerHealth;


    private void Awake(){
        anim= GetComponent<Animator>();
        enemyPatrol= GetComponentInParent<EnemyPatrol>();
    }

    private void Update(){
        cooldownTimer += Time.deltaTime;
        if(PlayerInSight()){
            if (cooldownTimer>= attackCooldown && playerHealth.currentHealth >0){
                cooldownTimer= 0;
                anim.SetTrigger("rangeAttack");
            }
        }
        if(enemyPatrol !=null)
            enemyPatrol.enabled= !PlayerInSight();
    }

    private void RangedAttack(){

        SoundManager.instance.PlaySound(fireballSound);
        cooldownTimer= 0;
        fireballs[FindFireball()].transform.position= firepoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball(){
        for (int i=0; i< fireballs.Length; i++){
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private bool PlayerInSight(){
        RaycastHit2D hit= Physics2D.BoxCast(boxCollider.bounds.center + transform.right *range* transform.localScale.x * colliderDistance,
        new Vector3( boxCollider.bounds.size.x *range,boxCollider.bounds.size.y, boxCollider.bounds.size.z),
         0,Vector2.left,0, playerLayer);

          if (hit.collider != null)
            playerHealth= hit.transform.GetComponent<Health>();

        return hit.collider !=null;
    }

    private void OnDrawGizmos(){
        Gizmos.color= Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right *range * transform.localScale.x * colliderDistance,
         new Vector3( boxCollider.bounds.size.x *range,boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer(){
        if(PlayerInSight()){
            playerHealth.TakeDamage(damage);
        }

    }
}
