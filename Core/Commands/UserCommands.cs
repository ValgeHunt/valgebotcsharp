using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;
using Discord.WebSocket;
using System.Globalization;

using Discord;
using Discord.Commands;

namespace Valge_bot.Core.Commands
{
    public class HelloWorld : ModuleBase<SocketCommandContext>
    {
        [Command("hello")]
        public async Task ValgeHunt()
        {
            await Context.Channel.SendMessageAsync("Hello World!");
        }
    }

    public class GiveDj : ModuleBase<SocketCommandContext>
    {
        [Command("dj")]
        public async Task GiveDj2()
        {
            var user = (IGuildUser)Context.User;
            var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "DJ");
            await user.AddRoleAsync(role);
            await Context.Channel.SendMessageAsync("DJ role given!");
        }

    }

    public class GiveWinRanks : ModuleBase<SocketCommandContext>
    {
        [Command("wins")]
        public async Task GiveWinRanks2([Remainder]string input ="0")
        {
            int userEnteredNumber = 0;
            bool ifIsNumber = int.TryParse(input, out userEnteredNumber);
            if (ifIsNumber)
            {
                var user = (IGuildUser)Context.User;
                CultureInfo ci = new CultureInfo("en-US");
                IEnumerable<IRole> roles = (IEnumerable < IRole > )Context.Guild.Roles.Where(x => x.Name.ToString().StartsWith("Tier", true, ci));
                await user.RemoveRolesAsync(roles);

                if (userEnteredNumber <= 0)
                {
                    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "Tier 0 (New)");
                    await user.AddRoleAsync(role);
                    await Context.Channel.SendMessageAsync("Tier 0 given");
                }

                if (userEnteredNumber >= 1 && userEnteredNumber <= 25)
                {
                    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "Tier 1 (Beginner)");
                    await user.AddRoleAsync(role);
                    await Context.Channel.SendMessageAsync("Tier 1 given");
                }

                if (userEnteredNumber >= 26 && userEnteredNumber <= 75)
                {
                    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "Tier 2 (Intermediate)");
                    await user.AddRoleAsync(role);
                    await Context.Channel.SendMessageAsync("Tier 2 given");
                }

                if (userEnteredNumber >= 76 && userEnteredNumber <= 150)
                {
                    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "Tier 3 (Proficient)");
                    await user.AddRoleAsync(role);
                    await Context.Channel.SendMessageAsync("Tier 3 given");
                }

                if (userEnteredNumber >= 151 && userEnteredNumber <= 300)
                {
                    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "Tier 4 (Advanced)");
                    await user.AddRoleAsync(role);
                    await Context.Channel.SendMessageAsync("Tier 4 given");
                }

                if (userEnteredNumber >= 300)
                {
                    var role = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == "Tier 5 (Elite)");
                    await user.AddRoleAsync(role);
                    await Context.Channel.SendMessageAsync("Tier 5 given");
                }

            }

            else
            {
                await Context.Channel.SendMessageAsync("Insert a valid number!");
            }
              
        }

    }

}
