namespace imbSCI.Core.math
{
    using System;
    using System.ComponentModel;
    using System.Security.Cryptography;
    using System.Text;
    using imbSCI.Data;
    using imbSCI.Data.collection.nested;

    /// <summary>
    /// Main MD algorithm
    /// </summary>
    public static class md5
    {


        private static Boolean _isCacheEnabled = true;
        /// <summary>
        ///
        /// </summary>
        public static Boolean isCacheEnabled
        {
            get
            {
                return _isCacheEnabled;
            }
            set
            {
                _isCacheEnabled = value;
            }
        }


        private static aceConcurrentDictionary<String> _cache = new aceConcurrentDictionary<String>(); //= new (Dictionary<String,String>); // = new Dictionary<String,String>();
                                                                                             /// <summary>
                                                                                             /// Description of $property$
                                                                                             /// </summary>
        [Category("md5")]
        [DisplayName("cache")]
        [Description("Description of $property$")]
        public static aceConcurrentDictionary<String> cache
        {
            get
            {
                if (_cache == null)
                {
                    //_cache //
                }
                return _cache;
            }
            set
            {
                _cache = value;
                
            }
        }


        private static MD5 _md5Hash = MD5.Create();
        /// <summary>
        ///
        /// </summary>
        private static MD5 md5Hash
        {
            get
            {
                return _md5Hash;
            }
        }

        public static string GetMd5HashInverse(string hash)
        {
            if (isCacheEnabled)
            {
                if (!cache.ContainsKey(hash)) return "not found in cache";
                return cache[hash];
            }
            return "-cache disabled-";
        }


        private static String _emptyInpit = "emptyInput";
        /// <summary> </summary>
        public static String emptyInput
        {
            get
            {
                return _emptyInpit;
            }
            set
            {
                _emptyInpit = value;
               // OnPropertyChanged("emptyInpit");
            }
        }

        /// <summary>
        /// Gets the MD5 hash for the string
        /// </summary>
        /// <param name="input">The input data to create hash for</param>
        /// <returns></returns>
        public static string GetMd5Hash(string input, Boolean useCache=true)
        {
            if (input.isNullOrEmptyString()) input = emptyInput;
            if (useCache && isCacheEnabled)
            {
                if (cache.ContainsKey(input))
                {
                    return cache[input];
                }
                else
                {
                    cache.Add(input, "");
                }
            }

            var md5 = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            if (!(useCache && isCacheEnabled)) return sBuilder.ToString();

            cache[input] = sBuilder.ToString();

            // Return the hexadecimal string.
            return cache[input];
        }

        
        /// <summary>
        /// Verifies the MD5 <c>hash</c> against the string <c>input</c>
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="hash">The hash.</param>
        /// <returns></returns>
        public static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
