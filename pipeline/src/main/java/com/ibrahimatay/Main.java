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
        pipeline.add(new OutputMessagesStage());
        pipeline.add(new SortMessagesStage());

        pipeline.execute();
    }
}