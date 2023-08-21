
using System.Collections.Generic;
using UnityEngine;

namespace EventSystem
{

    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>();

        public void Raise(T item)
        {
            //��Ϊ����еļ�����ִ�������٣�˳�ţ�0->���ͻᵼ�������ų����޷�����ÿ��������
            //���Ե�������� eventListeners.count - 1->�������Ա�֤ÿ����������
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

