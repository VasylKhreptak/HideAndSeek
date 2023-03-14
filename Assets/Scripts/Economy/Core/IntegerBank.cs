namespace Economy.Core
{
    public class IntegerBank : Bank<int>
    {
        public override void Add(int value)
        {
            if (value <= 0) return;

            this.value += value;
            onValueAdded?.Invoke(value);
            onValueChanged?.Invoke(this.value);
        }

        public override bool TrySpend(int value)
        {
            if (this.value >= value)
            {
                this.value -= value;
                onValueSpent?.Invoke(value);
                onValueChanged?.Invoke(this.value);
                return true;
            }

            return false;
        }
    }
}
