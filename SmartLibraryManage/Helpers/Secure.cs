using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using System.IO;
using Windows.Foundation;

namespace SmartLibraryManage.Helpers
{
    class Secure
    {
        private Aes _aes;
        private byte[] key;
        private byte[] iv;
        /// <summary>
        /// 密钥与向量存储路径
        /// </summary>
        private readonly string storePath;
        public Secure(string path)
        {
            _aes = Aes.Create();
            this.storePath = path;
            LoadKey();
        }
        private void LoadKey()
        {
            if (File.Exists(storePath))
            {
                try
                {
                    // 尝试从文件加载密钥和IV
                    (string keyBase64, string ivBase64) = LoadKeyAndIV(storePath);
                    _aes.Key = Convert.FromBase64String(keyBase64);
                    _aes.IV = Convert.FromBase64String(ivBase64);
                    key = _aes.Key;
                    iv= _aes.IV;
                }
                catch
                {
                    // 如果加载失败，生成新的密钥和IV
                    GenerateAndSaveKeyAndIV();
                }
            }
            else
            {
                //生成新的密钥
                GenerateAndSaveKeyAndIV();
            }
        }

        private void GenerateAndSaveKeyAndIV()
        {
            _aes.GenerateKey();
            _aes.GenerateIV();
            key = _aes.Key;
            iv = _aes.IV;
            SaveKeyAndIV(storePath);
        }
        /// <summary>
        /// 对密码进行加密
        /// </summary>
        /// <param name="plainTextPassword"></param>
        /// <returns>返回加密后的base64字符串</returns>
        public string EncryptPassword(string plainTextPassword)
        {
            if (string.IsNullOrEmpty(plainTextPassword)) throw new ArgumentNullException("密码不应为空");
            // 创建加密器
            ICryptoTransform encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);

            // 使用MemoryStream来存储加密后的数据
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        // 将密码写入加密流
                        swEncrypt.Write(plainTextPassword);
                    }
                }
                // 返回加密后的数据（密钥和IV应与加密数据一起存储）
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainTextPassword">明文密码</param>
        /// <param name="encryptedPasswordBase64">对应的加密后的密码</param>
        /// <returns>真-密码正确，假-密码错误</returns>
        public bool VerifyPassword(string plainTextPassword, string encryptedPasswordBase64)
        {
            string t = EncryptPassword(plainTextPassword);
            return t == encryptedPasswordBase64;
        }
        /// <summary>
        /// 解密密码
        /// </summary>
        /// <param name="encryptedPasswordBase64"></param>
        /// <returns>返回原密码</returns>
        public string DecryptPassword(string encryptedPasswordBase64)
        {
            // 创建解密器
            ICryptoTransform decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);

            // 将Base64字符串转换回字节数组
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedPasswordBase64);

            // 使用MemoryStream来存储解密后的数据
            using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // 读取解密后的数据
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        /// <summary>
        /// 保存密钥与IV到本地文件
        /// </summary>
        /// <param name="filePath">保存路径</param>
        public void SaveKeyAndIV(string filePath)
        {
            // 将密钥和IV转换为Base64字符串
            string keyBase64 = Convert.ToBase64String(key);
            string ivBase64 = Convert.ToBase64String(iv);

            // 创建一个简单的格式来存储密钥和IV，例如使用逗号分隔
            string keyAndIV = $"{keyBase64},{ivBase64}";

            // 将密钥和IV保存到文件
            File.WriteAllText(filePath, keyAndIV, Encoding.UTF8);
        }
        /// <summary>
        /// 从本地文件中加载密钥与IV
        /// </summary>
        /// <param name="filePath">保存路径</param>
        /// <returns></returns>
        public (string, string) LoadKeyAndIV(string filePath)
        {
            // 从文件加载密钥和IV
            string keyAndIV = File.ReadAllText(filePath, Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(keyAndIV))
            {
                throw new Exception("the file content is null");
            }
            string[] parts = keyAndIV.Split(',');
            return (parts[0], parts[1]); // 返回Base64编码的密钥和IV
        }
    }
}
