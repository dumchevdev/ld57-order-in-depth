﻿using UnityEngine;

namespace Game.Runtime.Gameplay.Character
{
    public class SpriteFlipper : MonoBehaviour
    {
        public float flipThreshold = 0.1f;
        [SerializeField] private bool isFacingRight = true;
    
        private SpriteRenderer spriteRenderer;
        private float lastXPosition;
        
        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            lastXPosition = transform.parent.position.x;
        }
        
        void Update()
        {
            float direction = 0f;
        
            direction = transform.parent.position.x - lastXPosition;
            lastXPosition = transform.parent.position.x;

            if (Mathf.Abs(direction) > flipThreshold)
            {
                bool shouldFaceRight = direction > 0;
                if (shouldFaceRight != isFacingRight)
                    FlipSprite(shouldFaceRight);
            }
        }

        private void FlipSprite(bool faceRight)
        {
            isFacingRight = faceRight;
            spriteRenderer.flipX = !faceRight;
            // Альтернативный вариант, если flipX не работает как ожидается:
        }

        public void ForceFlip(bool faceRight)
        {
            FlipSprite(faceRight);
        }
    }
}