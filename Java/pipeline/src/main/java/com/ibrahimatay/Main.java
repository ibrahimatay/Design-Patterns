package com.ibrahimatay;

import com.ibrahimatay.model.Messages;
import com.ibrahimatay.pipeline.MessagesPipeline;
import com.ibrahimatay.pipeline.Pipeline;
import com.ibrahimatay.stage.CreateMessagesStage;
import com.ibrahimatay.stage.OutputMessagesStage;
import com.ibrahimatay.stage.RemoveDuplicatesStage;
import com.ibrahimatay.stage.SortMessagesStage;

public class Main {
    public static void main(String[] args) {
        Pipeline<Messages> pipeline = new MessagesPipeline();
        pipeline.add(new CreateMessagesStage());
        pipeline.add(new RemoveDuplicatesStage());
        pipeline.add(new SortMessagesStage());
        pipeline.add(new OutputMessagesStage());

        pipeline.execute();
    }
}

class CreateMessagesStage implements Stage<Messages> {
    @Override
    public Messages execute(Messages input) {
        List<Message> messages = new ArrayList<Message>();
        messages.add(new Message(1, "Hi Alice"));
        messages.add(new Message(1, "Hi Alice"));
        messages.add(new Message(2, "Hello Bob"));
        messages.add(new Message(3, "How are you, Alice"));
        messages.add(new Message(4, "I am doing good."));
        messages.add(new Message(1, "Hi Alice"));

        return new Messages(messages);
    }
}

class OutputMessagesStage implements Stage<Messages> {
    @Override
    public Messages execute(Messages input) {
        for (Message message: input.messages()){
            System.out.println(message);
        }

        return input;
    }
}

class RemoveDuplicatesStage implements Stage<Messages> {
    @Override
    public Messages execute(Messages input) {
        Set<Message> messages = new HashSet<>();
        messages.addAll(input.messages());

        return new Messages(new ArrayList<>(messages));
    }
}

class SortMessagesStage implements Stage<Messages> {
    @Override
    public Messages execute(Messages input) {
        List<Message> messages = input.messages();
        Comparator<Message> compareById = Comparator.comparingLong(Message::id);

        Collections.sort(messages, compareById);

        return new Messages(messages);
    }
}

interface Stage<T> {
    T execute(final T input);
}

class MessagesPipeline implements Pipeline<Messages>{
    final List<Stage<Messages>> stages = new ArrayList<Stage<Messages>>();
    @Override
    public void add(Stage<Messages> stage) {
        stages.add(stage);
    }

    @Override
    public void execute() {
        Messages input = null, output;

        for (Stage<Messages> stage : stages) {
            output = stage.execute(input);
            input = output;
        }
    }
}


interface Pipeline<T> {
    void add(Stage<T> stage);
    void execute();
}

record Messages(List<Message> messages) {
}

record Message(long id, String message){

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Message message1 = (Message) o;
        return Objects.equals(id, message1.id) && Objects.equals(message, message1.message);
    }

    @Override
    public int hashCode() {
        return Objects.hash(id, message);
    }
}
