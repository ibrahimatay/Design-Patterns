package com.ibrahimatay;

import java.util.ArrayList;
import java.util.List;

interface PlaceHolder {
    void doubleClick();
}

class Folder implements PlaceHolder {
    final String name;
    final List<PlaceHolder> files;

    Folder(String name) {
        this.name = name;
        this.files = new ArrayList<>();
    }

    public void add(PlaceHolder file) {
        files.add(file);
    }

    @Override
    public void doubleClick() {
        System.out.println(name + " folder is Opened");
        for (PlaceHolder placeHolder : files) {
            placeHolder.doubleClick();
        }
    }
}

class File implements PlaceHolder {
    final String name;

    File(String name) {
        this.name = name;
    }

    @Override
    public void doubleClick() {
        System.out.println(name + " file is opened in a program");
    }
}

public class Main {
    public static void main(String[] args) {
        File file1 = new File("File 1");
        File file2 = new File("File 2");
        File file3 = new File("File 3");

        Folder folder1 = new Folder("Folder 1");
        folder1.add(file1);
        folder1.add(file2);
        folder1.add(file3);

        Folder folder2 = new Folder("Folder 2");
        File file4 = new File("File 4");
        File file5 = new File("File 5");

        folder2.add(file4);
        folder2.add(file5);

        folder1.add(folder2);
        folder1.doubleClick();
    }
}