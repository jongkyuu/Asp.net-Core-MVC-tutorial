namespace StateManagement.Data
{
    public class CounterState
    {
        private int _count = 0;
        public Action? OnStateChanged;

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                Refresh();
            }
        }

        private void Refresh()
        {
            OnStateChanged?.Invoke();
        }
    }
}
