using System.Collections;
using DesignPatterns.Pipeline.Model;

namespace DesignPatterns.Pipeline.Stage;

public class SortMessagesStage : IStage<Messages>
{
    public Messages Execute(Messages input)
    {
        List<Message> messages = input.MessageList;

        messages.Sort(new MessageComparer());

        return new Messages(messages);
    }
}

public class MessageComparer : IComparer<Message>
{
    public int Compare(Message x, Message y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        var idComparison = x.Id.CompareTo(y.Id);
        if (idComparison != 0) return idComparison;
        return string.Compare(x.message, y.message, StringComparison.Ordinal);
    }
}