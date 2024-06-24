namespace GlobalState
{
    public abstract class State
    {
        public abstract State Copy();
        
        public virtual int GetStateHashCode()
        {
            return 0;
        }
    }
}