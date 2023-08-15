using UnityEngine;

namespace BlueGravity.Common.Controller
{
    public abstract class SceneController : MonoBehaviour
    {
        protected abstract void Awake();
        protected abstract void OnEnable();
        protected abstract void OnDisable();
    }
}