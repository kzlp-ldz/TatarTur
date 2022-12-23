using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace TatarTur.Sqlite
{
    public static class TokenRepository
    {
        public static string GetFirebaseToken()
        {
            try
            {
                return SecureStorage.GetAsync("firebaseToken").Result;
            }
            catch
            {
                return null;
            }
        }

        public static void StoreFirebaseToken(string token)
        {
            try
            {
                SecureStorage.SetAsync("firebaseToken", token);
            }
            catch
            {
            }
        }
    }
}
