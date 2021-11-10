using System.Collections.Generic;
using System;
using UnityEngine;

namespace BallShooter
{
    internal sealed class ObjectPool
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;

        public ObjectPool(GameObject prefab)
        {
            _prefab = prefab;
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.SetActive(false);
        }

        public GameObject Pop()
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = GameObject.Instantiate(_prefab);
            }
            else
            {
                go = _stack.Pop();
            }
            go.SetActive(true);
            return go;
        }
    }
}

