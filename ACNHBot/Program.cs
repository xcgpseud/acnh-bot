using System;
using System.Threading.Tasks;
using ACNHBot.Application;
using DSharpPlus;

namespace ACNHBot
{
    class Program
    {
        static void Main(string[] args)
        {
            new Bot().Start().ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}