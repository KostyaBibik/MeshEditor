using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GlobalState
{
    public partial class StateManager : StaticInstanceBehaviour<StateManager>
    {
        private State _changeContext;
        private Dictionary<Type, StateInfoWrapper> _wrappers = new();

        public T GetState<T>(int id = 0) where T : State
        {
            if (_wrappers.TryGetValue(typeof(T), out var wrapper))
            {
                var states = wrapper.States.Select(x => x.CurrentState)
                    .Where(x => x.GetStateHashCode() == id)
                    .ToArray();

                if (states.Length > 1)
                {
                    throw new Exception($"Id:{id} StateType:{typeof(T).FullName}. Found {states.Length} !!!");
                }

                return (T)states.FirstOrDefault()?.Copy();
            }

            return null;
        }

        public T[] GetStates<T>() where T : State
        {
            if (_wrappers.TryGetValue(typeof(T), out var wrapper))
            {
                return wrapper.States.Select(x => x.CurrentState?.Copy())
                    .Cast<T>()
                    .ToArray();
            }

            return null;
        }

        public void SetState(State state)
        {
            if (state == null)
            {
                return;
            }

            var wrapper = AddWrapperIfNotAdded(state.GetType());
            var index = wrapper.States.FindIndex(x => 
                x.CurrentState.GetStateHashCode() == state.GetStateHashCode());

            if (index < 0)
            {
                var container = new StateContainerHolder
                {
                    CurrentState = state.Copy(), 
                    PreviousState = state.Copy()
                };
                
                wrapper.States.Add(container);
            }
            else
            {
                var previousState = wrapper.States[index].CurrentState;
                wrapper.States[index].PreviousState = previousState.Copy();
                wrapper.States[index].CurrentState = state.Copy();
            }

            wrapper.Callbacks.RemoveAll(x => x.Context == null);
            var tempCallbackCollection = wrapper.Callbacks
                .OrderBy(x => x.Order)
                .ToList();

            _changeContext = state;
            tempCallbackCollection.ForEach(x => x.Callback.Invoke());
            _changeContext = null;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var debugWrapper in _wrappers)
            {
                stringBuilder.AppendLine($"<b>{debugWrapper.Key.FullName}</b>");
                stringBuilder.AppendLine($"Callbacks count: {debugWrapper.Value.Callbacks.Count}");
                stringBuilder.AppendLine($"States count: {debugWrapper.Value.States.Count}");
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }

        private void TrackStateChangingInternal<TState>(Action<TState, TState> stateChangeCallback,
            MonoBehaviour context,
            int executionOrder,
            bool invoke)
            where TState : State
        {
            if (stateChangeCallback == null)
            {
                throw new InvalidOperationException("Попытка регистрации пустой реакции");
            }

            if (context == null)
            {
                context = this;
            }

            var wrapper = AddWrapperIfNotAdded(typeof(TState));
            var contextableCallback = new StateContextableCallback
            {
                Order = executionOrder,
                Context = context,
                Callback = () =>
                {
                    var tempStateCollection = wrapper.States;

                    if (_changeContext != null)
                    {
                        tempStateCollection = tempStateCollection
                            .Where(x => x.CurrentState.GetStateHashCode() == _changeContext.GetStateHashCode())
                            .ToList();
                    }
                    else
                    {
                        tempStateCollection = tempStateCollection.ToList();
                    }

                    tempStateCollection.ForEach(state => stateChangeCallback.Invoke(
                        (TState)state.PreviousState.Copy(),
                        (TState)state.CurrentState.Copy()));
                }
            };

            wrapper.Callbacks.Add(contextableCallback);

            if (invoke)
            {
                contextableCallback.Callback();
            }
        }

        private StateInfoWrapper AddWrapperIfNotAdded(Type type)
        {
            StateInfoWrapper wrapper;

            if (!_wrappers.TryGetValue(type, out wrapper))
            {
                wrapper = new StateInfoWrapper();
                _wrappers.Add(type, wrapper);
            }

            return wrapper;
        }
    }
}