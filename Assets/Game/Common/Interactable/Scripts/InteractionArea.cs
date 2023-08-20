using System;

using UnityEngine;

namespace BlueGravity.Common.Interaction
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class InteractionArea : MonoBehaviour
    {
        private Action<GameObject> OnTriggerEnter = null;
        private Action<GameObject> OnTriggerExit = null;

        public void Init(Action<GameObject> onTriggerEnter, Action<GameObject> onTriggerExit)
        {
            OnTriggerEnter = onTriggerEnter;
            OnTriggerExit = onTriggerExit;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTriggerEnter?.Invoke(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            OnTriggerExit?.Invoke(collision.gameObject);
        }
    }
}