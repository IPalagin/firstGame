using System;

namespace firstGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            int playerHealth = 100;
            int playerEnergy = 100;

            int enemyHealth = 100;
            int enemyEnergy = 100;

            int action = -1;

            int skipPlayerTurns = 0;
            int skipEnemyTurns = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"    Жизни: {0}                 Жизни противника: {1}", playerHealth, enemyHealth);
                Console.WriteLine(@"    Энергия: {0}               Энергия противника: {1}", playerEnergy, enemyEnergy);
                Console.WriteLine();
                Console.WriteLine("1. Запустить огненный шар (20 урона, -25 энергии)");
                Console.WriteLine("2. Заморозка (пропуск хода противником, -40 энергии)");
                Console.WriteLine("3. Удар посохом (10 урона)");
                Console.WriteLine("4. Лечебное заклинание (+30 здоровья, -55 энергии)");
                Console.WriteLine("5. Медитация (+35 энергии)");
                Console.WriteLine();

                if (playerHealth <= 0)
                {
                    Console.WriteLine("Вы проиграли!");
                    break;
                }

                if (enemyHealth <= 0)
                {
                    Console.WriteLine("Вы выиграли!");
                    break;
                }

                if (skipPlayerTurns == 0)
                {
                    action = int.Parse(Console.ReadLine());

                    if (action == 1)
                    {
                        if (playerEnergy >= 25)
                        {
                            enemyHealth -= 20;
                            playerEnergy -= 25;
                            Console.WriteLine("Вы запустили в противника огненный шар нанеся 20 единиц уроан");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно энергии, пропуск хода");
                            Console.ReadLine();
                        }
                    }

                    if (action == 2)
                    {
                        if (playerEnergy >= 40)
                        {
                            skipEnemyTurns = 2;
                            playerEnergy -= 40;
                            Console.WriteLine("Вы заморозили противника, он вынужден пропустить два хода");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно энергии, пропуск хода");
                            Console.ReadLine();
                        }
                    }

                    if (action == 3)                    
                    {
                            enemyHealth -= 10;
                            Console.WriteLine("Враг получил затрещину вашим посохом, нанесено 10 единиц урона");
                            Console.ReadLine();
                    }                    
                    if (action == 4)
                    {
                        if (playerEnergy >= 55)
                        {
                            playerHealth += 30;
                            playerEnergy -= 55;
                            Console.WriteLine("Вы используете лечение, ваше здоровье восполнилось на 30 единиц");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Недостаточно энергии, пропуск хода");
                            Console.ReadLine();
                        }
                    }

                    if (action == 5)
                    {
                        playerEnergy += 35;
                        Console.WriteLine("Вы начали медитировать, ваша энергия восстановилась на 35 единиц");
                        Console.ReadLine();
                    }
                }
                else
                {
                    skipPlayerTurns--;
                }



                if (skipEnemyTurns == 0)
                {
                    if (enemyEnergy <= 25)
                    {
                        action = 5;
                    }
                    if (enemyHealth <= 25 && enemyEnergy >=55)
                    {
                        action = 4;
                    }
                    if (action == 4)
                    {
                        if (enemyEnergy >= 55)
                        {
                            enemyHealth += 30;
                            enemyEnergy -= 55;
                            Console.WriteLine("Противник применил заклинание лечения, его здоровье восстановилось на 30 единиц");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Противник не имеет достаточно энергии, пропускает ход");
                            Console.ReadLine();
                        }
                        continue;
                    }

                    if (action == 5)
                    {
                        enemyEnergy += 35;
                        Console.WriteLine("Противник медитирует восстанавливая 35 единиц энергии");
                        Console.ReadLine();
                        continue;
                    }
                
                    else

                        action = rnd.Next(1, 4);

                    if (action == 1)
                    {
                        if (enemyEnergy >= 25)
                        {
                            playerHealth -= 20;
                            enemyEnergy -= 25;
                            Console.WriteLine("Огенный шар нанес вам 20 единиц урона");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Противник не имеет достаточно энергии, пропускает ход");
                            Console.ReadLine();
                        }
                    }
                    if (action == 2)
                    {
                        if (enemyEnergy >= 40)
                        {
                            skipPlayerTurns = 2;
                            enemyEnergy -= 40;
                            Console.WriteLine("Вас заморозили, вы пропускаете ход");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Противник не имеет достаточно энергии, пропускает ход");
                            Console.ReadLine();
                        }
                    }
                    if (action == 3)
                    {
                            playerHealth -= 10;
                            Console.WriteLine("Вас треснули посохом, нанесено 10 единиц урона");
                            Console.ReadLine();
                    }
                    if (action == 4)
                    {
                        if (enemyHealth >= 50)
                        {
                            action = rnd.Next(1, 4);
                        }
                        else if (enemyEnergy >= 55)
                        {
                            enemyHealth += 30;
                            enemyEnergy -= 55;
                            Console.WriteLine("Противник применил заклинание лечения, его здоровье восстановилось на 30 единиц");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Противник не имеет достаточно энергии, пропускает ход");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    skipEnemyTurns--;
                }
            }
        }
    }
}