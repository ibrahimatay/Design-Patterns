package com.ibrahimatay.stage;

import com.ibrahimatay.model.Message;
import com.ibrahimatay.model.Messages;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class SortMessagesStage implements Stage<Messages> {
    @Override
    public Messages execute(Messages input) {
        List<Message> messages = input.messages();
        Comparator<Message> compareById = Comparator.comparingLong(Message::id);

        Collections.sort(messages, compareById);

        return new Messages(messages);
    }
}
