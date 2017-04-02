using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Agents.States {
    public class StateMachine {
        private readonly AgentBase _entity;
        public IState CurrentState { get; set; }
        public IState PreviousState { get; set; }
        public StateMachine(AgentBase entity) {
            _entity = entity;

        }
        public void ChangeState(IState newState) {
            PreviousState = CurrentState;
            if (PreviousState != null) {
                PreviousState.Exit(_entity);
            }
            CurrentState = newState;
            newState.Enter(_entity);
        }

        public void Update() {
            if (PreviousState == null) {
                CurrentState.Enter(_entity);
            }
            if (CurrentState != null) {
                CurrentState.Execute(_entity);
            }

        }
    }
}
