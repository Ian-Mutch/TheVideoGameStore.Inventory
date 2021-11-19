using System.Text;

namespace TheVideoGameStore.Inventory.Data.InMemory.SeedData;

static class ProductDefinitionSeedData
{
    public static ProductDefinition[] GetData() =>
        new ProductDefinition[]
        {
            new()
            {
                ProductDefinitionId = 1,
                Name = "Final Fantasy VII Remake",
                Description = new StringBuilder().Append("A spectacular reimagining of one of the most visionary games ever, the first game in this project will be set in the eclectic city of Midgar and presents a fully standalone gaming experience.")
                                                .AppendLine("The world has fallen under the control of the Shinra Electric Power Company, a shadowy corporation controlling the planet's very life force as mako energy. In the sprawling city of Midgar, an anti-Shinra organization calling themselves Avalanche have stepped up their resistance. Cloud Strife, a former member of Shinra's elite SOLDIER unit now turned mercenary, lends his aid to the group, unaware of the epic consequences that await him.")
                                                .ToString()
            },
            new()
            {
                ProductDefinitionId = 2,
                Name = "Final Fantasy XV - Day One Edition",
                Description = new StringBuilder().Append("Enter the world of FINAL FANTASY XV, and experience epic action-packed battles along your journey of discovery. You are Noctis, the Crown Prince of the Kingdom of Lucis, and your quest is to reclaim your homeland from the clutches of the imperial army.")
                                                .AppendLine("Joined by your closest friends, you will take the wheel and experience a voyage like no other, travelling through the breathtaking world of Eos encountering larger-than-life beasts and unforgiving enemies. You will learn to master the skills of weaponry and magic, channelling the power of your ancestors allowing you to effortlessly warp through the air in thrilling combat.")
                                                .ToString()
            },
            new()
            {
                ProductDefinitionId = 3,
                Name = "Saints Row: Day One Edition",
                Description = new StringBuilder().Append("Welcome to Santo Ileso, a vibrant fictional city in the heart of the American Southwest. In a world rife with crime, where lawless factions fight for power, a group of young friends embark on their own criminal venture, as they rise to the top in their bid to become Self Made.")
                                                .AppendLine("As the future Boss, with Neenah, Kevin, and Eli by your side, you’ll form The Saints – and take on Los Panteros, The Idols, and Marshall as you build your empire across the streets of Santo Ileso and battle for control of the city. Ultimately Saints Row is the story of a start-up company, it’s just that the business The Saints are in happens to be crime.")
                                                .ToString()
            }
    };
}
