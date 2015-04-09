using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace L2L.ClientAPI.ServiceOperations
{
   
    public class L2LEncrypt
    {
        // Methods
        public L2LEncrypt()
        {
            this.HashIterations = 0x1388;
            this.SaltSize = 0x10;
        }

        private string calculateHash(int iteration)
        {
            byte[] salt = Encoding.UTF8.GetBytes(this.Salt);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(this.PlainText, salt, iteration))
            {
                return Convert.ToBase64String(bytes.GetBytes(0x40));
            }
        }

        public string Compute()
        {
            if (string.IsNullOrEmpty(this.PlainText))
            {
                throw new InvalidOperationException("PlainText cannot be empty");
            }
            this.HashedText = this.calculateHash(this.HashIterations);
            return this.HashedText;
        }

        public string Compute(string textToHash)
        {
            this.PlainText = textToHash;
            //this.generateSalt();
            this.Compute();
            return this.HashedText;
        }

        public string Compute(string textToHash, string salt)
        {
            this.PlainText = textToHash;
            this.Salt = salt;
            this.expandSalt();
            this.Compute();
            return this.HashedText;
        }

        public string Compute(string textToHash, int saltSize, int hashIterations)
        {
            this.PlainText = textToHash;
            this.HashIterations = hashIterations;
            this.SaltSize = saltSize;
            //this.generateSalt();
            this.Compute();
            return this.HashedText;
        }

        private void expandSalt()
        {
            try
            {
                int index = this.Salt.IndexOf('.');
                this.HashIterations = int.Parse(this.Salt.Substring(0, index), NumberStyles.Number);
            }
            catch (Exception)
            {
                throw new FormatException("The salt was not in an expected format of {int}.{string}");
            }
        }


        // Properties
        public string HashedText { get; private set; }

        public int HashIterations { get; set; }

        public string PlainText { get; set; }

        public string Salt { get; private set; }

        public int SaltSize { get; set; }
    }
}
