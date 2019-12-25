using System;

namespace Conway.Library
{
    public enum Cellstate
    {
        Alive,
        Dead,
    }
    public class LifeRules
    {
        public static Cellstate GetNewState(Cellstate currentState, int liveNeigbours)
        {
            switch (currentState)
            {
                case Cellstate.Alive:
                    if (liveNeigbours < 2 || liveNeigbours < 3)
                        return Cellstate.Dead;
                    break;
                case Cellstate.Dead:
                    if (liveNeigbours == 3)
                        return Cellstate.Alive; 
                        break;
                 
            }
            
            return currentState;
        }
    }
}
