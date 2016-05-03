using System.Collections.Generic;

namespace dokidoki.dokiUnity {
    /// <summary>
    /// State is a util to control the state transition
    /// </summary>
    public class State {
        private string currentState;
        private List<string> states;

        public string CurrentState { get { return this.currentState; } }
        public List<string> States { get { return this.states; } }

        public State(string[] states) {
            this.states = new List<string>();
            foreach (string state in states) {
                this.states.Add(state);
            }
            this.states.Sort();
        }
        public State(List<string> states)
            : this(states.ToArray()) {
        }

        public string Transfer(string state) {
            string oldState = this.CurrentState;
            if (this.states.Contains(state)) {
                this.currentState = state;
            }
            return oldState;
        }
    }
}
