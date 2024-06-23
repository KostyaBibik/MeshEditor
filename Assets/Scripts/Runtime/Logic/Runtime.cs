using System;
using System.Collections.Generic;
using Runtime.Enums;
using UnityEngine;

namespace Runtime.Logic
{
    public class Runtime : MonoBehaviour
    {
        private Dictionary<EShapeParameter, Delegate> eventHandlers;
        
        private void Start()
        {
            eventHandlers = new Dictionary<EShapeParameter, Delegate>
            {
                { EShapeParameter.Length, (Action<float>)null },
                { EShapeParameter.Width, (Action<float>)null },
                { EShapeParameter.Height, (Action<float>)null },
                { EShapeParameter.Radius, (Action<float>)null },
                { EShapeParameter.SideCount, (Action<int>)null },
                { EShapeParameter.Color, (Action<Color>)null }
            };
        }
        
        public void RegisterHandler<T>(EShapeParameter parameter, Action<T> handler)
        {
            if (eventHandlers.ContainsKey(parameter))
            {
                eventHandlers[parameter] = (Action<T>)eventHandlers[parameter] + handler;
            }
            else
            {
                eventHandlers[parameter] = handler;
            }
        }

        public void UnregisterHandler<T>(EShapeParameter parameter, Action<T> handler)
        {
            if (eventHandlers.ContainsKey(parameter))
            {
                eventHandlers[parameter] = (Action<T>)eventHandlers[parameter] - handler;
            }
        }

        public void TriggerEvent<T>(EShapeParameter parameter, T value)
        {
            if (eventHandlers.ContainsKey(parameter))
            {
                ((Action<T>)eventHandlers[parameter])?.Invoke(value);
            }
        }
    }
}