﻿using System;
using DltNode.Hash;
using System.Text;
using System.Security.Cryptography;

namespace DltNode.Blockchain
{
	public class Transaction
	{
		public readonly String info;

		public Byte[] signature;

		public Byte[] from; //pbKey from sender

		public Transaction(String info)
        {
			this.info = info;
        }

		public void Sign(RSAParameters parameters)
        {
			var hash = this.GetHash();
			using (RSA rsa = RSA.Create())
            {
				rsa.ImportParameters(parameters);
				RSAPKCS1SignatureFormatter rsaFormatter = new(rsa);
				rsaFormatter.SetHashAlgorithm(nameof(SHA256));
				signature = rsaFormatter.CreateSignature(hash);
            }
        }

		public Boolean VerifySignature(Byte[] publicKey)
        {
			return false;
        }

		public Byte[] GetHash() => PureHash.computeHash(Encoding.UTF8.GetBytes(info));
	}
}
