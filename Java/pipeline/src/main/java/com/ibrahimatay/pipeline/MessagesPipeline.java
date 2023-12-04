package com.ibrahimatay.pipeline;

import com.ibrahimatay.model.Messages;
import com.ibrahimatay.stage.Stage;

import java.util.ArrayList;
import java.util.List;

public class MessagesPipeline implements Pipeline<Messages>{
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
