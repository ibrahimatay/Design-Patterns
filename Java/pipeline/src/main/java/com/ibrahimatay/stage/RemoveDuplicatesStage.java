package com.ibrahimatay.stage;

import com.ibrahimatay.model.Message;
import com.ibrahimatay.model.Messages;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

public class RemoveDuplicatesStage implements Stage<Messages> {
    @Override
    public Messages execute(Messages input) {
        Set<Message> messages = new HashSet<>();
        messages.addAll(input.messages());

        return new Messages(new ArrayList<>(messages));
    }
}
