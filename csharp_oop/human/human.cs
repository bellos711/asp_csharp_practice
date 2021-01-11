namespace human
{
    class Human
    {
        //ATTRIBUTES
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
        //ATTRIBUTES END


        //CONSTRUCTOR
        public Human(string name)
        {
            this.Name = name;
            this.Strength = 3;
            this.Intelligence = 3;
            this.Dexterity = 3;
            this.health = 100;
        }

        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            this.Name = name;
            this.Strength = strength;
            this.Intelligence = intelligence;
            this.Dexterity = dexterity;
            this.health = health;
        }

        public Human()
        {
            this.Name = "default name";
            this.Strength = 3;
            this.Intelligence = 3;
            this.Dexterity = 3;
            this.health = 100;
        }
        //END CONSTRUCTORS


        //PUBLIC METHODS//
        public int getHealth()
        {
            return health;
        }//end getHealth

        public void setHealth(int newHealth)
        {
            this.health = newHealth;
            // return getHealth();
        }//end setHealth

        public int Attack(Human target)
        {
            int damage = 5 * this.Strength;
            // target.getHealth() = target.getHealth()-damage;
            int minusedHealth = target.getHealth()-damage; 
            target.setHealth(minusedHealth);
            // return target.setHealth(minusedHealth);
            return damage;
        }

        //PUBLIC METHODS END
    }
}