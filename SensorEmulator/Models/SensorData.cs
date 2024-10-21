namespace SensorEmulator.Models
{
    public class SensorData
    {
        public double? Value { get; set; }
        public int? Scaler { get; set; }

        public double GetCalculatedValue()
        {
            if (Value == null)
            {
                throw new ArgumentNullException(nameof(Value), "Cannot return calculated value because Value is null.");
            }
            if (Scaler == null)
            {
                throw new ArgumentNullException(nameof(Scaler), "Cannot return calculated value because Scaler is null.");
            }

            return Value.Value * Math.Pow(10, Scaler.Value);
        }
    }
}