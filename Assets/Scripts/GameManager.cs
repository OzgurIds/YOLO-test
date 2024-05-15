using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Color CLR_losthealth, CLR_founddifference, CLR_hint, CLR_hitbox;

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
            //reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        _healthbarslots[0].color = CLR_losthealth;
        _healthbarslots.RemoveAt(0);
    }

    //Increase found differences by 1, push you win screen on win 
    void OnFound()
    {
        if (_differenceslots.Count == 1)
        {
            //reload scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        _differenceslots[0].color = CLR_founddifference;
        _differenceslots.RemoveAt(0);
    }

    public void HighlightFoundClue(Transform hitboxparent)
    {
        SpriteRenderer _renderertop = hitboxparent.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer _rendererbottom = hitboxparent.GetChild(1).GetComponent<SpriteRenderer>();

        _renderertop.color = CLR_hitbox;
        _rendererbottom.color = CLR_hitbox;

        _differencehitboxes.Remove(hitboxparent.gameObject);


    }

    //Get hint on button press
    void GetHint()
    {
        GameObject hint = _differencehitboxes[0];

        SpriteRenderer top = hint.transform.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer bottom = hint.transform.GetChild(1).GetComponent<SpriteRenderer>();

        top.color = CLR_hint;
        bottom.color = CLR_hint;
    }
}

