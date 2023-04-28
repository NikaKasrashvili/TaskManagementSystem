using System.Security.Cryptography;

namespace Shared;
public static class IdGenerator
{
    private static readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();

    public static string Generate()
    {
        const int minLength = 5;
        const int maxLength = 10;

        var buffer = new byte[maxLength];
        _rng.GetBytes(buffer);

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var length = buffer[minLength - 1] % (maxLength - minLength + 1) + minLength;

        var result = new char[length];

        for (int i = 0; i < length; i++)
        {
            var index = buffer[i] % chars.Length;
            result[i] = chars[index];
        }

        return new string(result);
    }
}

