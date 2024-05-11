using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField]
    private List<Image> _healthbarslots;

    [SerializeField]
    private List<Image> _differenceslots;

    [SerializeField]
    private List<GameObject> _differencehitboxes;

    //Colors to be changed on Success/Fail
    [SerializeField]
    private Color CLR_losthealth, CLR_founddifference;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnFound, OnFound);
        EventManager.AddHandler(GameEvent.OnFail, OnFail);
        EventManager.AddHandler(GameEvent.OnHint, GetHint);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnFound, OnFound);
        EventManager.RemoveHandler(GameEvent.OnFail, OnFail);
        EventManager.RemoveHandler(GameEvent.OnHint, GetHint);
    }

    //Drop health by 1, restart on 0 health
    void OnFail()
    {
        if (_healthbarslots.Count == 0)
        {
            //TODO: Lose Con, Restart
        }

        _healthbarslots[0].color = CLR_losthealth;
        _healthbarslots.RemoveAt(0);
    }

    //Increase found differences by 1, push you win screen on win 
    void OnFound()
    {
        if (_differenceslots.Count == 1)
        {
            //TODO: Win Con
        }
        _differenceslots[0].color = CLR_founddifference;
        _differenceslots.RemoveAt(0);
    }

    //Get hint on button press
    void GetHint()
    {
        //TODO: Highlight hitboxes around the clue in the hitbox list
    }

    //remove the found difference's hitbox so raycast can't detect
    public void RemoveFoundDifference(GameObject removed)
    {
        GameObject parentofremove = removed.transform.parent.gameObject;
        
        int index = _differencehitboxes.IndexOf(parentofremove);

        _differencehitboxes.RemoveAt(index);

        parentofremove.SetActive(false);
    }
}

