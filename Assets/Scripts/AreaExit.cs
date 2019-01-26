using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Access scene management, allows us to change scenes

public class AreaExit : MonoBehaviour
{

    public string areaToLoad, areaTransitionName;
    public AreaEntrance entrance;

    // Start is called before the first frame update
    void Start()
    {
        entrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if the object entering the Trigger is actually the player. We only want to switch scenes if the player is the one triggering the event.
        if(other.tag == "Player")
        {
            // Load into new scene
            SceneManager.LoadScene(areaToLoad);
            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
