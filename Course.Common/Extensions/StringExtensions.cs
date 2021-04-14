namespace System
{
    public static class StringExtensions
    {
        public static string ToService(this String text)
        {
            if (String.IsNullOrEmpty(text))
                throw new FormatException();

            if (text.ToLower().EndsWith("service"))
                text = text.Replace("service", "");

            string firstLetter = text.Substring(0, 1).ToUpper();
            string remainingText = text.Length >= 2 ? text.Substring(1).ToLower() : "";
            return firstLetter + remainingText + "Service";
        }
    }
}
