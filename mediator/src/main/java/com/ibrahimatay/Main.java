package com.ibrahimatay;

import java.util.ArrayList;
import java.util.List;

interface Messenger {
    void Receiver(final String message);
}

interface Chat {
    void SendMessage(Messenger receiver, String message);
    void AddMessenger(Messenger messenger);
}

class AliceMessenger implements Messenger {
    @Override
    public void Receiver(String message) {
        System.out.printf("received the message: %s\n", message);
    }
}

class BobMessenger implements Messenger {
    @Override
    public void Receiver(String message) {
        System.out.printf("received the message:%s", message);
    }
}

class AnonymousChat implements Chat {
    private final List<Messenger> messengers;

    AnonymousChat() {
        this.messengers = new ArrayList<>();
    }

    @Override
    public void SendMessage(Messenger receiver, String message) {
        var messenger = messengers.stream()
                                                    .filter(x-> x == receiver)
                                                    .findAny();
        if (!messenger.isPresent()) return;

        messenger.get().Receiver(message);
    }

    @Override
    public void AddMessenger(Messenger messenger) {
        messengers.add(messenger);
    }
}

public class Main {
    public static void main(String[] args) {
        Chat chat = new AnonymousChat();

        Messenger bobMessenger = new BobMessenger();
        Messenger aliceMessenger = new AliceMessenger();

        chat.AddMessenger(bobMessenger);
        chat.AddMessenger(aliceMessenger);

        chat.SendMessage(aliceMessenger,"Hello");
        chat.SendMessage(bobMessenger,"How are you, Alice");
    }
}