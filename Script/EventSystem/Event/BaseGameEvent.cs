
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{

    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>();

        public void Raise(T item)
        {
            //因为如果有的监听器执行了销毁，顺着（0->）就会导致索引号出错，无法遍历每个监听器
            //所以倒序遍历（ eventListeners.count - 1->），可以保证每个都被遍历
            for (int i = eventListeners.Count - 1; i >= 0; i--)
            {
                eventListeners[i].OnEventRaised(item);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            if(!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }
        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}

