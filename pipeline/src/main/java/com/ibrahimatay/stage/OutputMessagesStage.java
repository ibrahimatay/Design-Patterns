package com.ibrahimatay.stage;

import com.ibrahimatay.model.Message;
import com.ibrahimatay.model.Messages;
import com.ibrahimatay.stage.Stage;

public class OutputMessagesStage implements Stage<Messages> {
    @Override
    public Messages execute(Messages input) {
        for (Message message: input.messages()){
            System.out.println(message);
        }

        return input;
    }
}
