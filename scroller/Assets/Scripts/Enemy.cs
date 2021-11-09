using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    PlayerSoundController soundController;

    // Start is called before the first frame update
    protected void Awake()
    {
        moveDirection = new Vector2(-1,0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        soundController = GetComponent<PlayerSoundController>();

    }
    // Update is called once per frame
    protected virtual void Update()
    {
        MovementUpdate();
    }

    protected virtual void MovementUpdate()
    {
        Vector2 _currentPosition;
        Vector2 _newDirection;

        _newDirection = (moveDirection * movementSpeed) * Time.deltaTime;

        _currentPosition = PixelPerfectClamp(transform.position, 16);
        _newDirection = SubPixelMovment(_newDirection, 16);

        Rect tempBounds = GameManager.staticGameManager.PlayerMovementBounds;
        Vector2 newPosition = _currentPosition + _newDirection;
        if (newPosition.x > tempBounds.xMin && newPosition.y > tempBounds.yMin && newPosition.x < tempBounds.xMax && newPosition.y < tempBounds.yMax)
        {
            if (!CheckHit())
            {
                transform.position = newPosition;
            }
            else
            {
                Death();
            }
        }
        else
        {
            Death();
        }

    }

    public override void TakeDamage(int _sentDamage)
    {
        soundController.PlaySound(SoundStates.Hurt);
        base.TakeDamage(_sentDamage);
    }
    public virtual void Death()
    {
        Destroy(gameObject);
    }
}
