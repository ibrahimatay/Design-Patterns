package com.ibrahimatay;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.stream.IntStream;

public class Main {
    public static void main(String[] args) {
        List<String> threads = List.of("Thread-1", "Thread-2", "Thread-3");

        // Using Java Streams to run logging in parallel
        threads.parallelStream().forEach(threadName -> {
            Singleton logger = Singleton.getInstance();
            IntStream.rangeClosed(1, 100).forEach(i -> {
                logger.log(threadName + " - Log message " + i);
                try {
                    Thread.sleep(100); // Simulating delay
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            });
        });
    }
}

class Singleton {
    private static volatile Singleton instance;
    private Singleton(){}

    public static Singleton getInstance(){
        if(instance==null){
            synchronized (Singleton.class){
                if (instance==null){
                    instance = new Singleton();
                }
            }
        }
        return instance;
    }

    public void log(String message) {
        String timeStamp = new SimpleDateFormat("HH:mm:ss.SSS").format(new Date());
        System.out.println(timeStamp + " - " + message);
    }
}