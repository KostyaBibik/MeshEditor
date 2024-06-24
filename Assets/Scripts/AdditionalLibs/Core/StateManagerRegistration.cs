using System;
using UnityEngine;

namespace GlobalState
{
    public partial class StateManager
    {
        /// <summary>
        /// Зарегистрировать реакцию изменения состояния.
        /// </summary>
        /// <param name="stateChangeCallback">Callback рекции CurrentState</param>
        /// <param name="invoke">Если True, после добавления, произойдёт вызов с текущим состоянием</param>
        /// <typeparam name="TState">Состояние</typeparam>
        public void TrackStateChanging<TState>(Action<TState> stateChangeCallback, bool invoke = true)
            where TState : State
        {
            if (stateChangeCallback == null)
            {
                throw new InvalidOperationException("Попытка регистрации пустой реакции");
            }

            TrackStateChanging<TState>((_, currentState) => stateChangeCallback.Invoke(currentState),
                invoke);
        }

        /// <summary>
        /// Зарегистрировать реакцию изменения состояния.
        /// </summary>
        /// <param name="stateChangeCallback">Callback рекции (PreviousState, CurrentState)</param>
        /// <param name="invoke">Если True, после добавления, произойдёт вызов с текущим состоянием</param>
        /// <typeparam name="TState">Состояние</typeparam>
        public void TrackStateChanging<TState>(Action<TState, TState> stateChangeCallback, bool invoke = true)
            where TState : State
        {
            TrackStateChangingInternal(stateChangeCallback, null, 0, invoke);
        }

        /// <summary>
        /// Зарегистрировать реакцию изменения состояния.
        /// </summary>
        /// <param name="stateChangeCallback">Callback рекции CurrentState</param>
        /// <param name="context">Контекст выполнения. Позволяет автоматически очищать трекеры при удалении объекта</param>
        /// <typeparam name="TState">Состояние</typeparam>
        public void TrackStateChanging<TState>(Action<TState> stateChangeCallback, MonoBehaviour context)
            where TState : State
        {
            if (stateChangeCallback == null)
            {
                throw new InvalidOperationException("Попытка регистрации пустой реакции");
            }

            TrackStateChanging<TState>((_, currentState) => stateChangeCallback.Invoke(currentState), context);
        }

        /// <summary>
        /// Зарегистрировать реакцию изменения состояния.
        /// </summary>
        /// <param name="stateChangeCallback">Callback рекции (PreviousState, CurrentState)</param>
        /// <param name="context">Контекст выполнения. Позволяет автоматически очищать трекеры при удалении объекта</param>
        /// <typeparam name="TState">Состояние</typeparam>
        public void TrackStateChanging<TState>(Action<TState, TState> stateChangeCallback, MonoBehaviour context)
            where TState : State
        {
            TrackStateChangingInternal(stateChangeCallback, context, 0, true);
        }
        
        /// <summary>
        /// Зарегистрировать реакцию изменения состояния.
        /// </summary>
        /// <param name="stateChangeCallback">Callback рекции CurrentState</param>
        /// <param name="order">Позволяет задать очерёдность выполнения обратного вызова</param>
        /// <typeparam name="TState">Состояние</typeparam>
        public void TrackStateChanging<TState>(Action<TState> stateChangeCallback, int order)
            where TState : State
        {
            if (stateChangeCallback == null)
            {
                throw new InvalidOperationException("Попытка регистрации пустой реакции");
            }

            TrackStateChanging<TState>((_, currentState) => stateChangeCallback.Invoke(currentState), order);
        }

        /// <summary>
        /// Зарегистрировать реакцию изменения состояния.
        /// </summary>
        /// <param name="stateChangeCallback">Callback рекции (PreviousState, CurrentState)</param>
        /// <param name="order">Позволяет задать очерёдность выполнения обратного вызова</param>
        /// <typeparam name="TState">Состояние</typeparam>
        public void TrackStateChanging<TState>(Action<TState, TState> stateChangeCallback, int order)
            where TState : State
        {
            TrackStateChangingInternal(stateChangeCallback, null, order, true);
        }
    }
}