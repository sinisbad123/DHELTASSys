using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

/// <summary>
/// Developer: Vasay, Brian Albert H.
/// Date Created: 06/13/2013
/// 
/// ****************************************************************************************************
/// REVISION HISTORY:
/// CHANGE DATE:    CHANGED BY:             DESCRIPTION
/// 06/03/2013                              Creation of the class
/// 12/10/2013      Vasay, Brian Albert H.  Revised existing DES encryption / decryption methods
/// 12/10/2013      Vasay, Brian Albert H.  Included AES encryption / decryption methods
/// 12/10/2013      Vasay, Brian Albert H.  Created AsymmetricEncryption and SymmetricEncrpytion classes
/// 01/08/2014      Vasay, Brian Albert H.  Included RSA encryption / decryption methods
/// 01/08/2014      Vasay, Brian Albert H.  Included XML documentation to all methods and properties
/// ****************************************************************************************************
/// </summary>
namespace BAHV.Common.Cryptography
{
    #region Asymmetric Encryption (RSA)

    #region RSA Encryption (Rivest, Shamir, Adelman)
    public class RSAEncryption
    {
        private bool isoaep;
        private RSACryptoServiceProvider rsa;
        private RSAParameters privatekey, publickey;

        /// <summary>
        /// This is to encrypt / decrypt a given string variable using asymmetric encryption
        /// </summary>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public RSAEncryption()
        {
            try
            {
                rsa = new RSACryptoServiceProvider(1024);
                isoaep = false;
                publickey = rsa.ExportParameters(false);
                privatekey = rsa.ExportParameters(true);
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to encrypt / decrypt a given string variable using asymmetric encryption
        /// </summary>
        /// <param name="IsOAEP">The boolean variable that will enable / disable Optimal Asymmetric Encryption Padding</param>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public RSAEncryption(bool IsOAEP)
        {
            try
            {
                rsa = new RSACryptoServiceProvider(1024);
                publickey = rsa.ExportParameters(false);
                privatekey = rsa.ExportParameters(true);
                // This is to determine if Optimal Asymmetric Encryption Padding will be enabled or disabled
                switch (IsOAEP)
                {
                    case true:
                        isoaep = true;
                        break;
                    case false:
                        isoaep = false;
                        break;
                }
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to encrypt / decrypt a given string variable using asymmetric encryption
        /// </summary>
        /// <param name="RSAKeySize">Set 1024, 1536, or 2048 bit encryption</param>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public RSAEncryption(int RSAKeySize)
        {
            // This is to throw possible exception(s)
            if (RSAKeySize <= 0 || RSAKeySize > 2048)
            {
                throw new ArgumentException();
            }
            try
            {
                isoaep = false;
                rsa = new RSACryptoServiceProvider(1024);
                // This is to determine the type of encryption to be used
                switch (RSAKeySize)
                {
                    case 1024:
                        rsa = new RSACryptoServiceProvider(1024);
                        break;
                    case 1536:
                        rsa = new RSACryptoServiceProvider(1536);
                        break;
                    case 2048:
                        rsa = new RSACryptoServiceProvider(2048);
                        break;
                }
                publickey = rsa.ExportParameters(false);
                privatekey = rsa.ExportParameters(true);
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to encrypt / decrypt a given string variable using asymmetric encryption
        /// </summary>
        /// <param name="IsOAEP">The boolean variable that will enable / disable Optimal Asymmetric Encryption Padding</param>
        /// <param name="RSAKeySize">Set 1024, 1536, or 2048 bit encryption</param>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public RSAEncryption(bool IsOAEP, int RSAKeySize)
        {
            // This is to throw possible exception(s)
            if (RSAKeySize <= 0 || RSAKeySize > 2048)
            {
                throw new ArgumentException();
            }
            try
            {
                rsa = new RSACryptoServiceProvider(1024);
                // This is to determine the type of encryption to be used
                switch (RSAKeySize)
                {
                    case 1024:
                        rsa = new RSACryptoServiceProvider(1024);
                        break;
                    case 1536:
                        rsa = new RSACryptoServiceProvider(1536);
                        break;
                    case 2048:
                        rsa = new RSACryptoServiceProvider(2048);
                        break;
                }
                // This is to determine if Optimal Asymmetric Encryption Padding will be enabled or disabled
                switch (IsOAEP)
                {
                    case true:
                        isoaep = true;
                        break;
                    case false:
                        isoaep = false;
                        break;
                }
                publickey = rsa.ExportParameters(false);
                privatekey = rsa.ExportParameters(true);
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to decrypt an RSA encrypted Base64 string and return it as plain text
        /// </summary>
        /// <param name="rsaPrivateKey">The RSAParameters variable that will serve as the private key for decryption</param>
        /// <param name="strToDecrypt">The Base64 string variable that is to be decrypted</param>
        /// <returns>The plain text converted from an RSA encrypted Base64 string</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string DecryptString(RSAParameters rsaPrivateKey, string strToDecrypt)
        {
            // This is to throw possible exception(s)
            if (strToDecrypt == null || strToDecrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            try
            {
                byte[] InputByteArray = Convert.FromBase64String(strToDecrypt);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                // This is to import the private key as an RSA parameter
                rsa.ImportParameters(rsaPrivateKey);
                // This to perform the decryption based on the given RSA parameter
                byte[] DecryptedByteArray = rsa.Decrypt(InputByteArray, isoaep);
                // This to return the decrypted bytes converted to a string
                Encoding e = Encoding.UTF8;
                return e.GetString(DecryptedByteArray);
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to decrypt an RSA encrypted Base64 string and return it as plain text
        /// </summary>
        /// <param name="strPrivateKey">The string variable that will serve as the private key for decryption</param>
        /// <param name="strToDecrypt">The Base64 string variable that is to be decrypted</param>
        /// <returns>The plain text converted from an RSA encrypted Base64 string</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string DecryptString(string strPrivateKey, string strToDecrypt)
        {
            // This is to throw possible exception(s)
            if (strPrivateKey == null || strPrivateKey.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strToDecrypt == null || strToDecrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            try
            {
                byte[] InputByteArray = Convert.FromBase64String(strToDecrypt);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                // This is to convert the private key into an RSAParameter
                StringReader sr = new StringReader(strPrivateKey);
                XmlSerializer xs = new XmlSerializer(typeof(RSAParameters));
                RSAParameters PrivateKey = (RSAParameters)xs.Deserialize(sr);
                // This is to import the private key as an RSA parameter
                rsa.ImportParameters(PrivateKey);
                // This to perform the decryption based on the given RSA parameter
                byte[] DecryptedByteArray = rsa.Decrypt(InputByteArray, isoaep);
                // This to return the decrypted bytes converted to a string
                Encoding e = Encoding.UTF8;
                return e.GetString(DecryptedByteArray);
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to encrypt a string using RSA and return it as an encrypted byte array converted to a Base64 string
        /// </summary>
        /// <param name="rsaPublicKey">The RSAParameters variable that will serve as the public key for encryption</param>
        /// <param name="strToEncrypt">The string variable that is to be encrypted</param>
        /// <returns>The RSA encrypted byte array converted to a Base64 string</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string EncryptString(RSAParameters rsaPublicKey, string strToEncrypt)
        {
            // This is to throw possible exception(s)
            if (strToEncrypt == null || strToEncrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            try
            {
                byte[] InputByteArray = Encoding.UTF8.GetBytes(strToEncrypt);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                // This is to import the public key as an RSA parameter
                rsa.ImportParameters(rsaPublicKey);
                // This to perform the encryption based on the given RSA parameter
                byte[] EncryptedByteArray = rsa.Encrypt(InputByteArray, isoaep);
                // This to return the encrypted bytes converted to a Base64
                return Convert.ToBase64String(EncryptedByteArray);
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to encrypt a string using RSA and return it as an encrypted byte array converted to a Base64 string
        /// </summary>
        /// <param name="strPublicKey">The string variable that will serve as the public key for encryption</param>
        /// <param name="strToEncrypt">The string variable that is to be encrypted</param>
        /// <returns>The RSA encrypted byte array converted to a Base64 string</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string EncryptString(string strPublicKey, string strToEncrypt)
        {
            // This is to throw possible exception(s)
            if (strPublicKey == null || strPublicKey.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strToEncrypt == null || strToEncrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            try
            {
                byte[] InputByteArray = Encoding.UTF8.GetBytes(strToEncrypt);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                // This is to convert the public key into an RSAParameter
                StringReader sr = new StringReader(strPublicKey);
                XmlSerializer xs = new XmlSerializer(typeof(RSAParameters));
                RSAParameters PublicKey = (RSAParameters)xs.Deserialize(sr);
                // This is to import the public key as an RSA parameter
                rsa.ImportParameters(PublicKey);
                // This to perform the encryption based on the given RSA parameter
                byte[] EncryptedByteArray = rsa.Encrypt(InputByteArray, isoaep);
                // This to return the encrypted bytes converted to a Base64
                return Convert.ToBase64String(EncryptedByteArray);
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to convert an RSAParameter into a string variable
        /// </summary>
        /// <param name="rsaKey">The RSAParameters variable that will be converted a string variable</param>
        /// <returns>The RSAParameter converted to a string data type</returns>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string RSAParametersToString(RSAParameters rsaKey)
        {
            try
            {
                StringWriter sw = new StringWriter();
                XmlSerializer xs = new XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, rsaKey);
                return sw.ToString();
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the private key for the RSA algorithm
        /// </summary>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string PrivateKey
        {
            get { return RSAParametersToString(privatekey); }
        }

        /// <summary>
        /// Gets the public key for the RSA algorithm
        /// </summary>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string PublicKey
        {
            get { return RSAParametersToString(publickey); }
        }
    }
    #endregion

    #endregion

    #region Symmetric Encryption (AES, DES)

    #region AES Encryption (Advanced Encryption Standard)
    public class AESEncryption
    {
        private string key, iv;
        private byte[] initializationvector = {
                                                    0xF2, 0xD4, 0xB6, 0x08, 0xE1, 0xC3, 0xA5, 0x97,
                                                    0xF1, 0xC3, 0xE2, 0xB4, 0xD5, 0xA7, 0x06, 0x98
                                              };
        private byte[] encryptionkey = {
                                            0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF,
                                            0x12, 0x24, 0x57, 0x68, 0x90, 0xAD, 0xBE, 0xCF,
                                            0x1E, 0x2F, 0x3C, 0x4D, 0x5A, 0x6B, 0x79, 0x80,
                                            0x10, 0x29, 0x3B, 0x4A, 0x5D, 0x6C, 0x7F, 0x8E
                                       };

        /// <summary>
        /// This is to encrypt / decrypt a given string variable using AES symmetric encryption
        /// </summary>
        /// <returns>A DESEncryption object</returns>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public AESEncryption() { try { } catch (CryptographicException e) { throw e; } }

        /// <summary>
        /// This is to decrypt a AES encrypted Base64 string and return it as plain text
        /// </summary>
        /// <param name="strToDecrypt">The Base64 string variable that is to be decrypted</param>
        /// <returns>The plain text converted from a AES encrypted Base64 string</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string DecryptString(string strToDecrypt)
        {
            // This is to throw possible exception(s)
            if (strToDecrypt == null || strToDecrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            try
            {
                byte[] InputByteArray = Convert.FromBase64String(strToDecrypt);
                // This is to create an AesCryptoServiceProvider instance with a given encryption key and initialization vector
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.IV = initializationvector;
                aes.Key = encryptionkey;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                // This is to create a decryptor to perform the stream transformation
                ICryptoTransform ict = aes.CreateDecryptor(aes.Key, aes.IV);
                // This is to create the stream used for decryption
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                // This is to write all given data to the stream
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                // This to return the decrypted bytes converted to a string from the memory stream
                Encoding e = Encoding.UTF8;
                return e.GetString(ms.ToArray());
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to decrypt a AES encrypted Base64 string and return it as plain text
        /// </summary>
        /// <param name="strToDecrypt">The Base64 string variable that is to be decrypted</param>
        /// <param name="strEncryptionKey">The string variable that will serve as the encryption key</param>
        /// <param name="strInitializationVector">The string variable that will serve as the initialization vector</param>
        /// <returns>The plain text converted from a AES encrypted Base64 string</returns>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string DecryptString(string strToDecrypt, string strEncryptionKey, string strInitializationVector)
        {
            // This is to throw possible exception(s)
            if (strToDecrypt == null || strToDecrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strEncryptionKey == null || strEncryptionKey.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strEncryptionKey.Length <= 31)
            {
                throw new ArgumentException();
            }
            if (strInitializationVector == null || strInitializationVector.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strInitializationVector.Length <= 15)
            {
                throw new ArgumentException();
            }
            try
            {
                byte[] InputByteArray = Convert.FromBase64String(strToDecrypt);
                // This is to create an AesCryptoServiceProvider instance with a given encryption key and initialization vector
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.IV = Encoding.UTF8.GetBytes(strInitializationVector.Substring(0, 16));
                aes.Key = Encoding.UTF8.GetBytes(strEncryptionKey.Substring(0, 32));
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                // This is to create a decryptor to perform the stream transformation
                ICryptoTransform ict = aes.CreateDecryptor(aes.Key, aes.IV);
                // This is to create the stream used for decryption
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                // This is to write all given data to the stream
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                // This to return the decrypted bytes converted to a string from the memory stream
                Encoding e = Encoding.UTF8;
                return e.GetString(ms.ToArray());
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        //// <summary>
        /// This is to encrypt a string using AES and return it as an encrypted byte array converted to a Base64 string
        /// </summary>
        /// <param name="strToEncrypt">The string variable that is to be encrypted</param>
        /// <returns>The AES encrypted byte array converted to a Base64 string</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string EncryptString(string strToEncrypt)
        {
            // This is to throw possible exception(s)
            if (strToEncrypt == null || strToEncrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            try
            {
                byte[] InputByteArray = Encoding.UTF8.GetBytes(strToEncrypt);
                // This is to create an AesCryptoServiceProvider instance with a given encryption key and initialization vector
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.IV = initializationvector;
                aes.Key = encryptionkey;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                // This is to create an encryptor to perform the stream transformation
                ICryptoTransform ict = aes.CreateEncryptor(aes.Key, aes.IV);
                // This is to create the stream used for encryption
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                // This is to write all given data to the stream
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to encrypt a string using AES and return it as an encrypted byte array converted to a Base64 string
        /// </summary>
        /// <param name="strToEncrypt">The string variable that is to be encrypted</param>
        /// <param name="strEncryptionKey">The string variable that will serve as the encryption key</param>
        /// <param name="strInitializationVector">The string variable that will serve as the initialization vector</param>
        /// <returns>The AES encrypted byte array converted to a Base64 string</returns>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string EncryptString(string strToEncrypt, string strEncryptionKey, string strInitializationVector)
        {
            // This is to throw possible exception(s)
            if (strToEncrypt == null || strToEncrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strEncryptionKey == null || strEncryptionKey.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strEncryptionKey.Length <= 31)
            {
                throw new ArgumentException();
            }
            if (strInitializationVector == null || strInitializationVector.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strInitializationVector.Length <= 15)
            {
                throw new ArgumentException();
            }
            try
            {
                byte[] InputByteArray = Encoding.UTF8.GetBytes(strToEncrypt);
                // This is to create an AesCryptoServiceProvider instance with a given encryption key and initialization vector
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.IV = Encoding.UTF8.GetBytes(strInitializationVector.Substring(0, 16));
                aes.Key = Encoding.UTF8.GetBytes(strEncryptionKey.Substring(0, 32));
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                // This is to create an encryptor to perform the stream transformation
                ICryptoTransform ict = aes.CreateEncryptor(aes.Key, aes.IV);
                // This is to create the stream used for encryption
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                // This is to write all given data to the stream
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets or sets the encryption key for the AES algorithm
        /// </summary>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string Key
        {
            set
            {
                // This is to throw possible exception(s)
                if (value == null || value.Length <= 0)
                {
                    throw new ArgumentNullException();
                }
                if (value.Length <= 31)
                {
                    throw new ArgumentException();
                }
                try { key = value.Substring(0, 32); }
                catch (CryptographicException e) { throw e; }
            }
            get { return key; }
        }

        /// <summary>
        /// Gets or sets the initialization vector for the AES algorithm
        /// </summary>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string IV
        {
            set
            {
                // This is to throw possible exception(s)
                if (value == null || value.Length <= 0)
                {
                    throw new ArgumentNullException();
                }
                if (value.Length <= 15)
                {
                    throw new ArgumentException();
                }
                try { iv = value.Substring(0, 16); }
                catch (CryptographicException e) { throw e; }
            }
            get { return iv; }
        }
    }
    #endregion

    #region DES Encryption (Data Encryption Standard)
    public class DESEncryption
    {
        private string key, iv;
        private byte[] initializationvector = { 0x13, 0x24, 0x57, 0x68, 0x90, 0xAD, 0xBE, 0xCF };
        private byte[] encryptionkey = { 0xF1, 0xC3, 0xE2, 0xB4, 0xD5, 0xA7, 0x06, 0x98 };

        /// <summary>
        /// This is to encrypt / decrypt a given string variable using DES symmetric encryption
        /// </summary>
        /// <returns>A DESEncryption object</returns>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public DESEncryption() { try { } catch (CryptographicException e) { throw e; } }

        /// <summary>
        /// This is to decrypt a DES encrypted Base64 string and return it as plain text
        /// </summary>
        /// <param name="strToDecrypt">The Base64 string variable that is to be decrypted</param>
        /// <returns>The plain text converted from a DES encrypted Base64 string</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string DecryptString(string strToDecrypt)
        {
            // This is to throw possible exception(s)
            if (strToDecrypt == null || strToDecrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            try
            {
                byte[] InputByteArray = Convert.FromBase64String(strToDecrypt);
                // This is to create an AesCryptoServiceProvider instance with a given encryption key and initialization vector
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.IV = initializationvector;
                des.Key = encryptionkey;
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                // This is to create a decryptor to perform the stream transformation
                ICryptoTransform ict = des.CreateDecryptor(des.Key, des.IV);
                // This is to create the stream used for decryption
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                // This is to write all given data to the stream
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                // This to return the decrypted bytes converted to a string from the memory stream
                Encoding e = Encoding.UTF8;
                return e.GetString(ms.ToArray());
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to decrypt a DES encrypted Base64 string and return it as plain text
        /// </summary>
        /// <param name="strToDecrypt">The Base64 string variable that is to be decrypted</param>
        /// <param name="strEncryptionKey">The string variable that will serve as the encryption key</param>
        /// <param name="strInitializationVector">The string variable that will serve as the initialization vector</param>
        /// <returns>The plain text converted from a DES encrypted Base64 string</returns>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string DecryptString(string strToDecrypt, string strEncryptionKey, string strInitializationVector)
        {
            // This is to throw possible exception(s)
            if (strToDecrypt == null || strToDecrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strEncryptionKey == null || strEncryptionKey.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strEncryptionKey.Length <= 7)
            {
                throw new ArgumentException();
            }
            if (strInitializationVector == null || strInitializationVector.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strInitializationVector.Length <= 7)
            {
                throw new ArgumentException();
            }
            try
            {
                byte[] InputByteArray = Convert.FromBase64String(strToDecrypt);
                // This is to create an AesCryptoServiceProvider instance with a given encryption key and initialization vector
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.IV = Encoding.UTF8.GetBytes(strInitializationVector.Substring(0, 8));
                des.Key = Encoding.UTF8.GetBytes(strEncryptionKey.Substring(0, 8));
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                // This is to create a decryptor to perform the stream transformation
                ICryptoTransform ict = des.CreateDecryptor(des.Key, des.IV);
                // This is to create the stream used for decryption
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                // This is to write all given data to the stream
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                // This to return the decrypted bytes converted to a string from the memory stream
                Encoding e = Encoding.UTF8;
                return e.GetString(ms.ToArray());
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to encrypt a string using DES and return it as an encrypted byte array converted to a Base64 string
        /// </summary>
        /// <param name="strToEncrypt">The string variable that is to be encrypted</param>
        /// <returns>The DES encrypted byte array converted to a Base64 string</returns>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string EncryptString(string strToEncrypt)
        {
            // This is to throw possible exception(s)
            if (strToEncrypt == null || strToEncrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            try
            {
                byte[] InputByteArray = Encoding.UTF8.GetBytes(strToEncrypt);
                // This is to create an DESCryptoServiceProvider instance with a given encryption key and initialization vector
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.IV = initializationvector;
                des.Key = encryptionkey;
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                // This is to create an encryptor to perform the stream transformation
                ICryptoTransform ict = des.CreateEncryptor(des.Key, des.IV);
                // This is to create the stream used for encryption
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                // This is to write all given data to the stream
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// This is to encrypt a string using DES and return it as an encrypted byte array converted to a Base64 string
        /// </summary>
        /// <param name="strToEncrypt">The string variable that is to be encrypted</param>
        /// <param name="strEncryptionKey">The string variable that will serve as the encryption key</param>
        /// <param name="strInitializationVector">The string variable that will serve as the initialization vector</param>
        /// <returns>The DES encrypted byte array converted to a Base64 string</returns>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string EncryptString(string strToEncrypt, string strEncryptionKey, string strInitializationVector)
        {
            // This is to throw possible exception(s)
            if (strToEncrypt == null || strToEncrypt.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strEncryptionKey == null || strEncryptionKey.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strEncryptionKey.Length <= 7)
            {
                throw new ArgumentException();
            }
            if (strInitializationVector == null || strInitializationVector.Length <= 0)
            {
                throw new ArgumentNullException();
            }
            if (strInitializationVector.Length <= 7)
            {
                throw new ArgumentException();
            }
            try
            {
                byte[] InputByteArray = Encoding.UTF8.GetBytes(strToEncrypt);
                // This is to create an DESCryptoServiceProvider instance with a given encryption key and initialization vector
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.IV = Encoding.UTF8.GetBytes(strInitializationVector.Substring(0, 8));
                des.Key = Encoding.UTF8.GetBytes(strEncryptionKey.Substring(0, 8));
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                // This is to create an encryptor to perform the stream transformation
                ICryptoTransform ict = des.CreateEncryptor(des.Key, des.IV);
                // This is to create the stream used for encryption
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, ict, CryptoStreamMode.Write);
                // This is to write all given data to the stream
                cs.Write(InputByteArray, 0, InputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets or sets the encryption key for the DES algorithm
        /// </summary>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string Key
        {
            set
            {
                // This is to throw possible exception(s)
                if (value == null || value.Length <= 0)
                {
                    throw new ArgumentNullException();
                }
                if (value.Length <= 7)
                {
                    throw new ArgumentException();
                }
                try { key = value.Substring(0, 8); }
                catch (CryptographicException e) { throw e; }
            }
            get { return key; }
        }

        /// <summary>
        /// Gets or sets the initialization vector for the DES algorithm
        /// </summary>
        /// <exception cref="System.ArgumentException"/>
        /// <exception cref="System.ArgumentNullException"/>
        /// <exception cref="System.Security.Cryptography.CryptographicException"/>
        public string IV
        {
            set
            {
                // This is to throw possible exception(s)
                if (value == null || value.Length <= 0)
                {
                    throw new ArgumentNullException();
                }
                if (value.Length <= 7)
                {
                    throw new ArgumentException();
                }
                try { iv = value.Substring(0, 8); }
                catch (CryptographicException e) { throw e; }
            }
            get { return iv; }
        }
    }
    #endregion

    #endregion
}