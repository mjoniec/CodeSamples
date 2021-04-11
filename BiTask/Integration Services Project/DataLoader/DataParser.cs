using System.Globalization;

namespace DataLoader
{
    public class DataParser
    {
        int _lastSuccessfullyParsedId;

        public bool CanParseIntoId(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;

            //drop dimention letter
            data = data.Substring(1);

            return int.TryParse(data, out _lastSuccessfullyParsedId);
        }

        public int GetLastSuccessfullyParsedId()
        {
            return _lastSuccessfullyParsedId;
        }

        int _lastSuccessfullyParsedInt;

        public bool CanParseIntoInt(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;

            return int.TryParse(data, out _lastSuccessfullyParsedInt);
        }

        public int GetLastSuccessfullyParsedInt()
        {
            return _lastSuccessfullyParsedInt;
        }

        decimal _lastSuccessfullyParsedDecimal;

        public bool CanParseIntoDecimal(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;

            return decimal.TryParse(data, out _lastSuccessfullyParsedDecimal);
        }

        public decimal GetLastSuccessfullyParsedDecimal()
        {
            return _lastSuccessfullyParsedDecimal;
        }

        float _lastSuccessfullyParsedFloat;

        public bool CanParseIntoFloat(string data)
        {
            if (string.IsNullOrEmpty(data)) return false;

            return float.TryParse(data, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _lastSuccessfullyParsedFloat);
        }

        public float GetLastSuccessfullyParsedFloat()
        {
            return _lastSuccessfullyParsedFloat;
        }
    }
}
