namespace DesignPatterns.Pipeline.Model;

public record Message(long Id, string message)
{
    public virtual bool Equals(Message? other)
    {
        if (other == null) return false;

        return (this.Id == other.Id && this.message == other.message);
    }

    public override int GetHashCode()
    {
        return int.Parse(Id.ToString());
    }
}

