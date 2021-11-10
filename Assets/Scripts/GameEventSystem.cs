using System;
using UnityEngine;

namespace BallShooter
{
    public sealed class GameEventSystem : MonoBehaviour
    {
        public static GameEventSystem current;

        void Awake()
        {
            current = this;
        }

        public event Action onGUIUpdate;
        public void GUIUpdate()
        {
            if (onGUIUpdate != null)
            {
                onGUIUpdate();
            }
        }
    }
}
