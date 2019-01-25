using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public Animator myAnim;
    // Used to ensure we don't have duplicate players on scene changes.
    public static PlayerController instance;
    public float moveSpeed;
    public string areaTransitionName;

    // Start is called before the first frame update
    void Start()
    {
        // instance is null the first time, if so we establish this static PlayerController is the instance, otherwise we destroy the gameObject(Player).
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        // When we load a new scene, don't destroy what is passed through DDoL. gameObject by default is whatever this script is attached to. PlayerController is attached to Player,
        // so this will keep player alive through scenes.
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Sets velocity to x,y value - set x and y value to user input(Input.GetAxisRaw) in order to move. Use moveSpeed to increase/decrease movement of player.
        rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        myAnim.SetFloat("moveX", rigidBody.velocity.x);
        myAnim.SetFloat("moveY", rigidBody.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
