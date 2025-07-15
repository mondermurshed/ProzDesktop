using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class TokenStorage
{
    private static readonly string TokenFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "ProzApp", "tokens.dat");

    public static void SaveTokens(string accessToken, string refreshToken)
    {
        // Combine the tokens into one string (we’ll split later)
        string combined = $"{accessToken}|||{refreshToken}";
        byte[] plainBytes = Encoding.UTF8.GetBytes(combined);

        // Protect using DPAPI
        byte[] protectedBytes = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);

        // Make sure folder exists
        Directory.CreateDirectory(Path.GetDirectoryName(TokenFilePath));

        // Save to file
        File.WriteAllBytes(TokenFilePath, protectedBytes);
    }

    public static (string accessToken, string refreshToken)? LoadTokens()
    {
        if (!File.Exists(TokenFilePath))
            return null;

        try
        {
            byte[] protectedBytes = File.ReadAllBytes(TokenFilePath);
            byte[] plainBytes = ProtectedData.Unprotect(protectedBytes, null, DataProtectionScope.CurrentUser);

            string combined = Encoding.UTF8.GetString(plainBytes);
            string[] parts = combined.Split(new[] { "|||" }, StringSplitOptions.None);

            if (parts.Length == 2)
                return (parts[0], parts[1]);
            else
                return null;
        }
        catch
        {
            // File might be corrupted or tampered with
            return null;
        }
    }

    public static void DeleteTokens()
    {
        if (File.Exists(TokenFilePath))
            File.Delete(TokenFilePath);
    }
}
