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

    public void HighlightFoundClue(SpriteRenderer _renderertop, SpriteRenderer _rendererbottom)
    {
        _renderertop.color = new Color (_renderertop.color.r, _renderertop.color.g, _renderertop.color.b, (150f/255f));
        _rendererbottom.color = new Color (_rendererbottom.color.r, _rendererbottom.color.g, _rendererbottom.color.b, (150f/255f));
    }

    //Get hint on button press
    void GetHint()
    {
        //TODO: Highlight hitboxes around the clue in the hitbox list
    }
}

