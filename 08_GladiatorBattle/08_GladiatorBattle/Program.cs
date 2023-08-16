namespace _08_GladiatorBattle
{
    /* Создать 5 бойцом, пользователь выбирает 2 бойцов и они сражаются друг с другом до смерти.
    У каждого бойца могут быть свои статы.
    Каждый игрок должен иметь особую способность для атаки, которая свойственна только его классу!
    Если можно выбрать одинаковых бойцов, то это не должна быть одна и та же ссылка на обного бойца, чтобы он не атаковал сам себя.
    Пример, что может быть уникальное у бойцов. Кто-то каждый 3 удар наносит удвоенный урон, другой имеет 30% увернуться
    от полученного урона, кто-то при получении урона немного лечит себя. Будут новые поля у наследников. 
    У кого-то может быть мана и это только его особенность.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
           
        }
    }

    public class Warrior:Character
    {
        public Warrior(string name,int health,int damage):base(name,health, damage)
        {
            Name = "Воин";
            Health = 300;
            Damage = 50;
        }


    }

    public class Character
    {
        public Character(string name,int health,int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public int Health { get; protected set; }
        public int Damage { get; protected set; }      
        public string Name { get; protected set; }
        //public string SkillName { get; protected set; }

        public void GetDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {Health} хп, {Damage} урона");
        }
    }
}