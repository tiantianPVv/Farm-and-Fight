
using UnityEngine;

namespace EventSystem
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }

}
