package com.ibrahimatay.stage;

import com.ibrahimatay.model.Message;
import com.ibrahimatay.model.Messages;

import java.util.ArrayList;
import java.util.List;

public class CreateMessagesStage implements Stage<Messages> {
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
