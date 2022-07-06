namespace ClassLibrary
{
    public class Person
    {
        public string? Name { get; set; }
        public string? FirstName { get; set; }

        public static Person Procreate(Person p1, Person p2)
        {
            Person person = new()
            {
                Name = p1.Name + " " + p2.Name,
                FirstName = p1.FirstName,
            };
            return person;
        }

        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }



        #region Parte relativa ai delegati
        public event EventHandler? Shout;
        public int AngerLevel { get; set; }

        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                // Call the delegate
                Shout?.Invoke(this, EventArgs.Empty);
            }
        }

        public static void Harry_Shout(object? sender, EventArgs e)
        {
            if (sender is null) return;
            Person p = (Person)sender;
            Console.WriteLine($"{p.FirstName} is this angry: {p.AngerLevel}");
        }
        #endregion
    }
}
