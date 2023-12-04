package com.ibrahimatay.stage;

public interface Stage<T> {
    T execute(final T input);
}
