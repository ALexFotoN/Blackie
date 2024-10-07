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
        static bool _isFacingRight = true;
        Animator _animator;

        private void Awake()
        {
            _animator = _character.GetComponent<Animator>();
            _invoker = new CharacterInvoker(_character);
            _characterrb = _character.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            ReadMove();
            _animator.SetFloat("xVelocity", Math.Abs(_characterrb.velocity.x));
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