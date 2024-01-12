using System;

using UnityEngine;

namespace BlueGravity.Common.Interaction
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class InteractionArea : MonoBehaviour
    {
        #region ACTIONS
        public event Action<GameObject> OnTriggerEnter = null;
        public event Action<GameObject> OnTriggerExit = null;
        #endregion

        #region UNITY_CALLS
        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTriggerEnter?.Invoke(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            OnTriggerExit?.Invoke(collision.gameObject);
        }
        #endregion
    }
}