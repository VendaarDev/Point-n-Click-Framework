using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
     [SerializeField] Actions[] actions;
     [SerializeField] float distancePosition = 1f;
     public Vector3 InteractPosition()
     {
          return transform.position + transform.forward * distancePosition;
     }

     public void Interact(PlayerScript player)
     {
          //Debug.Log("Clicked by player");

          StartCoroutine(WaitForPlayerArriving(player));
     }

     IEnumerator WaitForPlayerArriving(PlayerScript player)
     {
       while(!player.CheckIfArrived())
       {
            yield return null;
       }

       //Debug.Log("Player arrived");

       player.SetDirection(transform.position); //player faces object with the interactable component

       for (int i = 0; i < actions.Length; i++) {
            actions[i].Act();
       }

     }


}
