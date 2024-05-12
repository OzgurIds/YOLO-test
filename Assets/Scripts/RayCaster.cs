using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RayCaster : MonoBehaviour
{
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Vector2 rayOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, Mathf.Infinity);

            try
            {
                // Check if the ray hit something
                if (hit.collider.tag == "NotFound")
                {
                    //Get the data of hit collider
                    GameObject hitobject = hit.collider.gameObject;

                    Debug.Log("Hit object: " + hitobject.name);
                    
                    //parent of the both colliders in both pictures
                    Transform parent = hit.collider.transform.parent;

                    SpriteRenderer top = parent.GetChild(0).GetComponent<SpriteRenderer>();
                    SpriteRenderer bottom = parent.GetChild(1).GetComponent<SpriteRenderer>();


                    GameManager.Instance.HighlightFoundClue(top, bottom);
                    //Let game manager know player found a diff
                    EventManager.BroadCast(GameEvent.OnFound);

                    parent.GetChild(0).tag = "Found";
                    parent.GetChild(1).tag = "Found";
                }
                else if (hit.collider.tag == "GameBackground")
                {
                    //Let game manager know player failed
                    Debug.Log("Fail");
                    EventManager.BroadCast(GameEvent.OnFail);
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }

        }
    }
}