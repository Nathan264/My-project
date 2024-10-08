using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        Turn();
        OnRun();
    }


    #region Movement

    private void OnMove() {
        if (player.direction.sqrMagnitude > 0) {
            if (player.isRolling) {
                anim.SetTrigger("roll");
            }
            else {
                anim.SetInteger("transition", 1);
            }
        } 
        else {
            anim.SetInteger("transition", 0);
        } 
    }

    private void OnRun() {
        if (player.isRunning) {
            anim.SetInteger("transition", 2);
        }
    }
    
    private void Turn() {
        if (player.direction.x > 0) {
            player.transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0) {
            player.transform.eulerAngles = new Vector2(0, 180);
        }
    }

    #endregion
}
