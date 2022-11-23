using DnDRogueLikeUML.Creatures;
using DnDRogueLikeUML.Creatures.Player;
using System;
using System.Collections.Generic;
using DnDRogueLikeUML.Creatures.Enemies;
using DnDRogueLikeUML;

namespace DnDRogueLikeUML
{
    class Battle : ILocation
    {
        private Type Location { get; set; }

        public Battle(Player player)
        {
            Location = player.CurrentLocation;

            player.CurrentLocation = this.GetType();

            LocationScript(player);
        }

        private double DifficultyCalculator(int enemyAmount, double currentDifficulty)
        {
            if (enemyAmount >= 15)
            {
                return currentDifficulty * 5;
            }
            else if (enemyAmount >= 11)
            {
                return currentDifficulty * 4;
            }
            else if (enemyAmount >= 7)
            {
                return (currentDifficulty * 3);
            }
            else if (enemyAmount >= 3)
            {
                return currentDifficulty * 2.5;
            }
            else if (enemyAmount == 2)
            {
                return currentDifficulty * 2;
            }
            else if (enemyAmount == 1)
            {
                return currentDifficulty * 1.5;
            }
            else
            {
                return currentDifficulty;
            }
        }

        private List<ICreature> GenerateEnemies(Player player, Random random)
        {
            CreatureManager creatureManager = new CreatureManager();
            List<IClonableCreature> availableCreatures = creatureManager.GetAvailableCreatures(Location);
            List<ICreature> enemies = new List<ICreature>();

            int nameCount = 1;

            double difficultyThreshold = (double)random.Next((int)player.Level * 25) / 100;
            Console.WriteLine($"Threshold: {difficultyThreshold}");
            double difficultyscore = 0;

            while (DifficultyCalculator(enemies.Count, difficultyscore) < difficultyThreshold || DifficultyCalculator(enemies.Count, difficultyscore) < (double)player.Level / 8)
            {
                IClonableCreature enemy = availableCreatures[random.Next(availableCreatures.Count)];

                if (enemy.ChallengeRating <= (double)player.Level / 2 && DifficultyCalculator(enemies.Count + 1, difficultyscore + enemy.ChallengeRating) <= (double)player.Level / 2)
                {
                    enemies.Add(enemy.Clone(nameCount));
                    difficultyscore += enemy.ChallengeRating;
                    Console.WriteLine(difficultyscore);
                    nameCount++;
                }
            }

            return enemies;
        }

        public void LocationScript(Player player)
        {
            Random random = new Random();

            Console.WriteLine("Battle starts!");

            List<ICreature> enemies = GenerateEnemies(player, random);

            while (player.Health > 0 && enemies.Count > 0)
            {
                player.DoAction(enemies);

                List<ICreature> deadEnemies = new List<ICreature>();

                foreach (ICreature creature in enemies)
                {
                    if (creature.Health <= 0)
                    {
                        deadEnemies.Add(creature);
                    }
                }

                foreach (ICreature item in deadEnemies)
                {
                    player.XP += item.XP;
                    enemies.Remove(item);
                }

                if (enemies.Count > 0)
                {
                    foreach (ICreature creature in enemies)
                    {
                        creature.DoAction(new List<ICreature>() { player });
                    }
                }
            }

            player.CurrentLocation = Location;

        }
    }
}
