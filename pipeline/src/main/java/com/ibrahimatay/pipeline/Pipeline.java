package com.ibrahimatay.pipeline;

import com.ibrahimatay.stage.Stage;

public interface Pipeline<T> {
    void add(Stage<T> stage);
    void execute();
}
