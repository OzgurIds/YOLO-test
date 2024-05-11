using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
   public void OnClick()
    {
        EventManager.BroadCast(GameEvent.OnHint);
    }
}
