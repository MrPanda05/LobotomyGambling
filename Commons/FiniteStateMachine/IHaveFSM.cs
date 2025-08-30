using Godot;
using System;

namespace Commons.FiniteStateMachine
{
    /// <summary>
    /// An interface so that nodes that do not have state machines, can request other that do for a chance
    /// </summary>
    public interface IHaveFSM
    {
        public void RequestStateChange(string stateName);
    }
}
