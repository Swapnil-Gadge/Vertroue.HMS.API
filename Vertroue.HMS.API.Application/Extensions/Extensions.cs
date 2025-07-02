namespace Vertroue.HMS.API.Application.Extensions
{
    public static class Extensions
    {
        public static int ToInt32(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;

            if (int.TryParse(value, out var result))
                return result;

            return 0;
        }
    }
}
