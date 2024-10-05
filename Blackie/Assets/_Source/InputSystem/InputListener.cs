using CharacterSystem;
using System;
using UnityEngine;


namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] Character _character;
        [SerializeField] Rigidbody2D _characterrb;
        CharacterInvoker _invoker;
        float Horizontal;
        float Vertical;
        bool _isFacingRight = true;

        private void Awake()
        {
            _invoker = new CharacterInvoker(_character);
            _characterrb = _character.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            ReadMove();
        }

        private void ReadMove()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
            Vector2 moveDir = new Vector2(Horizontal, Vertical);
            FlipSprite();
            _invoker.Move(moveDir);
        }

        private void FlipSprite()
        {
            if (_isFacingRight && Horizontal < 0f || !_isFacingRight && Horizontal > 0f)
            {
                _isFacingRight = !_isFacingRight;
                Vector3 ls = _character.transform.localScale;
                ls.x *= -1f;
                _character.transform.localScale = ls;
            }
        }
    }
}