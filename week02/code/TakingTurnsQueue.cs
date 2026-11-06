
/// <summary>
/// This queue is circular. People are added to the back of the queue.
/// When GetNextPerson is called, the next person is returned and
/// placed back into the queue if they still have turns remaining.
/// A turns value of 0 or less means infinite turns.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a new person to the queue.
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person from the queue.
    /// Re-enqueue the person if they have turns remaining
    /// or infinite turns.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Infinite turns: keep the person in the queue.
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // More than one turn remaining: decrease turns and re-enqueue.
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
