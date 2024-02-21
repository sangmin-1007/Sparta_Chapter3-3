using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    protected SpriteRenderer _spriteRenderer;
    protected Animator _animator;

    public void CallMoveEvent(Vector2 dir)
    {
        Debug.Log(dir);
        OnMoveEvent?.Invoke(dir);
    }

    public void CallLookEvent(Vector2 dir)
    {
        if(dir.x <= 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }

        OnLookEvent?.Invoke(dir);
    }


}
