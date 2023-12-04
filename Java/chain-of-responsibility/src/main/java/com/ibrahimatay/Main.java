package com.ibrahimatay;

import java.util.Arrays;
import java.util.List;

interface Handler {
    Handler setNext(Handler handler);
    Object handle(String message);
}

abstract class AbstractHandler implements Handler {
    private Handler _handler;

    public final Handler setNext(Handler handler) {
        return _handler = handler;
    }

    public Object handle(String message) {
        if (_handler != null) return _handler.handle(message);
        return null;
    }
}

final class MaxCustomerCountHandler extends AbstractHandler {
    @Override
    public Object handle(String message) {
        System.out.printf("Max customer count validation handled for %s\n", message);
        return super.handle(message);
    }
}

final class DueDateHandler extends AbstractHandler {
    @Override
    public Object handle(String message) {
        System.out.printf("End date validation handled for %s\n", message);
        return super.handle(message);
    }
}

final class StartDateHandle extends AbstractHandler {
    @Override
    public Object handle(String message) {
        System.out.printf("Start date validation handled for %s\n", message);
        return super.handle(message);
    }
}

final class CreditBalanceHandle extends AbstractHandler {
    @Override
    public Object handle(String message) {
        System.out.printf("Credit balance handled for %s\n", message);
        return super.handle(message);
    }
}

final class Processor {
    private final AbstractHandler _handler;
    public Processor(AbstractHandler handler) {
        _handler = handler;
    }

    public void start(List<String> messages) {
        for (String message : messages) {
            _handler.handle(message);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        var maxCustomerCountHandle = new MaxCustomerCountHandler();
        var dueDateHandle = new DueDateHandler();
        var startDateHandle = new StartDateHandle();
        var creditBalanceHandle = new CreditBalanceHandle();

        maxCustomerCountHandle
                .setNext(dueDateHandle)
                .setNext(startDateHandle)
                .setNext(creditBalanceHandle);

        List<String> customers = Arrays.asList("Customer A","Customer B","Customer C","Customer D");

        var processor = new Processor(maxCustomerCountHandle);
        processor.start(customers);
    }
}