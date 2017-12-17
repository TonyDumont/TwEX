using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace TwEX_API
{
    public class LogManager
    {
        // PROPERTIES
        public static Boolean ConsoleLogging = false;
        //static byte[] bytes = ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName);
        public static BindingList<LogMessage> LogMessageList = new BindingList<LogMessage>();
        // FUNCTIONS
        public static void AddLogMessage(String source, String functionCall, String message, LogMessageType type = LogMessageType.LOG)
        {
            LogMessage logMessage = new LogMessage();
            logMessage.TimeStamp = DateTime.Now;
            logMessage.Source = source;
            logMessage.FunctionCall = functionCall;
            logMessage.Message = message;
            logMessage.type = type;
            LogMessageList.Insert(0, logMessage);

            if (ConsoleLogging)
            {
                Console.WriteLine(logMessage.TimeStamp + " | source=" + logMessage.Source + " | function=" + logMessage.FunctionCall + " | " + logMessage.type + " | " + logMessage.Message);
            }
        }

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="originalString">The original string.</param>
        /// <returns>The encrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown when the original string is null or empty.</exception>
        public static string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            //CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName), ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName)), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);
            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();

            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        /// <summary>
        /// Decrypt a crypted string.
        /// </summary>
        /// <param name="cryptedString">The crypted string.</param>
        /// <returns>The decrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown when the crypted string is null or empty.</exception>
        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            //CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName), ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName)), CryptoStreamMode.Read);
            //ASCIIEncoding.ASCII.GetBytes(System.Environment.MachineName)
            StreamReader reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();
        }
        // ENUMS
        public enum LogMessageType
        {
            LOG,
            DEBUG,
            EXCHANGE,
            EXCEPTION,
            OTHER
        }
        // MODELS
        public class LogMessage
        {
            public DateTime TimeStamp { get; set; }
            public string Source { get; set; }
            public string FunctionCall { get; set; }
            public string Message { get; set; }
            public LogMessageType type { get; set; }
        }
    }

    public static class EnumUtils
    {
        private static class EnumCache<T>
        {
            static readonly Type EnumType = typeof(T);
            static readonly Dictionary<T, string> FieldDescriptions = new Dictionary<T, string>();

            public static IDictionary<T, string> CachedDescriptions
            {
                get { return new Dictionary<T, string>(FieldDescriptions); }
            }

            public static string GetDescription(T value, string defaultValue)
            {
                string result = null;
                if (FieldDescriptions.ContainsKey(value))
                {
                    result = FieldDescriptions[value];
                }
                else
                {
                    lock (FieldDescriptions)
                    {
                        if (FieldDescriptions.ContainsKey(value))
                        {
                            result = FieldDescriptions[value];
                        }
                        else
                        {
                            FieldInfo fi = EnumType.GetField(value.ToString());
                            result = GetMemberDescription(fi, false);
                            FieldDescriptions[value] = result;
                        }
                    }
                }

                return result ?? defaultValue;
            }

            public static void LoadDescriptions()
            {
                lock (FieldDescriptions)
                {
                    FieldInfo[] fields = EnumType.GetFields();
                    if (null != fields)
                    {
                        T value;
                        FieldInfo field;
                        for (int i = 0; i < fields.Length; i++)
                        {
                            field = fields[i];
                            if (0 != (FieldAttributes.Static & field.Attributes))
                            {
                                value = (T)field.GetValue(null);
                                if (!FieldDescriptions.ContainsKey(value))
                                {
                                    FieldDescriptions[value] = GetMemberDescription(field, false);
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private static string GetMemberDescription(MemberInfo member, bool inherited)
        {
            string result = null;

            if (null != member)
            {
                object[] attrs = member.GetCustomAttributes(typeof(DescriptionAttribute), inherited);
                if (null != attrs && 0 != attrs.Length)
                {
                    result = ((DescriptionAttribute)attrs[0]).Description;
                    if (null != result && 0 == result.Length) result = null;
                }
            }

            return result;
        }
        
        public static string GetDescription<T>(T value, string defaultValue)
        {
            return EnumCache<T>.GetDescription(value, defaultValue);
        }

        public static string GetDescription<T>(T value)
        {
            return EnumCache<T>.GetDescription(value, string.Empty);
        }
        
        public static IDictionary<T, string> GetAllDescriptions<T>()
        {
            EnumCache<T>.LoadDescriptions();
            return EnumCache<T>.CachedDescriptions;
        }
    }
    public static class Extensions
    {
        public static void SetProperty(this object obj, string propertyName, object value)
        {
            var propertyInfo = obj.GetType().GetProperty(propertyName);
            if (propertyInfo == null) return;
            propertyInfo.SetValue(obj, value);
        }
    }

    class DecimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal) || objectType == typeof(decimal?));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
            {
                return token.ToObject<decimal>();
            }
            if (token.Type == JTokenType.String)
            {
                // customize this to suit your needs
                return Decimal.Parse(token.ToString(),
                       System.Globalization.CultureInfo.GetCultureInfo("es-ES"));
            }
            if (token.Type == JTokenType.Null && objectType == typeof(decimal?))
            {
                return null;
            }
            throw new JsonSerializationException("Unexpected token type: " +
                                                  token.Type.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }



    /*
    public class SimpleHash
    {
        /// <summary>
        /// Generates a hash for the given plain text value and returns a
        /// base64-encoded result. Before the hash is computed, a random salt
        /// is generated and appended to the plain text. This salt is stored at
        /// the end of the hash value, so it can be used later for hash
        /// verification.
        /// </summary>
        /// <param name="plainText">
        /// Plaintext value to be hashed. The function does not check whether
        /// this parameter is null.
        /// </param>
        /// <param name="hashAlgorithm">
        /// Name of the hash algorithm. Allowed values are: "MD5", "SHA1",
        /// "SHA256", "SHA384", and "SHA512" (if any other value is specified
        /// MD5 hashing algorithm will be used). This value is case-insensitive.
        /// </param>
        /// <param name="saltBytes">
        /// Salt bytes. This parameter can be null, in which case a random salt
        /// value will be generated.
        /// </param>
        /// <returns>
        /// Hash value formatted as a base64-encoded string.
        /// </returns>
        public static string ComputeHash(string plainText,
                                         string hashAlgorithm,
                                         byte[] saltBytes)
        {
            // If salt is not specified, generate it on the fly.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

            // Because we support multiple hashing algorithms, we must define
            // hash object as a common (abstract) base class. We will specify the
            // actual hashing algorithm class later during object creation.
            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithm.ToUpper())
            {
                case "SHA1":
                    hash = new SHA1Managed();
                    break;

                case "SHA256":
                    hash = new SHA256Managed();
                    break;

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        /// <summary>
        /// Compares a hash of the specified plain text value to a given hash
        /// value. Plain text is hashed with the same salt value as the original
        /// hash.
        /// </summary>
        /// <param name="plainText">
        /// Plain text to be verified against the specified hash. The function
        /// does not check whether this parameter is null.
        /// </param>
        /// <param name="hashAlgorithm">
        /// Name of the hash algorithm. Allowed values are: "MD5", "SHA1", 
        /// "SHA256", "SHA384", and "SHA512" (if any other value is specified,
        /// MD5 hashing algorithm will be used). This value is case-insensitive.
        /// </param>
        /// <param name="hashValue">
        /// Base64-encoded hash value produced by ComputeHash function. This value
        /// includes the original salt appended to it.
        /// </param>
        /// <returns>
        /// If computed hash mathes the specified hash the function the return
        /// value is true; otherwise, the function returns false.
        /// </returns>
        public static bool VerifyHash(string plainText,
                                      string hashAlgorithm,
                                      string hashValue)
        {
            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            // Make sure that hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Size of hash is based on the specified algorithm.
            switch (hashAlgorithm.ToUpper())
            {
                case "SHA1":
                    hashSizeInBits = 160;
                    break;

                case "SHA256":
                    hashSizeInBits = 256;
                    break;

                case "SHA384":
                    hashSizeInBits = 384;
                    break;

                case "SHA512":
                    hashSizeInBits = 512;
                    break;

                default: // Must be MD5
                    hashSizeInBits = 128;
                    break;
            }

            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                        hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            string expectedHashString =
                        ComputeHash(plainText, hashAlgorithm, saltBytes);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
        }
    }
    */

    /// <summary>
    /// Illustrates the use of the SimpleHash class.
    /// </summary>
    /*
    public class SimpleHashTest
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string password = "myP@5sw0rd";  // original password
            string wrongPassword = "password";    // wrong password

            string passwordHashMD5 =
                   SimpleHash.ComputeHash(password, "MD5", null);
            string passwordHashSha1 =
                   SimpleHash.ComputeHash(password, "SHA1", null);
            string passwordHashSha256 =
                   SimpleHash.ComputeHash(password, "SHA256", null);
            string passwordHashSha384 =
                   SimpleHash.ComputeHash(password, "SHA384", null);
            string passwordHashSha512 =
                   SimpleHash.ComputeHash(password, "SHA512", null);

            Console.WriteLine("COMPUTING HASH VALUES\r\n");
            Console.WriteLine("MD5   : {0}", passwordHashMD5);
            Console.WriteLine("SHA1  : {0}", passwordHashSha1);
            Console.WriteLine("SHA256: {0}", passwordHashSha256);
            Console.WriteLine("SHA384: {0}", passwordHashSha384);
            Console.WriteLine("SHA512: {0}", passwordHashSha512);
            Console.WriteLine("");

            Console.WriteLine("COMPARING PASSWORD HASHES\r\n");
            Console.WriteLine("MD5    (good): {0}",
                                SimpleHash.VerifyHash(
                                password, "MD5",
                                passwordHashMD5).ToString());
            Console.WriteLine("MD5    (bad) : {0}",
                                SimpleHash.VerifyHash(
                                wrongPassword, "MD5",
                                passwordHashMD5).ToString());
            Console.WriteLine("SHA1   (good): {0}",
                                SimpleHash.VerifyHash(
                                password, "SHA1",
                                passwordHashSha1).ToString());
            Console.WriteLine("SHA1   (bad) : {0}",
                                SimpleHash.VerifyHash(
                                wrongPassword, "SHA1",
                                passwordHashSha1).ToString());
            Console.WriteLine("SHA256 (good): {0}",
                                SimpleHash.VerifyHash(
                                password, "SHA256",
                                passwordHashSha256).ToString());
            Console.WriteLine("SHA256 (bad) : {0}",
                                SimpleHash.VerifyHash(
                                wrongPassword, "SHA256",
                                passwordHashSha256).ToString());
            Console.WriteLine("SHA384 (good): {0}",
                                SimpleHash.VerifyHash(
                                password, "SHA384",
                                passwordHashSha384).ToString());
            Console.WriteLine("SHA384 (bad) : {0}",
                                SimpleHash.VerifyHash(
                                wrongPassword, "SHA384",
                                passwordHashSha384).ToString());
            Console.WriteLine("SHA512 (good): {0}",
                                SimpleHash.VerifyHash(
                                password, "SHA512",
                                passwordHashSha512).ToString());
            Console.WriteLine("SHA512 (bad) : {0}",
                                SimpleHash.VerifyHash(
                                wrongPassword, "SHA512",
                                passwordHashSha512).ToString());
        }
    }
    */


}
