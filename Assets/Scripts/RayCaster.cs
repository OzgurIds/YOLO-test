using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, Mathf.Infinity);

            // Check if the ray hit something
            if (hit.collider != null)
            {
                //Get the data of hit collider
                GameObject hitobject = hit.collider.gameObject;

                Debug.Log("Hit object: " + hitobject.name);

                GameManager.Instance.RemoveFoundDifference(hitobject);

                //Let game manager know player found a diff
                EventManager.BroadCast(GameEvent.OnFound);
            }
            else 
            {
                //Let game manager know player failed
                EventManager.BroadCast(GameEvent.OnFail);
            }
        }
    }
}