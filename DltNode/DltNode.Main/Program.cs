﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using DltNode.Blockchain;
namespace DltNode.Main
{
	class Program
	{
		static void Main(string[] args)
		{
			Transaction tx1 = new Transaction("Product X has moved from A to B");
			Transaction tx2 = new Transaction("Product Y has moved from C to D");

			List<Transaction> transactions = new List<Transaction>();
			transactions.Add(tx1);
			transactions.Add(tx2);

			Block firstBlock = new Block(transactions, null);
			Console.WriteLine(BitConverter.ToString(firstBlock.blockHash));

			Transaction tx0 = new Transaction("Product Z has moved from E to F");
			List<Transaction> transactions1 = new List<Transaction>();
			transactions1.Add(tx0);

			Block secondBlock = new Block(transactions1, firstBlock);
			Console.WriteLine(BitConverter.ToString(secondBlock.previousBlockHash));
			Console.WriteLine(BitConverter.ToString(secondBlock.blockHash));

			Blockchain.Blockchain blockchain = new Blockchain.Blockchain(firstBlock);
			Console.WriteLine(blockchain.Height);
			Console.WriteLine(blockchain.AddNewBlock(secondBlock));
			Console.WriteLine(blockchain.Height);

			BigInteger target = new BigInteger(UInt64.MaxValue);
			target = BigInteger.Pow(target, 3);
			target = target * UInt32.MaxValue;
			target = target * UInt16.MaxValue / 128;
			firstBlock.ComputeHashWithTarget(target);
			Console.WriteLine(BitConverter.ToString(firstBlock.blockHash));
			Console.WriteLine(firstBlock.nonce);

			secondBlock.ComputeHashWithTarget(target);
			Console.WriteLine(BitConverter.ToString(secondBlock.blockHash));
			Console.WriteLine(secondBlock.nonce);
		}
	}
}
