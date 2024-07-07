using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerjump : MonoBehaviour
{
    private Rigidbody2D body;

    /*[Header("SFX")]
    [SerializeField] private Object player;*/

    [Header("obj_1_tojump")]
    [SerializeField] public object player ;

    // Start is called before the first frame update
    void Start()
    {
       object player = GetComponent<playerMovement>();
       body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void player_jump()
    {
        body.MovePosition(Vector2.up);
    }
}
