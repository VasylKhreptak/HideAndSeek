namespace Economy.Core
{
    public class IntegerBank : Bank<int>
    {
        public override void Add(int value)
        {
            if (value <= 0) return;

            this.value += value;
            onValueAdded?.Invoke(value);
            OnValueChanged();
        }

        public override bool TrySpend(int value)
        {
            if (this.value >= value)
            {
                this.value -= value;
                onValueSpent?.Invoke(value);
                OnValueChanged();
                return true;
            }

            return false;
        }

        protected virtual void OnValueChanged()
        {
            onValueChanged?.Invoke(this.value);
        }

        public bool CanAfford(int value)
        {
            return this.value >= value;
        }
    }
}
