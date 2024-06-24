using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GlobalState
{
    public class StateContainerHolder
    {
        public State PreviousState;
        public State CurrentState;
    }
    
    public class StateContextableCallback
    {
        public int Order;
        public MonoBehaviour Context;
        public Action Callback;
    }
    
    public class StateInfoWrapper
    {
        public List<StateContainerHolder> States { get; }
        public List<StateContextableCallback> Callbacks { get; }

        public StateInfoWrapper()
        {
            States = new List<StateContainerHolder>();
            Callbacks = new List<StateContextableCallback>();
        }

        public override string ToString()
        {
            if (States == null)
            {
                return String.Empty;
            }

            var typeName = States.GetType().Name;
            var listnersNumber = Callbacks.Count();
            
            return $"State type: {typeName} \n State listners count {listnersNumber}";
        }
    }
}