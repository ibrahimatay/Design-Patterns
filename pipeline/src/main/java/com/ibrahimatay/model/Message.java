package com.ibrahimatay.model;

import java.util.Objects;

public record Message(long id, String message){

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
