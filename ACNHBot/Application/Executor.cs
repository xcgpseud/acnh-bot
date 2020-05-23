using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;

namespace ACNHBot.Application
{
    public class Executor
    {
        protected async Task Execute(Func<Task> fn)
        {
            try
            {
                await fn();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw;
            }
        }
    }
}